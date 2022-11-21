using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using Cosmos.HAL.BlockDevice;

namespace GrapeFruit_CosmosDevKit
{
    public class gfdisk
    {
        public static void main()
        {
            Console.Clear();
            Console.WriteLine("GFDisk - GrapeFruit Disk Utility v0.1");
            do
            {
                Console.Write("gfdisk > ");

            } while (Command(Console.ReadLine()));

        }

        static bool Command(string command)
        {
            switch (command)
            {
                case "getdisks":
                    List<Disk> Disks = VFSManager.GetDisks();
                    foreach (Disk disk in Disks)
                    {
                        disk.DisplayInformation();
                    }
                    Console.Write("\n");
                    return true;

                /*case "createpart":
                    Console.Write("Enter disk number to create a partition on: ");
                    int*
                    return true;*/

                case "exit":
                    return false;
                default:
                    Console.WriteLine("unknown");
                    return true;
            }
        }
    }
}
