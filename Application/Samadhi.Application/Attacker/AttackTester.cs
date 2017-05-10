using Samadhi.Application.Crawler;
using Samadhi.Application.Utility;
using Samadhi.Attack.Common;
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

namespace Samadhi.Application.Attacker
{
    public static class AttackTester
    {
        private static Action<AttackHistory> _dataGridWrite;
        private static Action _resultCounter;
        private static Dictionary<string, ParentAttackHandler> _validators = new Dictionary<string, ParentAttackHandler>();

        public static void CycleThroughUntested(object actDataGrid, object actCounter)
        {
            while (CrawlerContext.AttackTestThreadAsService)
            {
                if (CrawlerContext.AttackTestThreadAsService)
                    Thread.Sleep(5000);

                if (actDataGrid != null)
                    _dataGridWrite = (Action<AttackHistory>)actDataGrid;
                _resultCounter = (Action)actCounter;
                // SQLiteConnection conn = new SQLiteConnection("data source=" + CrawlerContext.SessionFileName);
                // string selectQuery = @"SELECT id, url, payload, verification, type, priority, tested FROM attack_history WHERE tested <> 'T'";

                try
                {
                    AttackHistoryController attackHistoryController = new AttackHistoryController();
                    AttackHistoryFindResult attackHistoryFindResult = attackHistoryController.FindUntested();
                    if (attackHistoryFindResult.Error)
                        throw new Exception(attackHistoryFindResult.Message);

                    EventLimiter eventLimiter = new EventLimiter(20, new TimeSpan(0, 1, 0));//todo set to scale

                    foreach (AttackHistory history in attackHistoryFindResult.Items)
                    {
                        Request request = new Request();
                        request.Url = history.URL;

                        ParentAttackHandler attackHandler = null;
                        if (_validators.ContainsKey(history.Type))
                        {
                            attackHandler = _validators[history.Type];
                        }
                        else
                        {
                            string className = "AttackHandler";
                            string namespaceName = "Samadhi.Attack." + history.Type;
                            var myObj = Activator.CreateInstance(namespaceName, namespaceName + "." + className);
                            if (myObj == null)
                                throw new Exception("Unimplemented attack class.");
                            attackHandler = (ParentAttackHandler)myObj.Unwrap();

                            _validators.Add(history.Type, attackHandler);
                        }

                        request.Response = new Response();

                        while (eventLimiter.CanRequestNow() == false)
                            ;
                        eventLimiter.EnqueueRequest();

                        GetWebText(request);
                        bool valid = attackHandler.Validate(history, request);

                        if (valid)
                        {
                            history.Tested = true;
                            _dataGridWrite(history);
                        }

                        history.Tested = valid;

                        //AttackHistoryController attackHistoryController = new AttackHistoryController();
                        attackHistoryController.SetAsTested(history);
                        //string insertQuery = @"UPDATE attack_history SET " +
                        //                      "tested = '" + tested + "' " +
                        //                      "WHERE id = '" + history.AttackHistoryId + "'";
                        //using (System.Data.SQLite.SQLiteCommand updateCmd = new System.Data.SQLite.SQLiteCommand(conn))
                        //{
                        //    updateCmd.CommandText = insertQuery;
                        //    updateCmd.ExecuteNonQuery();
                        //}
                    }


                }
                catch
                {
                    throw;
                }
            }
        }

        private static void GetWebText(Request request)
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
                request.Response.Body = readStream.ReadToEnd();
                stream.Close();
                readStream.Close();
                //todo: save to request.Response.Body?
            }
            catch (Exception e)
            {
                request.Response.Error = true;
                request.Response.ErrorMessage = e.Message;
            }
            finally
            {
                if (httpResponse != null)
                {
                    httpResponse.Close();
                }
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
    }
}