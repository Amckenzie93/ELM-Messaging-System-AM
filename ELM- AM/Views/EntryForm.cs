using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
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
            this.form1 = form1;
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                ElmMessage message = new ElmMessage(MessageHeader.Text, MessageBody.Text);

                if (!ElmUtilities.IsUniqueId(MessageHeader.Text, form1.data))
                {
                    throw new Exception("Please enter a valid Header ID");
                }
                if (message.GetMessageType().ToUpper() == "S")
                {
                    Sms item = new Sms(MessageHeader.Text, MessageBody.Text);
                    form1.data.smsUniqueID.Add(MessageHeader.Text);
                    form1.data.smsMessages.Add(item);
                    Passback();
                }

                else if (message.GetMessageType().ToUpper() == "E")
                {
                    Email item = new Email(MessageHeader.Text, MessageBody.Text, form1.data);
                    form1.data.emailUniqueID.Add(MessageHeader.Text);
                    form1.data.emailMessages.Add(item);
                    Passback();
                }

                else if (message.GetMessageType().ToUpper() == "T")
                {
                    Twitter item = new Twitter(MessageHeader.Text, MessageBody.Text, form1.data);
                    form1.data.twitterUniqueID.Add(MessageHeader.Text);
                    form1.data.twitterMessages.Add(item);
                    Passback();
                }
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
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

        private void DisplayError(string errorMessage)
        {
            BasicError.Text = errorMessage;
        }

    }
}
