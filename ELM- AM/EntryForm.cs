using System;
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
            inputMessageBox.MaxLength = 140;
            inputMessageBox.Enabled = true;
            inputMessageBox.BackColor = Color.White;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            resetFormFields();
            inputMessageBox.MaxLength = 140;
            setFormFields(textBox4);
            setFormFields(inputMessageBox);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            resetFormFields();
            inputMessageBox.MaxLength = 1028;
            setFormFields(textBox2);
            setFormFields(textBox3);
            setFormFields(inputMessageBox);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            resetFormFields();
            inputMessageBox.MaxLength = 1028;
            setFormFields(textBox2);
            setFormFields(textBox3);
            setFormFields(inputMessageBox);
            setFormFields(textBox5);
            comboBox1.Enabled = true;
            comboBox1.BackColor = Color.White;
        }

        private void resetFormFields()
        {
            comboBox1.Enabled = false;
            comboBox1.BackColor = Color.Gainsboro;

            foreach (var item in textBoxes)
            {
                item.Text = "";
                item.Enabled = false;
                item.BackColor = Color.Gainsboro;
            }
        }

        private void setFormFields(TextBox item)
        {
            item.Enabled = true;
            item.BackColor = Color.White;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Sms item = new Sms();
                item.ID = form1.UniqueId("S");
                item.PhoneNumber = textBox1.Text;
                item.Textmessage = inputMessageBox.Text;
                form1.data.smsMessages.Add(item);
                Passback();

            }
            else if (radioButton2.Checked)
            {
                Twitter item = new Twitter();
                item.ID = form1.UniqueId("T");
                item.TwitterID = textBox4.Text;
                item.TwitterMessage = inputMessageBox.Text;
                form1.data.twitterMessages.Add(item);
                form1.data.twitterHandleUse.Add(item.TwitterID);
                Passback();
            }
            else if (radioButton3.Checked)
            {
                Email item = new Email();
                item.ID = form1.UniqueId("E");
                item.Subject = textBox3.Text;
                item.EmailAddress = textBox2.Text;
                item.EmailMessage = form1.LinkCheck(inputMessageBox.Text);
                form1.data.emailMessages.Add(item);
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
                form1.data.emailMessages.Add(item);
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
            form1.UpdateListView();
            form1.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }

    }
}
