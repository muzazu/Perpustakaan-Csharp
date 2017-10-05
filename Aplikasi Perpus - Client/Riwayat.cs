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
    public partial class Riwayat : Form
    {
        int ids;
        public Riwayat(string id)
        {
            InitializeComponent();
            ids = Convert.ToInt16(id);
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

        private void Riwayat_Load(object sender, EventArgs e)
        {
            DB.query("select b.judul as NAMA,a.waktu_pinjam as 'Waktu Pinjam',a.waktu_kembali as 'Waktu Kembali',a.status from db_pinjam a, db_buku b where iduser = " + ids + " and a.idbuku = b.id", "result", "users", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
