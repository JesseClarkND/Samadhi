using Newtonsoft.Json.Linq;
using Samadhi.Application.Crawler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samadhi2.Settings
{
    public partial class frmCookie : Form
    {
        public string CurrentURL = "";
        public frmCookie(string url)
        {
            InitializeComponent();
            url = TrimHTTP(url);
            CurrentURL = url;
            if (CrawlerContext.CookieContainer == null)
                CrawlerContext.CookieContainer = new CookieContainer();
        }

        private string TrimHTTP(string url)
        {
            if (url.StartsWith("https://"))
                url = url.Substring(8, url.Length - 8);
            else if (url.StartsWith("http://"))
                url = url.Substring(7, url.Length - 7);
            return url.Trim('.');
        }

        private void PrintCookie(Cookie c)
        {
            _lstCookies.Items.Add(String.Format("Domain = {0}; Name = {1}; Value = {2};", c.Domain, c.Name, c.Value));
        }

        private void _btnSaveJSON_Click(object sender, EventArgs e)
        {
            JArray cookieArray = JArray.Parse(_txtJSONCookie.Text);
            for (int x = 0; x < cookieArray.Count; x++)
            {
                try
                {
                    if (!String.IsNullOrEmpty(cookieArray[x]["name"].ToString()) &&
                        !String.IsNullOrEmpty(cookieArray[x]["value"].ToString()) &&
                        !String.IsNullOrEmpty(cookieArray[x]["domain"].ToString()))
                    {
                        string name = cookieArray[x]["name"].ToString();
                        string value = cookieArray[x]["value"].ToString();
                        string cookieUrl = cookieArray[x]["domain"].ToString();
                        cookieUrl = TrimHTTP(cookieUrl);

                        Cookie c = new Cookie(name, value, "/", cookieUrl);
                        CrawlerContext.CookieContainer.Add(c);
                        PrintCookie(c);
                    }
                    else if (!String.IsNullOrEmpty(cookieArray[x]["name"].ToString()) &&
                             !String.IsNullOrEmpty(cookieArray[x]["value"].ToString()))
                    {
                        string name = cookieArray[x]["name"].ToString();
                        string value = cookieArray[x]["value"].ToString();

                        Cookie c = new Cookie(name, value, "/", CurrentURL);
                        CrawlerContext.CookieContainer.Add(c);
                        PrintCookie(c);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void _btnClear_Click(object sender, EventArgs e)
        {
            _txtCookieName.Text = "";
            _txtCookieValue.Text = "";
            _txtCookieDomain.Text = "";
            _txtJSONCookie.Text = "";
            CrawlerContext.CookieContainer = new CookieContainer();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCookie_Load(object sender, EventArgs e)
        {
            try
            {
                if (CrawlerContext.CookieContainer.Count == 0)
                    return;
                if (String.IsNullOrEmpty(CurrentURL))
                    throw new Exception("A URL must be placed in the text box to set cookies.");

                //https://stackoverflow.com/questions/13675154/how-to-get-cookies-info-inside-of-a-cookiecontainer-all-of-them-not-for-a-spe
                Hashtable table = (Hashtable)CrawlerContext.CookieContainer.GetType().InvokeMember("m_domainTable",
                                                                         BindingFlags.NonPublic |
                                                                         BindingFlags.GetField |
                                                                         BindingFlags.Instance,
                                                                         null,
                                                                         CrawlerContext.CookieContainer,
                                                                         new object[] { });

                foreach (var key in table.Keys)
                {
                    string keyString = key.ToString();
                    foreach (Cookie c in CrawlerContext.CookieContainer.GetCookies(new Uri(string.Format("http://{0}/", keyString.Trim('.')))))
                    {
                        PrintCookie(c);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _btnSaveCookie_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_txtCookieName.Text))
                if (!String.IsNullOrEmpty(_txtCookieValue.Text))
                {
                    Cookie c = new Cookie(_txtCookieName.Text, _txtCookieValue.Text, "/", _txtCookieDomain.Text);
                    CrawlerContext.CookieContainer.Add(c);
                    PrintCookie(c);
                }
        }

        private void _btnRemoveCookie_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _btnAuto_Click(object sender, EventArgs e)
        {
            _txtCookieDomain.Text = CurrentURL;
        }
    }
}
