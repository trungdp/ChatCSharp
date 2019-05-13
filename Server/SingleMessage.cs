using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{   /// <summary>
/// Class SingleMessage dùng để gửi tin nhắn cho 1 user.
/// </summary>
    public partial class SingleMessage : Form
    {
        public string message;

        public SingleMessage()
        {
            InitializeComponent();
            tbMessage.GotFocus += RemoveText;
            tbMessage.LostFocus += AddText;
            tbMessage.Focus();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbMessage.Text != "Enter text here...") {
                message = tbMessage.Text;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (tbMessage.Text == "Enter text here...") {
                tbMessage.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMessage.Text))
                tbMessage.Text = "Enter text here...";
        }
    }
}
