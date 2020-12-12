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
    public partial class ChangeDataCustomer : Form
    {
        public ChangeDataCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.Name_Customer = this.textBox1.Text;
            DataBase.Login_Customer = this.textBox2.Text;
            DataBase.Password_Customer = this.textBox3.Text;
            DataBase.Telephone_Customer = this.textBox4.Text;
            DataBase.Email_Customer = this.textBox5.Text;
            DataBase.NumCard_Customer = this.textBox6.Text;
            DataBase.Time = this.textBox7.Text;
            this.Hide();
        }

        private void ChangeDataCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
