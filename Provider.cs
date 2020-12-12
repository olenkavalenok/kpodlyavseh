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
    public partial class Provider : Form
    {
        public Provider()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageCustomer messageCustomer = new MessageCustomer();
            messageCustomer.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Request request = new Request();
            for (int i = 0; i < DataBase.Product_Name.Length - 1; i++)
                request.dataGridView1.Rows.Add(DataBase.Product_Name[i],
                                                DataBase.Product_Price[i],
                                                DataBase.Product_Demand[i],
                                                DataBase.Product_Last_Demand[i],
                                                DataBase.Product_Count[i]);
            request.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeDataProvider cdp = new ChangeDataProvider();
            cdp.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageFormProvider mfp = new MessageFormProvider();
            mfp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageProvider mp = new MessageProvider();
            mp.Show();
        }
    }
}
