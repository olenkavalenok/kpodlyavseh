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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageForm messageForm = new MessageForm();
            messageForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageCustomer messageCustomer = new MessageCustomer();
            messageCustomer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeDataCustomer cdc = new ChangeDataCustomer();
            cdc.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Request request = new Request();

            /*request.Controls.Remove(request.dataGridView1);
            request.Controls.Add(this.dataGridView1);*/
            //string t = this.dataGridView1.Rows[1].Cells[2].ToString();
            object ob1;
            object ob2;
            object ob3;
            object ob4;
            object ob5;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                ob1 = dataGridView1[0, i].Value;
                DataBase.Product_Name[i] = ob1.ToString();
                ob2 = dataGridView1[1, i].Value;
                DataBase.Product_Price[i] = Convert.ToInt32(ob2);
                ob3 = dataGridView1[2, i].Value;
                DataBase.Product_Demand[i] = Convert.ToInt32(ob3);
                ob4 = dataGridView1[3, i].Value;
                DataBase.Product_Last_Demand[i] = Convert.ToInt32(ob4);
                ob5 = dataGridView1[4, i].Value;
                DataBase.Product_Count[i] = Convert.ToInt32(ob5);
            }
            Random rnd = new Random(); 
            int req_num = rnd.Next(0, 100);
            DataBase.Request_Number = req_num;
            /*for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                request.dataGridView1.Rows.Add( DataBase.Product_Name[i], 
                                                DataBase.Product_Price[i], 
                                                DataBase.Product_Demand[i], 
                                                DataBase.Product_Last_Demand[i], 
                                                DataBase.Product_Count[i]);
            request.Show();*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageProvider messageProvider = new MessageProvider();
            messageProvider.Show();
        }
    }
}
