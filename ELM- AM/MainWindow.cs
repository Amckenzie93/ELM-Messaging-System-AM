using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ELM__AM
{

    public partial class MainWindow : Form
    {
        public DataCollection data = new DataCollection();

        string abbreviations = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "textwords.csv");
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
                        updateListView();
                        System.Threading.Thread.Sleep(300);
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
                        email.EmailMessage = LinkCheck(WordAbreviations(input[1]));
                        email.EmailAddress = input[3];
                        email.Subject = input[5];
                        if (email.Subject.Contains("SIR"))
                        {
                            SIR report = new SIR();
                            report.BranchCode = input[6];
                            report.IncidentCode = input[7];
                            email.BranchCode = input[6];
                            email.IncidentCode = input[7];
                            data.sIRMessages.Add(report);
                        }
                        data.emailUniqueID.Add(email.ID);
                        data.emailMessages.Add(email);
                        updateListView();
                        System.Threading.Thread.Sleep(300);
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
                        tweet.TwitterMessage = WordAbreviations(input[1]);
                        tweet.TwitterID = input[4];
                        data.twitterUniqueID.Add(tweet.ID);
                        data.twitterHandleUse.Add(tweet.TwitterID);
                        data.twitterMessages.Add(tweet);
                        updateListView();
                        System.Threading.Thread.Sleep(300);
                    }
                }
            }
            
        }

        public string LinkCheck(string val)
        {
            string regex = @"((http|www|https|ftp):\/\/)?[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:\/~\+#]*[\w\-\@?^=%&amp;\/~\+#])?";
            MatchCollection replaced = System.Text.RegularExpressions.Regex.Matches(val, regex);
            foreach (var item in replaced)
            {
                data.quarantinedList.Add(item.ToString());
                val = System.Text.RegularExpressions.Regex.Replace(val, regex, "<URL Quarantined>");
            }
            return val;
        }

        private string WordAbreviations(string message)
        {
            StreamReader streamReader = new StreamReader(abbreviations);
            string[] input = new string[File.ReadAllLines(abbreviations).Length];
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

        public string UniqueId(string type)
        {
            var number = 1;
            var newUnique = type + String.Format("{0:D9}", number);
            if (type == "S")
            {
                while (data.smsUniqueID.Contains(newUnique))
                {
                    newUnique = type + String.Format("{0:D9}", number++);
                }
                data.smsUniqueID.Add(newUnique);
            }
            else if (type == "T")
            {
                while (data.twitterUniqueID.Contains(newUnique))
                {
                    newUnique = type + String.Format("{0:D9}", number++);
                }
                data.twitterUniqueID.Add(newUnique);
            }
            else
            {
                while (data.emailUniqueID.Contains(newUnique))
                {
                    newUnique = type + String.Format("{0:D9}", number++);
                }
                data.emailUniqueID.Add(newUnique);
            }
            return newUnique;
        }

        public void updateListView()
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
                if (item.Subject.Contains("SIR"))
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
            autosizeColumns();
        }

        private void autosizeColumns()
        {
            smsMessagesList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            smsMessagesList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            emailMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            emailMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            twitterMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            twitterMessageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void JSONExportButton_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ELM JSON EXPORT - " + DateTime.Today.ToString("yyyMMdd") + ".json");
            using (StreamWriter file = File.CreateText(path))
            {
                using (JsonTextWriter jw = new JsonTextWriter(file))
                {
                    jw.WriteStartObject();
                    jw.WritePropertyName("All SMS Messages");
                    jw.WriteStartArray();
                    foreach (var item in data.smsMessages)
                    {
                        string json = JsonConvert.SerializeObject(item);
                        jw.WriteValue(json + ",");
                    }
                    jw.WriteEndArray();
                    jw.WritePropertyName("All Twitter Messages");
                    jw.WriteStartArray();
                    foreach (var item in data.twitterMessages)
                    {
                        string json = JsonConvert.SerializeObject(item); ;
                        jw.WriteValue(json + ",");
                    }
                    jw.WriteEndArray();
                    jw.WritePropertyName("All Email Messages");
                    jw.WriteStartArray();
                    foreach (var item in data.emailMessages)
                    {
                        string json = JsonConvert.SerializeObject(item); ;
                        jw.WriteValue(json + ",");
                    }
                    jw.WriteEndArray();
                    jw.WritePropertyName("All Quarantined Links");
                    jw.WriteStartArray();
                    foreach (var item in data.quarantinedList)
                    {
                        string json = JsonConvert.SerializeObject(item); ;
                        jw.WriteValue(json + ",");
                    }
                    jw.WriteEndArray();
                    jw.WriteEndObject();
                }
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
    }
}
