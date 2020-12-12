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
    public partial class MessageProvider : Form
    {
        public MessageProvider()
        {
            InitializeComponent();
        }

        private void MessageProvider_Load(object sender, EventArgs e)
        {
            label2.Text = DataBase.Addresser_Provider;
            label4.Text = DataBase.Message_Text_Provider;
        }
    }
}
