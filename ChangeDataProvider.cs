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
    public partial class ChangeDataProvider : Form
    {
        public ChangeDataProvider()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.Name_Provider = this.textBox1.Text;
            DataBase.Login_Provider = this.textBox2.Text;
            DataBase.Password_Provider = this.textBox3.Text;
            DataBase.Telephone_Provider = this.textBox4.Text;
            DataBase.Email_Provider = this.textBox5.Text;
            DataBase.NumCard_Provider = this.textBox6.Text;
            this.Hide();
        }
    }
}
