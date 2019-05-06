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
            setupMenuItemEvent();
        }

        #region VARS
        public TcpClient clientSocket;
        public NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        Thread ctThread;
        public string name = null;
        //Dictionary<string, Object> nowChatting = new Dictionary<string, Object>();
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
        private void mListBox_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add) {
                // scroll the new item into view   
                if (currentListbox != null) {
                    currentListbox.TopIndex = currentListbox.Items.Count - 1;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try {
                if (!tbMessage.Text.Equals("")) {
                    chat.Add("gChat");
                    chat.Add(tbMessage.Text);
                    byte[] outStream = ObjectToByteArray(chat);

                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    tbMessage.Text = "";
                    chat.Clear();
                }
            } catch (Exception er) {
                //btnConnect.Enabled = true;
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

        private void btnClr_Click(object sender, EventArgs e)
        {
            //lbxMessage.Items.Clear();
            if (currentListbox != null) {
                currentListbox.Items.Clear();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (lvListName.SelectedIndex != -1) {
            //    String clientName = listBox1.GetItemText(listBox1.SelectedItem);
            //    chat.Clear();
            //    chat.Add("pChat");
            //    chat.Add(clientName);
            //    chat.Add(name);
            //    chat.Add("new");

            //    byte[] outStream = ObjectToByteArray(chat);
            //    serverStream.Write(outStream, 0, outStream.Length);
            //    serverStream.Flush();

            //    formPrivate privateChat = new formPrivate(clientName, clientSocket, name);
            //    nowChatting.Add(clientName);
            //    privateChat.Text = "Private Chat with " + clientName;
            //    privateChat.Show();
            //    chat.Clear();
            //}
        }

        private void lvListName_DoubleClick(object sender, EventArgs e)
        {
            //ListViewItem item = lvListName.SelectedItems as Track;
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

        #endregion

        #region UTILS
        private void setupMenuItemEvent()
        {
            deleteItem.Click += deleteItem_Click;
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
                //btnConnect.Enabled = false;


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

        private void removeTabPage(string tabname)
        {
            foreach (TabPage page in tabCtrl.TabPages) {
                if (page.Text == tabname) {
                    tabCtrl.TabPages.Remove(page);
                    break;
                }
            }
        }

        #endregion




        public void setName(String title)
        {
            this.Text = title;
            name = title;
        }

        public void updateMessage(String m)
        {
            this.Invoke((MethodInvoker)delegate {
                if (currentListbox != null) {
                    this.currentListbox.Items.Add(">>" + m + Environment.NewLine);
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
                        //btnConnect.Enabled = true;
                    }

                    parts = (List<string>)ByteArrayToObject(inStream);
                    switch (parts[0]) {
                        case "userList":
                            getUsers(parts);
                            break;

                        case "gChat":
                            readData = "" + parts[1];
                            msg();
                            break;

                        case "pChat":
                            managePrivateChat(parts);
                            break;
                    }

                    if (readData[0].Equals('\0')) {
                        readData = "Reconnect Again";
                        msg();

                        this.Invoke((MethodInvoker)delegate // To Write the Received data
                        {
                            //btnConnect.Enabled = true;
                        });

                        ctThread.Abort();
                        clientSocket.Close();
                        break;
                    }
                    chat.Clear();
                }
            } catch (Exception e) {
                ctThread.Abort();
                clientSocket.Close();
                //btnConnect.Enabled = true;
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

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
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


        public void managePrivateChat(List<string> parts)
        {
            this.Invoke((MethodInvoker)delegate // To Write the Received data
            {
                //if (parts[3].Equals("new")) {
                //    formPrivate privateC = new formPrivate(parts[2], clientSocket, name);
                //    nowChatting.Add(parts[2]);
                //    privateC.Text = "Private Chat with " + parts[2];
                //    privateC.Show();
                //} else {
                //    if (Application.OpenForms["formPrivate"] != null) {
                //        (Application.OpenForms["formPrivate"] as formPrivate).setHistory(parts[3]);
                //    }
                //}
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
                    //indicator.BackColor = Color.Red;
                    lbName.Text = "Reconnect";
                    lbName.Enabled = true;
                    lbName.ForeColor = Color.Red;
                    this.Invoke((MethodInvoker)delegate // cross threads
                    {
                        //btnConnect.Enabled = true;
                    });
                    flag = false;
                } else {
                    //indicator.BackColor = Color.Green;
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
    }
}
