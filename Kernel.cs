using Cosmos.HAL.Drivers.Video;
using Cosmos.System.ExtendedASCII;
using Cosmos.System.FileSystem;
using Cosmos.System.Graphics;
using System;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace grapeFruitRebuild
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Logger.Debug("grapeFruit OS Code starts here");

            Console.WriteLine();

            // Linux-style greeting
            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GrapeFruit OS!");
            Console.ForegroundColor = ConsoleColor.White;

            Logger.Log(1, "Initialising drivers...");

            #region Filesystem Init
            //Nulling FS vars, so if they're not initialised, FS commands can't be used
            Globals.vFS = null;
            Globals.drive = null;
            Globals.workingdir = "";
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
            #endregion

            Logger.Log(1, "Set hostname to \"livecd\""); ;
            Globals.hostname = "livecd";
            Logger.Log(1, "Init done");

            if (!UserHandler.Login())
            {
                ErrorScreen.CustomError("Failed to create live user, system cannot progress");
            }
            //Extented ASCII
            Console.Clear();
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
