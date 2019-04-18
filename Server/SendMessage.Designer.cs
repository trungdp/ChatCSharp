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
            this.clbxClient = new System.Windows.Forms.CheckedListBox();
            this.tbxEnterMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clbxClient
            // 
            this.clbxClient.FormattingEnabled = true;
            this.clbxClient.Location = new System.Drawing.Point(12, 12);
            this.clbxClient.Name = "clbxClient";
            this.clbxClient.Size = new System.Drawing.Size(483, 199);
            this.clbxClient.TabIndex = 0;
            // 
            // tbxEnterMessage
            // 
            this.tbxEnterMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEnterMessage.Location = new System.Drawing.Point(12, 253);
            this.tbxEnterMessage.Multiline = true;
            this.tbxEnterMessage.Name = "tbxEnterMessage";
            this.tbxEnterMessage.Size = new System.Drawing.Size(387, 33);
            this.tbxEnterMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(405, 252);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(89, 34);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // SendMessage
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 298);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbxEnterMessage);
            this.Controls.Add(this.clbxClient);
            this.Name = "SendMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbxClient;
        private System.Windows.Forms.TextBox tbxEnterMessage;
        private System.Windows.Forms.Button btnSend;
    }
}