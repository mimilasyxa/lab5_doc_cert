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
    public partial class Form2 : Form
    {

        public static string Connect = "Server=localhost;Database=medical2;user=root;password=123123;charset=utf8";
        public MySqlConnection con = new MySqlConnection(Connect);
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from worker where email = '{0}' AND password = '{1}'", textBox1.Text, textBox2.Text);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Form1.rights= Convert.ToInt32(dataReader["access_lvl"]);  
                }
            }
            dataReader.Close();
            this.Close();
        }
    }
}
