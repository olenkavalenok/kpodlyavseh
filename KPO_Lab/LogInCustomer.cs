using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace KPO_Lab
{
    public partial class LogInCustomer : Form
    {
        string connection = "Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""; // строка соединения

        public LogInCustomer()
        {
            InitializeComponent();
        }

        public bool Login_Password(string login, string password)
        {
            OleDbConnection dbase = new OleDbConnection(connection);
            dbase.Open();

            string query = "SELECT * FROM Customer WHERE Логин='" + login + "' AND Пароль='" + password + "'";
            OleDbCommand dbcom = new OleDbCommand(query);
            dbcom.Connection = dbase;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            if (reader.HasRows == false)
            {
                dbase.Close();
                return false;
            }
            else
            {
                dbase.Close();
                return true;
            }      
        }

        public void LogInCustomer_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click1(object sender, EventArgs e)
        {
            string log = textBox1.Text;
            string pas = textBox2.Text;

            OleDbConnection dbase = new OleDbConnection(connection);
            dbase.Open();
            string query1 = "SELECT id FROM Customer WHERE Логин='" + log + "' AND Пароль='" + pas + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = dbase;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            if (Login_Password(log, pas))
            {
                Customer customer = new Customer((int)reader["id"]);
                customer.Show();
                this.Hide();
            }
        }
    }
}
