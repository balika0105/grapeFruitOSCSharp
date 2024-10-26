using System;

using Cosmos.System.FileSystem;
using System.IO;
using Cosmos.HAL;
using Cosmos.Core;
using Cosmos.System.FileSystem.FAT;
using Cosmos.System.FileSystem.ISO9660;

#pragma warning disable CA2211
#pragma warning disable IDE0059

namespace grapeFruitRebuild
{
    public class Globals
    {
        public const string build = "0.10 CosmosRolling-Rebuild";
        public const string osname = "grapeFruitOS";
        public const bool devBuild = true;

        //Virtual devices
        public static CosmosVFS vFS;
        public static FileSystem fatFileSystem;
        public static FatFileSystemFactory fatFSFactory;
        public static ISO9660FileSystem opticalDiscFS;
        public static DriveInfo drive;
        public static NetworkDevice nic;

        //ENV
        public static string currentuser;
        public static string hostname;
        public static string workingdir;
        public static string oldpwd;

        public static bool swapYZ;

        public static void Printsysteminfo()
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
