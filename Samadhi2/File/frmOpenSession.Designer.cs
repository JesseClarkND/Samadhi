namespace Samadhi2.File
{
    partial class frmOpenSession
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
            this._radEntire = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._radAttack = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._btnFindSession = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._radPartialHistory = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _radEntire
            // 
            this._radEntire.AutoSize = true;
            this._radEntire.Location = new System.Drawing.Point(6, 19);
            this._radEntire.Name = "_radEntire";
            this._radEntire.Size = new System.Drawing.Size(203, 17);
            this._radEntire.TabIndex = 0;
            this._radEntire.TabStop = true;
            this._radEntire.Text = "Load Entire History To Continue Scan";
            this._radEntire.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._radPartialHistory);
            this.groupBox1.Controls.Add(this._radAttack);
            this.groupBox1.Controls.Add(this._radEntire);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 127);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Options";
            // 
            // _radAttack
            // 
            this._radAttack.AutoSize = true;
            this._radAttack.Location = new System.Drawing.Point(6, 87);
            this._radAttack.Name = "_radAttack";
            this._radAttack.Size = new System.Drawing.Size(118, 17);
            this._radAttack.TabIndex = 1;
            this._radAttack.TabStop = true;
            this._radAttack.Text = "Load Attack History";
            this._radAttack.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // _btnFindSession
            // 
            this._btnFindSession.Location = new System.Drawing.Point(12, 13);
            this._btnFindSession.Name = "_btnFindSession";
            this._btnFindSession.Size = new System.Drawing.Size(120, 23);
            this._btnFindSession.TabIndex = 2;
            this._btnFindSession.Text = "Find Session File";
            this._btnFindSession.UseVisualStyleBackColor = true;
            this._btnFindSession.Click += new System.EventHandler(this._btnFindSession_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(18, 230);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 3;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _radPartialHistory
            // 
            this._radPartialHistory.AutoSize = true;
            this._radPartialHistory.Location = new System.Drawing.Point(6, 42);
            this._radPartialHistory.Name = "_radPartialHistory";
            this._radPartialHistory.Size = new System.Drawing.Size(114, 17);
            this._radPartialHistory.TabIndex = 5;
            this._radPartialHistory.TabStop = true;
            this._radPartialHistory.Text = "Load Entire History";
            this._radPartialHistory.UseVisualStyleBackColor = true;
            // 
            // frmOpenSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 265);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnFindSession);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmOpenSession";
            this.Text = "frmOpenSession";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton _radEntire;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button _btnFindSession;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.RadioButton _radAttack;
        private System.Windows.Forms.RadioButton _radPartialHistory;
    }
}