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

namespace Client
{
    public partial class ChatDetail : Form
    {
        ClientManager clientManager = new ClientManager();
        public ChatDetail()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            clientManager.SetDataFunction = new ClientManager.SetDataControl(AddMessage);
            clientManager.Connect(IPAddress.Parse("127.0.0.1"), 5000);
        }

        private void AddMessage(string message)
        {
            this.lbxMessage.Items.Add(message);
        }

        

        private void btnSend_Click(object sender, EventArgs e)
        {
            clientManager.SendData(this.tbMessage.Text);
            this.tbMessage.Text = "";
        }
    }
}
