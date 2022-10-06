using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gevers_Autogarage.Classes
{
    public static class Session
    {
        private static bool loggedIn;

        private static string username;

        private static bool isEmployee;


        public static void setSession(User user)
        {
            username = user.Username;
            isEmployee = user.IsEmployee;
            loggedIn = true;
        }


        public static bool getIsEmployee()
        {
            return isEmployee;
        }
        public static bool getLoggedIn()
        {
            return loggedIn;
        }
        
        public static string getUserName()
        {
            return username;
        }

    }
}
