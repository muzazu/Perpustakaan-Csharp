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
    public partial class Form1 : Form
    {
        //variables
        bool sub = false;
        public Form1()
        {
            InitializeComponent();
            foreach (Control c in konten.Controls)
                c.Hide();
            foreach (Control b in submenu.Controls)
            {
                Button btn = (Button)b;
                btn.FlatAppearance.BorderSize = 0;
            }
            submenu.Hide();
        }

        private void content_load()
        {
            foreach (Control c in konten.Controls)
                c.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            #region style
            WindowState = FormWindowState.Maximized;
            control.Width = Width + 3;
            konten.Width = Width;
            submenu.Width = Width;
            btn_akun.Location = new Point(Width - btn_akun.Width + 3, 0);
            btn_akun.FlatAppearance.BorderSize = 0;
            search.Location = new Point((Width - search.Width) - 10, search.Location.Y);
            #endregion  
            //var
            int i = 0,count = 0;
            DB.query("select * from db_buku limit 15","result","buku");
            int batas = DB.dt.Rows.Count;
            foreach(Control c in konten.Controls)
            {
                if (i == batas)
                    break;
                c.Show();
                count = 0;
                foreach(Control item in c.Controls)
                {
                    if (item is Label)
                    {
                        if (count == 0)
                            item.Text = Convert.ToString(DB.dt.Rows[i]["deskripsi"]);
                        else
                            item.Text = Convert.ToString(DB.dt.Rows[i]["judul"]);
                    }
                    else if (item is Button)
                    {
                        Button btn = (Button)item;
                        btn.Tag = Convert.ToString(DB.dt.Rows[i]["id"]);
                        btn.Click += new EventHandler(pinjam);
                    }
                    count++;
                }

                i++;
            }

            login lgn = new login();
            lgn.ShowDialog();
        }

        private void pinjam(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(session.userId))
            {
                if (MessageBox.Show("Yakin Meminjam Buku Ini ?",
                   "Pinjam ?", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, 0, false)
                   == DialogResult.Yes)
                {
                    Button btn = (Button)sender;
                    DB.query("INSERT into db_pinjam (idbuku,iduser,waktu_pinjam,status)" +
                          " VALUES('" + btn.Tag + "','" + session.userId + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "',1)", "insert");
                }
            }
            else
            {
                login lgn = new login();
                lgn.ShowDialog();
            }
        }

        private void btn_akun_Click(object sender, EventArgs e)
        {
            if (!sub)
            {
                sub = true;
                submenu.Show();
            }
            else
            {
                sub = false;
                submenu.Hide();
            }
        }

        private void cari_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                DB.query("select * from db_buku limit 15", "result", "buku");
            }
            else
            {
                DB.query("select * from db_buku where"
                    + " judul like '%" + textBox1.Text + "%'"
                    + " or kategori like '%" + textBox1.Text + "%'"
                    + " or deskripsi like '%" + textBox1.Text + "%'"
                    + " limit 15", "result", "buku");
            }
            content_load();
            int batas = DB.dt.Rows.Count;
            int i = 0, count = 0;
            foreach (Control c in konten.Controls)
            {
                if (i == batas)
                    break;
                c.Show();
                count = 0;
                foreach (Control item in c.Controls)
                {
                    if (item is Label)
                    {
                        if (count == 0)
                            item.Text = Convert.ToString(DB.dt.Rows[i]["deskripsi"]);
                        else
                            item.Text = Convert.ToString(DB.dt.Rows[i]["judul"]);
                    }
                    else if (item is Button)
                    {
                        Button btn = (Button)item;
                        btn.Tag = Convert.ToString(DB.dt.Rows[i]["id"]);
                        btn.Click += new EventHandler(pinjam);
                    }
                    count++;
                }
                i++;
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(session.userId))
            {
                session.userId = null;
                submenu.Hide();
                login lgn = new login();
                lgn.ShowDialog();
            }
        }

        private void riwayat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(session.userId))
            {
                Riwayat rw = new Riwayat(session.userId);
                rw.ShowDialog();
            }
        }

        private void akunku_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(session.userId))
            {
                Edit rw = new Edit(session.userId);
                rw.ShowDialog();
            }
        }
    }
}
