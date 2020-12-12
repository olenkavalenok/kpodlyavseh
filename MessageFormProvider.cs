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
    public partial class MessageFormProvider : Form
    {
        public MessageFormProvider()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.Addresser_Provider = textBox2.Text;
            DataBase.Message_Text_Provider = textBox1.Text;
            this.Hide();
        }

        private void MessageFormProvider_Load(object sender, EventArgs e)
        {

        }
    }
}
