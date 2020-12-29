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
    public partial class LogInProvider : Form
    {
        string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""; // строка соединения

        public LogInProvider()
        {
            InitializeComponent();
        }

        public bool Login_Password(String login, String password)
        {

            OleDbConnection dbase = new OleDbConnection(connection);
            dbase.Open();

            string query = "SELECT * FROM Provider WHERE Логин='" + login + "' AND Пароль='" + password + "'";
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
        private void button1_Click(object sender, EventArgs e)
        {
            string log = textBox1.Text;
            string pas = textBox2.Text;

            OleDbConnection dbase = new OleDbConnection(connection);
            dbase.Open();
            string query1 = "SELECT id FROM Provider WHERE Логин='" + log + "' AND Пароль='" + pas + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = dbase;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            if (Login_Password(log, pas))
            {
                Provider provider = new Provider((int)reader["id"]);
                provider.Show();
                this.Hide();
            }
        }

        private void LogInProvider_Load(object sender, EventArgs e)
        {

        }
    }
}
