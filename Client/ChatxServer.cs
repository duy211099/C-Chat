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
    public partial class ChatxServer : Form
    {
        private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string username;
        public ChatxServer()
        {
            InitializeComponent();
        }
        public ChatxServer(Socket ClientSocket,string username)
        {
            InitializeComponent();

            clientSocket = ClientSocket;
            this.username = username;
            Text = username + " chat với Server.";
        }

        public void Receive(string msg)
        {
            lbChat.Items.Add(msg);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            clientSocket.Send(Encoding.Unicode.GetBytes("One " + username + " : " + txtMess.Text));

            lbChat.Items.Add(username+": "+txtMess.Text);
            txtMess.Text = "";
        }

        private void ChatxServer_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
