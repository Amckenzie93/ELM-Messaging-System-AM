namespace ELM__AM
{
    partial class Trending
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TrendingListBox = new System.Windows.Forms.ListView();
            this.TwitterCount = new System.Windows.Forms.ColumnHeader();
            this.TwitterUser = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // TrendingListBox
            // 
            this.TrendingListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TwitterCount,
            this.TwitterUser});
            this.TrendingListBox.HideSelection = false;
            this.TrendingListBox.Location = new System.Drawing.Point(12, 58);
            this.TrendingListBox.Name = "TrendingListBox";
            this.TrendingListBox.Size = new System.Drawing.Size(346, 399);
            this.TrendingListBox.TabIndex = 0;
            this.TrendingListBox.UseCompatibleStateImageBehavior = false;
            // 
            // TwitterCount
            // 
            this.TwitterCount.Name = "TwitterCount";
            this.TwitterCount.Text = "Count";
            this.TwitterCount.Width = 150;
            // 
            // TwitterUser
            // 
            this.TwitterUser.Name = "TwitterUser";
            this.TwitterUser.Text = "Twitter User";
            this.TwitterUser.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trendinig List";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(228, 473);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(130, 40);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Close";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Trending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 525);
            this.ControlBox = false;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrendingListBox);
            this.Name = "Trending";
            this.Text = "Trending";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TrendingListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ColumnHeader TwitterCount;
        private System.Windows.Forms.ColumnHeader TwitterUser;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}