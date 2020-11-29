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
    public partial class Form3 : Form
    {
        public static string Connect = "Server=localhost;Database=medical2;user=root;password=123123;charset=utf8";
        public MySqlConnection con = new MySqlConnection(Connect);
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("insert into worker(lname, fname, mname, position, email, password, access_lvl) " +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, (comboBox1.SelectedIndex + 1));
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Добавление прошло успешно", "Добавление прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show(" ", "Ошибка");

                }
            }
        }
    }
}
