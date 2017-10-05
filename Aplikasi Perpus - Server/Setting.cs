using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplikasi_Perpus___Server
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        //membuat drop shadow pada form
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void simpan_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["connectionString"] = db.Text;
            Properties.Settings.Default["ipServer"] = ip.Text;
            Properties.Settings.Default["defaultPath"] = path.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                path.Text = fd.SelectedPath;
            }            
        }

        private void batal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            path.Text = Properties.Settings.Default.defaultPath;
            ip.Text = Properties.Settings.Default.ipServer;
            db.Text = Properties.Settings.Default.connectionString;
        }
    }
}
