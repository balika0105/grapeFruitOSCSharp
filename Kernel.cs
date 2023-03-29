using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

using Cosmos.System.FileSystem;
using System.IO;
using Cosmos.System.Graphics;
using Cosmos.System.ExtendedASCII;

namespace GrapeFruit_CosmosRolling
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {   
            Logger.Debug("Grapefruit OS code begins here");
            //Extented ASCII
            Encoding.RegisterProvider(CosmosEncodingProvider.Instance);
            Console.InputEncoding = Encoding.GetEncoding(437);
            Console.OutputEncoding = Encoding.GetEncoding(437);
            //Set screen size
            VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size80x25);

            Console.Clear();

            // Linux-style greeting
            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GrapeFruit OS!");
            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine("Initializing drivers, please wait...");
            Logger.Log(1, "Filesystem init");
            #region FS Init
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
            #endregion

            #region Network Init
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
            #endregion

            Logger.Log(1, "Set hostname to \"livecd\""); ;
            Globals.hostname = "livecd";
            Globals.workingdir = @"0:\";
            Logger.Log(1, "Init done");


            KBManager.AskForLayout();
            Console.WriteLine();
            

            if (!UserHandler.Login())
            {
                ErrorScreen.CustomError("Failed to create live user, system cannot progress");
            }

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
