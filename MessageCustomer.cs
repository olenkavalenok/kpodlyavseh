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
    public partial class MessageCustomer : Form
    {
        public MessageCustomer()
        {
            InitializeComponent();
        }


        /*public string Txt
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }*/

        private void MessageCustomer_Load(object sender, EventArgs e)
        {
            label2.Text = DataBase.Addresser;
            label4.Text = DataBase.Message_Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MessageCustomer_Load_1(object sender, EventArgs e)
        {

        }

        /*private void label2_TextChanged(object sender, EventArgs e)
        {
            label2.Text = "dfgdf";
            //this.Txt = DataBase.Text;
            this.ShowDialog();
        }*/
    }
}
