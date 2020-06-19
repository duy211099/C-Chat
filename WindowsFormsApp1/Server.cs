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

namespace WindowsFormsApp1
{
    public partial class Server : Form
    {
        //public static int connections = 0;
        public TcpListener server;
        public TcpListener threadListener;
        public static List<TcpClient> ClientSockets = new List<TcpClient>();
        public List<ChatxClient> chatxclients = new List<ChatxClient>();
        
        public Server()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            OnOpen();
            StartServer();
            UpdateAmountOfClients();
        }
        //cập nhật số client online
        private void UpdateAmountOfClients()
        {
            Thread th = new Thread(new ThreadStart(()=> {

                while (true)
                {
                    Thread.Sleep(1000);

                    using (SqlConnection cn = new SqlConnection(Helper.ConnectionString))
                    {
                        SqlCommand cmdCount = cn.CreateCommand();

                        cmdCount = new SqlCommand("SELECT Count(*) FROM taikhoan where status=1", cn);

                        cn.Open();
                        SqlDataReader readerCount = cmdCount.ExecuteReader();
                        int count = 0;
                        while (readerCount.Read())
                        {
                            count = readerCount.GetInt32(0);
                        }
                        if (count != lbOnline.Items.Count)
                        {
                            lblConnections.Text = count+"";
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

                cmd = new SqlCommand("SELECT * FROM taikhoan where status = 1", cnn);

                cnn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                lbOnline.Items.Clear();
                while (reader.Read())
                {
                    lbOnline.Items.Add(reader["username"].ToString().Trim() + 
                    " || " + 
                    reader["port"].ToString().Trim() +" : "+reader["ip"].ToString().Trim());
                }
                cnn.Close();
                cnn.Dispose();
            }
        }

        public void StartServer()
        {
            Thread th = new Thread(new ThreadStart(()=> {

                IPAddress localIpAddress = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localIpAddress, 9999);
                server.Start();
                while (true)
                {
                    threadListener = server;
                    Thread newthread = new Thread(new ThreadStart(HandleConnection));
                    newthread.Start();
                }
            }));
            th.Start();
        }
        public void HandleConnection()
        {
            int recv;
            byte[] data = new byte[1024];

            TcpClient client = threadListener.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            String remoteIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            String remotePort = ((IPEndPoint)client.Client.RemoteEndPoint).Port.ToString();
            
            ClientSockets.Add(client);

            while (true)
            {
                try
                {
                    data = new byte[1024];
                    recv = ns.Read(data, 0, data.Length);
                    if (recv == 0)
                        break;
                    //ns.Write(data, 0, recv);
                    string msg = Encoding.Unicode.GetString(data, 0, recv);
                    Console.WriteLine(msg);
                    if (msg.Substring(0, 3).Contains("All"))
                    {
                        lvChatAll.Items.Add(msg.Substring(3));
                        if (msg.Contains("just have connected!"))
                        {
                            ConnectClient(remotePort,remoteIP, msg.Split()[0].Substring(3));
                        }
                        for (int i = 0; i < ClientSockets.Count; i++)
                        {
                            ClientSockets[i].GetStream().Write(Encoding.Unicode.GetBytes(msg), 0, Encoding.Unicode.GetBytes(msg).Length);
                        }
                    }
                    else if (msg.Substring(0, 4).Contains("One "))
                    {
                        foreach(ChatxClient cxc in chatxclients)
                        {
                            if(cxc.username==msg.Split()[1])
                            {
                                cxc.Receive(msg.Substring(4));
                            }    
                        }
                    }
                    else if (msg.Substring(0, 3).Contains("cvc"))
                    {
                        foreach (TcpClient cl in ClientSockets)
                        {
                            string port =((IPEndPoint)cl.Client.RemoteEndPoint).Port.ToString();
                            string ip =((IPEndPoint)cl.Client.RemoteEndPoint).Address.ToString();
                            if(port == msg.Split()[1] && ip == msg.Split()[2])
                            {
                                Console.WriteLine(msg);
                                cl.GetStream().Write(Encoding.Unicode.GetBytes(msg),0, Encoding.Unicode.GetBytes(msg).Length);
                            }
                        }
                    }
                } catch { }
            }
            ns.Close();
            client.Close();

            DisconnectClient(remotePort,remoteIP);

            ClientSockets.Add(client);
            //connections--;
        }

        void ConnectClient(string remotePort,string remoteIP,string username)
        {
            using (SqlConnection cnn = new SqlConnection(Helper.ConnectionString))
            {
                SqlCommand cmd = cnn.CreateCommand();

                Console.WriteLine(username + remoteIP + remotePort);
                cmd = new SqlCommand("Update taikhoan set ip = '" + remoteIP + "', port = '" + remotePort + "',status=1 where username='" + username + "'", cnn);

                cnn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cnn.Close();
                cnn.Dispose();
                da.Dispose();
            }
        }

        void DisconnectClient(string remotePort,string remoteIP)
        {
            using (SqlConnection cnn = new SqlConnection(Helper.ConnectionString))
            {
                SqlCommand cmd = cnn.CreateCommand();

                cmd = new SqlCommand("Update taikhoan set ip = NULL, port = NULL,status=0 where port='" + remotePort + "'and ip='"+remoteIP+"'", cnn);

                cnn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cnn.Close();
                cnn.Dispose();
                da.Dispose();
            }
        }
        private void btnSendAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ClientSockets.Count; i++)
            {
                Console.WriteLine(Encoding.Unicode.GetBytes("All" + "Server: " + txtChatAll.Text).Length);
                ClientSockets[i].GetStream().Write(Encoding.Unicode.GetBytes("All"+ "Server: " + txtChatAll.Text), 0, Encoding.Unicode.GetBytes("All" + "Server: " + txtChatAll.Text).Length);
            }

            lvChatAll.Items.Add("Server: " + txtChatAll.Text + "\n");
            txtChatAll.Text = "";
        }
        public void OnOpen()
        {
            using (SqlConnection cnn = new SqlConnection(Helper.ConnectionString))
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd = new SqlCommand("Update taikhoan set status = 0,ip = null, port = null", cnn);
                cnn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cnn.Close();
                cnn.Dispose();
                da.Dispose();
            }
        }

        private void lbOnline_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbOnline.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Console.WriteLine(((IPEndPoint)ClientSockets[index].Client.RemoteEndPoint).Port.ToString());
                
                //ChatxClient cxc=new ChatxClient(ClientSockets[Math.Abs(ClientSockets.Count() - index-1)],lbOnline.Items[index].ToString().Split()[0]);
                ChatxClient cxc=new ChatxClient(ClientSockets[index],lbOnline.Items[index].ToString().Split()[0]);
                cxc.Show();
                chatxclients.Add(cxc);
            }
        }

        private void lbOnline_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Server_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSendAll.PerformClick();
        }

        private void Server_KeyPress_1(object sender, KeyPressEventArgs e)
        {
        }

        private void Server_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSendAll.PerformClick();
        }
    }

}
