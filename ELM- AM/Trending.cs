using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ELM__AM
{
    public partial class Trending : Form
    {
        public MainWindow form1;

        public Trending(MainWindow form1)
        {
            InitializeComponent();
            TrendingListBox.View = View.Details;
            TrendingListBox.GridLines = true;
            TrendingListBox.FullRowSelect = true;
            this.form1 = form1;

            OnLoadUpdate();
        }

        private void OnLoadUpdate()
        {
            var result = new Dictionary<string, int>();
            foreach (string value in form1.data.twitterTrending)
            {
                if (result.TryGetValue(value, out int count))
                {
                    result[value] = count + 1;
                }
                else
                {
                    result.Add(value, 1);
                }
            }
            foreach (var item in result)
            {
                var row = new string[] { item.Value.ToString(), item.Key };
                var listItem = new ListViewItem(row);
                TrendingListBox.Items.Add(listItem);
            }
            TrendingListBox.Sorting = SortOrder.Descending;
            TrendingListBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            TrendingListBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }
    }
}
