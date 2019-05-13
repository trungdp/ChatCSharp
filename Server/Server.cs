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
    /// <summary>
    /// Class server xử lý  yêu cầu từ client và phản hồi.
    /// </summary>
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
            CheckForIllegalCrossThreadCalls = false; // Cho phép các thread sử dụng chung tài nguyên.
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

        /// <summary>
        /// Mở ra from SendMessage 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        // Mở ra form Disconnect
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

        /// <summary>
        /// Hàm updateUI(String m) để thêm message text vào listbox hiện tại.
        /// this.Invoke((MethodInvoker)delegate: đoạn code khởi chạy một thread khác,
        /// khi có một thread cần dùng tài nguyên thì các thread khác bị "lock" cho tới khi thread kia hoàn thành
        /// tác vụ ( thread safe )
        /// </summary>
        /// <param name="m"></param>
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

        /// <summary>
        /// HÀm startServer cho phép server lắng nghe kết nối, nếu xảy ra lỗi thì dừng server
        /// </summary>
        public async void startServer()
        {
            listener.Start();
            updateUI("Server Started at " + listener.LocalEndpoint);
            updateUI("Waiting for Clients");
            try {
                int counter = 0;
                while (true) {
                    counter++;
                    // Gán TCPClient vừa kết nối cho biến client.
                    client = await Task.Run(() => listener.AcceptTcpClientAsync(), cancellation.Token);
                    // Đọc dữ liệu gửi lên.
                    byte[] name = new byte[50];
                    NetworkStream stre = client.GetStream(); 
                    stre.Read(name, 0, name.Length); 
                    String username = Encoding.ASCII.GetString(name);
                    username = username.Substring(0, username.IndexOf("$"));
                    // Thêm biến client vào dictionary clientList.
                    clientList.Add(username, client);
                    lvClient.Items.Add(createLvItem(username));
                    // Gửi tin nhắn xuống các client.
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.findListBox("Home").Items.Add(username + " connected ");
                    });
                    globalChat(username + " Joined ", username, false);
                    // Gửi UserList xuống các client.
                    await Task.Delay(1000).ContinueWith(t => sendUsersList());
                    var c = new Thread(() => ServerReceive(client, username));
                    c.Start();
                }
            } catch (Exception) {
                listener.Stop();// Dừng server.
            }
        }

        /// <summary>
        /// Hàm globalChat gửi tin nhắn xuống toàn bộ client.
        /// </summary>
        /// <param name="msg"> tin nhắn </param>
        /// <param name="uName"> người gửi </param>
        /// <param name="flag"> nếu là tin nhắn của mình -> flag = false </param>
        public void globalChat(string msg, string uName, bool flag)
        {
            try {
                foreach (var Item in clientList) {// duyệt tất cả client.
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;
                    // Lấy tin nhắn từ client và thiết lập tin nhắn cho tất cả client.
                    if (flag) {
                        chat.Add("gChat");
                        chat.Add(uName + " says : " + msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    } else {
                        chat.Add("gChat");
                        chat.Add(msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    }
                    // Gửi tin nhắn
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                    chat.Clear();
                }
            } catch (Exception er) {

            }
        }  //end broadcast function

        /// <summary>
        /// Chuyển đổi mảng byte[] thành object
        /// </summary>
        /// <param name="arrBytes"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Chuyển object thảnh mảng byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream()) {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        // Hàm ServerReceive để nhận tin nhắn từ client và phản hồi lại,
        // Nếu xảy ra lỗi thì đóng TCPClient
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
                        case "gChat":// nếu là tin nhắn global thì thêm vào tab hiện tại 
                                     // và gửi cho tất cả các client
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.currentListbox.Items.Add(username + ": " + parts[1]);
                            });
                            globalChat(parts[1], username, true);
                            break;

                            // nếu là private chat thì mở tab tương ứng. 
                        case "pChat":
                            if (parts[1] == "Server") {
                                selectPage(parts[2]);
                                this.currentListbox.Items.Add(parts[2] + ": " + parts[3]);
                            } else {
                                // nếu người nhận không phải server thì chuyển tiếp tới client nhận.
                                privateChat(parts);
                            }
                            break;
                    }
                    parts.Clear();
                } catch (Exception r) {
                    // Nếu xảy ra lỗi thì đóng TCPClient
                    this.findListBox("Home").Items.Add(username + " disconnected ");
                    globalChat("Client Disconnected: " + username + "$", username, false);
                    clientList.Remove(username);
                    lvClient.Items.Remove(getLvItem(username));
                    sendUsersList();
                    break;
                }
            }
        }


        /// <summary>
        /// Gửi list các user đang online cho các client
        /// </summary>
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

        /// <summary>
        /// Gửi tin nhắn riêng tư tới client nhận tin nhắn.
        /// </summary>
        /// <param name="text"></param>
        private void privateChat(List<string> text)
        {
            try {
                byte[] byData = ObjectToByteArray(text);
                TcpClient workerSocket = null;
                // Lấy ra TCPClient nhận tin nhắn từ dictionary clientList
                // Dictionary clientList gồm 1 cặp key-value 
                // Key: tên user, value: TCPClient tương ứng của user đó.
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
