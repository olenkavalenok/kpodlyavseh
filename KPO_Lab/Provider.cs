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
    public partial class Provider : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения
        public Provider(int id)
        {
            InitializeComponent();

            connection.Open();
            string query = "SELECT Имя FROM Provider WHERE id=" + id;
            OleDbCommand dbcom = new OleDbCommand(query);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            this.label1.Text = reader["Имя"].ToString();
            connection.Close();

            dataGridView1.Rows.Clear();
            connection.Open(); // открываем соединение
            string query1 = "SELECT * FROM Products"; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query1, connection); // команда
            OleDbDataReader dbReader = dbCommand.ExecuteReader(); // считываем данные

            if (dbReader.HasRows == false)
                MessageBox.Show("Ошибка");
            else
                while (dbReader.Read())
                    dataGridView1.Rows.Add(dbReader["Название"], dbReader["Цена"], dbReader["Спрос за текущий месяц"], dbReader["Спрос за прошедший месяц"], dbReader["Количество"]);

            dbReader.Close();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query1 = "SELECT Email FROM Provider WHERE Имя='" + label1.Text + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            MessageCustomer messageCustomer = new MessageCustomer(reader["Email"].ToString());
            messageCustomer.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Request request = new Request();
            request.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query1 = "SELECT id FROM Provider WHERE Имя='" + label1.Text + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            ChangeDataProvider cdc = new ChangeDataProvider((int)reader["id"]);
            connection.Close();
            cdc.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query1 = "SELECT id FROM Provider WHERE Имя='" + label1.Text + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            MessageFormProvider messageFormProvider = new MessageFormProvider((int)reader["id"]);
            connection.Close();
            messageFormProvider.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*MessageProvider mp = new MessageProvider();
            mp.Show();*/

            /*connection.Open();
            string query1 = "SELECT Email FROM Provider WHERE Имя='" + label1.Text + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            MessageProvider messageProvider = new MessageProvider(reader["Email"].ToString());
            messageProvider.Show();*/
        }
    }
}
