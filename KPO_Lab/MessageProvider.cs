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
    public partial class MessageProvider : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения

        public MessageProvider(string email_customer)
        {
            InitializeComponent();

            connection.Open(); // открываем соединение
            string query1 = "SELECT * FROM Message WHERE Кому='" + email_customer + "'"; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query1, connection); // команда
            OleDbDataReader dbReader = dbCommand.ExecuteReader(); // считываем данные

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Сообщений нет");
                Hide();
            }
            else
                while (dbReader.Read())
                {
                    label2.Text = dbReader["От кого"].ToString();
                    label4.Text = dbReader["Сообщение"].ToString();
                }

            dbReader.Close();
            connection.Close();
        }

        private void MessageProvider_Load(object sender, EventArgs e)
        {
            /*label2.Text = DataBase.Addresser_Provider;
            label4.Text = DataBase.Message_Text_Provider;*/
        }
    }
}
