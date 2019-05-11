namespace Client
{
    partial class ChatDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatDetail));
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lvListName = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.lbName = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.menuTripClient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuTripTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3.SuspendLayout();
            this.menuTripClient.SuspendLayout();
            this.ctxMenuTripTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxSearch
            // 
            this.tbxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxSearch.Location = new System.Drawing.Point(12, 8);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(126, 20);
            this.tbxSearch.TabIndex = 13;
            this.tbxSearch.Text = "Find friend";
            this.tbxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSearch_KeyDown);
            // 
            // lvListName
            // 
            this.lvListName.Location = new System.Drawing.Point(12, 38);
            this.lvListName.Name = "lvListName";
            this.lvListName.Size = new System.Drawing.Size(126, 340);
            this.lvListName.TabIndex = 12;
            this.lvListName.UseCompatibleStateImageBehavior = false;
            this.lvListName.View = System.Windows.Forms.View.List;
            this.lvListName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvListName_MouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabCtrl);
            this.panel3.Controls.Add(this.lbName);
            this.panel3.Controls.Add(this.tbMessage);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Location = new System.Drawing.Point(144, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 383);
            this.panel3.TabIndex = 11;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Location = new System.Drawing.Point(4, 36);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(321, 274);
            this.tabCtrl.TabIndex = 7;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
            this.tabCtrl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabCtrl_MouseClick);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.lbName.Location = new System.Drawing.Point(3, 5);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(76, 27);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "label1";
            this.lbName.Click += new System.EventHandler(this.lbName_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(4, 340);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(230, 36);
            this.tbMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(240, 340);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(85, 37);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // menuTripClient
            // 
            this.menuTripClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openChatToolStripMenuItem});
            this.menuTripClient.Name = "contextMenuStrip1";
            this.menuTripClient.Size = new System.Drawing.Size(130, 26);
            // 
            // openChatToolStripMenuItem
            // 
            this.openChatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openChatToolStripMenuItem.Image")));
            this.openChatToolStripMenuItem.Name = "openChatToolStripMenuItem";
            this.openChatToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.openChatToolStripMenuItem.Text = "Open chat";
            this.openChatToolStripMenuItem.Click += new System.EventHandler(this.openChatToolStripMenuItem_Click);
            // 
            // ctxMenuTripTab
            // 
            this.ctxMenuTripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItem});
            this.ctxMenuTripTab.Name = "ctxMenuTripTab";
            this.ctxMenuTripTab.Size = new System.Drawing.Size(107, 26);
            // 
            // deleteItem
            // 
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(106, 22);
            this.deleteItem.Text = "delete";
            // 
            // ChatDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 384);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lvListName);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatDetail_FormClosing);
            this.Load += new System.EventHandler(this.ChatDetail_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuTripClient.ResumeLayout(false);
            this.ctxMenuTripTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.ListView lvListName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.ContextMenuStrip menuTripClient;
        private System.Windows.Forms.ToolStripMenuItem openChatToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTripTab;
        private System.Windows.Forms.ToolStripMenuItem deleteItem;
    }
}

