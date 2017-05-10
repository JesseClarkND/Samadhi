using Core.SQLite.Accessor;
using Newtonsoft.Json;
using Samadhi.Application.Crawler;
using Samadhi.Attack.Common;
using Samadhi.Common.Component.Controllers;
using Samadhi.Common.Data;
using Samadhi.Data;
using Samadhi.History.Controller.Controllers;
using Samadhi.History.Data;
using Samadhi.History.Data.Results;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Samadhi.Application.Utility
{
    public static class SessionFileHandler
    {
        public static void CreateSessionFile(string sessionFileName)
        {
            try
            {
                System.Data.SQLite.SQLiteConnection.CreateFile(sessionFileName);
                using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=" + sessionFileName))
                {
                    SettingsController settingsController = new SettingsController();
                    settingsController.CreateTable();

                    URLHistoryController historyController = new URLHistoryController();
                    historyController.CreateTable();

                    ExhaustedURLController uncrawledController = new ExhaustedURLController();
                    uncrawledController.CreateTable();

                    AttackHistoryController attackHistoryController = new AttackHistoryController();
                    attackHistoryController.CreateTable();

                    ExhaustedURLController exhaustedURLController = new ExhaustedURLController();
                    exhaustedURLController.CreateTable();
                }
            }
            catch
            {

            }
        }

        public static void SaveCrawlerContext()
        {
            SQLiteConnection conn = new SQLiteConnection("data source=" + CrawlerContext.SessionFileName);
            SettingsController settingsController = new SettingsController();
            Setting setting = new Setting();
            setting.Name = "Depth";
            setting.Value = CrawlerContext.Depth.ToString();
            settingsController.UpdateSetting(setting);

            if (CrawlerContext.URI != null)
            {
                setting.Name = "Uri";
                setting.Value = CrawlerContext.URI.ToString();
                settingsController.UpdateSetting(setting);
            }

            setting.Name = "IncludeSubdomains";
            setting.Value = CrawlerContext.IncludeSubdomains ? "T" : "F";
            settingsController.UpdateSetting(setting);

            setting.Name = "IncludeDOMUrls";
            setting.Value = CrawlerContext.IncludeDOMUrls ? "T" : "F";
            settingsController.UpdateSetting(setting);

            setting.Name = "ExhaustPageInput";
            setting.Value = CrawlerContext.ExhaustPageInput ? "T" : "F";
            settingsController.UpdateSetting(setting);

            //setting.Name = "Authority";
            //setting.Value = CrawlerContext.Authority;
            //settingsController.UpdateSetting(setting);

            setting.Name = "IgnoreDirectory";
            setting.Value = String.Join(":::", CrawlerContext.IgnoreDirectory.ToArray());
            settingsController.UpdateSetting(setting);

            setting.Name = "IgnoreVariable";
            setting.Value = String.Join(":::", CrawlerContext.IgnoreVariable.ToArray());
            settingsController.UpdateSetting(setting);

            setting.Name = "UserAgent";
            setting.Value = CrawlerContext.UserAgent;
            settingsController.UpdateSetting(setting);

            if (CrawlerContext.CookieContainer != null)
            {
                string cookieValues = "";
                bool notOnFirst = false;
                foreach (Cookie cookie in CrawlerContext.CookieContainer.GetCookies(CrawlerContext.URI))
                {
                    if (notOnFirst)
                        cookieValues += ":::";
                    cookieValues += JsonConvert.SerializeObject(cookie);
                    notOnFirst = true;
                }

                setting.Name = "CookieContainer";
                setting.Value = cookieValues;
                settingsController.UpdateSetting(setting);
            }
        }

        public static void LoadCrawlerContextSettings(string fileName)
        {
            SQLiteConnection conn = new SQLiteConnection("data source=" + fileName);
            SettingsController settingsController = new SettingsController();
            CrawlerContext.SessionFileName = fileName;
            Settings.ConnectionString = "data source=" + fileName;
            string depth = settingsController.GetValue("Depth");
            CrawlerContext.Depth = int.Parse(depth);
            CrawlerContext.URI = new Uri(settingsController.GetValue("Uri"));
            CrawlerContext.Authority = CrawlerContext.URI.Authority;
            CrawlerContext.UserAgent = settingsController.GetValue("UserAgent");
            CrawlerContext.IncludeSubdomains = settingsController.GetValue("IncludeSubdomains") == "T";
            CrawlerContext.IncludeDOMUrls = settingsController.GetValue("IncludeDOMUrls") == "T";
            CrawlerContext.ExhaustPageInput = settingsController.GetValue("ExhaustPageInput") == "T";

            string ignoreDirectories = settingsController.GetValue("IgnoreDirectory");
            string ignoreVariables = settingsController.GetValue("IgnoreVariable");
            string cookieContainer = settingsController.GetValue("CookieContainer");

            foreach (string dir in ignoreDirectories.Split(new string[] { ":::" }, StringSplitOptions.RemoveEmptyEntries))
                CrawlerContext.IgnoreDirectory.Add(dir);

            foreach (string variable in ignoreVariables.Split(new string[] { ":::" }, StringSplitOptions.RemoveEmptyEntries))
                CrawlerContext.IgnoreVariable.Add(variable);

            if (CrawlerContext.CookieContainer == null)
                CrawlerContext.CookieContainer = new CookieContainer();
            foreach (string stringCookie in cookieContainer.Split(new string[] { ":::" }, StringSplitOptions.RemoveEmptyEntries))
            {
                Cookie cookie = JsonConvert.DeserializeObject<Cookie>(stringCookie);
                CrawlerContext.CookieContainer.Add(cookie);
            }
        }

        public static void LoadExhausted()
        {
            SQLiteConnection conn = new SQLiteConnection("data source=" + CrawlerContext.SessionFileName);
            ExhaustedURLController controller = new ExhaustedURLController();
            ExhaustedURLFindResult result = controller.FindAll();
            foreach (ExhaustedURL url in result.Items)
            {
                CrawlerContext.ExhaustedURL.Add(url.URL);
            }
        }

        public static void LoadAttackURLCounts()
        {
            SQLiteConnection conn = new SQLiteConnection("data source=" + CrawlerContext.SessionFileName);

            string selectQuery = @"SELECT COUNT(*) FROM attack_history";

            try
            {
                conn.Open();
                using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    cmd.CommandText = selectQuery;
                    using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SessionFileContext.AttackCount = int.Parse(reader["COUNT(*)"].ToString());
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void LoadHistory(Action<URLHistory> WriteToDataGrid)
        {
            SQLiteConnection conn = new SQLiteConnection("data source=" + CrawlerContext.SessionFileName);

            string selectQuery = @"SELECT id, url, response_code, length, priority, info FROM url_history";

            try
            {
                conn.Open();
                using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    cmd.CommandText = selectQuery;
                    using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SessionFileContext.HistoryCount++;
                            if (WriteToDataGrid != null)
                            {
                                Request request = new Request();
                                request.Url = reader["url"].ToString();

                                CrawlerContext.Pages.Add(request);

                                URLHistory history = new URLHistory();
                                history.URLHistoryId = int.Parse(reader["id"].ToString());
                                history.URL = reader["url"].ToString();
                                history.Length = int.Parse(reader["length"].ToString());
                                history.Priority = int.Parse(reader["priority"].ToString());
                                history.Info = reader["info"].ToString();
                                history.ResponseCode = reader["response_code"].ToString();
                                // history.EntryDate = DateTime.Parse(reader["date"].ToString());
                                WriteToDataGrid(history);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void LogExhsutedUrl(string url)
        {
            ExhaustedURL eUrl = new ExhaustedURL();
            eUrl.URL = url;
            SQLiteConnection conn = new SQLiteConnection("data source=" + CrawlerContext.SessionFileName);
            ExhaustedURLController exhaustedURLController = new ExhaustedURLController();
            exhaustedURLController.Insert(eUrl);
        }

        public static void LogAttack(AttackModel attack, Request request)
        {
            AttackHistory history = new AttackHistory();
            history.URL = request.Url;
            history.Payload = attack.Payload;
            history.Priority = attack.Priority;
            history.Type = attack.Type;
            history.Verification = (attack.Confirmed ? "T" : "F") + " : " + attack.Verification;
            SQLiteConnection conn = new SQLiteConnection("data source=" + CrawlerContext.SessionFileName);
            AttackHistoryController attackHistoryController = new AttackHistoryController();
            attackHistoryController.Insert(history);
        }
    }
}