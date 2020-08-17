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
        //Singleton database class
        public DataCollection data = DataCollection.Instance();


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
            SIRMessageList.View = View.Details;
            SIRMessageList.GridLines = true;
            SIRMessageList.FullRowSelect = true;
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
                emailMessageList.Items.Add(listItem);
            }
            foreach (var item in data.twitterMessages)
            {
                var listItem = new ListViewItem(new string[] { item.ID, item.TwitterID, item.TwitterMessage });
                twitterMessageList.Items.Add(listItem);
            }
            foreach (var item in data.SIRemailMessages)
            {
                if (item.Subject.Contains("SIR") || item.IncidentCode != null)
                {
                    var listItem = new ListViewItem(new string[] { item.ID, item.EmailAddress, item.Subject, item.EmailMessage, item.BranchCode, item.IncidentCode });
                    listItem.BackColor = Color.Red;
                    listItem.ForeColor = Color.White;
                    SIRMessageList.Items.Add(listItem);
                }
            }
            AutosizeColumns();
        }

        //import from csv file, checking each ID isnt already in used and logging any failed attempts on the way - for aditional functionality the message is to display on screen one at a time so as they come in one by one they are rendered on screen 0.5s at a time.
        private void ImportAllButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "CVS files (*.csv*)|*.csv*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(dialog.FileName);
                string[] input = new string[File.ReadAllLines(dialog.FileName).Length];
                input = streamReader.ReadLine().Split(',');
                while (!streamReader.EndOfStream)
                {
                    input = streamReader.ReadLine().Split(',');
                    var identifier = input[0].First().ToString();
                    bool proceed = true;

                    //check message ID for type
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
                                Sms text = new Sms(input[0], input[2], ElmUtilities.WordAbreviations(input[1]), data);
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
                        try
                        {
                            if (input[5].Contains("SIR"))
                            {
                                foreach (var id in data.SIRemailMessages)
                                {
                                    if (input[0] == id.ID)
                                    {
                                        proceed = false;
                                        data.importErrors.Add(input[0]);
                                    }
                                }
                                if (proceed == true)
                                {
                                    Email item = new Email(input[0], input[5], input[3], input[1], input[6], input[7], data);
                                    data.SIRemailMessages.Add(item);
                                    data.emailUniqueID.Add(item.ID);
                                }
                            }
                            else
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
                                    Email item = new Email(input[0], input[5], input[3], input[1], data);
                                    data.emailMessages.Add(item);
                                    data.emailUniqueID.Add(item.ID);
                                    UpdateListView();
                                    System.Threading.Thread.Sleep(500);
                                }
                            }
                        }
                        catch (Exception errorMessage)
                        {
                            //silent exception message for the prototype - real application could have a dialog for the failing message to correct the data manually.
                            // have placed these as a json export to highlight.
                        }
                    }
                    else if (identifier.ToLower() == "t")
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
                                //silent exception message for the prototype - real application could have a dialog for the failing message to correct the data manually.
                                // have placed these as a json export to highlight.
                            }
                        }
                    }
                }
                if (data.importErrors.Count > 0)
                {
                    MessageBox.Show("Not all messages could be imported and processed due to ether incorrect data and/ or there being duplicate entries.", "Failed Import Items");
                }
            }
            else
            {
                return;
            }
        }

        //Method for the view button on click to launch the export call, but only if there's actually data to process. 
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

        //Method to call whenever the UI updates
        private void AutosizeColumns()
        {
            smsMessagesList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            smsMessagesList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            emailMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            emailMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            twitterMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            twitterMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            SIRMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            SIRMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        // different methods to control button clicks on the form UI to go to other form views to add new messages or see the twitter trending list etc.
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
