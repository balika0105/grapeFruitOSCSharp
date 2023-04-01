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

namespace GrapeFruit_CosmosRolling
{
    public class gfdisk
    {
        public static void main()
        {
            if (Globals.vFS == null)
            {
                Console.WriteLine("gfdisk - file system isn't initialised");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("GFDisk - GrapeFruit Disk Utility v0.1");
                do
                {
                    Console.Write("gfdisk > ");

                } while (Command(Console.ReadLine()));
            }
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

                case "listvolumes":
                    var volumes = Globals.vFS.GetVolumes(); ;
                    foreach (var vol in volumes)
                    {
                        Console.WriteLine("  " + vol.mName + "\t   \t" + Globals.vFS.GetFileSystemType(vol.mName) + " \t" + vol.mSize + " MB\t" + vol.mParent);
                    }
                    return true;

                case "help":
                    Console.WriteLine("getdisks: list disks");
                    Console.WriteLine("listvolumes: list volumes on every disk");
                    return true;

                case "exit":
                    return false;
                default:
                    Console.WriteLine("unknown");
                    return true;
            }
        }
    }
}
