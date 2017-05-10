using Samadhi.Application;
using Samadhi.Application.Attacker;
using Samadhi.Application.Crawler;
using Samadhi.Application.Utility;
using Samadhi.Attack.Common;
using Samadhi.Data;
using Samadhi.History.Data;
using Samadhi2.File;
using Samadhi2.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samadhi2
{
    public partial class Form1 : Form
    {
        private string _sessionFileName = "";
        private bool _pause = false;
        //private bool _cancel = false;
        private static Action<URLHistory> _dataGridWrite;
        private static Action<AttackHistory> _attackDataGridWrite;
        private static Action<AttackHistory> _resultDataGridWrite;
        private static Action _siteCounter;
        private static Action _attackCounter;
        private static Action _resultCounter;
        private bool _continuedSession = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Would you like this to be a reloadable session?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _sessionFileName = "Samadhi " + DateTime.Now.ToString("mm-dd-yyyy_hh-mm-ss-t") + ".db3";
                CrawlerContext.SessionFileName = _sessionFileName;
                Core.SQLite.Accessor.Settings.ConnectionString = "data source=" + _sessionFileName;

                SessionFileHandler.CreateSessionFile(_sessionFileName);
            }
            CrawlerContext.Initialize();
            _lstAttacks.Items.Add("Error");
            _lstAttacks.Items.Add("XSS");
            _txtURL.Text = "blackhorseproperty.com";
        }

        private void _btnLaunch_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.Yes;
            if (_continuedSession)
                dialogResult = MessageBox.Show("Warning! An old session has been loaded into the current context. Data may be overwritten.", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(_txtURL.Text))
                {
                    MessageBox.Show("Enter a starting URL: example.com");
                    _txtURL.Focus();
                    return;
                }
                _btnLaunch.Enabled = false;
                _lblComplete.Text = "";
                CrawlerContext.SessionFileName = _sessionFileName;
                Core.SQLite.Accessor.Settings.ConnectionString = "data source=" + _sessionFileName;
                CrawlerContext.SetURL(_txtURL.Text);

                SessionFileHandler.SaveCrawlerContext();

                //Request initialRequest = new Request(_txtURL.Text);
                //Do Probe here
            }
            _bgwScanner.DoWork += new DoWorkEventHandler(_bgwScanner_DoWork);
            _bgwScanner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwScanner_RunWorkerCompleted);
            //backgroundWorker1.CancellationPending

            _bgwScanner.RunWorkerAsync();
        }

        #region Scanner
        private void _bgwScanner_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _dataGridWrite = new Action<URLHistory>(WriteToDataGrid);
                _siteCounter = new Action(UpdateSiteCount);

                Crawler.CrawlSite(_dataGridWrite, _siteCounter);
                //LinearCrawler.CrawlSite(DataGridWrite, SiteCounter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Scanner Error: "+ex.Message);
            }
        }

        private void _bgwScanner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //_lblComplete.Text = "Complete";
            //_btnLaunch.Enabled = true;
            //_pbLoading.Visible = false;
        }

        public void UpdateSiteCount()
        {
            if (_lblSiteCount.InvokeRequired)
            {
                this.Invoke(_siteCounter);
                return;
            }

            string counter = _lblSiteCount.Text;
            int count = int.Parse(counter);
            _lblSiteCount.Text = (++count).ToString();
        }

        public void WriteToDataGrid(URLHistory info)
        {
            if (_dgvQueries.InvokeRequired)
            {
                this.Invoke(_dataGridWrite, info);
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            //if (info.Priority == 10)
            //{
            //    row.DefaultCellStyle.BackColor = Color.Red;
            //}
            //else if (info.Priority < 10 && info.Priority >= 5)
            //{
            //    row.DefaultCellStyle.BackColor = Color.Orange;
            //}
            //else if (info.Priority > 0 && info.Priority < 5)
            //{
            //    row.DefaultCellStyle.BackColor = Color.Yellow;
            //}
            row.CreateCells(_dgvQueries);
            row.Cells[0].Value = info.URL;
            row.Cells[1].Value = info.ResponseCode;
            row.Cells[2].Value = info.Length;
            row.Cells[3].Value = info.Priority;
            row.Cells[4].Value = info.Info;
            //if (_chkTop.Checked && info.Priority != 0)
            //    _dgvQueries.Rows.Insert(0, row);
            //else
            _dgvQueries.Rows.Add(row);
            _dgvQueries.Refresh();
        }

        public void WriteToErrorDataGrid(AttackHistory attack)
        {
            if (_dgvError.InvokeRequired)
            {
                this.Invoke(_attackDataGridWrite, attack);
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(_dgvError);
            row.Cells[0].Value = attack.URL;
            row.Cells[1].Value = attack.Payload;
            row.Cells[2].Value = attack.Priority;
            row.Cells[3].Value = attack.Type;
            _dgvError.Rows.Add(row);
            _dgvError.Refresh();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Samadhi2.File.frmOpenSession.LoadType loadType;
                frmOpenSession form = new frmOpenSession();
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _continuedSession = true;
                    _sessionFileName = form.FileName;
                    CrawlerContext.SessionFileName = _sessionFileName;
                    Core.SQLite.Accessor.Settings.ConnectionString = "data source=" + _sessionFileName;
                    loadType = form.LoadSessionType;

                    SessionFileHandler.LoadCrawlerContextSettings(_sessionFileName);
                    _txtURL.Text = CrawlerContext.URI.ToString();
                    switch (loadType)
                    {
                        case (Samadhi2.File.frmOpenSession.LoadType.Full):
                            SessionFileHandler.LoadHistory(new Action<URLHistory>(WriteToDataGrid));
                            SessionFileHandler.LoadExhausted();
                            break;
                        case (Samadhi2.File.frmOpenSession.LoadType.History):
                            SessionFileHandler.LoadHistory(null);
                            break;
                        case (Samadhi2.File.frmOpenSession.LoadType.Attack):
                            SessionFileHandler.LoadAttackURLCounts();
                            break;
                    }
                    _lblSiteCount.Text = SessionFileContext.HistoryCount.ToString();
                    _lblAttacks.Text = SessionFileContext.AttackCount.ToString();
                    _lblComplete.Text = SessionFileContext.ResultCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmScannerSettings form = new frmScannerSettings();
                var result = form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void _btnPause_Click(object sender, EventArgs e)
        {
            _pause = !_pause;
            if (_pause)
            {
                CrawlerContext.PauseEvent.Reset();
                _btnPause.Text = "Resume";
            //    _btnReset.Enabled = true;
            //    _btnSave.Enabled = true;
            //    _pbLoading.Visible = false;
            }
            else
            {
            //    ThreadParameters.pauseEvent.Set();
                CrawlerContext.PauseEvent.Set();
                _btnPause.Text = "Pause";
            //    _btnReset.Enabled = false;
            //    _btnSave.Enabled = false;
            //    _pbLoading.Visible = true;
            }
        }

        private void cookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCookie form = new frmCookie(_txtURL.Text);
                var result = form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Attack Generator
        private void _btnAttackGenerate_Click(object sender, EventArgs e)
        {
            _btnAttackGenerate.Enabled = false;
            _bgwAttackThread.DoWork += new DoWorkEventHandler(_bgwAttackThread_DoWork);
            _bgwAttackThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwAttackThread_RunWorkerCompleted);

            _bgwAttackThread.RunWorkerAsync(_lstAttacks.SelectedItems.Cast<string>().ToList());
        }

        private void _bgwAttackThread_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<string> items = (List<string>)e.Argument;
                foreach (string item in items)
                {
                    string className = "AttackHandler";
                    string namespaceName = "Samadhi.Attack." + item;
                    var myObj = Activator.CreateInstance(namespaceName, namespaceName + "." + className);
                    if (myObj == null)
                        throw new Exception("Unimplemented attack class.");

                    _attackDataGridWrite = new Action<AttackHistory>(WriteToErrorDataGrid);
                    ParentAttackHandler attackHandler = (ParentAttackHandler)myObj.Unwrap();
                    _attackCounter = new Action(UpdateAttackCount);

                    CreateAttackURLs.Generate(_attackDataGridWrite, attackHandler, _attackCounter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Create Attacks: "+ex.Message);
            }
        }

        private void _bgwAttackThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //_lblComplete.Text = "Complete";
            //_btnAttackGenerate.Enabled = true;
            //_pbLoading.Visible = false;

        }

        public void UpdateAttackCount()
        {
            if (_lblAttacks.InvokeRequired)
            {
                this.Invoke(_attackCounter);
                return;
            }

            string counter = _lblAttacks.Text;
            int count = int.Parse(counter);
            _lblAttacks.Text = (++count).ToString();
        }
        #endregion

        #region Attack Testers
        public void WriteToResultDataGrid(AttackHistory attack)
        {
            if (_dgvResults.InvokeRequired)
            {
                this.Invoke(_resultDataGridWrite, attack);
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(_dgvResults);
            row.Cells[0].Value = attack.URL;
            row.Cells[1].Value = attack.Payload;
            row.Cells[2].Value = attack.Priority;
            row.Cells[3].Value = attack.Type;
            _dgvResults.Rows.Add(row);
            _dgvResults.Refresh();
        }

        private void _btnAttackTest_Click(object sender, EventArgs e)
        {
            _btnAttackTest.Enabled = false;
            _bgwAttackRequests.DoWork += new DoWorkEventHandler(_bgwAttackRequests_DoWork);
            _bgwAttackRequests.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwAttackRequests_RunWorkerCompleted);

            _bgwAttackRequests.RunWorkerAsync();
        }

        private void _bgwAttackRequests_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _resultDataGridWrite = new Action<AttackHistory>(WriteToResultDataGrid);
                _resultCounter = new Action(UpdateResultCount);

                AttackTester.CycleThroughUntested(_resultDataGridWrite, _resultCounter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _bgwAttackRequests_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public void UpdateResultCount()
        {
            if (_lblResults.InvokeRequired)
            {
                this.Invoke(_resultCounter);
                return;
            }

            string counter = _lblResults.Text;
            int count = int.Parse(counter);
            _lblResults.Text = (++count).ToString();
        }
        #endregion

        private void _btnActiveScan_Click(object sender, EventArgs e)
        {
            CrawlerContext.SessionFileName = _sessionFileName;
            Core.SQLite.Accessor.Settings.ConnectionString = "data source=" + _sessionFileName;
            CrawlerContext.SetURL(_txtURL.Text);

            SessionFileHandler.SaveCrawlerContext();

            _btnAttackTest.Enabled = false;
            _btnAttackGenerate.Enabled = false;
            _btnActiveScan.Enabled = false;
            _btnAttackTest.Enabled = false;

            _bgwActive.DoWork += new DoWorkEventHandler(_bgwActive_DoWork);
            _bgwActive.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwActive_RunWorkerCompleted);

            _bgwActive.RunWorkerAsync(_lstAttacks.SelectedItems.Cast<string>().ToList());
        }

        private void _bgwActive_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Start generating urls
                _bgwScanner.DoWork += new DoWorkEventHandler(_bgwScanner_DoWork);
                _bgwScanner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwScanner_RunWorkerCompleted);
                _bgwScanner.RunWorkerAsync();

                CrawlerContext.AttackTestThreadAsService = true;
                _bgwAttackRequests.DoWork += new DoWorkEventHandler(_bgwAttackRequests_DoWork);
                _bgwAttackRequests.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwAttackRequests_RunWorkerCompleted);
                _bgwAttackRequests.RunWorkerAsync();

                List<string> items = (List<string>)e.Argument;
                bool first = true;
                while (_bgwScanner.IsBusy || _bgwAttackRequests.IsBusy)
                {
                    if (first)
                    {
                        Thread.Sleep(3000);
                        first = false;
                    }

                    _bgwAttackThread.DoWork += new DoWorkEventHandler(_bgwAttackThread_DoWork);
                    _bgwAttackThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwAttackThread_RunWorkerCompleted);
                    if (!_bgwAttackThread.IsBusy)
                    {
                        _bgwAttackThread.RunWorkerAsync(items);
                    }
                    else
                        Thread.Sleep(60000);
                }

                CrawlerContext.AttackTestThreadAsService = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Attack Thread: " + ex.Message);
            }
        }

        private void _bgwActive_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //_btnAttackTest.Enabled = true;
        }

        private void _btnSingleTest_Click(object sender, EventArgs e)
        {
            CrawlerContext.ExhaustPageInput = true;
            CrawlerContext.SinglePage = true;

            CrawlerContext.SessionFileName = _sessionFileName;
            Core.SQLite.Accessor.Settings.ConnectionString = "data source=" + _sessionFileName;
            CrawlerContext.SetURL(_txtURL.Text);

            SessionFileHandler.SaveCrawlerContext();

            _btnAttackTest.Enabled = false;
            _btnAttackGenerate.Enabled = false;
            _btnActiveScan.Enabled = false;
            _btnAttackTest.Enabled = false;

            _bgwActive.DoWork += new DoWorkEventHandler(_bgwActive_DoWork);
            _bgwActive.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwActive_RunWorkerCompleted);

            _bgwActive.RunWorkerAsync(_lstAttacks.SelectedItems.Cast<string>().ToList());
        }
    }
}