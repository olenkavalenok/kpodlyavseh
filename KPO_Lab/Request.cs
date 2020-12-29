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
    
    public partial class Request : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=""C:\Users\Анастасия\Documents\Auto.mdb"""); // строка соединения

        public Request()
        {
            InitializeComponent();

            dataGridView1.Rows.Clear();
            connection.Open(); // открываем соединение
            string query1 = "SELECT * FROM Request"; // строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query1, connection); // команда
            OleDbDataReader dbReader = dbCommand.ExecuteReader(); // считываем данные

            if (dbReader.HasRows == false)
                MessageBox.Show("Ошибка");
            else
                while (dbReader.Read())
                    dataGridView1.Rows.Add(dbReader["Название"], dbReader["Цена"], dbReader["Количество"]);

            dbReader.Close();
            connection.Close();
        }

        private void Request_Load(object sender, EventArgs e)
        {

        }
    }
}
