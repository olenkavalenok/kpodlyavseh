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
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        /**private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataBase.Addresser = textBox1.Text;
        }*/

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            String em = textBox2.Text;

            if (em == DataBase.Email_Provider)
            {
                DataBase.Addresser = textBox2.Text;
                DataBase.Message_Text = textBox1.Text;
                this.Hide();
            }
            
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
