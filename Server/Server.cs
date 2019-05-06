using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        List<string> data = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        ServerManager serverManager = new ServerManager(IPAddress.Any, 5000);
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            serverManager.SetDataFunction = new ServerManager.SetDataControl(AddLog);
            serverManager.Listen();
        }

        private void AddLog(string data)
        {
            this.lbxLog.Items.Add(data);
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            SendMessage sendMessageForm = new SendMessage(data);
            sendMessageForm.ShowDialog();
            foreach (string item in sendMessageForm.outputList)
            {
                AddLog(item);
            }
            AddLog(sendMessageForm.message);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect disconnectForm = new Disconnect(data);
            disconnectForm.ShowDialog();
            foreach (string item in disconnectForm.outputList)
            {
                AddLog(item);
            }
        }

        private void cbAllow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllow.Checked)
            {
                serverManager.Listen();
            }
            else
            {
                serverManager.Close();
                AddLog("Da dong ket noi");
            }
        }

        private void SearchClick(object sender, EventArgs e)
        {
            lvClient.SelectedItems.Clear();
            for (int i = lvClient.Items.Count - 1; i >= 0; i--)
            {
                if (lvClient.Items[i].ToString().ToLower().Contains(tbxSearch.Text.ToLower()))
                {
                    lvClient.Items[i].Selected = true;
                    lvClient.Select();
                }
            }
        }

        private void OnTextChange(object sender, EventArgs e)
        {
        }

        private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lvClient.Items.Add(tbxSearch.Text);
                tbxSearch.Text = "";
            }
        }
    }
}
