using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientxClient : Form
    {
        public Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public string username;
        string port;
        string ip;
        public string chatter;
        public ClientxClient(Socket ClientSocket, string username,string chatter, string port, string ip)
        {
            InitializeComponent();

            clientSocket = ClientSocket;
            this.username = username;
            this.port = port;
            this.ip = ip;
            this.chatter = chatter;
            Text =username+" chat với "+chatter;
        }
        public void Receive(string msg)
        {
            lbChat.Items.Add(msg);
        }
        public ClientxClient()
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            clientSocket.Send(Encoding.Unicode.GetBytes("cvc " + port + " " + ip + " " + username + " : " + txtMess.Text));

            lbChat.Items.Add(username + ": " + txtMess.Text);
            txtMess.Text = "";
        }
    }
}
