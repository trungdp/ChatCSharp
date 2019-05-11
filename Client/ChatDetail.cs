using ChatRealTime.DAO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatDetail : Form
    {
        public ChatDetail()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            addTabPage("Home");
            addTabPage("Server");
            commonSetup();
            lbName.Text = "Reconnect";
            lbName.Enabled = true;
            lbName.ForeColor = Color.Red;
        }

        #region VARS
        public TcpClient clientSocket;
        public NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        Thread ctThread;
        public string name = null;
        List<string> nowChatting = new List<string>();
        List<string> chat = new List<string>();
        List<TabPage> tabList = new List<TabPage>();

        ListBox currentListbox
        {
            get {
                if (tabCtrl.SelectedTab.Controls.Count > 0) {
                    return tabCtrl.SelectedTab.Controls[0] as ListBox;
                }
                return null;
            }
        }
        #endregion


        #region EVENTS
        public void RemoveText(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "Find friend") {
                tbxSearch.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSearch.Text))
                tbxSearch.Text = "Find friend";
        }

        private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (UserStore.Instance.getAllUserName().Contains(tbxSearch.Text)) {
                    selectPage(tbxSearch.Text);
                    tbxSearch.Text = "";
                }
            }
        }

        private void mListBox_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add) {
                if (currentListbox != null) {
                    currentListbox.TopIndex = currentListbox.Items.Count - 1;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try {
                if (!tbMessage.Text.Equals("")) {
                    chat.Clear();
                    switch (tabCtrl.SelectedTab.Text) {
                        case "Home":
                            chat.Add("gChat");
                            chat.Add(tbMessage.Text);
                            break;
                        default:
                            chat.Add("pChat");
                            chat.Add(tabCtrl.SelectedTab.Text);
                            chat.Add(name);
                            chat.Add(tbMessage.Text);
                            break;
                    }

                    byte[] outStream = ObjectToByteArray(chat);

                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    tbMessage.Text = "";
                    chat.Clear();

                    this.currentListbox.Items.Add(tbMessage.Text);
                }
            } catch (Exception ) {

            }
        }

        private void lbName_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void ChatDetail_Load(object sender, EventArgs e)
        {
            connect();
        }

        private void openChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvListName.SelectedItems.Count > 0 && lvListName.SelectedItems[0].Text != name) {
                selectPage(lvListName.SelectedItems[0].Text);
            }
        }

        private void tabCtrl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                if (tabCtrl.GetTabRect(tabCtrl.SelectedIndex).Contains(new Point(e.X, e.Y))) {
                    ctxMenuTripTab.Show(tabCtrl, e.X, e.Y);
                }
            }
        }

        private void deleteItem_Click(Object sender, System.EventArgs e)
        {
            removeTabPage(tabCtrl.SelectedTab.Text);
        }


        private void lvListName_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                if (lvListName.FocusedItem.Bounds.Contains(e.Location )) {
                    menuTripClient.Show(lvListName, e.X, e.Y);
                }
            }
        }

        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCtrl.SelectedTab.Text == "Server") {
                tbMessage.Hide();
                btnSend.Hide();
            } else {
                tbMessage.Show();
                btnSend.Show();
            }
        }

        private void ChatDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to exit? ", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes) {
                try {
                    ctThread.Abort();
                    clientSocket.Close();
                } catch (Exception ee) { }

                Application.ExitThread();
            } else if (dialog == DialogResult.No) {
                e.Cancel = true;
            }
        }
        #endregion

        #region UTILS
        private void commonSetup()
        {
            deleteItem.Click += deleteItem_Click;
            tbxSearch.GotFocus += RemoveText;
            tbxSearch.LostFocus += AddText;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (string key in UserStore.Instance.getAllUserName()) {
                collection.Add(key);
            }
            tbxSearch.AutoCompleteCustomSource = collection;
        }

        private void connect()
        {
            clientSocket = new TcpClient();
            try {
                clientSocket.Connect("127.0.0.1", 5000);
                readData = "Connected to Server ";
                msg();

                serverStream = clientSocket.GetStream();

                byte[] outStream = Encoding.ASCII.GetBytes(name + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                ctThread = new Thread(getMessage);
                ctThread.Start();
            } catch (Exception er) {
                updateMessage("Server Not Started");
            }
        }

        private void addTabPage(string tabname)
        {
            TabPage tab = new TabPage(tabname);
            tabCtrl.TabPages.Add(tab);
            ListBox listBox = new ListBox();
            listBox.Dock = DockStyle.Fill;
            tab.Controls.Add(listBox);
        }

        private void selectPage(string tabname)
        {
            foreach (TabPage page in tabCtrl.TabPages) {
                if (page.Text == tabname) {
                    tabCtrl.SelectedTab = page;
                    return;
                }
            }
            addTabPage(tabname);
            tabCtrl.SelectTab(tabCtrl.TabPages.Count - 1);
        }

        private ListBox findListBox(string tabname)
        {
            try {
                foreach (TabPage page in tabCtrl.TabPages) {
                    if (page.Text == tabname) {
                        return page.Controls[0] as ListBox;
                    }
                }
                return null;
            } catch (Exception) {
                return null;
            }
        }

        private void removeTabPage(string tabname)
        {
            foreach (TabPage page in tabCtrl.TabPages) {
                if (page.Text == tabname) {
                    tabCtrl.TabPages.Remove(page);
                    break;
                }
            }
        }

        public void setName(String title)
        {
            this.Text = title;
            name = title;
        }

        public void updateMessage(String m)
        {
            this.Invoke((MethodInvoker)delegate {
                if (currentListbox != null) {
                    this.currentListbox.Items.Add(">>" + m );
                }
            });
        }

        private ListViewItem createLvItem(string m)
        {
            ListViewItem item = new ListViewItem();
            item.Text = m;
            return item;
        }

        public ListViewItem getLvItem(string text)
        {
            ListViewItem listviewitem = new ListViewItem();
            for (int i = 0; i < lvListName.Items.Count; i++) {
                listviewitem = lvListName.Items[i];
                if (text == listviewitem.Text) {
                    return listviewitem;
                }
            }
            return null;
        }

        public void getUsers(List<string> parts)
        {
            this.Invoke((MethodInvoker)delegate {
                lvListName.Items.Clear();
                for (int i = 1; i < parts.Count; i++) {
                    lvListName.Items.Add(createLvItem(parts[i]));
                }
            });
        }

        private void getMessage()
        {
            try {
                while (true) {
                    serverStream = clientSocket.GetStream();
                    byte[] inStream = new byte[10025];
                    serverStream.Read(inStream, 0, inStream.Length);
                    List<string> parts = null;

                    if (!SocketConnected(clientSocket)) {
                        MessageBox.Show("You've been Disconnected");
                        ctThread.Abort();
                        clientSocket.Close();
                    }

                    parts = (List<string>)ByteArrayToObject(inStream);
                    switch (parts[0]) {
                        case "userList":
                            getUsers(parts);
                            break;

                        case "gChat":
                            this.Invoke((MethodInvoker)delegate {
                                this.findListBox("Home").Items.Add(parts[1]);
                            });
                            break;

                        case "pChat":
                            managePrivateChat(parts);
                            break;
                    }

                    chat.Clear();
                }
            } catch (Exception e) {
                ctThread.Abort();
                clientSocket.Close();
                Console.WriteLine(e);
            }

        }

        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                updateMessage(readData);
        }

        public void managePrivateChat(List<string> parts)
        {
            this.Invoke((MethodInvoker)delegate 
            {
                selectPage(parts[2]);
                updateMessage(parts[3]);
            });
        }


        public byte[] ObjectToByteArray(object _Object)
        {
            using (var stream = new MemoryStream()) {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, _Object);
                return stream.ToArray();
            }
        }

        public Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream()) {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        bool SocketConnected(TcpClient s) //check whether client is connected server
        {
            bool flag = false;
            try {
                bool part1 = s.Client.Poll(10, SelectMode.SelectRead);
                bool part2 = (s.Available == 0);
                if (part1 && part2) {
                    lbName.Text = "Reconnect";
                    lbName.Enabled = true;
                    lbName.ForeColor = Color.Red;
                    flag = false;
                } else {
                    lbName.Text = "Conected";
                    lbName.Enabled = false;
                    lbName.ForeColor = Color.Green;
                    flag = true;
                }
            } catch (Exception er) {
                Console.WriteLine(er);
            }
            return flag;
        }


        #endregion

    }
}
