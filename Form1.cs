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
using BankApp.Properties;

namespace BankApp
{
    public partial class Form1 : Form
    {
        string abal;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=COMPAQ-CQ40;Initial Catalog=bank;Integrated Security=True");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT balance FROM    bankdetails WHERE  balance= (SELECT MIN(balance)  FROM bankdetails); ", con);
            abal = (string)cmd1.ExecuteScalar();
            int bal = int.Parse(abal);
            bal = bal - int.Parse(textBox3.Text);
            string sql = "insert into bankdetails(accountid,accountname,amount,balance) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + bal + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Transferred Successfully....Avl bal: " + bal);
            }
            else
            {
                MessageBox.Show("Error");
            }
            cmd.Dispose();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 acc = new Form2();
            acc.Show();
        }
    }
}
