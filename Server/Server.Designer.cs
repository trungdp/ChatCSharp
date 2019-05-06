namespace Server
{
    partial class Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbAllow = new System.Windows.Forms.CheckBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lvClient = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxLog
            // 
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.Location = new System.Drawing.Point(12, 34);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(465, 394);
            this.lbxLog.TabIndex = 17;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(483, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(189, 34);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close Server";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // cbAllow
            // 
            this.cbAllow.AutoSize = true;
            this.cbAllow.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAllow.Checked = true;
            this.cbAllow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAllow.Location = new System.Drawing.Point(21, 8);
            this.cbAllow.Name = "cbAllow";
            this.cbAllow.Size = new System.Drawing.Size(111, 20);
            this.cbAllow.TabIndex = 15;
            this.cbAllow.Text = "Allow Connect";
            this.cbAllow.UseVisualStyleBackColor = true;
            this.cbAllow.CheckedChanged += new System.EventHandler(this.cbAllow_CheckedChanged);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(483, 356);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(189, 34);
            this.btnDisconnect.TabIndex = 14;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessage.Location = new System.Drawing.Point(483, 316);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(189, 34);
            this.btnMessage.TabIndex = 13;
            this.btnMessage.Text = "Send Message";
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(556, 11);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(115, 20);
            this.tbxSearch.TabIndex = 11;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            this.tbxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSearch_KeyDown);
            // 
            // lvClient
            // 
            this.lvClient.Location = new System.Drawing.Point(483, 37);
            this.lvClient.Name = "lvClient";
            this.lvClient.Size = new System.Drawing.Size(189, 273);
            this.lvClient.TabIndex = 10;
            this.lvClient.UseCompatibleStateImageBehavior = false;
            this.lvClient.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(482, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Find client";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 437);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbAllow);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lvClient);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox cbAllow;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnMessage;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.ListView lvClient;
        private System.Windows.Forms.Label label1;
    }
}

