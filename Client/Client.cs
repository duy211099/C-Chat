using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Client
{
    public partial class Client : Form
    {
        ChatxServer chatxserver;
        private static readonly Socket clientSocket = new Socket
           (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string username;
        public List<ClientxClient> clientxclients = new List<ClientxClient>();
        public Client(string username)
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            this.username = username;
            Text = username;
            UpdateAmountOfClients();
            ConnectToServer();
        }

        private void UpdateAmountOfClients()
        {
            Thread th = new Thread(new ThreadStart(() => {

                while (true)
                {
                    Thread.Sleep(1000);

                    using (SqlConnection cn = new SqlConnection(Helper.ConnectionString))
                    {
                        SqlCommand cmdCount = cn.CreateCommand();

                        cmdCount = new SqlCommand("SELECT Count(*) FROM taikhoan where port IS NOT null", cn);

                        cn.Open();

                        SqlDataReader readerCount = cmdCount.ExecuteReader();
                        int count = 0;

                        while (readerCount.Read())
                        {
                            count = readerCount.GetInt32(0);
                        }

                        if (count != lbOnline.Items.Count)
                        {
                            lblConnections.Text = count + "";
                            RefreshLabels();
                        }

                        cn.Close();
                        cn.Dispose();
                    }
                }
            }));
            th.Start();
        }
        private void RefreshLabels()
        {
            using (SqlConnection cnn = new SqlConnection(Helper.ConnectionString))
            {
                SqlCommand cmd = cnn.CreateCommand();

                cmd = new SqlCommand("SELECT * FROM taikhoan where port IS NOT null", cnn);

                cnn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                lbOnline.Items.Clear();
                while (reader.Read())
                {
                    lbOnline.Items.Add(reader["username"].ToString().Trim() + " || " + reader["port"].ToString().Trim() + " : " + reader["ip"].ToString().Trim());
                }
                cnn.Close();
                cnn.Dispose();
            }
        }

        public void ConnectToServer()
        {
            while (!clientSocket.Connected)
            {
                try
                {
                    clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
                }
                catch (SocketException)
                {
                    MessageBox.Show("Không thể két nối server");
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }
            lbChatAll.Items.Add("Kết nối đến server thành công");
            clientSocket.Send(Encoding.Unicode.GetBytes("All" + username + " just have connected!" ));
            //Lắng nghe khi server gửi tin
            Thread listen = new Thread(ReceiveResponse);
            listen.IsBackground = true;
            listen.Start();
        }
        public void ReceiveResponse()
        {
            while (true)
            {
                var buffer = new byte[2048];
                try
                {
                    int recv = clientSocket.Receive(buffer);
                    string msg = Encoding.Unicode.GetString(buffer, 0, buffer.Length);

                    if (msg.Substring(0, 3).Contains("All"))
                    {
                        lbChatAll.Items.Add(msg.Substring(3));
                    }
                    else if (msg.Substring(0, 4).Contains("One "))
                    {
                        chatxserver.Receive(msg.Substring(4));
                    }
                    else if (msg.Substring(0, 4).Contains("cvc"))
                    {
                        //cxc.Receive(msg.Substring(4));
                        foreach (ClientxClient cxc in clientxclients)
                        {
                            //string ip = ((IPEndPoint)cl.Client.RemoteEndPoint).Address.ToString();
                            if (cxc.chatter == msg.Split()[3])
                            {
                                string msgOnly = string.Join(" ", msg.Split(' ').Skip(3));
                                cxc.Receive(msgOnly);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    clientSocket.Close();
                }
            }
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            clientSocket.Send(Encoding.Unicode.GetBytes("All"+username+": "+txtChatAll.Text));
            txtChatAll.Text = "";
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();

            Environment.Exit(0);
            Application.Exit();
        }

        private void btnSendToServer_Click(object sender, EventArgs e)
        {
            if (!CheckOpened("ChatxServer"))
            {
                chatxserver = new ChatxServer(clientSocket, username);
                chatxserver.Show();
            }
        }

        private void lbOnline_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbOnline.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string chatter = lbOnline.Items[index].ToString().Split()[0];
                string port = lbOnline.Items[index].ToString().Split()[2];
                string ip = lbOnline.Items[index].ToString().Split()[4];
                ClientxClient cxc = new ClientxClient(clientSocket, username,chatter, port, ip);
                clientxclients.Add(cxc);
                cxc.Show();
             /*             
                Console.WriteLine(((IPEndPoint)ClientSockets[ClientSockets.Count() - index - 1].Client.RemoteEndPoint).Port.ToString());
                ChatxClient cxc = new ChatxClient(ClientSockets[ClientSockets.Count() - index - 1], lbOnline.Items[index].ToString().Split()[0]);
                cxc.Show();
                chatxclients.Add(cxc);    
             */
            }
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void lbOnline_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lbOnline_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
