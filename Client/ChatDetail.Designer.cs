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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lvListName = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.lbName = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.menuTripClient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuTripTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.menuTripClient.SuspendLayout();
            this.ctxMenuTripTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 20);
            this.textBox1.TabIndex = 13;
            // 
            // lvListName
            // 
            this.lvListName.Location = new System.Drawing.Point(12, 38);
            this.lvListName.Name = "lvListName";
            this.lvListName.Size = new System.Drawing.Size(173, 397);
            this.lvListName.TabIndex = 12;
            this.lvListName.UseCompatibleStateImageBehavior = false;
            this.lvListName.View = System.Windows.Forms.View.List;
            this.lvListName.DoubleClick += new System.EventHandler(this.lvListName_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLogout);
            this.panel3.Controls.Add(this.tabCtrl);
            this.panel3.Controls.Add(this.lbName);
            this.panel3.Controls.Add(this.tbMessage);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Location = new System.Drawing.Point(191, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 433);
            this.panel3.TabIndex = 11;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(442, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 26);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Location = new System.Drawing.Point(4, 36);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(512, 319);
            this.tabCtrl.TabIndex = 7;
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
            this.tbMessage.Location = new System.Drawing.Point(4, 396);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(423, 36);
            this.tbMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(433, 396);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 37);
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
            this.deleteItem.Size = new System.Drawing.Size(180, 22);
            this.deleteItem.Text = "delete";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Find client";
            // 
            // ChatDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lvListName);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ChatDetail_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuTripClient.ResumeLayout(false);
            this.ctxMenuTripTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView lvListName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.ContextMenuStrip menuTripClient;
        private System.Windows.Forms.ToolStripMenuItem openChatToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTripTab;
        private System.Windows.Forms.ToolStripMenuItem deleteItem;
        private System.Windows.Forms.Label label1;
    }
}

