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
    public partial class MessageFormProvider : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения

        public MessageFormProvider(int id)
        {
            InitializeComponent();

            connection.Open();
            string query = "SELECT * FROM Provider WHERE id=" + id;
            OleDbCommand dbcom = new OleDbCommand(query);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            this.id = (int)reader["id"];
            connection.Close();
        }

        public bool sendMessageProvider(string adresat, string message)
        {
            connection.Open();
            string query = "SELECT * FROM Provider WHERE id=" + id;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string adr = this.textBox2.Text;
            string mess = this.textBox1.Text;

            sendMessageProvider(adr, mess);
        }

        private void MessageFormProvider_Load(object sender, EventArgs e)
        {

        }
    }
}
