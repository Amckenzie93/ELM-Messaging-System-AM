using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ELM__AM
{

    public partial class MainWindow : Form
    {
        //variables hoisted for use in program
        public DataCollection data = new DataCollection();
        string inputFile = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "input.csv");



        //Main method call to initiate the main form window - a centralised place for ELM users.
        public MainWindow()
        {
            InitializeComponent();
            smsMessagesList.View = View.Details;
            smsMessagesList.GridLines = true;
            smsMessagesList.FullRowSelect = true;
            twitterMessageList.View = View.Details;
            twitterMessageList.GridLines = true;
            twitterMessageList.FullRowSelect = true;
            emailMessageList.View = View.Details;
            emailMessageList.GridLines = true;
            emailMessageList.FullRowSelect = true;
        }



        //Method to update the UI when new data has been added to the system from ether an entry or import / external.
        public void UpdateListView()
        {
            smsMessagesList.Items.Clear();
            emailMessageList.Items.Clear();
            twitterMessageList.Items.Clear();
            foreach (Sms item in data.smsMessages)
            {
                var listItem = new ListViewItem(new string[] { item.ID, item.PhoneNumber, item.Textmessage });
                smsMessagesList.Items.Add(listItem);
            }
            foreach (var item in data.emailMessages)
            {
                var listItem = new ListViewItem(new string[] { item.ID, item.EmailAddress, item.Subject, item.EmailMessage });
                if (item.Subject.Contains("SIR") || item.IncidentCode != null)
                {
                    listItem = new ListViewItem(new string[] { item.ID, item.EmailAddress, item.Subject, item.EmailMessage, item.BranchCode, item.IncidentCode });
                    listItem.BackColor = Color.Red;
                    listItem.ForeColor = Color.White;
                }
                emailMessageList.Items.Add(listItem);
            }
            foreach (var item in data.twitterMessages)
            {
                var listItem = new ListViewItem(new string[] { item.ID, item.TwitterID, item.TwitterMessage });
                twitterMessageList.Items.Add(listItem);
            }
            AutosizeColumns();
        }



        //Method to call whenever the UI updates
        private void AutosizeColumns()
        {
            smsMessagesList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            smsMessagesList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            emailMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            emailMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            twitterMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            twitterMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }



        //import from csv file, checking each ID isnt already in used and logging any failed attempts on the way - for aditional functionality the message is to display on screen one at a time so as they come in one by one they are rendered on screen 0.5s at a time.
        private void ImportAllButton_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(inputFile);
            string[] input = new string[File.ReadAllLines(inputFile).Length];
            input = streamReader.ReadLine().Split(',');
            while (!streamReader.EndOfStream)
            {
                input = streamReader.ReadLine().Split(',');

                //messages first letter to check which type of message this is.
                var identifier = input[0].First().ToString();
                bool proceed = true;

                if (identifier.ToLower() == "s")
                {
                    foreach (var id in data.smsMessages)
                    {
                        if (input[0] == id.ID)
                        {
                            proceed = false;

                            data.importErrors.Add(input[0]);
                        }
                    }
                    if (proceed == true)
                    {

                        try
                        {
                            Sms text = new Sms(input[0], input[2], ElmUtilities.WordAbreviations(input[1]));
                            data.smsUniqueID.Add(text.ID);
                            data.smsMessages.Add(text);
                            UpdateListView();
                            System.Threading.Thread.Sleep(500);
                        }
                        catch (Exception errorMessage)
                        {
                            //silent exception message for the prototype - real application could have a dialog for the failing message to correct the data manually.
                            // have placed these as a json export to highlight.
                        }
                    }
                }
                if (identifier.ToLower() == "e")
                {
                    foreach (var id in data.emailMessages)
                    {
                        if (input[0] == id.ID)
                        {
                            proceed = false;
                            data.importErrors.Add(input[0]);
                        }
                    }
                    if (proceed == true)
                    {

                        try
                        {
                            if (input[5].Contains("SIR"))
                            {
                                Email item = new Email(input[0], input[5], input[3], input[1], input[6], input[7], data);
                                data.emailMessages.Add(item);
                                data.emailUniqueID.Add(item.ID);
                            }
                            else
                            {
                                Email item = new Email(input[0], input[5], input[3], input[1], data);
                                data.emailMessages.Add(item);
                                data.emailUniqueID.Add(item.ID);
                            }
                            UpdateListView();
                            System.Threading.Thread.Sleep(500);
                        }
                        catch (Exception errorMessage)
                        {
                            //silent exception message for the prototype - real application could have a dialog for the failing message to correct the data manually.
                        }
                    }
                }

                if (identifier.ToLower() == "t")
                {
                    foreach (var id in data.twitterMessages)
                    {
                        if (input[0] == id.ID)
                        {
                            proceed = false;
                            data.importErrors.Add(input[0]);
                        }
                    }
                    if (proceed == true)
                    {
                        try
                        {
                            Twitter tweet = new Twitter(input[0], input[4], input[1], data);
                            data.twitterUniqueID.Add(tweet.ID);
                            data.twitterHandleUse.Add(tweet.TwitterID);
                            data.twitterMessages.Add(tweet);
                            UpdateListView();
                            System.Threading.Thread.Sleep(500);
                        }
                        catch (Exception errorMessage)
                        {
                        }
                    }
                }
            }
            if (data.importErrors.Count > 0)
            {
                importErrorsBox.Text = "Not all imported messages could be processed due to incorrect data and/or duplicate entries.";
            }

        }


        private void JSONExportButton_Click(object sender, EventArgs e)
        {
            if (data.smsMessages.Count > 0 && data.emailMessages.Count > 0 && data.twitterMessages.Count > 0)
            {
                ElmUtilities.ExportJSON(data);
            }
            else
            {
                MessageBox.Show("You have no data to export.");
            }

        }

        private void NewEntryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            EntryForm entry = new EntryForm(this);
            entry.Show();
        }

        private void QuarentineButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Quarentine quarentine = new Quarentine(this);
            quarentine.Show();
        }

        private void TrendingListButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trending trendinigForm = new Trending(this);
            trendinigForm.Show();
        }

        private void MentionsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mentions mentionsForm = new Mentions(this);
            mentionsForm.Show();
        }
    }
}
