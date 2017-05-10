namespace Samadhi2.Settings
{
    partial class frmCookie
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
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._txtJSONCookie = new System.Windows.Forms.TextBox();
            this._btnClear = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnSaveJSON = new System.Windows.Forms.Button();
            this._lblCookieVal = new System.Windows.Forms.Label();
            this._lblCookieName = new System.Windows.Forms.Label();
            this._txtCookieValue = new System.Windows.Forms.TextBox();
            this._txtCookieName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this._txtCookieDomain = new System.Windows.Forms.TextBox();
            this._lstCookies = new System.Windows.Forms.ListBox();
            this._btnRemoveCookie = new System.Windows.Forms.Button();
            this._btnSaveCookie = new System.Windows.Forms.Button();
            this._btnAuto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(254, 13);
            this.label13.TabIndex = 109;
            this.label13.Text = "Enter value pairs manually or paste in a JSON object";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 108;
            this.label12.Text = "JSON";
            // 
            // _txtJSONCookie
            // 
            this._txtJSONCookie.Location = new System.Drawing.Point(12, 281);
            this._txtJSONCookie.Multiline = true;
            this._txtJSONCookie.Name = "_txtJSONCookie";
            this._txtJSONCookie.Size = new System.Drawing.Size(593, 151);
            this._txtJSONCookie.TabIndex = 107;
            // 
            // _btnClear
            // 
            this._btnClear.Location = new System.Drawing.Point(392, 438);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(75, 23);
            this._btnClear.TabIndex = 106;
            this._btnClear.Text = "Clear";
            this._btnClear.UseVisualStyleBackColor = true;
            this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(530, 438);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 105;
            this._btnCancel.Text = "Close";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnSaveJSON
            // 
            this._btnSaveJSON.Location = new System.Drawing.Point(12, 438);
            this._btnSaveJSON.Name = "_btnSaveJSON";
            this._btnSaveJSON.Size = new System.Drawing.Size(41, 23);
            this._btnSaveJSON.TabIndex = 104;
            this._btnSaveJSON.Text = "Save";
            this._btnSaveJSON.UseVisualStyleBackColor = true;
            this._btnSaveJSON.Click += new System.EventHandler(this._btnSaveJSON_Click);
            // 
            // _lblCookieVal
            // 
            this._lblCookieVal.AutoSize = true;
            this._lblCookieVal.Location = new System.Drawing.Point(146, 146);
            this._lblCookieVal.Name = "_lblCookieVal";
            this._lblCookieVal.Size = new System.Drawing.Size(34, 13);
            this._lblCookieVal.TabIndex = 97;
            this._lblCookieVal.Text = "Value";
            // 
            // _lblCookieName
            // 
            this._lblCookieName.AutoSize = true;
            this._lblCookieName.Location = new System.Drawing.Point(18, 146);
            this._lblCookieName.Name = "_lblCookieName";
            this._lblCookieName.Size = new System.Drawing.Size(35, 13);
            this._lblCookieName.TabIndex = 96;
            this._lblCookieName.Text = "Name";
            // 
            // _txtCookieValue
            // 
            this._txtCookieValue.Location = new System.Drawing.Point(139, 162);
            this._txtCookieValue.Name = "_txtCookieValue";
            this._txtCookieValue.Size = new System.Drawing.Size(221, 20);
            this._txtCookieValue.TabIndex = 84;
            // 
            // _txtCookieName
            // 
            this._txtCookieName.Location = new System.Drawing.Point(21, 162);
            this._txtCookieName.Name = "_txtCookieName";
            this._txtCookieName.Size = new System.Drawing.Size(112, 20);
            this._txtCookieName.TabIndex = 78;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(366, 146);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 135;
            this.label21.Text = "Domain";
            // 
            // _txtCookieDomain
            // 
            this._txtCookieDomain.Location = new System.Drawing.Point(369, 162);
            this._txtCookieDomain.Name = "_txtCookieDomain";
            this._txtCookieDomain.Size = new System.Drawing.Size(221, 20);
            this._txtCookieDomain.TabIndex = 123;
            // 
            // _lstCookies
            // 
            this._lstCookies.FormattingEnabled = true;
            this._lstCookies.Location = new System.Drawing.Point(21, 48);
            this._lstCookies.Name = "_lstCookies";
            this._lstCookies.Size = new System.Drawing.Size(584, 95);
            this._lstCookies.TabIndex = 136;
            // 
            // _btnRemoveCookie
            // 
            this._btnRemoveCookie.Location = new System.Drawing.Point(79, 188);
            this._btnRemoveCookie.Name = "_btnRemoveCookie";
            this._btnRemoveCookie.Size = new System.Drawing.Size(62, 23);
            this._btnRemoveCookie.TabIndex = 138;
            this._btnRemoveCookie.Text = "Remove";
            this._btnRemoveCookie.UseVisualStyleBackColor = true;
            this._btnRemoveCookie.Click += new System.EventHandler(this._btnRemoveCookie_Click);
            // 
            // _btnSaveCookie
            // 
            this._btnSaveCookie.Location = new System.Drawing.Point(21, 188);
            this._btnSaveCookie.Name = "_btnSaveCookie";
            this._btnSaveCookie.Size = new System.Drawing.Size(52, 23);
            this._btnSaveCookie.TabIndex = 137;
            this._btnSaveCookie.Text = "Save";
            this._btnSaveCookie.UseVisualStyleBackColor = true;
            this._btnSaveCookie.Click += new System.EventHandler(this._btnSaveCookie_Click);
            // 
            // _btnAuto
            // 
            this._btnAuto.Location = new System.Drawing.Point(528, 188);
            this._btnAuto.Name = "_btnAuto";
            this._btnAuto.Size = new System.Drawing.Size(62, 23);
            this._btnAuto.TabIndex = 139;
            this._btnAuto.Text = "Populate";
            this._btnAuto.UseVisualStyleBackColor = true;
            this._btnAuto.Click += new System.EventHandler(this._btnAuto_Click);
            // 
            // frmCookie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 481);
            this.Controls.Add(this._btnAuto);
            this.Controls.Add(this._btnRemoveCookie);
            this.Controls.Add(this._btnSaveCookie);
            this.Controls.Add(this._lstCookies);
            this.Controls.Add(this.label21);
            this.Controls.Add(this._txtCookieDomain);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._txtJSONCookie);
            this.Controls.Add(this._btnClear);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSaveJSON);
            this.Controls.Add(this._lblCookieVal);
            this.Controls.Add(this._lblCookieName);
            this.Controls.Add(this._txtCookieValue);
            this.Controls.Add(this._txtCookieName);
            this.Name = "frmCookie";
            this.Text = "frmCookie";
            this.Load += new System.EventHandler(this.frmCookie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _txtJSONCookie;
        private System.Windows.Forms.Button _btnClear;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnSaveJSON;
        private System.Windows.Forms.Label _lblCookieVal;
        private System.Windows.Forms.Label _lblCookieName;
        private System.Windows.Forms.TextBox _txtCookieValue;
        private System.Windows.Forms.TextBox _txtCookieName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox _txtCookieDomain;
        private System.Windows.Forms.ListBox _lstCookies;
        private System.Windows.Forms.Button _btnRemoveCookie;
        private System.Windows.Forms.Button _btnSaveCookie;
        private System.Windows.Forms.Button _btnAuto;
    }
}