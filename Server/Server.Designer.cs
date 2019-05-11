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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.btnClose = new System.Windows.Forms.Button();
            this.cbAllow = new System.Windows.Forms.CheckBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lvClient = new System.Windows.Forms.ListView();
            this.ctxMenuClient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disconnectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.ctxMenuHomeTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbxHomeMessage = new System.Windows.Forms.ToolStripTextBox();
            this.btnAllClient = new System.Windows.Forms.Button();
            this.ctxMenuClient.SuspendLayout();
            this.ctxMenuHomeTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(352, 346);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 34);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close Server";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbAllow
            // 
            this.cbAllow.AutoSize = true;
            this.cbAllow.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAllow.Checked = true;
            this.cbAllow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAllow.Location = new System.Drawing.Point(13, 8);
            this.cbAllow.Name = "cbAllow";
            this.cbAllow.Size = new System.Drawing.Size(111, 20);
            this.cbAllow.TabIndex = 15;
            this.cbAllow.Text = "Allow Connect";
            this.cbAllow.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(352, 306);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(146, 34);
            this.btnDisconnect.TabIndex = 14;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessage.Location = new System.Drawing.Point(352, 266);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(146, 34);
            this.btnMessage.TabIndex = 13;
            this.btnMessage.Text = "Send Message";
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxSearch.Location = new System.Drawing.Point(352, 8);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(145, 20);
            this.tbxSearch.TabIndex = 11;
            this.tbxSearch.Text = "Find friend";
            this.tbxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSearch_KeyDown);
            // 
            // lvClient
            // 
            this.lvClient.Location = new System.Drawing.Point(352, 34);
            this.lvClient.Name = "lvClient";
            this.lvClient.Size = new System.Drawing.Size(146, 226);
            this.lvClient.TabIndex = 10;
            this.lvClient.UseCompatibleStateImageBehavior = false;
            this.lvClient.View = System.Windows.Forms.View.List;
            this.lvClient.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvClient_MouseClick);
            // 
            // ctxMenuClient
            // 
            this.ctxMenuClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectItem,
            this.sendMessageItem});
            this.ctxMenuClient.Name = "ctxMenuClient";
            this.ctxMenuClient.Size = new System.Drawing.Size(150, 48);
            // 
            // disconnectItem
            // 
            this.disconnectItem.Name = "disconnectItem";
            this.disconnectItem.Size = new System.Drawing.Size(149, 22);
            this.disconnectItem.Text = "Disconnect";
            this.disconnectItem.Click += new System.EventHandler(this.disconnectItem_Click);
            // 
            // sendMessageItem
            // 
            this.sendMessageItem.Name = "sendMessageItem";
            this.sendMessageItem.Size = new System.Drawing.Size(149, 22);
            this.sendMessageItem.Text = "Send message";
            this.sendMessageItem.Click += new System.EventHandler(this.sendMessageItem_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Location = new System.Drawing.Point(13, 34);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(333, 345);
            this.tabCtrl.TabIndex = 22;
            this.tabCtrl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabCtrl_MouseClick);
            // 
            // ctxMenuHomeTab
            // 
            this.ctxMenuHomeTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbxHomeMessage});
            this.ctxMenuHomeTab.Name = "ctxMenuHomeTab";
            this.ctxMenuHomeTab.Size = new System.Drawing.Size(161, 29);
            // 
            // tbxHomeMessage
            // 
            this.tbxHomeMessage.Name = "tbxHomeMessage";
            this.tbxHomeMessage.Size = new System.Drawing.Size(100, 23);
            this.tbxHomeMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxHomeMessage_KeyDown);
            // 
            // btnAllClient
            // 
            this.btnAllClient.Location = new System.Drawing.Point(271, 6);
            this.btnAllClient.Name = "btnAllClient";
            this.btnAllClient.Size = new System.Drawing.Size(75, 23);
            this.btnAllClient.TabIndex = 24;
            this.btnAllClient.Text = "All Client";
            this.btnAllClient.UseVisualStyleBackColor = true;
            this.btnAllClient.Click += new System.EventHandler(this.btnAllClient_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 390);
            this.Controls.Add(this.btnAllClient);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbAllow);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lvClient);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.Load += new System.EventHandler(this.Server_Load);
            this.ctxMenuClient.ResumeLayout(false);
            this.ctxMenuHomeTab.ResumeLayout(false);
            this.ctxMenuHomeTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TbxSearch_GotFocus(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox cbAllow;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnMessage;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.ListView lvClient;
        private System.Windows.Forms.ContextMenuStrip ctxMenuClient;
        private System.Windows.Forms.ToolStripMenuItem disconnectItem;
        private System.Windows.Forms.ToolStripMenuItem sendMessageItem;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.ContextMenuStrip ctxMenuHomeTab;
        private System.Windows.Forms.ToolStripTextBox tbxHomeMessage;
        private System.Windows.Forms.Button btnAllClient;
    }
}

