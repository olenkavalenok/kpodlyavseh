﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogInCustomer logInCustomer = new LogInCustomer();
            logInCustomer.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogInProvider logInProvider = new LogInProvider();
            logInProvider.Show();
            this.Hide();
        }
    }
}
