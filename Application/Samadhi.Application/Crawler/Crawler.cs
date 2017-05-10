using Samadhi.Application.Utility;
using Samadhi.Data;
using Samadhi.History.Controller.Controllers;
using Samadhi.History.Data;
using Samadhi.History.Data.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Samadhi.Application.Crawler
{
    public class Crawler
    {
        private static Action<URLHistory> _dataGridWrite;
        private static Action _siteCounter;

        public static void CrawlSite(object actDataGrid, object actCounter)
        {
            _dataGridWrite = (Action<Samadhi.History.Data.URLHistory>)actDataGrid;
            _siteCounter = (Action)actCounter;

            Request request = new Request(CrawlerContext.URI);
            int step = 0;

            CrawlPage(request, step + 1);
        }

        private static void CrawlPage(Request request, int step)
        {
            if (request.Url.Trim('/').Split('/').Count() - 2 > CrawlerContext.Depth)
                return;

            if (CrawlerContext.SinglePage && step > 2)
                return;

            Uri tempUri = new Uri(request.Url);
            string tempDomain = GetDomain.GetDomainFromUrl(tempUri);
            if (CrawlerContext.IgnoreDirectory.Count != 0 && IgnoreDirectory(request.Url, tempDomain))
                return;

            if (!PageHasBeenCrawled(request))
            {
                string htmltext = GetWebText(request);

                _siteCounter.Invoke();
                if (request.Response.Error)
                {
                    //log
                    return;
                }

                URLHistory urlHistory = new URLHistory();
                urlHistory.URL = request.Url;
                urlHistory.ResponseCode = request.Response.Code;
                urlHistory.Length = htmltext.Length;
                //if(request.Attack != null)
                //do attack confirmation

                _dataGridWrite.Invoke(urlHistory);

                AddPageToHistory(request, urlHistory);

                LinkParser linkParser = new LinkParser();
                //if (_goodUrls.Count > 0)
                //{
                //    linkParser.GoodUrls.AddRange(_goodUrls);
                //    _goodUrls = new List<UrlEntity>();
                //}
                linkParser.ParseLinksAgility(htmltext, request.Url);

                foreach (Request link in linkParser.GoodUrls)//.Sort((x, y) => x.Url.Length.CompareTo(y.Url.Length)))
                {
                    CrawlerContext.PauseEvent.WaitOne(Timeout.Infinite);
                    try
                    {
                        CrawlPage(link, step + 1);
                    }
                    catch
                    {
                       // _failedUrls.Add(link + " (on page at url " + url + ") - " + exc.Message);
                    }
                }
                SessionFileHandler.LogExhsutedUrl(request.Url);
            }
        }

        private static bool IgnoreDirectory(string url, string domain)
        {
            string directory = url.Split(new string[] { domain }, StringSplitOptions.None).Last().Trim('/');

            if (String.IsNullOrEmpty(directory))
                return false;

            foreach (string ignoreDir in CrawlerContext.IgnoreDirectory)
            {
                if (directory.StartsWith(ignoreDir))
                    return true;
            }

            return false;
        }

        private static void AddPageToHistory(Request request, URLHistory urlHistory)
        {
            if (!CrawlerContext.IncludeDOMUrls)
            {
                request.Url = request.Url.Split('#').First();
            }

            CrawlerContext.Pages.Add(request);

           using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=" + CrawlerContext.SessionFileName))
           {
                urlHistory.ResponseCode = request.Response.Code;
                urlHistory.URL = request.Url;
                urlHistory.EntryDate = DateTime.Now;

                URLHistoryController historyDataController = new URLHistoryController();
                URLHistoryUpdateResult result = historyDataController.Insert(urlHistory);
                if (result.Error)
                    throw new Exception(result.Messaage);
           }
        }

        private static HttpWebRequest BuildRequest(string myUri)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(myUri);
            request.CookieContainer = CrawlerContext.CookieContainer;
            request.Method = CrawlerContext.Verb.ToString();
            //request.Method = "HEAD";
            //request.AllowAutoRedirect = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.UserAgent = CrawlerContext.UserAgent;
            //  request.KeepAlive = false;
            return request;
        }

        private static string GetWebText(Request request)
        {
            HttpWebResponse httpResponse = null;
            try
            {
                // UriBuilder uriBuilder = new UriBuilder(_myUri.Scheme, url);
                // HttpWebRequest request = BuildRequest(uriBuilder.Uri);
                HttpWebRequest httpRequest = BuildRequest(request.Url);

                httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                foreach (Cookie cookie in httpResponse.Cookies)
                    CrawlerContext.CookieContainer.Add(cookie);

                Stream stream = httpResponse.GetResponseStream();
                StreamReader readStream = null;
                if (httpResponse.CharacterSet == null)
                {
                    readStream = new StreamReader(stream);
                }
                else
                {
                    readStream = new StreamReader(stream, Encoding.GetEncoding(httpResponse.CharacterSet));
                }

                request.Response.Code = httpResponse.StatusCode.ToString();

                string httpBody = readStream.ReadToEnd();
                stream.Close();
                readStream.Close();
                //todo: save to request.Response.Body?
                return httpBody;
            }
            catch (Exception e)
            {
                request.Response.Error = true;
                request.Response.ErrorMessage = e.Message;
                return "Error";
            }
            finally
            {
                if (httpResponse != null)
                {
                    httpResponse.Close();
                }
            }
        }

        private static bool PageHasBeenCrawled(Request request)
        {
            if (!CrawlerContext.IncludeDOMUrls)
            {
                request.Url = request.Url.Split('#').First();
            }

            if (CrawlerContext.Pages.Contains(request))
                return true;

            //List<UrlEntity> urls = _attackUrls.Where(x => x.Url.Split('?')[0] == url.Url.Split('?')[0]).ToList();
            //urls = urls.Where(x => x.Attack.Type == url.Attack.Type).ToList();
            //urls = urls.Where(x => x.AttackedParameter == url.AttackedParameter).ToList();

            //if (urls.Count > 0)
            //    return true;

            return false;
        }
    }
}
