namespace Samadhi2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._txtURL = new System.Windows.Forms.TextBox();
            this._btnLaunch = new System.Windows.Forms.Button();
            this._lblComplete = new System.Windows.Forms.Label();
            this._bgwScanner = new System.ComponentModel.BackgroundWorker();
            this._lblSiteCount = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this._btnPause = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._dgvQueries = new System.Windows.Forms.DataGridView();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._dgvError = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this._dgvResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttackType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._btnAttackGenerate = new System.Windows.Forms.Button();
            this._bgwAttackThread = new System.ComponentModel.BackgroundWorker();
            this._btnAttackTest = new System.Windows.Forms.Button();
            this._lblAttacks = new System.Windows.Forms.Label();
            this._lblResults = new System.Windows.Forms.Label();
            this._bgwAttackRequests = new System.ComponentModel.BackgroundWorker();
            this._lstAttacks = new System.Windows.Forms.ListBox();
            this._btnActiveScan = new System.Windows.Forms.Button();
            this._bgwActive = new System.ComponentModel.BackgroundWorker();
            this._btnSingleTest = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvQueries)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvError)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtURL
            // 
            this._txtURL.Location = new System.Drawing.Point(251, 27);
            this._txtURL.Name = "_txtURL";
            this._txtURL.Size = new System.Drawing.Size(256, 20);
            this._txtURL.TabIndex = 1;
            // 
            // _btnLaunch
            // 
            this._btnLaunch.Location = new System.Drawing.Point(215, 118);
            this._btnLaunch.Name = "_btnLaunch";
            this._btnLaunch.Size = new System.Drawing.Size(175, 53);
            this._btnLaunch.TabIndex = 12;
            this._btnLaunch.Text = "Launch Scanner";
            this._btnLaunch.UseVisualStyleBackColor = true;
            this._btnLaunch.Click += new System.EventHandler(this._btnLaunch_Click);
            // 
            // _lblComplete
            // 
            this._lblComplete.AutoSize = true;
            this._lblComplete.Location = new System.Drawing.Point(67, 245);
            this._lblComplete.Name = "_lblComplete";
            this._lblComplete.Size = new System.Drawing.Size(0, 13);
            this._lblComplete.TabIndex = 13;
            // 
            // _lblSiteCount
            // 
            this._lblSiteCount.AutoSize = true;
            this._lblSiteCount.Location = new System.Drawing.Point(413, 77);
            this._lblSiteCount.Name = "_lblSiteCount";
            this._lblSiteCount.Size = new System.Drawing.Size(13, 13);
            this._lblSiteCount.TabIndex = 49;
            this._lblSiteCount.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1266, 24);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scannerToolStripMenuItem,
            this.cookieToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // scannerToolStripMenuItem
            // 
            this.scannerToolStripMenuItem.Name = "scannerToolStripMenuItem";
            this.scannerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.scannerToolStripMenuItem.Text = "Scanner";
            this.scannerToolStripMenuItem.Click += new System.EventHandler(this.scannerToolStripMenuItem_Click);
            // 
            // cookieToolStripMenuItem
            // 
            this.cookieToolStripMenuItem.Name = "cookieToolStripMenuItem";
            this.cookieToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.cookieToolStripMenuItem.Text = "Cookie";
            this.cookieToolStripMenuItem.Click += new System.EventHandler(this.cookieToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Quick Start";
            // 
            // _btnPause
            // 
            this._btnPause.Location = new System.Drawing.Point(692, 67);
            this._btnPause.Name = "_btnPause";
            this._btnPause.Size = new System.Drawing.Size(75, 23);
            this._btnPause.TabIndex = 54;
            this._btnPause.Text = "Pause";
            this._btnPause.UseVisualStyleBackColor = true;
            this._btnPause.Click += new System.EventHandler(this._btnPause_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(396, 96);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(858, 471);
            this.tabControl1.TabIndex = 55;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._dgvQueries);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(850, 445);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scanner";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _dgvQueries
            // 
            this._dgvQueries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvQueries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.URL,
            this.StatusCode,
            this.Length,
            this.Priority,
            this.Info});
            this._dgvQueries.Location = new System.Drawing.Point(3, 3);
            this._dgvQueries.Name = "_dgvQueries";
            this._dgvQueries.Size = new System.Drawing.Size(838, 433);
            this._dgvQueries.TabIndex = 48;
            // 
            // URL
            // 
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            // 
            // StatusCode
            // 
            this.StatusCode.HeaderText = "Code";
            this.StatusCode.Name = "StatusCode";
            // 
            // Length
            // 
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            // 
            // Info
            // 
            this.Info.HeaderText = "Info";
            this.Info.Name = "Info";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._dgvError);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(850, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Attacks";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _dgvError
            // 
            this._dgvError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.Type});
            this._dgvError.Location = new System.Drawing.Point(6, 6);
            this._dgvError.Name = "_dgvError";
            this._dgvError.Size = new System.Drawing.Size(838, 433);
            this._dgvError.TabIndex = 49;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "URL";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Payload";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this._dgvResults);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(850, 445);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Results";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // _dgvResults
            // 
            this._dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.AttackType});
            this._dgvResults.Location = new System.Drawing.Point(6, 6);
            this._dgvResults.Name = "_dgvResults";
            this._dgvResults.Size = new System.Drawing.Size(838, 433);
            this._dgvResults.TabIndex = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "URL";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Payload";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // AttackType
            // 
            this.AttackType.HeaderText = "Type";
            this.AttackType.Name = "AttackType";
            // 
            // _btnAttackGenerate
            // 
            this._btnAttackGenerate.Location = new System.Drawing.Point(215, 278);
            this._btnAttackGenerate.Name = "_btnAttackGenerate";
            this._btnAttackGenerate.Size = new System.Drawing.Size(175, 53);
            this._btnAttackGenerate.TabIndex = 56;
            this._btnAttackGenerate.Text = "Attack Generate";
            this._btnAttackGenerate.UseVisualStyleBackColor = true;
            this._btnAttackGenerate.Click += new System.EventHandler(this._btnAttackGenerate_Click);
            // 
            // _btnAttackTest
            // 
            this._btnAttackTest.Location = new System.Drawing.Point(215, 337);
            this._btnAttackTest.Name = "_btnAttackTest";
            this._btnAttackTest.Size = new System.Drawing.Size(175, 53);
            this._btnAttackTest.TabIndex = 57;
            this._btnAttackTest.Text = "Attack Test";
            this._btnAttackTest.UseVisualStyleBackColor = true;
            this._btnAttackTest.Click += new System.EventHandler(this._btnAttackTest_Click);
            // 
            // _lblAttacks
            // 
            this._lblAttacks.AutoSize = true;
            this._lblAttacks.Location = new System.Drawing.Point(469, 80);
            this._lblAttacks.Name = "_lblAttacks";
            this._lblAttacks.Size = new System.Drawing.Size(13, 13);
            this._lblAttacks.TabIndex = 58;
            this._lblAttacks.Text = "0";
            // 
            // _lblResults
            // 
            this._lblResults.AutoSize = true;
            this._lblResults.Location = new System.Drawing.Point(513, 80);
            this._lblResults.Name = "_lblResults";
            this._lblResults.Size = new System.Drawing.Size(13, 13);
            this._lblResults.TabIndex = 59;
            this._lblResults.Text = "0";
            // 
            // _lstAttacks
            // 
            this._lstAttacks.FormattingEnabled = true;
            this._lstAttacks.Location = new System.Drawing.Point(215, 177);
            this._lstAttacks.Name = "_lstAttacks";
            this._lstAttacks.Size = new System.Drawing.Size(175, 95);
            this._lstAttacks.TabIndex = 61;
            // 
            // _btnActiveScan
            // 
            this._btnActiveScan.Location = new System.Drawing.Point(513, 27);
            this._btnActiveScan.Name = "_btnActiveScan";
            this._btnActiveScan.Size = new System.Drawing.Size(114, 32);
            this._btnActiveScan.TabIndex = 62;
            this._btnActiveScan.Text = "Active Scan";
            this._btnActiveScan.UseVisualStyleBackColor = true;
            this._btnActiveScan.Click += new System.EventHandler(this._btnActiveScan_Click);
            // 
            // _btnSingleTest
            // 
            this._btnSingleTest.Location = new System.Drawing.Point(633, 27);
            this._btnSingleTest.Name = "_btnSingleTest";
            this._btnSingleTest.Size = new System.Drawing.Size(114, 32);
            this._btnSingleTest.TabIndex = 63;
            this._btnSingleTest.Text = "Single Page Test";
            this._btnSingleTest.UseVisualStyleBackColor = true;
            this._btnSingleTest.Click += new System.EventHandler(this._btnSingleTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 592);
            this.Controls.Add(this._btnSingleTest);
            this.Controls.Add(this._btnActiveScan);
            this.Controls.Add(this._lstAttacks);
            this.Controls.Add(this._lblResults);
            this.Controls.Add(this._lblAttacks);
            this.Controls.Add(this._btnAttackTest);
            this.Controls.Add(this._btnAttackGenerate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this._btnPause);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._lblSiteCount);
            this.Controls.Add(this._lblComplete);
            this.Controls.Add(this._btnLaunch);
            this.Controls.Add(this._txtURL);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvQueries)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvError)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtURL;
        private System.Windows.Forms.Button _btnLaunch;
        private System.Windows.Forms.Label _lblComplete;
        private System.ComponentModel.BackgroundWorker _bgwScanner;
        private System.Windows.Forms.Label _lblSiteCount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scannerToolStripMenuItem;
        private System.Windows.Forms.Button _btnPause;
        private System.Windows.Forms.ToolStripMenuItem cookieToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _dgvQueries;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView _dgvError;
        private System.Windows.Forms.Button _btnAttackGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.ComponentModel.BackgroundWorker _bgwAttackThread;
        private System.Windows.Forms.Button _btnAttackTest;
        private System.Windows.Forms.Label _lblAttacks;
        private System.Windows.Forms.Label _lblResults;
        private System.ComponentModel.BackgroundWorker _bgwAttackRequests;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView _dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttackType;
        private System.Windows.Forms.ListBox _lstAttacks;
        private System.Windows.Forms.Button _btnActiveScan;
        private System.ComponentModel.BackgroundWorker _bgwActive;
        private System.Windows.Forms.Button _btnSingleTest;
    }
}

