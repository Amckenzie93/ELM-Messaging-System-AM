namespace ELM__AM
{
    partial class MainWindow
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
            this.SuspendLayout();
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MainWindow";
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Button importAll;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView smsMessagesList;
        private System.Windows.Forms.ColumnHeader smsID;
        private System.Windows.Forms.ColumnHeader smsPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView emailMessageList;
        private System.Windows.Forms.ColumnHeader EmailID;
        private System.Windows.Forms.ColumnHeader EmailBody;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView twitterMessageList;
        private System.Windows.Forms.ColumnHeader TwitterID;
        private System.Windows.Forms.ColumnHeader TwitterMessage;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader smsMessage;
        private System.Windows.Forms.Button ExportJSON;
        private System.Windows.Forms.ColumnHeader EmailAddress;
        private System.Windows.Forms.ColumnHeader EmailSubject;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader TwitterHandle;
        private System.Windows.Forms.Button NewEntry;
        private System.Windows.Forms.Button Quarentine;
        private System.Windows.Forms.Label label1;
    }
}

