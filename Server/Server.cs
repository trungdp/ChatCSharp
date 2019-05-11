using ChatRealTime.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

namespace Server
{
    public partial class Server : Form
    {

        #region VARS
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
        TcpClient client;
        String clNo;
        Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();
        CancellationTokenSource cancellation = new CancellationTokenSource();
        List<string> chat = new List<string>();

        ListBox currentListbox
        {
            get {
                if (tabCtrl.SelectedTab.Controls.Count > 0) {
                    return tabCtrl.SelectedTab.Controls[0] as ListBox;
                } else {
                    ListBox listBox = new ListBox();
                    tabCtrl.SelectedTab.Controls.Add(listBox);
                    return listBox;
                }
            }
        }
        #endregion 


        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            addTabPage("Home");
            commonSetup();
        }

        #region  EVENTS
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

        private void Server_Load(object sender, EventArgs e)
        {
            cancellation = new CancellationTokenSource();
            startServer();
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

        private void btnMessage_Click(object sender, EventArgs e)
        {
            try {
                SendMessage sendMessageForm = new SendMessage();
                List<string> parts = new List<string>();
                foreach (string key in clientList.Keys) {
                    sendMessageForm.inputList.Add(key);
                }
                this.Hide();
                sendMessageForm.ShowDialog();
                this.Show();
                if (sendMessageForm.outputList.Count > 0) {
                    foreach (string name in sendMessageForm.outputList) {
                        parts.Add("pChat");
                        parts.Add(name);
                        parts.Add("Server");
                        parts.Add(sendMessageForm.message);
                        privateChat(parts);
                    }
                }
            } catch (SocketException se) {
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect disconnectForm = new Disconnect();
            foreach (string key in clientList.Keys) {
                disconnectForm.inputList.Add(key);
            }
            this.Hide();
            disconnectForm.ShowDialog();
            this.Show();
            if (disconnectForm.outputList.Count > 0) {
                foreach (string name in disconnectForm.outputList) {
                    TcpClient workerSocket = null;
                    workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == name).Value;
                    workerSocket.Close();
                }
            }
        }

        private void disconnectItem_Click(object sender, EventArgs e)
        {
            try {
                TcpClient workerSocket = null;
                foreach (ListViewItem item in lvClient.SelectedItems) {
                    workerSocket = null;
                    workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == item.Text).Value; 
                    workerSocket.Close();
                }
            } catch (SocketException se) {
            }
        }

        private void sendMessageItem_Click(object sender, EventArgs e)
        {
            SingleMessage form = new SingleMessage();
            form.ShowDialog();
            if (!String.IsNullOrEmpty(form.message) && lvClient.SelectedItems.Count > 0) {
                byte[] byData = ObjectToByteArray(chat);
                foreach (ListViewItem item in lvClient.SelectedItems) {
                    List<string> parts = new List<string>();
                    parts.Add("pChat");
                    parts.Add(item.Text);
                    parts.Add("Server");
                    parts.Add("Server : " + form.message);
                    privateChat(parts);
                }
            }
        }

