using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cosmos.System.FileSystem;
using System.IO;
using Cosmos.HAL;

namespace GrapeFruit_CosmosDevKit
{
    public class Globals
    {
        public const string build = "0.0.3 CosmosDevKitBuild";
        public const string osname = "GrapeFruitOS-Cosmos";
        public const bool devBuild = true;

        //Virtual devices
        public static CosmosVFS vFS;
        public static DriveInfo drive;
        public static NetworkDevice nic;

        //ENV
        public static string currentuser;
        public static string hostname;
        public static string workingdir;


        public static void printsysteminfo()
        {
            Console.WriteLine("\n" + osname + " " + build);
            Console.WriteLine("Total memory: " + Cosmos.Core.GCImplementation.GetAvailableRAM() + "MB");
            Console.WriteLine("Used memory: " + Cosmos.Core.GCImplementation.GetUsedRAM() + " bytes");
        }
    }
}
