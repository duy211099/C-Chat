using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Account
    {
        public string user { get; set; }
        public string password { get; set; }
        public string port { get; set; }
        public string ip { get; set; }
    }
}
