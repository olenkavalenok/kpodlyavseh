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
    public partial class Customer : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения
        public Customer(int id)
        {
            InitializeComponent();

            connection.Open();
            string query = "SELECT Имя FROM Customer WHERE id=" + id;
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
            string query1 = "SELECT id FROM Customer WHERE Имя='" + label1.Text + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            MessageForm messageForm = new MessageForm((int)reader["id"]);
            connection.Close();
            messageForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*connection.Open();
            string query1 = "SELECT Email FROM Customer WHERE Имя='" + label1.Text + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            MessageCustomer messageCustomer = new MessageCustomer(reader["Email"].ToString());
            messageCustomer.Show();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query1 = "SELECT id FROM Customer WHERE Имя='" + label1.Text + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            ChangeDataCustomer cdc = new ChangeDataCustomer((int)reader["id"]);
            connection.Close();
            cdc.Show();
        }

        public bool madeRequest()
        {
            connection.Open(); // открываем соединение
            string query2 = "DELETE * FROM Request";
            OleDbCommand dbCommand = new OleDbCommand(query2, connection); // команда
            dbCommand.ExecuteNonQuery();
            string query3 = "INSERT INTO Request SELECT Products.Название, Products.Цена, Products.Количество FROM Products"; // строка запроса
            OleDbCommand dbCommand1 = new OleDbCommand(query3, connection); // команда   
            dbCommand1.ExecuteNonQuery();
            /*if (dbCommand1.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошибка выполнения запроса");
                connection.Close();
                return false;
            }
            else
            {*/
                MessageBox.Show("Заказ отправлен!");
                connection.Close();
                return true;
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*connection.Open(); // открываем соединение
            string query2 = "DELETE * FROM Request";
            OleDbCommand dbCommand = new OleDbCommand(query2, connection); // команда
            dbCommand.ExecuteNonQuery();
            string query3 = "INSERT INTO Request SELECT Products.Название, Products.Цена, Products.Количество FROM Products"; // строка запроса
            OleDbCommand dbCommand1 = new OleDbCommand(query3, connection); // команда   

            if (dbCommand1.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса");
            else
                MessageBox.Show("Заказ отправлен!");

            connection.Close();*/
            madeRequest();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*connection.Open();
            string query1 = "SELECT Email FROM Provider WHERE Имя='" + label1.Text + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            MessageProvider messageProvider = new MessageProvider(reader["Email"].ToString());
            messageProvider.Show();*/

            connection.Open();
            string query1 = "SELECT Email FROM Customer WHERE Имя='" + label1.Text + "'";
            OleDbCommand dbcom = new OleDbCommand(query1);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            MessageProvider messageProvider = new MessageProvider(reader["Email"].ToString());
            messageProvider.Show();
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Введены не все данные!");
                return;
            }

            string name_product = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string price_product = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string product_demand = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string product_last_demand = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string product_count = dataGridView1.Rows[index].Cells[4].Value.ToString();

            OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения
            cn.Open(); // открываем соединение
            string query = "INSERT INTO Products VALUES ('" + name_product + "', " + price_product + ", " + product_demand + ", " + product_last_demand + ", " + product_count + ")"; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, cn); // команда   

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса");
            else
                MessageBox.Show("Данные успешно добавлены");

            cn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Введены не все данные!");
                return;
            }

            string product_count = dataGridView1.Rows[index].Cells[4].Value.ToString();

            OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения
            cn.Open(); // открываем соединение
            string query = "DELETE FROM Products WHERE Количество=" + product_count; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, cn); // команда   

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса");
            else
                MessageBox.Show("Данные успешно удалены");

            cn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null)
            {
                MessageBox.Show("Введены не все данные!");
                return;
            }

            string name_product = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string price_product = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string product_demand = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string product_last_demand = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string product_count = dataGridView1.Rows[index].Cells[4].Value.ToString();

            connection.Open(); // открываем соединение
            string query = "UPDATE Products SET Цена=" + price_product + ", [Спрос за текущий месяц]=" + product_demand + ", [Спрос за прошедший месяц]=" + product_last_demand + ", Количество=" + product_count + " WHERE Название='" + name_product + "'"; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, connection); // команда   
            //dbCommand.Connection = connection;

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса");
            else
                MessageBox.Show("Данные успешно изменены");

            connection.Close();
        }
    }
}
