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
    public partial class ChangeDataCustomer : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения
        
        public ChangeDataCustomer(int id)
        {
            InitializeComponent();

            connection.Open();
            string query = "SELECT * FROM Customer WHERE id=" + id;
            OleDbCommand dbcom = new OleDbCommand(query);
            dbcom.Connection = connection;
            OleDbDataReader reader = dbcom.ExecuteReader();
            reader.Read();

            this.textBox1.Text = reader["Имя"].ToString();
            this.textBox2.Text = reader["Логин"].ToString();
            this.textBox3.Text = reader["Пароль"].ToString();
            this.textBox4.Text = reader["Телефон"].ToString();
            this.textBox5.Text = reader["Email"].ToString();
            this.textBox6.Text = reader["Номер карты"].ToString();
            this.textBox7.Text = reader["Имя"].ToString();

            this.id = (int)reader["id"];
            connection.Close();
        }

        public bool changeDataCustomer(string name_customer, string login_customer, string password_customer, string telephone_customer, string email_customer, string numcard_customer)
        {
            connection.Open();
            string query1 = "UPDATE Customer SET Имя='" + name_customer + "', Логин='" + login_customer + "', Пароль='" + password_customer + "', Телефон='" + telephone_customer + "', Email='" + email_customer + "', [Номер карты]='" + numcard_customer + "' WHERE id =" + id; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query1, connection); // команда   

            if (dbCommand.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошибка выполнения запроса");
                connection.Close();
                return false;

            }
            else
            {
                MessageBox.Show("Данные успешно изменены");
                connection.Close();
                return true;
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name_cust = this.textBox1.Text;
            string login_cust = this.textBox2.Text;
            string password_cust = this.textBox3.Text;
            string telephone_cust = this.textBox4.Text;
            string email_cust = this.textBox5.Text;
            string numcard_cust = this.textBox6.Text;

            changeDataCustomer(name_cust, login_cust, password_cust, telephone_cust, email_cust, numcard_cust);
            /*connection.Open();
            string query1 = "UPDATE Customer SET Имя='" + name_customer + "', Логин='" + login_customer + "', Пароль='" + password_customer + "', Телефон='" + telephone_customer + "', Email='" + email_customer + "', [Номер карты]='" + numcard_customer + "' WHERE id =" + id; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query1, connection); // команда   

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса");
            else
                MessageBox.Show("Данные успешно изменены");
            connection.Close();*/
        }

        private void ChangeDataCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
