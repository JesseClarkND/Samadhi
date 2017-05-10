using Samadhi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Samadhi.Application.Crawler
{
    public static class CrawlerContext
    {
        public static ManualResetEvent PauseEvent = new ManualResetEvent(true);

        public static bool AttackTestThreadAsService = false;
        public static bool SinglePage = false;

        public static string SessionFileName;
        public static int Depth = 10;
        public static Uri URI;
        public static string Authority;
        public static HTTPVerb Verb = HTTPVerb.GET;
        public static List<string> IgnoreDirectory = new List<string>();
        public static List<string> IgnoreVariable = new List<string>();//todo
        public static CookieContainer CookieContainer = null;
        public static List<Request> Pages = new List<Request>();
        //public static List<string> GoodPages = new List<string>();
        //public static List<string> FailedUrls = new List<string>();
        public static List<string> ExhaustedURL = new List<string>();
        public static bool IncludeSubdomains = false;
        public static bool IncludeDOMUrls = false;//todo
        public static bool ExhaustPageInput = false;
        public static string UserAgent = "";

        public static bool ActiveScanMode = true;
        public static int ScanId = 0;


        public static void Initialize()
        {
            UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.1";
        }

        public static void SetURL(string url)
        {
            UriBuilder uriBuilder = new UriBuilder(url);
            URI = uriBuilder.Uri;
            Authority = URI.Authority;
        }
    }

    public enum HTTPVerb
    {
        ALL,
        GET,
        POST
    }
}
