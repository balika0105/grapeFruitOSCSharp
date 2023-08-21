using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cosmos.System.FileSystem;
using System.IO;
using Cosmos.HAL;
using System.Net.NetworkInformation;
using Cosmos.Core;

namespace GrapeFruit_CosmosRolling
{
    public class Globals
    {
        public const string build = "0.0.5 CosmosRolling";
        public const string osname = "GrapeFruitOS-Cosmos";
        public const bool devBuild = true;

        //Virtual devices
        public static CosmosVFS vFS;
        public static DriveInfo drive;
        public static NetworkDevice nic;

        //ENV
        //public static IDictionary<string, string> Environment = new Dictionary<string, string>();
        public static string currentuser;
        public static string hostname;
        public static string workingdir;
        public static bool swapYZ;


        public static void printsysteminfo()
        {
            Console.WriteLine(osname + " " + build);
            float usedpercent = 0f;
            if (CPU.CanReadCPUID() != 0)
            {
                Console.WriteLine($"CPU: {CPU.GetCPUBrandString()}");
                usedpercent = GCImplementation.GetUsedRAM() / (CPU.GetAmountOfRAM() * 1048576);
            }
            else
            {
                usedpercent = GCImplementation.GetUsedRAM() / (GCImplementation.GetAvailableRAM() * 1048576);
            }
            
            string realUsedPercent = "";
            if (usedpercent < 1)
                realUsedPercent = "<1%";
            else
                realUsedPercent = usedpercent.ToString();
            
            Console.WriteLine($"Memory usage: {GCImplementation.GetUsedRAM()} / {GCImplementation.GetAvailableRAM() * 1048576} bytes ({realUsedPercent})");
        }
    }
}
