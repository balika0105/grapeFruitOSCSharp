using System;
using System.Collections.Generic;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using Cosmos.HAL.BlockDevice;

namespace grapeFruitOSCSharp.Filesystem
{
    public class Gfdisk
    {
        public static void Main()
        {
            Console.Clear();
            Console.WriteLine("GFDisk - GrapeFruit Disk Utility v0.1");
            Console.WriteLine("\nNot yet implemented");
            /*if (Globals.vFS == null)
            {
                Console.WriteLine("WARNING! Virtual Filesystem isn't initialised!");
            }

            do
            {
                Console.Write("gfdisk > ");

            } while (Command(Console.ReadLine()));*/
            return;
        }

        /*static bool Command(string command)
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
                    if (Globals.vFS != null)
                    {
                        var volumes = Globals.vFS.GetVolumes();

                        foreach (var vol in volumes)
                        {
                            Console.WriteLine("  " + vol.mName + "\t   \t" + Globals.vFS.GetFileSystemType(vol.mName) + " \t" + vol.mSize + " MB\t" + vol.mParent);
                        }
                    }
                    else
                    {
                        Console.WriteLine("listvolumes: Virtual Filesystem isn't initialised");
                    }
                    
                    return true;

                case "devices":
                    Logger.Log(1, "Looking for storage devices...");
                    BlockDevice[] devices = BlockDevice.Devices.ToArray();
                    foreach (BlockDevice device in devices)
                    {
                        Console.WriteLine("Blockdevice: " + device.ToString());
                        Console.WriteLine(device.BlockCount + " blocks");
                        Console.WriteLine(device.BlockSize + " bytes / block");
                        Console.WriteLine("Type: " + device.Type.ToString());
                    }
                    return true;

                case "format":
                    Format();
                    return true;


                case "help":
                    Console.WriteLine("\nAvailable commands:");
                    Console.WriteLine("getdisks: list disks");
                    Console.WriteLine("listvolumes: list volumes on every disk (requires vFS init)");
                    Console.WriteLine("devices: List blockdevices");
                    Console.WriteLine("format: Enter formatting mode");
                    Console.WriteLine();
                    return true;

                case "exit":
                    return false;
                default:
                    Console.WriteLine("unknown");
                    return true;
            }
        }

        static void Format()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("gfdisk - formatting mode");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("\nSelect device to format\n");

            //Getting blockdevices
            BlockDevice[] blockDevices = BlockDevice.Devices.ToArray();
            for (int i = 0; i < blockDevices.Length; i++)
            {
                Console.WriteLine("Device #" + i);
                Console.WriteLine("Blockdevice: " + blockDevices[i].ToString());
                Console.WriteLine(blockDevices[i].BlockCount + " blocks");
                Console.WriteLine(blockDevices[i].BlockSize + " bytes / block");
                Console.WriteLine('\n');
            }
            Console.Write("Device? > ");
            int selection = Convert.ToInt32(Console.ReadLine());

            BlockDevice blockDevice = blockDevices[selection];

            Disk disk = new(blockDevice);

            Console.WriteLine("The program will now format device #" + selection);
            if (Choice())
            {
                try
                {
                    long maxDiskSize = disk.Size;
                    Console.Write($"\nNew partition size in bytes? ({maxDiskSize}) > ");
                    long disksize = 0;
                    if(Console.ReadLine() != "")
                    {
                        disksize = Convert.ToInt64(Console.ReadLine());
                    }
                    else
                    {
                        disksize = maxDiskSize;
                    }

                    Console.Clear();
                    Console.WriteLine("Formatting device, please wait...");

                    Console.WriteLine("\nStage 1: deleting drive partitions...");
                    disk.Clear();

                    Console.WriteLine("\nStage 2: Creating new partition (on entire disk)");
                    disk.CreatePartition(disksize);

                    Console.WriteLine("\nStage 3: Format partition to FAT32");
                    
                    disk.FormatPartition(0, "FAT32", true);
                }
                catch(Exception e)
                {
                    ErrorScreen.SpecifiedError(e);
                }
                

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Formatting cancelled");
                return;
            }
            
        }

        static bool Choice()
        {
        redochoice:
            Console.Write("Are you sure? (Y/n)");
            if (!Globals.swapYZ)
            {
                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.Enter:
                    case ConsoleKey.Y:
                        return true;

                    case ConsoleKey.N:
                        Console.Write('\n');
                        return false;

                    default:
                        Console.Write('\n');
                        goto redochoice;
                }
            }
            else
            {
                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.Enter:
                    case ConsoleKey.Z:
                        return true;

                    case ConsoleKey.N:
                        Console.Write('\n');
                        return false;

                    default:
                        Console.Write('\n');
                        goto redochoice;
                }
            }
        }*/
    }
}
