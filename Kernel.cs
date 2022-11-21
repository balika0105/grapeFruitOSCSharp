using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

using Cosmos.System.FileSystem;
using System.IO;
using Cosmos.System.Graphics;
using Cosmos.System.ExtendedASCII;

namespace GrapeFruit_CosmosDevKit
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Logger.Debug("Grapefruit OS code begins here");
            //Extented ASCII
            Encoding.RegisterProvider(CosmosEncodingProvider.Instance);
            //Set screen size
            VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size80x25);

            //Unused
            #region Screen size setup
            //Console.WriteLine("Choose screen size:");
            //Console.WriteLine("(1): 90x60");
            //Console.WriteLine("(2): 90x30");
            //Console.WriteLine("(3): 80x50");
            //Console.WriteLine("(4): 80x25");
            //Console.WriteLine("(5): 40x50");
            //Console.WriteLine("(6): 40x25");

            //Console.Write("\n > ");
            //switch (Console.ReadKey().Key)
            //{
            //    case ConsoleKey.D1:
            //    case ConsoleKey.NumPad1:
            //        VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size90x60);
            //        break;
            //    case ConsoleKey.D2:
            //    case ConsoleKey.NumPad2:
            //        VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size90x30);
            //        break;
            //    case ConsoleKey.D3:
            //    case ConsoleKey.NumPad3:
            //        VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size80x50);
            //        break;
            //    case ConsoleKey.D4:
            //    case ConsoleKey.NumPad4:
            //        VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size80x25);
            //        break;
            //    case ConsoleKey.D5:
            //    case ConsoleKey.NumPad5:
            //        VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size40x50);
            //        break;
            //    case ConsoleKey.D6:
            //    case ConsoleKey.NumPad6:
            //        VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size40x25);
            //        break;

            //    default:
            //        break;
            //}
            #endregion

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


            Console.WriteLine("Initializing drivers, please wait...");
            Logger.Log(1, "Filesystem init");
            //FS Init
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

            //Network init
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


            Logger.Log(1, "Set hostname to \"livecd\""); ;
            Globals.hostname = "livecd";
            Logger.Log(1, "Init done");


            if (!UserHandler.Login())
            {
                ErrorScreen.CustomError("Failed to create live user, system cannot progress");
            }


            //Print system data
            Globals.printsysteminfo();
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
