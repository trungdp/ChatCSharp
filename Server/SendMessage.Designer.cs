namespace Server
{
    partial class SendMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMessage));
            this.btnSend = new System.Windows.Forms.Button();
            this.tbxEnterMessage = new System.Windows.Forms.TextBox();
            this.clbxClient = new System.Windows.Forms.CheckedListBox();
            this.btnEmoji = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.dialogFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(245, 253);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(89, 34);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbxEnterMessage
            // 
            this.tbxEnterMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEnterMessage.Location = new System.Drawing.Point(12, 253);
            this.tbxEnterMessage.Multiline = true;
            this.tbxEnterMessage.Name = "tbxEnterMessage";
            this.tbxEnterMessage.Size = new System.Drawing.Size(227, 33);
            this.tbxEnterMessage.TabIndex = 4;
            // 
            // clbxClient
            // 
            this.clbxClient.FormattingEnabled = true;
            this.clbxClient.Location = new System.Drawing.Point(12, 12);
            this.clbxClient.Name = "clbxClient";
            this.clbxClient.Size = new System.Drawing.Size(322, 199);
            this.clbxClient.TabIndex = 3;
            // 
            // btnEmoji
            // 
            this.btnEmoji.Location = new System.Drawing.Point(270, 217);
            this.btnEmoji.Name = "btnEmoji";
            this.btnEmoji.Size = new System.Drawing.Size(64, 30);
            this.btnEmoji.TabIndex = 6;
            this.btnEmoji.Text = "Emoji";
            this.btnEmoji.UseVisualStyleBackColor = true;
            this.btnEmoji.Click += new System.EventHandler(this.btnEmoji_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(200, 217);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(64, 30);
            this.btnFile.TabIndex = 7;
            this.btnFile.Text = "File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // dialogFile
            // 
            this.dialogFile.DefaultExt = "txt";
            this.dialogFile.FileName = "openFileDialog1";
            this.dialogFile.InitialDirectory = "C:\\";
            this.dialogFile.RestoreDirectory = true;
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 296);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnEmoji);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbxEnterMessage);
            this.Controls.Add(this.clbxClient);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SendMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendMessage";
            this.Shown += new System.EventHandler(this.SendMessage_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbxEnterMessage;
        private System.Windows.Forms.CheckedListBox clbxClient;
        private System.Windows.Forms.Button btnEmoji;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.OpenFileDialog dialogFile;
    }
}