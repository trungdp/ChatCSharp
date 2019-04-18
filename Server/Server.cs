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
        ServerManager serverManager = new ServerManager(IPAddress.Any,5000);
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
            SendMessage sendMessageForm = new SendMessage();
            sendMessageForm.ShowDialog();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect disconnectForm = new Disconnect();
            disconnectForm.ShowDialog();
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
    }
}
