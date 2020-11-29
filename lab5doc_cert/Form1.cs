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
    public partial class Form1 : Form
    {
        public static string Connect = "Server=localhost;Database=medical2;user=root;password=123123;charset=utf8";
        public MySqlConnection con = new MySqlConnection(Connect);
        public static int rights;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 secondform = new Form2();
            secondform.Show();
            secondform.FormClosing += new FormClosingEventHandler(f2_FormClosing); //подписываемся на событие
        }

        void f2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rights == 0)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 thirdform = new Form3();
            thirdform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 fourthform = new Form4();
            fourthform.Show();
        }
    }
}
