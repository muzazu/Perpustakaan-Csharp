using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Globalization;

namespace Aplikasi_Perpus___Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //style 
            control.Location = new Point(Width-control.Width+13,0);
            exit.FlatAppearance.BorderSize = 0;
            min.FlatAppearance.BorderSize = 0;
            show.Hide();
            show.Location = new Point(0, 0);
            show.FlatAppearance.BorderSize = 0;
            show.BackColor = Color.LightGray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region form1_style
            WindowState = FormWindowState.Maximized;
            menus();
            konten_load();
            konten_reposition();
            panel4.Height = Height - (chart1.Height + 100);
            dataGridView3.Height = panel4.Height - 80;
            #endregion
            //list user
            DB.query("select * from users limit " + nextCount + "," + limit, "result", "users", dataGridView1);
            //list buku
            DB.query("select * from db_buku limit " + next1Count + "," + limit1, "result", "buku", dataGridView2);
            //status pinjam
            DB.query("select a.id,b.judul,c.nama,a.waktu_pinjam from db_pinjam a, db_buku b, users c where b.id = a.idbuku and c.id = a.iduser and status = 1", "result", "pinjam", dataGridView3);
            DB.query("select count(*) as total from users", "result", "count");
            total = Convert.ToInt64(DB.dt.Rows[0]["total"]);
            text_tot.Text = total.ToString();
            DB.query("select count(*) as total from db_buku", "result", "count");
            total1 = Convert.ToInt64(DB.dt.Rows[0]["total"]);
            text_buku.Text = total1.ToString();
            count();

            //chart
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            for (int x = 1; x <= 12; x++)
            {
                getchart(x);
            }
        }
        #region chart
        private void getchart(int month)
        {
            try
            {
                DB.query("select count(*) as total from db_pinjam where MONTH(waktu_pinjam) = " + month, "result", "chart");
                chart1.Series[0].Points.AddXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), Convert.ToInt64(DB.dt.Rows[0]["total"]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region menu
        int defaultSize = 291;
        private void menus()
        {
            //variables
            int i = 152;
            Color dasar = ColorTranslator.FromHtml("#3498db");
            Color dasar1 = ColorTranslator.FromHtml("#2980b9");
            Color c1 = ColorTranslator.FromHtml("#2d74a5");
            Color c2 = ColorTranslator.FromHtml("#66b3e8");

            menu.Height = this.Height;
            menu.Location = new Point(0, 0);
            menu.BackColor = dasar1;
            foreach (Control btn in menu.Controls)
            {
                if (btn is Button)
                {
                    Button bt = (Button)btn;
                    bt.Location = new Point(0, i);
                    bt.Height = 50;
                    bt.FlatAppearance.BorderSize = 0;
                    bt.ForeColor = Color.White;
                    bt.BackColor = dasar;
                    bt.TextAlign = ContentAlignment.MiddleLeft;
                    bt.Padding = new Padding(25, 0, 0, 0);
                    bt.Click += new EventHandler(this.btnSelect);
                    i = i + bt.Height + 1;
                }
                else
                {
                    foreach (Control btn2 in btn.Controls)
                    {
                        Button bt2 = (Button)btn2;
                        bt2.FlatAppearance.BorderSize = 0;
                        bt2.BackColor = c1;
                        bt2.ForeColor = Color.White;
                    }
                }
            }
            menuBottom.Location = new Point(0, Height - menuBottom.Height + 2);
        }
        private void btnSelect(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            konten_reload();
            foreach (Control pnl in konten.Controls)
            {
                if (pnl is Panel)
                {
                    Panel pn = (Panel)pnl;
                    if (pn.Name == Convert.ToString(btn.Tag))
                        pn.Show();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            show.Show();
            menu.Hide();
            menu.Width = 0;
            konten.Width = Width;
            konten.Location = new Point(0, konten.Location.Y);
            konten_reposition();
        }

        private void show_Click(object sender, EventArgs e)
        {
            show.Hide();
            menu.Show();
            menu.Width = defaultSize;
            konten.Width = Width - defaultSize - 10;
            konten.Location = new Point(defaultSize + 10, konten.Location.Y);
            konten_reposition();
        }
        //setting button
        private void button5_Click(object sender, EventArgs e)
        {
            Setting st = new Setting();
            st.ShowDialog();
        }
        #endregion

        #region konten
        private void konten_load()
        {
            konten.Width = this.Width - menu.Width;
            foreach (Control pnl in konten.Controls)
            {
                if (pnl is Panel)
                {
                    Panel pn = (Panel)pnl;
                    pn.Dock = DockStyle.Fill;
                    if (pn.Name == "panel1")
                        pn.Show();
                    else
                        pn.Hide();
                }
            }
        }
        private void konten_reload()
        {
            foreach (Control pnl in konten.Controls)
            {
                if (pnl is Panel)
                {
                    Panel pn = (Panel)pnl;
                    pn.Hide();
                }
            }
        }
        private void konten_reposition()
        {
            dataGridView1.Width = konten.Width;
            dataGridView1.Height = Height - 200;
            dataGridView1.Location = new Point(dataGridView1.Location.X, filters.Location.Y + filters.Height + 20);
            controls.Location = new Point(0, 20);
            filters.Location = new Point((konten.Width - filters.Width) - 10, 20);
            navigation.Width = konten.Width - 10;
            navigation.Location = new Point(dataGridView1.Location.X, Height - navigation.Height - 40);
            before.Location = new Point(0, 0);
            next.Location = new Point(navigation.Width - next.Width - 10, 0);
            //buku
            dataGridView2.Width = konten.Width - 10;
            dataGridView2.Height = Height - 200;
            dataGridView2.Location = new Point(dataGridView2.Location.X, filters1.Location.Y + filters1.Height + 20);
            controls1.Location = new Point(0, 20);
            filters1.Location = new Point((konten.Width - filters1.Width) - 10, 20);
            navigation1.Width = konten.Width - 10;
            navigation1.Location = new Point(dataGridView2.Location.X, Height - navigation1.Height - 40);
            before1.Location = new Point(0, 0);
            next1.Location = new Point(navigation1.Width - next1.Width - 10, 0);
        }
        #endregion

        #region control
        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region datagridview1-CRUD
        //variables
        int nextCount = 0;
        int limit = 5;
        Int64 total;
        private void count()
        {
            if (nextCount == 0)
            {
                before.Enabled = false;
                next.Enabled = true;
            }
            else if (nextCount >= total - limit)
            {
                next.Enabled = false;
                before.Enabled = true;
            }
            else
            {
                before.Enabled = true;
                next.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                nextCount = 0;
                DB.query("select * from users limit  0," + limit, "result", "users", dataGridView1);
            }
            else
            {
                string c = textBox1.Text;
                DB.query("select * from users where id like '%" + c + "%'" +
                    " or username like '%" + c + "%'" +
                    " or nama like '%" + c + "%'" +
                    " or ttl like '%" + c + "%'" +
                    " or alamat like '%" + c + "%'", "result", "users", dataGridView1);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            nextCount = nextCount + limit - 1;
            DB.query("select * from users limit " + nextCount + "," + limit, "result", "users", dataGridView1);
            count();
        }

        private void before_Click(object sender, EventArgs e)
        {
            nextCount = nextCount - limit + 1;
            DB.query("select * from users limit  " + nextCount + "," + limit, "result", "users", dataGridView1);
            count();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limit = Convert.ToInt16(comboBox1.Text);
            nextCount = 0;
            DB.query("select * from users limit 0," + limit, "result", "users", dataGridView1);
            count();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                if (MessageBox.Show("Anda yakin menghapus record ini ?",
                   "Delete Warning", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false)
                   == DialogResult.Yes)
                {
                    int id = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                    DB.query("delete from users where id = " + id, "delete");
                    nextCount = 0;
                    DB.query("select * from users limit 0," + limit, "result", "users", dataGridView1);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                string id = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                Form_edit edit = new Form_edit("users", id);
                edit.Closed += delegate
                {
                    DB.query("select * from users limit " + limit, "result", "users", dataGridView1);
                };
                edit.ShowDialog();
            }
        }
        #endregion

        #region datagridview2-CRUD
        //variables
        int next1Count = 0;
        int limit1 = 5;
        Int64 total1;
        private void count1()
        {
            if (next1Count == 0)
            {
                before1.Enabled = false;
                next1.Enabled = true;
            }
            else if (next1Count >= total1 - limit1)
            {
                next1.Enabled = false;
                before1.Enabled = true;
            }
            else
            {
                before1.Enabled = true;
                next1.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                next1Count = 0;
                DB.query("select * from db_buku limit 0," + limit1, "result", "db_buku", dataGridView2);
            }
            else
            {
                string c = textBox2.Text;
                DB.query("select * from db_buku where id like '%" + c + "%'" +
                    " or judul like '%" + c + "%'" +
                    " or kategori like '%" + c + "%'" +
                    " or published like '%" + c + "%'" +
                    " or deskripsi like '%" + c + "%'", "result", "db_buku", dataGridView2);
            }
        }

        private void next1_Click(object sender, EventArgs e)
        {
            next1Count = next1Count + limit1 - 1;
            DB.query("select * from db_buku limit " + next1Count + "," + limit1, "result", "db_buku", dataGridView2);
            count1();
        }

        private void before1_Click(object sender, EventArgs e)
        {
            next1Count = next1Count - limit1 + 1;
            DB.query("select * from db_buku limit " + next1Count + "," + limit1, "result", "db_buku", dataGridView2);
            count1();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            limit1 = Convert.ToInt16(comboBox1.Text);
            next1Count = 0;
            DB.query("select * from db_buku limit 0," + limit1, "result", "db_buku", dataGridView2);
            count1();
        }

        private void delete1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count != 0)
            {
                if (MessageBox.Show("Anda yakin menghapus record ini ?",
                   "delete1 Warning", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false)
                   == DialogResult.Yes)
                {
                    int id = Convert.ToInt16(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value);
                    DB.query("delete1 from db_buku where id = " + id, "delete1");
                    next1Count = 0;
                    DB.query("select * from db_buku limit 0," + limit1, "result", "db_buku", dataGridView2);
                }
            }
        }

        private void edit1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count != 0)
            {
                string id = Convert.ToString(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value);
                Form_edit edit1 = new Form_edit("db_buku", id);
                edit1.Closed += delegate
                {
                    DB.query("select * from db_buku limit 0," + limit1, "result", "db_buku", dataGridView2);
                };
                edit1.ShowDialog();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            Form_edit edit1 = new Form_edit("db_buku");
            edit1.Closed += delegate
            {
                DB.query("select * from db_buku limit 0," + limit1, "result", "db_buku", dataGridView2);
            };
            edit1.ShowDialog();
        }
        #endregion

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 id = Convert.ToInt64(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value);
                MessageBox.Show(Convert.ToString(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[3].Value));
                DateTime date1 = Convert.ToDateTime(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[3].Value);
                DB.query("update db_pinjam set waktu_kembali = '" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "',status = 0 where id = " + id, "update");
                if ((DateTime.Now.Date - date1.Date).TotalDays > 7)
                {
                    MessageBox.Show("User ini terkena denda pengembalian - " + Rupiah.ToRupiah(10000));
                }

                DB.query("select a.id,b.judul,c.nama,a.waktu_pinjam from db_pinjam a, db_buku b, users c where b.id = a.idbuku and c.id = a.iduser and status = 1", "result", "pinjam", dataGridView3);
            }
            catch
            {
                MessageBox.Show("Ada kesalahan dalam memproses permintaan Anda!");
            }
        }
    }   
}
