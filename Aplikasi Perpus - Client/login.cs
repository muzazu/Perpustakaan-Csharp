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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
            panel2.Show();
            panel1.Hide();
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

        private void label2_Click(object sender, EventArgs e)
        {
            if(go.Text == "Login")
            {
                go.Text = "Register";
                panel1.Show();
                panel2.Hide();
                label2.Text = "Sudah punya akun ? Login";
                judul.Text = "REGISTER PERPUS";
            }
            else
            {
                go.Text = "Login";
                panel2.Show();
                panel1.Hide();
                label2.Text = "Belum punya akun ? Register disini";
                judul.Text = "LOGIN PERPUS";
            }
        }

        private void go_Click(object sender, EventArgs e)
        {
            if(go.Text == "Login")
            {
                string ps = DB.CreateMD5(pass.Text);
                string un = uname.Text;
                DB.query("select count(username) as total, id from users where username = '"+un+"' and pass = '"+ps+"'","result","login");
                if(Convert.ToInt16(DB.dt.Rows[0]["total"]) > 0)
                {
                    session.userId = Convert.ToString(DB.dt.Rows[0]["id"]);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username atau Password Salah");
                }
            }
            else
            {
                string ps = DB.CreateMD5(textBox3.Text);
                DB.query("INSERT into users (nama,username,pass,ttl,alamat)" +
                    " VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + ps + "','" + textBox4.Text + "','" + textBox5.Text + "')", "insert");
            }
        }
    }
}
