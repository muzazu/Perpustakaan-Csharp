using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplikasi_Perpus___Client
{
    public partial class Edit : Form
    {
        int ids;
        public Edit(string id)
        {
            InitializeComponent();
            ids = int.Parse(id);
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

        private void Edit_Load(object sender, EventArgs e)
        {
            DB.query("select nama,username,pass,ttl,alamat from users where id =" + ids,"result","edit");
            textBox1.Text = Convert.ToString(DB.dt.Rows[0]["nama"]);
            textBox2.Text = Convert.ToString(DB.dt.Rows[0]["username"]);
            textBox3.Text = Convert.ToString(DB.dt.Rows[0]["pass"]);
            textBox4.Text = Convert.ToString(DB.dt.Rows[0]["ttl"]);
            textBox5.Text = Convert.ToString(DB.dt.Rows[0]["alamat"]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ps = DB.CreateMD5(textBox3.Text);
            DB.query("UPDATE users SET" +
                " nama = '" + textBox1.Text + "'," +
                " username = '" + textBox2.Text + "'," +
                " pass = '" + ps + "'," +
                " ttl = '" + textBox4.Text + "'," +
                " alamat = '" + textBox5.Text + "'" +
                " WHERE id ='" + ids + "'", "update");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
