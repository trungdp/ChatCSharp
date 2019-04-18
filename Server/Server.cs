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
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
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
    }
}
