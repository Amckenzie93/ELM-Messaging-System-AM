﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace ELM__AM
{

    public partial class EntryForm : Form
    {
        public List<TextBoxBase> textBoxes = new List<TextBoxBase> { };

        public MainWindow form1;

        public EntryForm(MainWindow form1)
        {
            InitializeComponent();
            textBoxes.Add(textBox1);
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);
            textBoxes.Add(textBox4);
            textBoxes.Add(inputMessageBox);

            this.form1 = form1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            resetFormFields();
            setFormFields(textBox1);
            inputMessageBox.Enabled = true;
            inputMessageBox.BackColor = Color.White;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            resetFormFields();
            setFormFields(textBox4);
            setFormFields(inputMessageBox);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            resetFormFields();
            setFormFields(textBox2);
            setFormFields(textBox3);
            setFormFields(inputMessageBox);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            resetFormFields();
            setFormFields(textBox2);
            setFormFields(textBox3);
            setFormFields(inputMessageBox);
            setFormFields(textBox5);
            comboBox1.Enabled = true;
            comboBox1.BackColor = Color.White;
        }

        public void resetFormFields()
        {
            comboBox1.Enabled = false;
            comboBox1.BackColor = Color.Gainsboro;

            foreach (var item in textBoxes)
            {
                item.Enabled = false;
                item.BackColor = Color.Gainsboro;
            }
        }

        public void setFormFields(TextBox item)
        {
            item.Enabled = true;
            item.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Sms item = new Sms();
                item.ID = form1.UniqueId("S");
                item.PhoneNumber = textBox1.Text;
                item.Textmessage = inputMessageBox.Text;
                form1.smsMessages.Add(item);
                Passback();

            }
            else if (radioButton2.Checked)
            {
                Twitter item = new Twitter();
                item.ID = form1.UniqueId("T");
                item.TwitterID = textBox4.Text;
                item.TwitterMessage = inputMessageBox.Text;
                form1.twitterMessages.Add(item);
                Passback();
            }
            else if (radioButton3.Checked)
            {
                Email item = new Email();
                item.ID = form1.UniqueId("E");
                item.Subject = textBox3.Text;
                item.EmailAddress = textBox2.Text;
                item.EmailMessage = form1.LinkCheck(inputMessageBox.Text);
                form1.emailMessages.Add(item);
                Passback();
            }
            else if (radioButton4.Checked)
            {
                Email item = new Email();
                item.ID = form1.UniqueId("E");
                item.Subject = textBox3.Text;
                item.EmailAddress = textBox2.Text;
                item.EmailMessage = form1.LinkCheck(inputMessageBox.Text);
                item.BranchCode = textBox5.Text;
                item.IncidentCode = comboBox1.SelectedItem.ToString();
                form1.emailMessages.Add(item);
                Passback();
            }
            else
            {
                // nothing :( 
            }

        }

        public void Passback()
        {
            this.Hide();
            form1.updateListView();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }
    }
}
