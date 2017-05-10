using Samadhi.Application.Crawler;
using Samadhi.Application.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samadhi2.Settings
{
    public partial class frmScannerSettings : Form
    {
        public frmScannerSettings()
        {
            InitializeComponent();
        }

        private void frmScannerSettings_Load(object sender, EventArgs e)
        {
            _txtUserAgent.Text = CrawlerContext.UserAgent;
            _chkSubdomains.Checked = CrawlerContext.IncludeSubdomains;
            _chkDOMScan.Checked = CrawlerContext.IncludeDOMUrls;
            _chkExhaust.Checked = CrawlerContext.ExhaustPageInput;
            foreach (string dir in CrawlerContext.IgnoreDirectory)
            {
                _lstIgnoreDir.Items.Add(dir);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CrawlerContext.UserAgent = _txtUserAgent.Text;
            CrawlerContext.IncludeSubdomains = _chkSubdomains.Checked;
            CrawlerContext.IncludeDOMUrls = _chkDOMScan.Checked;
            CrawlerContext.ExhaustPageInput = _chkExhaust.Checked;
            SessionFileHandler.SaveCrawlerContext();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void _btnSaveDir_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(_txtDirectory.Text))
                return;
            string dir = _txtDirectory.Text.Trim('/');
            _lstIgnoreDir.Items.Add(dir);
            CrawlerContext.IgnoreDirectory.Add(dir);
        }

        private void _btnRemoveDir_Click(object sender, EventArgs e)
        {
            CrawlerContext.IgnoreDirectory.RemoveAt(_lstIgnoreDir.SelectedIndex);
            _lstIgnoreDir.Items.RemoveAt(_lstIgnoreDir.SelectedIndex);
        }
    }
}
