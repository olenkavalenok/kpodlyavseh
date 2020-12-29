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
    public partial class MessageForm : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения

        public MessageForm(int id)
        {
            InitializeComponent();

            connection.Open();
            string query = "SELECT * FROM Customer WHERE id=" + id;
            OleDbCommand dbcom = new OleDbCommand(query);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            this.id = (int)reader["id"];
            connection.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public bool sendMessage(string adresat, string message) 
        {
            connection.Open();
            string query = "SELECT * FROM Customer WHERE id=" + id;
            OleDbCommand dbcom = new OleDbCommand(query);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();
            string adresant = reader["Email"].ToString();

            string query1 = "INSERT INTO Message VALUES ('" + adresant + "', '" + adresat + "', '" + message + "')"; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query1, connection); // команда   

            if (dbCommand.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошибка выполнения запроса");
                connection.Close();
                return false;
            }
            else
            {
                MessageBox.Show("Сообщение отправлено");
                connection.Close();
                return true;
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {

            string adr = this.textBox1.Text;
            string mess = this.textBox2.Text;

            sendMessage(adr, mess);
            /*connection.Open();
            string query = "SELECT * FROM Customer WHERE id=" + id;
            OleDbCommand dbcom = new OleDbCommand(query);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();
            string adresant = reader["Email"].ToString();

            string query1 = "INSERT INTO Message VALUES ('" + adresant + "', '" + adresat + "', '" + message + "')"; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query1, connection); // команда   

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса");
            else
                MessageBox.Show("Сообщение отправлено");
            connection.Close();*/
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
