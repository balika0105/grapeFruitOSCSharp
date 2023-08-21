using System;
using System.Collections.Generic;
using System.IO;

using Sys = Cosmos.System;

using Cosmos.HAL.Drivers.Video;

namespace GrapeFruit_CosmosRolling.nano
{
    public class nanomain
    {
        const string verNum = "0.3";
        static string fileName = "";
        static int cursorX, cursorY;

        static List<string> text;

        static bool saveFileFooter;

        public static void Main(string file = "")
        {
            Logger.Debug("Nano launched");
            cursorX = 0;
            cursorY = 0;

            text = new List<string>();
            if (file == "")
            {
                text.Add("");
            }
            else
            {
                //Checking for file
                if (file.Contains(@":\"))
                {
                    //Absolute path, don't need pwd from Globals
                    if (File.Exists(file))
                        text = LoadFile(file);
                    else
                    {
                        //File does not exist, we'll create it later
                        text.Add("");
                    }
                }
                else
                {
                    file = Globals.workingdir + file;
                    //Relative path
                    if (File.Exists(file))
                        text = LoadFile(file);
                    else
                    {
                        //File does not exist, we'll create it later
                        text.Add("");
                    }
                }
            }

            fileName = file;
            Logger.Debug($"{file}");


            

            while (true)
            {
                Render(text, cursorX, cursorY, saveFileFooter);
                if(saveFileFooter)
                {
                    saveFileFooter = false;
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.X)
                {
                    // Quit the editor
                    Console.Clear();
                    break;
                }
                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.O)
                {
                    // Save the file
                    SaveFile(text, file);
                }

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        // Insert a new line
                        Logger.Debug("LF");
                        text.Insert(cursorY + 1, text[cursorY].Substring(cursorX));
                        text[cursorY] = text[cursorY].Substring(0, cursorX);
                        cursorY++;
                        cursorX = 0;
                        break;
                    case ConsoleKey.Backspace:
                        // Delete the character to the left of the cursor
                        Logger.Debug("BKSP");
                        if (cursorX > 0)
                        {
                            text[cursorY] = text[cursorY].Remove(cursorX - 1, 1);
                            cursorX--;
                        }
                        else if (cursorY > 0)
                        {
                            int lineLength = text[cursorY - 1].Length;
                            text[cursorY - 1] += text[cursorY];
                            text.RemoveAt(cursorY);
                            cursorY--;
                            cursorX = lineLength;
                        }
                        break;
                    case ConsoleKey.Delete:
                        Logger.Debug("DEL");
                        // Delete the character at the cursor
                        if (cursorX < text[cursorY].Length)
                        {
                            text[cursorY] = text[cursorY].Remove(cursorX, 1);
                        }
                        else if (cursorY < text.Count - 1)
                        {
                            text[cursorY] += text[cursorY + 1];
                            text.RemoveAt(cursorY + 1);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        // Move the cursor left
                        Logger.Debug("LeftArrow");
                        if (cursorX > 0)
                        {
                            cursorX--;
                        }
                        else if (cursorY > 0)
                        {
                            cursorY--;
                            cursorX = text[cursorY].Length;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        // Move the cursor right
                        Logger.Debug("RightArrow");
                        if (cursorX < text[cursorY].Length)
                        {
                            cursorX++;
                        }
                        else if (cursorY < text.Count - 1)
                        {
                            cursorY++;
                            cursorX = 0;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        // Move the cursor up
                        Logger.Debug("UpArrow");
                        if (cursorY > 0)
                        {
                            cursorY--;
                            cursorX = Math.Min(cursorX, text[cursorY].Length);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        // Move the cursor down
                        Logger.Debug("DownArrow");
                        if (cursorY < text.Count - 1)
                        {
                            cursorY++;
                            cursorX = Math.Min(cursorX, text[cursorY].Length);
                        }
                        break;
                    case ConsoleKey.End:
                        //Move cursor to end of line
                        Logger.Debug("End key");
                        if (cursorX < text[cursorY].Length)
                        {
                            cursorX = text[cursorY].Length;
                        }
                        break;
                    case ConsoleKey.Home:
                        //Move cursor to beginning of line
                        Logger.Debug("Home key");
                        cursorX = 0;
                        break;
                    default:
                        if (key.KeyChar >= ' ')
                        {
                            // Insert a character at the cursor
                            Logger.Debug("Insert char \'" + key.KeyChar + '\'');
                            string line = text[cursorY];
                            text[cursorY] = line.Substring(0, cursorX) + key.KeyChar + line.Substring(cursorX);
                            cursorX++;
                            /*selectionStartX = cursorX;
                            selectionStartY = cursorY;*/
                        }
                        break;
                }   
            }
        }



        static void Render(List<string> text, int cursorX, int cursorY, bool saved = false)
        {
            Logger.Debug("Render");
            Console.Clear();
            //Writing window header
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("GrapeFruit Nano "+ verNum + " | Editing: " + fileName);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(cursorX, cursorY);

            for (int i = 0; i < text.Count; i++)
            {
                Console.SetCursorPosition(0, i+1);
                Console.Write(text[i]);
            }

            //Writing small footer
            if (!saved)
            {
                Console.SetCursorPosition(0, 24);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Ctrl-O: Save // Ctrl-X: Exit instantly");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Logger.Debug("Save file footer");
                Console.SetCursorPosition(0, 24);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Saved file as " + fileName);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.SetCursorPosition(cursorX, cursorY + 1);
        }

        static void SaveFile(List<string> text, string filepath)
        {
            Logger.Debug("SaveFile");
            Logger.Debug($"{filepath}");
            if (filepath == "")
            {
                Console.Clear();
                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine();
                if (File.Exists(fileName))
                {
                    Logger.Debug("save file as " + fileName);
                    StreamWriter writer = new StreamWriter(fileName);
                    foreach (string line in text)
                    {
                        writer.WriteLine(line);
                        Logger.Debug($"{line}");
                    }
                    writer.Close();
                    saveFileFooter = true;
                }
                else
                {
                    Logger.Debug("create & save file as " + fileName);

                    File.Create(fileName).Close();
                    StreamWriter writer = new StreamWriter(fileName);
                    foreach (string line in text)
                    {
                        writer.WriteLine(line);
                        Logger.Debug($"{line}");
                    }
                    writer.Close();
                    saveFileFooter = true;
                }
            }
            else
            {
                try
                {
                    if (File.Exists(filepath))
                    {
                        Logger.Debug("save file as " + filepath);
                        StreamWriter writer = new StreamWriter(filepath);
                        foreach (string line in text)
                        {
                            writer.WriteLine(line);
                            Logger.Debug($"{line}");
                        }
                        writer.Close();
                        saveFileFooter = true;
                    }
                    else
                    {
                        Logger.Debug("create & save file as " + filepath);

                        File.Create(filepath).Close();
                        StreamWriter writer = new StreamWriter(filepath);
                        foreach (string line in text)
                        {
                            writer.WriteLine(line);
                            Logger.Debug($"{line}");
                        }
                        writer.Close();
                        saveFileFooter = true;
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.Clear();
                    Console.Write("Enter file name: ");
                    string fileName = Console.ReadLine();
                    if (File.Exists(fileName))
                    {
                        Logger.Debug("save file as " + fileName);
                        StreamWriter writer = new StreamWriter(fileName);
                        foreach (string line in text)
                        {
                            writer.WriteLine(line);
                            Logger.Debug($"{line}");
                        }
                        writer.Close();
                        saveFileFooter = true;
                    }
                    else
                    {
                        Logger.Debug("create & save file as " + fileName);

                        File.Create(fileName).Close();
                        StreamWriter writer = new StreamWriter(fileName);
                        foreach (string line in text)
                        {
                            writer.WriteLine(line);
                            Logger.Debug($"{line}");
                        }
                        writer.Close();
                        saveFileFooter = true;
                    }
                }
            }

        }

        private static void CreateAndSave()
        {

        }

        static List<string> LoadFile(string path)
        {
            Logger.Debug("LoadFile");
            Logger.Debug($"Path: {path}");
            List<string> temp = new List<string>();
            string[] fileContent = File.ReadAllLines(path);

            foreach (string line in fileContent)
                temp.Add(line);

            return temp;

        }
    }
}