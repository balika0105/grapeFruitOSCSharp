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
            if (path == "")
            {
                string[] filePaths = Directory.GetFiles(@"0:\");
                Console.WriteLine("Directory listing of {0}", Globals.drive.VolumeLabel);
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var d in System.IO.Directory.GetDirectories(@"0:\"))
                {
                    var dir = new DirectoryInfo(d);
                    var dirName = dir.Name;

                    if (dirName.Contains(" "))
                        Console.Write("\"" + dirName + "\"" + " ");
                    else
                        Console.Write(dirName + " ");
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < filePaths.Length; ++i)
                {
                    string path_ = filePaths[i];
                    Console.Write(System.IO.Path.GetFileName(path_) + " ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                Console.WriteLine("        " + $"{Globals.drive.TotalSize}" + " bytes total");
                Console.WriteLine("        " + $"{Globals.drive.AvailableFreeSpace}" + " bytes free");
            }
            else
            {
                Console.WriteLine("Not yet implemented");
            }
        }

        public static void Touch(string filename)
        {
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

        public static void Cat(string path)
        {
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
}
