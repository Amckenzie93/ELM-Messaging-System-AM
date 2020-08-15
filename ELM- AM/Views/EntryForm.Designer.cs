namespace ELM__AM
{
    partial class EntryForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.MessageBody = new System.Windows.Forms.TextBox();
            this.MessageHeader = new System.Windows.Forms.TextBox();
            this.BasicError = new System.Windows.Forms.Label();
            this.BasicInstructions = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.errorBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(326, 534);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(113, 41);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(204, 534);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(107, 41);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(22, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Entry Form Basic";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 15);
            this.label12.TabIndex = 13;
            this.label12.Text = "Message Header";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 15);
            this.label14.TabIndex = 13;
            this.label14.Text = "Message Body";
            // 
            // MessageBody
            // 
            this.MessageBody.AcceptsReturn = true;
            this.MessageBody.AcceptsTab = true;
            this.MessageBody.AllowDrop = true;
            this.MessageBody.BackColor = System.Drawing.Color.GhostWhite;
            this.MessageBody.Location = new System.Drawing.Point(22, 160);
            this.MessageBody.MaxLength = 1024;
            this.MessageBody.Multiline = true;
            this.MessageBody.Name = "MessageBody";
            this.MessageBody.Size = new System.Drawing.Size(417, 156);
            this.MessageBody.TabIndex = 5;
            // 
            // MessageHeader
            // 
            this.MessageHeader.BackColor = System.Drawing.Color.GhostWhite;
            this.MessageHeader.Location = new System.Drawing.Point(22, 100);
            this.MessageHeader.MaxLength = 10;
            this.MessageHeader.Name = "MessageHeader";
            this.MessageHeader.Size = new System.Drawing.Size(417, 23);
            this.MessageHeader.TabIndex = 5;
            // 
            // BasicError
            // 
            this.BasicError.Location = new System.Drawing.Point(0, 0);
            this.BasicError.Name = "BasicError";
            this.BasicError.Size = new System.Drawing.Size(100, 23);
            this.BasicError.TabIndex = 15;
            // 
            // BasicInstructions
            // 
            this.BasicInstructions.AutoSize = true;
            this.BasicInstructions.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BasicInstructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BasicInstructions.Location = new System.Drawing.Point(24, 336);
            this.BasicInstructions.Name = "BasicInstructions";
            this.BasicInstructions.Size = new System.Drawing.Size(113, 15);
            this.BasicInstructions.TabIndex = 13;
            this.BasicInstructions.Text = "Message Structures:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(31, 356);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(202, 15);
            this.label15.TabIndex = 13;
            this.label15.Text = "SMS          :  Message, Phone number";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(31, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(255, 15);
            this.label16.TabIndex = 13;
            this.label16.Text = "Email         :  Subject, Sender Address,  Message";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(31, 397);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(408, 15);
            this.label17.TabIndex = 13;
            this.label17.Text = "SIR Email  :  Subject, Sender Address,  Message, Branch Code, Incident Code";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(30, 418);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(177, 15);
            this.label18.TabIndex = 13;
            this.label18.Text = "Twitter       :  Sender ID, Message";
            // 
            // errorBox
            // 
            this.errorBox.BackColor = System.Drawing.SystemColors.Control;
            this.errorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorBox.ForeColor = System.Drawing.Color.OrangeRed;
            this.errorBox.Location = new System.Drawing.Point(22, 444);
            this.errorBox.Name = "errorBox";
            this.errorBox.Size = new System.Drawing.Size(417, 75);
            this.errorBox.TabIndex = 14;
            this.errorBox.Text = "";
            // 
            // EntryForm
            // 
            this.ClientSize = new System.Drawing.Size(465, 593);
            this.ControlBox = false;
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.BasicInstructions);
            this.Controls.Add(this.BasicError);
            this.Controls.Add(this.MessageHeader);
            this.Controls.Add(this.MessageBody);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.AddButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox MessageBody;
        private System.Windows.Forms.TextBox MessageHeader;
        private System.Windows.Forms.Label BasicError;
        private System.Windows.Forms.Label BasicInstructions;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RichTextBox errorBox;
    }
}

