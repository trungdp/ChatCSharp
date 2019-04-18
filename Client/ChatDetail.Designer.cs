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
            this.lvListName = new System.Windows.Forms.ListView();
            this.lbName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbType = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvListName
            // 
            this.lvListName.Location = new System.Drawing.Point(12, 35);
            this.lvListName.Name = "lvListName";
            this.lvListName.Size = new System.Drawing.Size(173, 397);
            this.lvListName.TabIndex = 8;
            this.lvListName.UseCompatibleStateImageBehavior = false;
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
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.lbName);
            this.panel3.Controls.Add(this.tbType);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Location = new System.Drawing.Point(191, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 444);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(4, 365);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(628, 25);
            this.panel2.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(4, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(628, 323);
            this.panel4.TabIndex = 2;
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(4, 396);
            this.tbType.Multiline = true;
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(540, 36);
            this.tbType.TabIndex = 1;
            this.tbType.TextChanged += new System.EventHandler(this.tbType_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(549, 396);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 36);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 20);
            this.textBox1.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(135, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 21);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.lvListName);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 444);
            this.panel1.TabIndex = 5;
            // 
            // ChatDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(836, 443);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "ChatDetail";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvListName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

