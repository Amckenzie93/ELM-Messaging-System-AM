using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ELM__AM
{

    public partial class MainWindow : Form
    {
        //hoisted collection of data classes and paths to files for use in program
        public DataCollection data = new DataCollection();
        string inputFile = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "input.csv");
        string outputPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;

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




        public void UpdateListView()
        {
            smsMessagesList.Items.Clear();
            emailMessageList.Items.Clear();
            twitterMessageList.Items.Clear();
            foreach (Sms item in data.smsMessages)
            {
                var row = new string[] { item.ID, item.PhoneNumber, item.Textmessage };
                var listItem = new ListViewItem(row);
                smsMessagesList.Items.Add(listItem);
            }
            foreach (var item in data.emailMessages)
            {
                var row = new string[] { item.ID, item.EmailAddress, item.Subject, item.EmailMessage };
                var listItem = new ListViewItem(row);
                if (item.Subject.Contains("SIR") || item.IncidentCode != null)
                {
                    row = new string[] { item.ID, item.EmailAddress, item.Subject, item.EmailMessage, item.BranchCode, item.IncidentCode };
                    listItem = new ListViewItem(row);
                    listItem.BackColor = Color.Red;
                    listItem.ForeColor = Color.White;
                }
                emailMessageList.Items.Add(listItem);
            }
            foreach (var item in data.twitterMessages)
            {
                var row = new string[] { item.ID, item.TwitterID, item.TwitterMessage };
                var listItem = new ListViewItem(row);
                twitterMessageList.Items.Add(listItem);
            }
            AutosizeColumns();
        }




        private void AutosizeColumns()
        {
            smsMessagesList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            smsMessagesList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            emailMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            emailMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            twitterMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            twitterMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }




        public string WordAbreviations(string message)
        {
            StreamReader streamReader = new StreamReader("textwords.csv");
            string[] input = new string[File.ReadAllLines("textwords.csv").Length];
            input = streamReader.ReadLine().Split(',');
            while (!streamReader.EndOfStream)
            {
                input = streamReader.ReadLine().Split(',');
                var identifier = input[0];
                if (message.ToLower().Contains(identifier.ToLower()))
                {
                    var position = message.IndexOf(identifier);
                    if (position >= 0)
                    {
                        var builder = new StringBuilder(message);
                        builder.Insert(position + identifier.Length, "<" + input[1] + ">");
                        message = builder.ToString();
                    }
                }
            }
            streamReader.Close();
            return message;
        }





        //import from csv
        private void ImportAllButton_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(inputFile);
            string[] input = new string[File.ReadAllLines(inputFile).Length];
            input = streamReader.ReadLine().Split(',');
            while (!streamReader.EndOfStream)
            {
                input = streamReader.ReadLine().Split(',');
                var identifier = input[0].First().ToString();
                bool proceed = true;
                foreach (var id in data.smsMessages)
                {
                    if (input[0] == id.ID)
                    {
                        proceed = false;
                    }
                }
                if (proceed == true)
                {
                    if (identifier.ToLower() == "s")
                    {
                        Sms text = new Sms();
                        text.ID = input[0];
                        text.Textmessage = WordAbreviations(input[1]);
                        text.PhoneNumber = input[2];
                        data.smsUniqueID.Add(text.ID);
                        data.smsMessages.Add(text);
                        UpdateListView();
                        System.Threading.Thread.Sleep(500);
                    }
                }

                foreach (var id in data.emailMessages)
                {
                    if (input[0] == id.ID)
                    {
                        proceed = false;
                    }
                }
                if (proceed == true)
                {
                    if (identifier.ToLower() == "e")
                    {
                        Email email = new Email();
                        email.ID = input[0];
                        email.EmailMessage = ElmUtilities.LinkCheck(WordAbreviations(input[1]), data);
                        email.EmailAddress = input[3];
                        email.Subject = input[5];
                        if (email.Subject.Contains("SIR"))
                        {

                            email.BranchCode = input[6];
                            email.IncidentCode = input[7];
                            email.BranchCode = input[6];
                            email.IncidentCode = input[7];
                        }
                        data.emailUniqueID.Add(email.ID);
                        data.emailMessages.Add(email);
                        UpdateListView();
                        System.Threading.Thread.Sleep(500);
                    }
                }
                foreach (var id in data.twitterMessages)
                {
                    if (input[0] == id.ID)
                    {
                        proceed = false;
                    }
                }
                if (proceed == true)
                {
                    if (identifier.ToLower() == "t")
                    {
                        Twitter tweet = new Twitter();
                        tweet.ID = input[0];
                        tweet.TwitterMessage = ElmUtilities.GetHashTags(WordAbreviations(input[1]), data);
                        tweet.TwitterID = input[4];
                        data.twitterUniqueID.Add(tweet.ID);
                        data.twitterHandleUse.Add(tweet.TwitterID);
                        data.twitterMessages.Add(tweet);
                        UpdateListView();
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }


        private void JSONExportButton_Click(object sender, EventArgs e)
        {
            ElmUtilities.exportJSON(data, this);
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
