using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

using Cosmos.System.ExtendedASCII;

using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;

namespace GrapeFruitCSharp
{
    public class Kernel : Sys.Kernel
    {

        //Creating the Virtual File System (handler) | DO NOT MOVE THIS LINE
        CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {
            Console.WriteLine("\nCosmos bootstrap complete.\n");
            Console.Write("\n\nPress a key to continue!");
            Console.ReadKey();
            #region Setup console
            Encoding.RegisterProvider(CosmosEncodingProvider.Instance);
            Console.Clear();
            #endregion
            #region liveCD
            if (SystemVars.isLive)
                {
                    Console.WriteLine("Running in live CD mode");
                }
                else if (!SystemVars.isLive)
                {
                    Console.WriteLine("Running in normal mode");
                }
            #endregion

            #region FS Init
            /*Console.WriteLine("Attempting File System Initialization . . .");
            long available_space = 0;
            try
            {
                VFSManager.RegisterVFS(fs);
                available_space = Sys.FileSystem.VFS.VFSManager.GetAvailableFreeSpace("0:\\");
            }
            catch (Exception e)
            {
                ErrorScreen.Main("Error during initial file system setup | " + e.Message);
            }
            if (available_space > 0)
                {
                    Console.WriteLine("Filesystem OK");
                Console.WriteLine("Available Free Space: " + available_space + " Bytes");
                EnvVars.isFS = true;
                }
            else if (available_space == 0)
            {
                Console.WriteLine("Running without filesystem!");
                EnvVars.isFS = false;
            }*/
            //FileSystem is temporarily out
            EnvVars.isFS = false;
            #endregion
            Shell.Init();
        }

        protected override void Run()
        {
            try
            {
                Shell.CLI();
            }
            catch (Exception e)
            {
                ErrorScreen.Main(e);
            }
        }
    }
}
