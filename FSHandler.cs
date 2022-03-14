using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;

namespace GrapeFruitCSharp
{
    public class FSHandler
    {
        public static bool InitFS(){
            return false;

            //Code moved to Kernel.cs
            /*CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
            long available_space = 0;
            try
            {
                VFSManager.RegisterVFS(fs, false);
                available_space = Sys.FileSystem.VFS.VFSManager.GetAvailableFreeSpace("0:\\");
            }
            catch(Exception e)
            {
                ErrorScreen.Main("Error during initial file system setup | " + e.Message);
            }

            if (available_space == 0)
                return false;

            else
                return true;
            */
        }
    }
}
