using System;
using System.Collections.Generic;
using System.Text;

using Sys = Cosmos.System;

using Cosmos.System.FileSystem;
using System.IO;

namespace GrapeFruit_CosmosRolling
{
    public class FS
    {
        public static void List(string path = "")
        {
            if (Globals.vFS == null)
            {
                Console.WriteLine("FS.List: Virtual Filesystem is not initialised!");
            }
            else
            {
                path = (path == "") ? Globals.workingdir : path;

                if (path != "" && !path.Contains(@":\"))
                    path = Globals.workingdir + path;

                string[] filePaths = Directory.GetFiles(path);
                Console.WriteLine("Directory listing of {0}", path);
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var d in Directory.GetDirectories(path))
                {
                    var dir = new DirectoryInfo(d);
                    var dirName = dir.Name;

                    if (dirName.Contains(' '))
                        Console.Write("\"" + dirName + "\"" + " ");
                    else
                        Console.Write(dirName + " ");
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < filePaths.Length; ++i)
                {
                    string path_ = filePaths[i];
                    Console.Write(Path.GetFileName(path_) + " ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTotal: " + $"{Globals.drive.TotalSize}" + " b / Free: " + $"{Globals.drive.AvailableFreeSpace}" + " b");
            }
        }

        public static void Touch(string filename)
        {
            if (Globals.vFS == null)
            {
                Console.WriteLine("FS.Touch: Virtual Filesystem is not initialised!");
            }
            else
            {
                if (!filename.Contains(@":\"))
                    filename = Globals.workingdir + filename;

                Logger.Debug("Filename: " + filename);
                try
                {
                    if (!File.Exists(filename))
                        File.Create(filename);
                    else
                        Console.WriteLine("File already exists");
                }
                catch (FileNotFoundException)
                {
                    File.Create(filename);
                }
            }
        }

        public static void Cat(string path)
        {
            if (Globals.vFS == null)
            {
                Console.WriteLine("FS.Cat: Virtual Filesystem is not initialised!");
            }
            else
            {
                if (!path.Contains(@":\"))
                    path = Globals.workingdir + path;

                Logger.Debug($"{path}");
                try
                {
                    string[] fileContent = File.ReadAllLines(path);
                    foreach (var i in fileContent)
                        Console.WriteLine(i);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("cat: File Not Found");
                }
            }

        }

        public static void Mkdir(string path)
        {
            if (Globals.vFS == null)
            {
                Console.WriteLine("FS.Mkdir: Virtual Filesystem is not initialised!");
            }
            else
            {
                if (!path.Contains(@":\"))
                    path = Globals.workingdir + path;

                if (Directory.Exists(path))
                    Console.WriteLine("mkdir: directory already exists");
                else
                    Directory.CreateDirectory(path);
            }
        }
    }
}
