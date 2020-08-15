namespace ELM__AM
{
    partial class Mentions
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
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.MentionsListBox = new System.Windows.Forms.ListView();
            this.MessageID = new System.Windows.Forms.ColumnHeader();
            this.MessageSender = new System.Windows.Forms.ColumnHeader();
            this.MessageMention = new System.Windows.Forms.ColumnHeader();
            this.FullMessage = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Twitter Mentions List";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(705, 473);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(134, 40);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Close";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click_1);
            // 
            // MentionsListBox
            // 
            this.MentionsListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MessageID,
            this.MessageSender,
            this.MessageMention,
            this.FullMessage});
            this.MentionsListBox.HideSelection = false;
            this.MentionsListBox.Location = new System.Drawing.Point(12, 55);
            this.MentionsListBox.Name = "MentionsListBox";
            this.MentionsListBox.Size = new System.Drawing.Size(827, 397);
            this.MentionsListBox.TabIndex = 3;
            this.MentionsListBox.UseCompatibleStateImageBehavior = false;
            // 
            // MessageID
            // 
            this.MessageID.Name = "MessageID";
            this.MessageID.Text = "Message ID";
            // 
            // MessageSender
            // 
            this.MessageSender.Name = "MessageSender";
            this.MessageSender.Text = "Sender";
            // 
            // MessageMention
            // 
            this.MessageMention.Name = "MessageMention";
            this.MessageMention.Text = "Message Mention";
            // 
            // FullMessage
            // 
            this.FullMessage.Name = "FullMessage";
            this.FullMessage.Text = "Full Message";
            // 
            // Mentions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 525);
            this.ControlBox = false;
            this.Controls.Add(this.MentionsListBox);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label1);
            this.Name = "Mentions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mentions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ListView MentionsListBox;
        private System.Windows.Forms.ColumnHeader MessageID;
        private System.Windows.Forms.ColumnHeader MessageSender;
        private System.Windows.Forms.ColumnHeader MessageMention;
        private System.Windows.Forms.ColumnHeader FullMessage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}