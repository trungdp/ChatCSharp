using ChatRealTime.DAO;
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
    public partial class AllClient : Form
    {
        private List<string> allClient = new List<string>();
        public List<string> onlineClient = new List<string>();
        public AllClient()
        {
            InitializeComponent();
            allClient = UserStore.Instance.getAllUserName();
        }

        private void AllClient_Shown(object sender, EventArgs e)
        {
            foreach (string client in allClient) {
                ListViewItem item = new ListViewItem(client);
                lvClient.Items.Add(item);
            }

            foreach (ListViewItem item in lvClient.Items) {
                if (onlineClient.Contains(item.Text)) {
                    item.SubItems.Add("online");
                } else {
                    item.SubItems.Add("offline");
                }
            }
        }
    }
}
