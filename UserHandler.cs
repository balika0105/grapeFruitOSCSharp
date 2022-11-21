using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapeFruit_CosmosDevKit
{
    public class UserHandler
    {
        //This class will have the proper user handling elements in future builds
        public static bool Login()
        {
            Console.Write("\nUsername for this session: ");
            Globals.currentuser = Console.ReadLine();
            return true;
        }
    }
}
