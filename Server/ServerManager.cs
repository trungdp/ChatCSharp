using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerManager
    {
        private IPAddress serverIP;
        private int port;
        public IPAddress ServerIP {
            get { return serverIP; }
            set { this.serverIP = value; }
        }

        public int Port  {
            get { return this.port; }
            set { this.port = value; }
        }
        //delegate để set dữ liệu cho các Control
        //Tại thời điểm này ta chưa biết dữ liệu sẽ được hiển thị vào đâu nên ta phải dùng delegate
        public delegate void SetDataControl(string Data);
        public SetDataControl SetDataFunction = null;
        Socket serverSocket = null;
        IPEndPoint serverEP = null;
        Socket clientSocket = null;
        //buffer để nhận và gởi dữ liệu
        byte[] buff = new byte[1024];
        //Số byte thực sự nhận được
        int byteReceive = 0;
        string stringReceive = "";
        public ServerManager(IPAddress ServerIP, int Port)
        {
            this.ServerIP = ServerIP;
            this.Port = Port;
        }
        //Lắng nghe kết nối
        public void Listen() {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverEP = new IPEndPoint(ServerIP, Port);
            serverSocket.Bind(serverEP);
            serverSocket.Listen(-1);                        //-1: không giới hạn số lượng client kết nối đến
            SetDataFunction("Đang chờ kết nối . . .");
            //Bắt đầu chấp nhận Client kết nối đến
            serverSocket.BeginAccept(new AsyncCallback(AcceptSocket), serverSocket);
        }
        //Hàm callback chấp nhận Client kết nối
        private void AcceptSocket(IAsyncResult ia)
        {
            try {
                Socket s = (Socket)ia.AsyncState;
                clientSocket = s.EndAccept(ia);
                string hello = "Hello Client";
                buff = Encoding.ASCII.GetBytes(hello);
                SetDataFunction("Client " + clientSocket.RemoteEndPoint.ToString() + " đã kết nối!");
                //clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendData), clientSocket);
            } catch (Exception) {

            }
        }
        private void SendData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            s.EndSend(ia);
            buff = new byte[1024];
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveData), s);
        }
        public void Close()
        {
            if (clientSocket != null) {
                clientSocket.Close();
            }
            if (serverSocket != null) {
                serverSocket.Close();
            }
        }
        private void ReceiveData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            try {
                byteReceive = s.EndReceive(ia);
            } catch {
                this.Close();
                SetDataFunction("Client ngắt kết nối");
                this.Listen();
                return;
            }
            if (byteReceive == 0) {
                Close();
                SetDataFunction("Clien đóng kết nối");
            }  else {
                stringReceive = Encoding.ASCII.GetString(buff, 0, byteReceive);
                SetDataFunction(stringReceive);
                //Sau khi Server nhận dữ liệu xong thì bắt đầu gởi dữ liệu xuống cho Client
                s.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendData), s);
            }
        }
    }
}
