using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPO_Lab
{
    public partial class LogInCustomer : Form
    {
        public LogInCustomer()
        {
            InitializeComponent();
        }

        bool Login_Password(String login, String password)
        {
            if (login == DataBase.Login_Customer && password == DataBase.Password_Customer)
                return true;
            else
                return false;
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            String log = textBox1.Text;
            String pas = textBox2.Text;

            if (Login_Password(log, pas))
            {
                Customer customer = new Customer();
                customer.Show();
                this.Hide();
            }
        }*/

        private void LogInCustomer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click1(object sender, EventArgs e)
        {
            String log = textBox1.Text;
            String pas = textBox2.Text;

            if (Login_Password(log, pas))
            {
                Customer customer = new Customer();
                customer.Show();
                this.Hide();
            }
        }
    }
}
