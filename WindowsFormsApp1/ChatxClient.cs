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

namespace WindowsFormsApp1
{
    public partial class ChatxClient : Form
    {
        TcpClient client;
        public string username;
        public ChatxClient()
        {
            InitializeComponent();
        }
        public ChatxClient(TcpClient client,string username)
        {
            InitializeComponent();

            this.client = client;
            this.username = username;
            Text = "Chat với "+username;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                client.GetStream().Write(Encoding.Unicode.GetBytes("One " + "Server: " + txtMess.Text), 0, Encoding.Unicode.GetBytes("One " + "Server: " + txtMess.Text).Length);

            }
            catch { }


            lbChat.Items.Add("Server: " + txtMess.Text + "\n");
            txtMess.Text = "";
        }

        public void Receive(string msg)
        {
            lbChat.Items.Add(msg);
        }

        private void lbChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMess_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
