using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gevers_Autogarage.Classes
{
    public class Session
    {
        private static bool loggedIn;

        public static bool LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }
        private static string username;

        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        private static bool isEmployee;

        public static bool IsEmpmloyee
        {
            get { return isEmployee; }
            set { isEmployee = value; }
        }

    }
}
