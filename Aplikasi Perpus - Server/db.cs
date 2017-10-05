using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Text;

namespace Aplikasi_Perpus___Server
{
    class DB
    {
        public static DataTable dt = new DataTable();
        private readonly static MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.connectionString);
        //Get, Update dan Insert Query
        public static void query(string command,string tipe, String tableName = null, DataGridView ls = null)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    if (tipe == "insert" || tipe == "update" || tipe == "delete")
                    {
                        int rows = cmd.ExecuteNonQuery(); // Gets the count of affected rows
                        if (rows > 0)
                            MessageBox.Show("Berhasil " + tipe + " Data");
                        else
                            MessageBox.Show("Gagal " + tipe + " Data");
                    }
                    else if(tipe == "result")
                    {
                        using (MySqlDataAdapter ra = new MySqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            ra.Fill(ds,tableName);
                            dt = ds.Tables[tableName];
                        }
                        if (ls != null)
                            ls.DataSource = dt;
                    }
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
