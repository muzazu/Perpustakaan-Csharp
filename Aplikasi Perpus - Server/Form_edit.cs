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
    public partial class Form_edit : Form
    {
        private string table,query;
        private int ids;
        public Form_edit(string t, string id = null)
        {
            InitializeComponent();

            //mengglobalkan variable constructor
            table = t;
            if (id != null)
                ids = int.Parse(id);

            if (t == "users")
            {
                query = "edit";
                label1.Text = label1.Text + " User";
                panel3.Hide();
                panel2.Show();
                panel2.Dock = DockStyle.Fill;
                DB.query("select nama,username,ttl,alamat from users where id = "+id+" limit 1","result","edit");
                user1.Text = Convert.ToString(DB.dt.Rows[0]["nama"]);
                user2.Text = Convert.ToString(DB.dt.Rows[0]["username"]);
                user3.Text = Convert.ToString(DB.dt.Rows[0]["ttl"]);
                user4.Text = Convert.ToString(DB.dt.Rows[0]["alamat"]);
            }
            else if(id != null && t == "db_buku")
            {
                query = "edit";
                label1.Text = label1.Text + " Buku";
                panel2.Hide();
                panel3.Show();
                panel3.Dock = DockStyle.Fill;
                DB.query("select judul,stok,posisi,deskripsi,published,kategori from db_buku where id = " + id + " limit 1", "result", "edit");
                judul.Text = Convert.ToString(DB.dt.Rows[0]["judul"]);
                stok.Text = Convert.ToString(DB.dt.Rows[0]["stok"]);
                posisi.Text = Convert.ToString(DB.dt.Rows[0]["posisi"]);
                deskripsi.Text = Convert.ToString(DB.dt.Rows[0]["deskripsi"]);
                kategori.Text = Convert.ToString(DB.dt.Rows[0]["kategori"]);
                DateTime result;
                if (DateTime.TryParseExact(Convert.ToString(DB.dt.Rows[0]["published"]), "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
                {
                    tahun.Value = result;
                }
            }
            else if(id == null && t == "db_buku")
            {
                query = "add";
                label1.Text = "Tambahkan Buku";
                panel2.Hide();
                panel3.Show();
                panel3.Dock = DockStyle.Fill;
            }
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

        private void batal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog gambar = new OpenFileDialog();
            gambar.Filter = "Image Files(*.png, *.jpg) | *.png; *.jpg";
            if (gambar.ShowDialog() == DialogResult.OK)
            {
                Upload.copy(gambar.FileName);
                pictureBox1.ImageLocation = "http://localhost/perpus_csharp/"+ System.IO.Path.GetFileName(gambar.FileName);
            }
        }*/

        private void simpan_Click(object sender, EventArgs e)
        {
            if (table == "users" && query == "edit")
            {
                DB.query("UPDATE users SET" +
                    " nama = '" + user1.Text + "'," +
                    " username = '" + user2.Text + "'," +
                    " ttl = '" + user3.Text + "'," +
                    " alamat = '" + user4.Text + "'" +
                    " WHERE id ='" + ids + "'", "update");
            }
            else if (table == "db_buku" && query == "edit")
            {
                string thn = tahun.Value.Date.ToString("yyyy-MM-dd");
                DB.query("UPDATE db_buku SET" +
                    " judul = '" + judul.Text + "'," +
                    " stok = '" + stok.Text + "'," +
                    " posisi = '" + posisi.Text + "'," +
                    " deskripsi = '" + deskripsi.Text + "'," +
                    " kategori = '" + kategori.Text + "'," +
                    " published = '"+thn+"'" +
                    " WHERE id ='" + ids + "'", "update");
            }
            else if (table == "db_buku" && query == "add")
            {
                string thn = tahun.Value.Date.ToString("yyyy-MM-dd");
                DB.query("INSERT into db_buku (judul,stok,posisi,deskripsi,kategori,published)" +
                    " VALUES('"+judul.Text+ "','" + stok.Text + "','" + posisi.Text + "','" + deskripsi.Text + "','" + kategori.Text + "','" + thn + "')", "insert");
            }
            this.Close();
        }
    }
}
