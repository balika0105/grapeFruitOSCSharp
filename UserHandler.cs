using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace GrapeFruitCSharp
{
    public class UserHandler
    {
        public static bool Login(string username /*,string password*/){
            if (SystemVars.isLive)
            {
                EnvVars.currentUser = username;
                return true;
            }
            else
            {
                //This part will be implemented once we have a proper installer
            }
            //Return false will be used if the user isn't in the system
            //return false;
        }
    }
}
