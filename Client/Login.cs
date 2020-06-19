using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(Helper.ConnectionString))
            {
                SqlCommand cmd = cnn.CreateCommand();

                cmd = new SqlCommand("select * from taikhoan where username ='" + txtUsername.Text + "'and password ='" + txtPassword.Text + "' and status = 0",cnn);

                cnn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    Form frm = new Client(txtUsername.Text);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công!");
                    txtPassword.Text = "";
                    txtUsername.Text = "";

                }
                cnn.Close();
                cnn.Dispose();
                da.Dispose();

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
