using System;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
using System.IO;
using Cosmos.System.Graphics;
using Cosmos.HAL.Drivers.Video;
using Cosmos.System.ExtendedASCII;

namespace grapeFruitOSCSharp
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {   
            Logger.Debug("Grapefruit OS code begins here");

            // Moved "change screen size" and "use Extended ASCII", so
            // if there's any trouble on boot, we can see it
            Console.WriteLine();

            // Linux-style greeting
            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GrapeFruit OS!");
            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine("Initializing drivers, please wait...");

            #region FS Init
            //Nulling FS vars, so if they're not initialised, FS commands can't be used
            Globals.vFS = null;
            Globals.drive = null;
            Globals.workingdir = "";
        fs_sw_loopback:
            Console.Write("Load Filesystem drivers?\n1 = Yes // 2 = No > ");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine();
                    Logger.Log(1, "Filesystem init");
                    try
                    {
                        Globals.vFS = new CosmosVFS();
                        Sys.FileSystem.VFS.VFSManager.RegisterVFS(Globals.vFS);
                        Globals.drive = new DriveInfo("0");
                        Globals.workingdir = @"0:\";
                        Logger.Log(1, "FS Init ok");
                    }
                    catch (Exception ex)
                    {
                        ErrorScreen.SpecifiedError(ex);
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine();
                    goto fs_sw_loopback;
            }
            #endregion

            #region Network Init
            //Nulling NW vars, so if they're not initialised, NW commands can't be used
            Globals.nic = null;
        nw_init_loopback:
            Console.Write("Load Network drivers?\n1 = Yes // 2 = No > ");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine();
                    Logger.Log(1, "Network init");
                    try
                    {
                        Globals.nic = Cosmos.HAL.NetworkDevice.GetDeviceByName("eth0");
                        if (Globals.nic.Enable())
                        {
                            Logger.Log(1, "Network init ok");
                            Logger.Log(1, "Attempting to set IP with DHCP...");
                            GrapeFruitNW.DHCPDiscovery();
                        }

                    }
                    catch (Exception e)
                    {
                        Logger.Log(3, "Couldn't initialise network. Error: " + e.Message);
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine();
                    goto nw_init_loopback;
            }
            #endregion

            Logger.Log(1, "Set hostname to \"livecd\""); ;
            Globals.hostname = "livecd";
            Logger.Log(1, "Init done");


            KBManager.AskForLayout();
            

            if (!UserHandler.Login())
            {
                ErrorScreen.CustomError("Failed to create live user, system cannot progress");
            }

            //Extented ASCII
            Encoding.RegisterProvider(CosmosEncodingProvider.Instance);
            Console.InputEncoding = Encoding.GetEncoding(437);
            Console.OutputEncoding = Encoding.GetEncoding(437);
            //Set screen size
            VGAScreen.SetTextMode(VGADriver.TextSize.Size80x25);

            Console.Clear();
            #region splash
            Console.WriteLine(@"   _____                      ______          _ _      ____   _____ ");
            Console.WriteLine(@"  / ____|                    |  ____|        (_) |    / __ \ / ____|");
            Console.WriteLine(@" | |  __ _ __ __ _ _ __   ___| |__ _ __ _   _ _| |_  | |  | | (___  ");
            Console.WriteLine(@" | | |_ | '__/ _` | '_ \ / _ \  __| '__| | | | | __| | |  | |\___ \ ");
            Console.WriteLine(@" | |__| | | | (_| | |_) |  __/ |  | |  | |_| | | |_  | |__| |____) |");
            Console.WriteLine(@"  \_____|_|  \__,_| .__/ \___|_|  |_|   \__,_|_|\__|  \____/|_____/ ");
            Console.WriteLine(@"                  | |                                               ");
            Console.WriteLine(@"                  |_|                                               ");
            Console.Write("\n\n");
            #endregion
            //Print system data
            Globals.Printsysteminfo();
            Logger.Debug("Calling Run()");
        }

        protected override void Run()
        {
            try
            {
                Command.Main();
            }
            catch (Exception ex)
            {
                ErrorScreen.SpecifiedError(ex);
            }
        }
    }
}
