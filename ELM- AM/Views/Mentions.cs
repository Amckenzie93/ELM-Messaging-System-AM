using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ELM__AM
{
    public partial class Mentions : Form
    {

        public MainWindow form1;

        public Mentions(MainWindow form1)
        {
            InitializeComponent();
            MentionsListBox.View = View.Details;
            MentionsListBox.GridLines = true;
            MentionsListBox.FullRowSelect = true;
            this.form1 = form1;

            OnLoadUpdate();
        }

        private void OnLoadUpdate()
        {
            foreach (Twitter value in form1.data.twitterMessages)
            { 
                var regex = @"((@+[a-zA-Z0-9(_)]{1,}))";


                MatchCollection locatedTwitterMention = Regex.Matches(value.TwitterMessage, regex);
                foreach (var item in locatedTwitterMention)
                {
                    if(item.ToString().ToLower() == "@elm" || item.ToString().ToLower() == "@eustonleisure" || item.ToString().ToLower() == "@eustonleisurecentre")
                    {
                        var row = new string[] { value.ID, value.TwitterID, item.ToString(), value.TwitterMessage };
                        var listItem = new ListViewItem(row);
                        MentionsListBox.Items.Add(listItem);
                    }
                }
            }
            MentionsListBox.Sorting = SortOrder.Descending;
            MentionsListBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            MentionsListBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        private void BackButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }
    }
}
