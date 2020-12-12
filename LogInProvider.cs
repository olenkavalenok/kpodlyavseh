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
    public partial class LogInProvider : Form
    {
        public LogInProvider()
        {
            InitializeComponent();
        }

        bool Login_Password(String login, String password)
        {
            if (login == DataBase.Login_Provider && password == DataBase.Password_Provider)
                return true;
            else
                return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String log = textBox1.Text;
            String pas = textBox2.Text;

            if (Login_Password(log, pas))
            {
                Provider provider = new Provider();
                provider.Show();
                this.Hide();
            }
        }

        private void LogInProvider_Load(object sender, EventArgs e)
        {

        }
    }
}
