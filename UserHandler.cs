using System;

namespace grapeFruitRebuild
{
    public class UserHandler
    {
        //This class will have the proper user handling elements in future builds
        public static bool Login()
        {
            Console.Write("\n" + Globals.hostname + " login: ");
            Globals.currentuser = Console.ReadLine();
            return true;
        }
    }
}
