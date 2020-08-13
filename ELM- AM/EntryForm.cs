using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


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

      

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Sms item = new Sms();
                item.ID = ElmUtilities.GenUniqueId("S", form1.data);
                item.PhoneNumber = textBox1.Text;
                item.Textmessage = form1.WordAbreviations(inputMessageBox.Text);
                form1.data.smsMessages.Add(item);
                Passback();

            }
            else if (radioButton2.Checked)
            {
                Twitter item = new Twitter();
                item.ID = ElmUtilities.GenUniqueId("T", form1.data);
                item.TwitterID = textBox4.Text;
                item.TwitterMessage = ElmUtilities.GetHashTags(form1.WordAbreviations(inputMessageBox.Text), form1.data);
                form1.data.twitterMessages.Add(item);
                form1.data.twitterHandleUse.Add(item.TwitterID);
                Passback();
            }
            else if (radioButton3.Checked)
            {
                Email item = new Email();
                item.ID = ElmUtilities.GenUniqueId("E", form1.data);
                item.Subject = textBox3.Text;
                item.EmailAddress = textBox2.Text;
                item.EmailMessage = ElmUtilities.LinkCheck(inputMessageBox.Text, form1.data);
                form1.data.emailMessages.Add(item);
                Passback();
            }
            else if (radioButton4.Checked)
            {
                Email item = new Email();
                item.ID = ElmUtilities.GenUniqueId("E", form1.data);
                item.Subject = textBox3.Text;
                item.EmailAddress = textBox2.Text;
                item.EmailMessage = ElmUtilities.LinkCheck(inputMessageBox.Text, form1.data);
                item.BranchCode = textBox5.Text;
                item.IncidentCode = comboBox1.SelectedItem.ToString();
                form1.data.emailMessages.Add(item);
                Passback();
            }

            //This of code is the two field input testing section;
            else if (MessageHeader.Text.Length > 0 && MessageBody.Text.Length > 0)
            {
                if (MessageHeader.Text.Substring(0, 1).ToUpper() == "S" || MessageHeader.Text.Substring(0, 1).ToUpper() == "E" || MessageHeader.Text.Substring(0, 1).ToUpper() == "T")
                {
                    if (ElmUtilities.IsUniqueId(MessageHeader.Text, form1.data))
                    {
                        ElmMessage message = new ElmMessage(MessageHeader.Text, MessageBody.Text);
                        var body = MessageBody.Text.Split(',');

                        if (message.GetMessageType().ToUpper() == "S")
                        {
                            try
                            {
                                Sms item = new Sms();

                                item.ID = MessageHeader.Text;
                                item.PhoneNumber = body[1];
                                item.Textmessage = form1.WordAbreviations(body[0]);
                                if (item.Validation())
                                {
                                    form1.data.smsMessages.Add(item);
                                    Passback();
                                }
                                else
                                {
                                    DisplayError();
                                }
                            }
                            catch
                            {
                                DisplayError();
                            }
                        }

                        else if (message.GetMessageType().ToUpper() == "E")
                        {
                            try
                            {


                                Email item = new Email();

                                item.ID = MessageHeader.Text;
                                item.Subject = body[0];
                                item.EmailAddress = body[1];
                                item.EmailMessage = ElmUtilities.LinkCheck(body[2], form1.data);

                                if (body.Length == 5)
                                {
                                    item.BranchCode = body[3];
                                    item.IncidentCode = body[4];
                                }

                                if (item.Validation())
                                {
                                    form1.data.emailMessages.Add(item);
                                    Passback();
                                }
                                else
                                {
                                    DisplayError();
                                }
                            }
                            catch
                            {
                                DisplayError();
                            }

                        }
                        else if (message.GetMessageType().ToUpper() == "T")
                        {
                            try
                            {
                                Twitter item = new Twitter();
                                item.ID = MessageHeader.Text;
                                item.TwitterID = body[0];
                                item.TwitterMessage = ElmUtilities.GetHashTags(form1.WordAbreviations(body[1]), form1.data);

                                if (item.Validation())
                                {
                                    form1.data.twitterMessages.Add(item);
                                    form1.data.twitterHandleUse.Add(item.TwitterID);
                                    Passback();
                                }
                                else
                                {
                                    DisplayError();
                                }
                            }
                            catch
                            {
                                DisplayError();
                            }
                        }
                    }
                    else
                    {
                        BasicError.Text = "Please check your message Header ID.";
                    }
                }
                else
                {
                    BasicError.Text = "Please enter a unique Header ID (starting with one of the following : S E T ).";
                }
            }
            else
            {
                DisplayError();
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

        private void DisplayError()
        {
            BasicError.Text = "Please check all details correctly.";
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
    }
}
