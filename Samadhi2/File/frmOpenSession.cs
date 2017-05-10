using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samadhi2.File
{
    public partial class frmOpenSession : Form
    {
        public string FileName { get; set; }
        public LoadType LoadSessionType { get; set; }
        public frmOpenSession()
        {
            InitializeComponent();
        }

        private void _btnFindSession_Click(object sender, EventArgs e)
        {
            if (_radEntire.Checked)
                LoadSessionType = LoadType.Full;
            if (_radPartialHistory.Checked)
                LoadSessionType = LoadType.History;
            if (_radAttack.Checked)
                LoadSessionType = LoadType.Attack;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public enum LoadType
        {
            Full,
            Attack,
            History
        }
    }
}