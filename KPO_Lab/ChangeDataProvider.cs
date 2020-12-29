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
    public partial class ChangeDataProvider : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения

        public ChangeDataProvider(int id)
        {
            InitializeComponent();

            connection.Open();
            string query = "SELECT * FROM Provider WHERE id=" + id;
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

            this.id = (int)reader["id"];
            connection.Close();
        }

        public bool changeDataProvider(string name_provider, string login_provider, string password_provider, string telephone_provider, string email_provider, string numcard_provider) 
        {
            connection.Open();
            string query1 = "UPDATE Provider SET Имя='" + name_provider + "', Логин='" + login_provider + "', Пароль='" + password_provider + "', Телефон='" + telephone_provider + "', Email='" + email_provider + "', [Номер карты]='" + numcard_provider + "' WHERE id =" + id; // строка запроса
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
            string name_prov = this.textBox1.Text;
            string login_prov = this.textBox2.Text;
            string password_prov = this.textBox3.Text;
            string telephone_prov = this.textBox4.Text;
            string email_prov = this.textBox5.Text;
            string numcard_prov = this.textBox6.Text;

            /*connection.Open();
            string query1 = "UPDATE Provider SET Имя='" + name_customer + "', Логин='" + login_customer + "', Пароль='" + password_customer + "', Телефон='" + telephone_customer + "', Email='" + email_customer + "', [Номер карты]='" + numcard_customer + "' WHERE id =" + id; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query1, connection); // команда   

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса");
            else
                MessageBox.Show("Данные успешно изменены");
            connection.Close();*/
            changeDataProvider(name_prov, login_prov, password_prov, telephone_prov, email_prov, numcard_prov);
        }
    }
}
