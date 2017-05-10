using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLite.Accessor
{
    public class Settings
    {
        //Trim this
        private static readonly string XMLFILENAME = "settings.xml";
        private static bool _loaded = false;
        private static string _connectionString = "";
        private static string _activeDirectoryDomain = "";
        private static string _activeDirectoryName = "";
        private static string _activeDirectoryUser = "";
        private static string _activeDirectoryPassword = "";
        private static string _activeDirectoryContainer = "";
        private static string _baseURL = "";
        private static string _emailServer = "";
        private static string _emailPort = "";
        private static string _emailUser = "";
        private static string _emailPassword = "";
        private static string _fromAddress = "";

        public static string ConnectionString
        {
            get
            {
                //if (_loaded == false)
                //    LoadConfiguration();

                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public static string ActiveDirectoryDomain
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _activeDirectoryDomain;
            }
        }

        public static string ActiveDirectoryName
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _activeDirectoryName;
            }
        }

        public static string ActiveDirectoryUser
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _activeDirectoryUser;
            }
        }

        public static string ActiveDirectoryPassword
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _activeDirectoryPassword;
            }
        }

        public static string ActiveDirectoryContainer
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _activeDirectoryContainer;
            }
        }

        public static string BaseURL
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _baseURL;
            }
        }

        public static string EmailServer
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _emailServer;
            }
        }

        public static string EmailPort
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _emailPort;
            }
        }

        public static string EmailUser
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _emailUser;
            }
        }

        public static string EmailPassword
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _emailPassword;
            }
        }

        public static string FromAddress
        {
            get
            {
                if (_loaded == false)
                    LoadConfiguration();

                return _fromAddress;
            }
        }

        public static void LoadConfiguration()
        {
            //String xmlFilePath = "";
            //try
            //{
            //    xmlFilePath = Path.Combine(System.Web.HttpRuntime.BinDirectory, XMLFILENAME);
            //}
            //catch
            //{
            //    try
            //    {
            //        xmlFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), XMLFILENAME);
            //    }
            //    catch
            //    {
            //        xmlFilePath = XMLFILENAME;
            //    }
            //}

            //if (!File.Exists(xmlFilePath))
            //    return;

            //XmlDocument _xmlDocument = new XmlDocument();
            //try
            //{
            //    _xmlDocument.Load(xmlFilePath);
            //    XmlNode docNode = _xmlDocument.DocumentElement;

            //    //Settings
            //    if (docNode.SelectSingleNode("//ConnectionString") != null)
            //    {
            //        _connectionString = docNode.SelectSingleNode("//ConnectionString").InnerText;
            //    }

            //    if (docNode.SelectSingleNode("//ADDomain") != null)
            //    {
            //        _activeDirectoryDomain = docNode.SelectSingleNode("//ADDomain").InnerText;
            //    }

            //    if (docNode.SelectSingleNode("//ADName") != null)
            //    {
            //        _activeDirectoryName = docNode.SelectSingleNode("//ADName").InnerText;
            //    }

            //    string[] adNameParts = _activeDirectoryName.Split('.');
            //    _activeDirectoryContainer = string.Join(",", adNameParts.ToList().Select(p => "DC=" + p));

            //    if (docNode.SelectSingleNode("//ADUser") != null)
            //    {
            //        _activeDirectoryUser = adNameParts[0] + "\\" + docNode.SelectSingleNode("//ADUser").InnerText;
            //    }

            //    if (docNode.SelectSingleNode("//ADPassword") != null)
            //    {
            //        _activeDirectoryPassword = docNode.SelectSingleNode("//ADPassword").InnerText;
            //    }

            //    if (docNode.SelectSingleNode("//BaseURL") != null)
            //    {
            //        _baseURL = docNode.SelectSingleNode("//BaseURL").InnerText;
            //    }

            //    if (docNode.SelectSingleNode("//EmailServer") != null)
            //    {
            //        _emailServer = docNode.SelectSingleNode("//EmailServer").InnerText;
            //    }

            //    if (docNode.SelectSingleNode("//EmailPort") != null)
            //    {
            //        _emailPort = docNode.SelectSingleNode("//EmailPort").InnerText;
            //    }

            //    if (docNode.SelectSingleNode("//EmailUser") != null)
            //    {
            //        _emailUser = docNode.SelectSingleNode("//EmailUser").InnerText;
            //    }

            //    if (docNode.SelectSingleNode("//EmailPassword") != null)
            //    {
            //        _emailPassword = docNode.SelectSingleNode("//EmailPassword").InnerText;
            //    }

            //    if (docNode.SelectSingleNode("//FromAddress") != null)
            //    {
            //        _fromAddress = docNode.SelectSingleNode("//FromAddress").InnerText;
            //    }

            //    _loaded = true;
            //}
            //catch (Exception)
            //{
            //    throw new Exception("Configuration file is not valid. settings values to their defaults.");
            //}
        }
    }
}
