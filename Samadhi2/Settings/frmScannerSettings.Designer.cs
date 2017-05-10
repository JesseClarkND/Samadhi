namespace Samadhi2.Settings
{
    partial class frmScannerSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._txtUserAgent = new System.Windows.Forms.TextBox();
            this._lstIgnoreDir = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._txtDirectory = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this._btnRemoveDir = new System.Windows.Forms.Button();
            this._btnSaveDir = new System.Windows.Forms.Button();
            this._chkSubdomains = new System.Windows.Forms.CheckBox();
            this._chkDOMScan = new System.Windows.Forms.CheckBox();
            this._chkExhaust = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(496, 411);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(577, 411);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Agent:";
            // 
            // _txtUserAgent
            // 
            this._txtUserAgent.Location = new System.Drawing.Point(81, 6);
            this._txtUserAgent.Name = "_txtUserAgent";
            this._txtUserAgent.Size = new System.Drawing.Size(241, 20);
            this._txtUserAgent.TabIndex = 3;
            // 
            // _lstIgnoreDir
            // 
            this._lstIgnoreDir.FormattingEnabled = true;
            this._lstIgnoreDir.Location = new System.Drawing.Point(15, 66);
            this._lstIgnoreDir.Name = "_lstIgnoreDir";
            this._lstIgnoreDir.Size = new System.Drawing.Size(120, 212);
            this._lstIgnoreDir.TabIndex = 4;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(202, 66);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 212);
            this.listBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Directories To Ignore";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "URL Parameters To Ignore";
            // 
            // _txtDirectory
            // 
            this._txtDirectory.Location = new System.Drawing.Point(15, 284);
            this._txtDirectory.Name = "_txtDirectory";
            this._txtDirectory.Size = new System.Drawing.Size(120, 20);
            this._txtDirectory.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(202, 284);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(202, 310);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(52, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // _btnRemoveDir
            // 
            this._btnRemoveDir.Location = new System.Drawing.Point(73, 310);
            this._btnRemoveDir.Name = "_btnRemoveDir";
            this._btnRemoveDir.Size = new System.Drawing.Size(62, 23);
            this._btnRemoveDir.TabIndex = 15;
            this._btnRemoveDir.Text = "Remove";
            this._btnRemoveDir.UseVisualStyleBackColor = true;
            this._btnRemoveDir.Click += new System.EventHandler(this._btnRemoveDir_Click);
            // 
            // _btnSaveDir
            // 
            this._btnSaveDir.Location = new System.Drawing.Point(15, 310);
            this._btnSaveDir.Name = "_btnSaveDir";
            this._btnSaveDir.Size = new System.Drawing.Size(52, 23);
            this._btnSaveDir.TabIndex = 14;
            this._btnSaveDir.Text = "Save";
            this._btnSaveDir.UseVisualStyleBackColor = true;
            this._btnSaveDir.Click += new System.EventHandler(this._btnSaveDir_Click);
            // 
            // _chkSubdomains
            // 
            this._chkSubdomains.AutoSize = true;
            this._chkSubdomains.Location = new System.Drawing.Point(15, 364);
            this._chkSubdomains.Name = "_chkSubdomains";
            this._chkSubdomains.Size = new System.Drawing.Size(122, 17);
            this._chkSubdomains.TabIndex = 54;
            this._chkSubdomains.Text = "Include Subdomains";
            this._chkSubdomains.UseVisualStyleBackColor = true;
            // 
            // _chkDOMScan
            // 
            this._chkDOMScan.AutoSize = true;
            this._chkDOMScan.Location = new System.Drawing.Point(15, 387);
            this._chkDOMScan.Name = "_chkDOMScan";
            this._chkDOMScan.Size = new System.Drawing.Size(119, 17);
            this._chkDOMScan.TabIndex = 55;
            this._chkDOMScan.Text = "Include DOM URLs";
            this._chkDOMScan.UseVisualStyleBackColor = true;
            // 
            // _chkExhaust
            // 
            this._chkExhaust.AutoSize = true;
            this._chkExhaust.Location = new System.Drawing.Point(15, 410);
            this._chkExhaust.Name = "_chkExhaust";
            this._chkExhaust.Size = new System.Drawing.Size(119, 17);
            this._chkExhaust.TabIndex = 56;
            this._chkExhaust.Text = "Exhaust Page Input";
            this._chkExhaust.UseVisualStyleBackColor = true;
            // 
            // frmScannerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 446);
            this.Controls.Add(this._chkExhaust);
            this.Controls.Add(this._chkDOMScan);
            this.Controls.Add(this._chkSubdomains);
            this.Controls.Add(this._btnRemoveDir);
            this.Controls.Add(this._btnSaveDir);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this._txtDirectory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this._lstIgnoreDir);
            this.Controls.Add(this._txtUserAgent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmScannerSettings";
            this.Text = "frmScannerSettings";
            this.Load += new System.EventHandler(this.frmScannerSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtUserAgent;
        private System.Windows.Forms.ListBox _lstIgnoreDir;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtDirectory;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button _btnRemoveDir;
        private System.Windows.Forms.Button _btnSaveDir;
        private System.Windows.Forms.CheckBox _chkSubdomains;
        private System.Windows.Forms.CheckBox _chkDOMScan;
        private System.Windows.Forms.CheckBox _chkExhaust;
    }
}