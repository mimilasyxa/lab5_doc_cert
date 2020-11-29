using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace lab5doc_cert
{
    public partial class Form4 : Form
    {
        public static int[] ids = new int[10];
        public static string Connect = "Server=localhost;Database=medical2;user=root;password=123123;charset=utf8";
        public MySqlConnection con = new MySqlConnection(Connect);
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            listBox1.Items.Clear();
            string sql = string.Format("select * from worker where lname like '%{0}%' and fname like '%{1}%' " +
                " and mname like '%{2}%' and position like '%{3}%'", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ids[counter] = Convert.ToInt32(dataReader["id_worker"]);
                    counter++;
                    listBox1.Items.Add(dataReader["lname"].ToString() + " " + dataReader["fname"].ToString() + " " + dataReader["mname"].ToString() + " " + dataReader["position"].ToString());
                }
            }
            dataReader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = string.Format("delete from worker where id_worker = {0}", ids[listBox1.SelectedIndex]);
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Удаление прошлоу успешно", "Удаление прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("Не выбран сотрудник", "Ошибка");

                }
            }
        }
    }
}
