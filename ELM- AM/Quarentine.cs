using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ELM__AM
{
    public partial class Quarentine : Form
    {


        public MainWindow form1;


        public Quarentine(MainWindow form1)
        {
            InitializeComponent();
            this.form1 = form1;
            foreach (var link in form1.data.quarantinedList)
            {
                listBox1.Items.Add(link);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }
    }
}
