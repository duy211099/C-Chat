using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Helper
    {
        private static string _ConnectionString = "";
        public static string ConnectionString
        {
            get
            {
                if (_ConnectionString == "")
                {
                    _ConnectionString = @"SERVER=.;DATABASE=ChatServer;Integrated Security=true";
                }
                return _ConnectionString;
            }
        }
    }
}