        private void lvClient_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                if (lvClient.FocusedItem.Bounds.Contains(e.Location)) {
                    ctxMenuClient.Show(lvClient, e.X, e.Y);
                }
            }
        }

        private void tabCtrl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                ctxMenuHomeTab.Show(tabCtrl, e.X, e.Y);
            }
        }

        private void btnAllClient_Click(object sender, EventArgs e)
        {
            AllClient allClientForm = new AllClient();
            foreach (string key in clientList.Keys) {
                allClientForm.onlineClient.Add(key);
            }
            allClientForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (cbAllow.Checked) {
                try {
                    listener.Stop();
                    updateUI("Server Stopped");
                    foreach (TcpClient item in clientList.Values) {
                        item.Close();
                    }
                    cbAllow.Checked = false;
                    btnClose.Text = "Start Server";
                } catch (SocketException er) {

                }
            } else {
                startServer();
                cbAllow.Checked = true;
                btnClose.Text = "Close Server";
            }
        }

        private void tbxHomeMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(tbxHomeMessage.Text)) {
                globalChat(tbxHomeMessage.Text, "Server", true);
                this.findListBox("Home").Items.Add("Server: " + tbxHomeMessage.Text);
                ctxMenuHomeTab.Hide();
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                listener.Stop();
                updateUI("Server Stopped");
                foreach (TcpClient item in clientList.Values) {
                    item.Close();
                }
                Process.GetCurrentProcess().Kill();
            } catch (SocketException er) {

            }
        }
        #endregion

        #region UTILS
        private void commonSetup()
        {
            tbxSearch.GotFocus += RemoveText;
            tbxSearch.LostFocus += AddText;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (string key in UserStore.Instance.getAllUserName()) {
                collection.Add(key);
            }
            tbxSearch.AutoCompleteCustomSource = collection;
        }

        public void updateUI(String m)
        {
            this.Invoke((MethodInvoker)delegate 
            {
                this.currentListbox.Items.Add(">>" + m );
            });
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
                    tabCtrl.SelectTab(page);
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

        private ListViewItem createLvItem(string m)
        {
            ListViewItem item = new ListViewItem();
            item.Text = m;
            return item;
        }

        public ListViewItem getLvItem(string text)
        {
            ListViewItem listviewitem = new ListViewItem();
            for (int i = 0; i < lvClient.Items.Count; i++) {
                listviewitem = lvClient.Items[i];
                if (text == listviewitem.Text) {
                    return listviewitem;
                }
            }
            return null;
        }

        void createFakeClient(List<string> data)
        {
            foreach ( string name in data) {
                lvClient.Items.Add(createLvItem(name));
            };
        }

        public async void startServer()
        {
            listener.Start();
            updateUI("Server Started at " + listener.LocalEndpoint);
            updateUI("Waiting for Clients");
            try {
                int counter = 0;
                while (true) {
                    counter++;
                    client = await Task.Run(() => listener.AcceptTcpClientAsync(), cancellation.Token);
                    
                    byte[] name = new byte[50];
                    NetworkStream stre = client.GetStream(); 
                    stre.Read(name, 0, name.Length); 
                    String username = Encoding.ASCII.GetString(name);
                    username = username.Substring(0, username.IndexOf("$"));
                    
                    clientList.Add(username, client);
                    lvClient.Items.Add(createLvItem(username));

                    this.Invoke((MethodInvoker)delegate
                    {
                        this.findListBox("Home").Items.Add(username + " connected ");
                    });
                    globalChat(username + " Joined ", username, false);

                    await Task.Delay(1000).ContinueWith(t => sendUsersList());
                    var c = new Thread(() => ServerReceive(client, username));
                    c.Start();
                }
            } catch (Exception) {
                listener.Stop();
            }
        }

        public void globalChat(string msg, string uName, bool flag)
        {
            try {
                foreach (var Item in clientList) {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    if (flag) {
                        chat.Add("gChat");
                        chat.Add(uName + " says : " + msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    } else {
                        chat.Add("gChat");
                        chat.Add(msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    }

                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                    chat.Clear();
                }
            } catch (Exception er) {

            }
        }  //end broadcast function


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

        public byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream()) {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public void ServerReceive(TcpClient clientn, String username)
        {
            byte[] data = new byte[1000];
            String text = null;
            while (true) {
                try {
                    NetworkStream stream = clientn.GetStream(); //Gets The Stream of The Connection
                    stream.Read(data, 0, data.Length); //Receives Data 
                    List<string> parts = (List<string>)ByteArrayToObject(data);

                    switch (parts[0]) {
                        case "gChat":
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.currentListbox.Items.Add(username + ": " + parts[1]);
                            });
                            globalChat(parts[1], username, true);
                            break;

                        case "pChat":
                            if (parts[1] == "Server") {
                                selectPage(parts[2]);
                                this.currentListbox.Items.Add(parts[2] + ": " + parts[3]);
                            } else {
                                privateChat(parts);
                            }
                            break;
                    }
                    parts.Clear();
                } catch (Exception r) {
                    this.findListBox("Home").Items.Add(username + " disconnected ");
                    globalChat("Client Disconnected: " + username + "$", username, false);
                    clientList.Remove(username);
                    lvClient.Items.Remove(getLvItem(username));
                    sendUsersList();
                    break;
                }
            }
        }

        public void sendUsersList()
        {
            try {
                byte[] userList = new byte[1024];
                List<string> users = new List<string>();

                users.Add("userList");
                if (lvClient.Items.Count > 0) {
                    foreach (ListViewItem item in lvClient.Items) {
                        users.Add(item.Text);
                    }
                }
                
                userList = ObjectToByteArray(users);

                foreach (var Item in clientList) {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    broadcastStream.Write(userList, 0, userList.Length);
                    broadcastStream.Flush();
                    users.Clear();
                }
            } catch (SocketException se) {
            }
        }

        private void privateChat(List<string> text)
        {
            try {
                byte[] byData = ObjectToByteArray(text);
                TcpClient workerSocket = null;
                workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == text[1]).Value; 

                NetworkStream stm = workerSocket.GetStream();
                stm.Write(byData, 0, byData.Length);
                stm.Flush();
            } catch (SocketException se) {

            }
        }
        #endregion

        
    }
}
