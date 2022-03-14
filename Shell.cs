using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Sys = Cosmos.System;

namespace GrapeFruitCSharp
{
    public class Shell
    {
        public static void Init()
        {
            if (SystemVars.isLive)
            {
                EnvVars.hostname = "GrapeFruitLive";

                Console.WriteLine("\n - - - GrapeFruit Shell Initialization - - -");

                Console.WriteLine("This system is running in a live environment");
                Console.WriteLine("Any change to the settings WILL BE LOST!");
                #region fs check
                if (EnvVars.isFS)
                {
                    Console.WriteLine("The system has an available filesystem");
                    Console.WriteLine("Changes to the files will be saved");
                }
                else if (EnvVars.isFS)
                {
                    Console.WriteLine("The system does not have an available filesystem");
                    Console.WriteLine("Users are unable to change files");
                }
                #endregion

                #region Login
                Console.Write("Please enter a username for this session: ");
                if (UserHandler.Login(Console.ReadLine()))
                {
                    Console.WriteLine("Successfully logged in as " + EnvVars.currentUser);
                }
                else
                {
                    Console.WriteLine("Login failed! Setting user to \"live\"");
                    EnvVars.currentUser = "live";
                }
                #endregion
            }
            else
            {
                //This part will be implemented once we have proper installer and all
            }

            Console.Clear();
            Console.Write("   _____                      ______          _ _      ____   _____ \n  / ____|                    |  ____|        (_) |    / __ \\ / ____|\n | |  __ _ __ __ _ _ __   ___| |__ _ __ _   _ _| |_  | |  | | (___  \n | | |_ | '__/ _` | '_ \\ / _ \\  __| '__| | | | | __| | |  | |\\___ \\ \n | |__| | | | (_| | |_) |  __/ |  | |  | |_| | | |_  | |__| |____) |\n  \\_____|_|  \\__,_| .__/ \\___|_|  |_|   \\__,_|_|\\__|  \\____/|_____/ \n                  | |                                               \n                  |_|                                               \n");
            Console.WriteLine("\n"+SystemVars.systemBuild);
            if (SystemVars.isTestBuild)
            {
                Console.WriteLine("This build is for TESTING PURPOSES!");
            }
        }

        public static void CLI()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(EnvVars.currentUser + "@" + EnvVars.hostname);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" > ");

            string commandInput = Console.ReadLine();
            string[] commandInputSplit = commandInput.Split(' ');
            Commands.Input(commandInputSplit);
        }
    }

    class Commands
    {
        public static void Input(string[] input)
        {
            switch (input[0])
            {
                case "ver":
                case "sysver":
                    SysVer();
                    break;

                case "man":
                    Manual(input[1]);
                    break;

                case "shutdown":
                    Shutdown(input);
                    break;

                case "crash":
                    Crash(input);
                    break;

                case "help":
                    Help();
                    break;

                case "clear":
                case "cls":
                    Console.Clear();
                    break;

                case "graphics":
                    Console.Clear();
                    GraphicsTest.CallThisFromOutside();
                    break;

                case "credits":
                    Console.WriteLine("\n - - - Credits - - -");
                    Console.WriteLine(SystemVars.credits);
                    break;


                default:
                    Console.WriteLine("Unknown command!");
                    break;
            }
        }

        static void SysVer()
        {
            Console.WriteLine(SystemVars.systemName);
            Console.WriteLine("Version "+SystemVars.systemVersion);
            Console.WriteLine("Build number"+SystemVars.systemBuild);
        }

        static void Help()
        {
            Console.WriteLine("help - shows this");
            Console.WriteLine("ver, sysver - prints system version info");
            Console.WriteLine("man <command> - prints command manual");
            Console.WriteLine("clear - clears screen");
            Console.WriteLine("credits - Print credits to screen");
            Console.WriteLine("shutdown - shuts system down (parameters available)");
            Console.WriteLine("\n - - - DEBUG - - -");
            Console.WriteLine("crash <message> - Crash the system with a custom message");
            Console.WriteLine("graphics - Launches a test graphical environment");
        }

        static void Crash(string[] message)
        {
            string message2 = "";
            for (int i = 1; i < message.Length; i++)
            {
                message2 += message[i] + " ";
            }
            throw new Exception(message2);
        }

        /*NOTE: Shutdown will be in a separate class, so
         * when the system gets complex, everything will be unloaded properly!
         */
        static void Shutdown(string[] parameters)
        {
            if (parameters[1] == "-s")
            {
                if (Choice("This will shut down your device. Continue?"))
                {
                    Cosmos.System.Power.Shutdown();
                    
                }
                else
                {
                    Console.WriteLine("Shutdown cancelled");
                }
            }
            if (parameters[1] == "-r")
            {
                if (Choice("This will reboot your device. Continue?"))
                {
                    Cosmos.System.Power.Reboot();
                }
                else
                {
                    Console.WriteLine("Reboot cancelled");
                }
            }
            else
            {
                Console.WriteLine("Invalid parameters, see \"man shutdown\" for more information");
            }
        }

        static void Manual(string command)
        {
            switch (command)
            {
                case "shutdown":
                    Console.WriteLine("shutdown - Power control for the OS");
                    Console.WriteLine("Usage: shutdown [-s | -r]");
                    Console.WriteLine("\t-s : Perform a proper shutdown");
                    Console.WriteLine("\t-r : Perform a proper reboot");
                    break;

                case "ver":
                case "sysver":
                    Console.WriteLine("ver | sysver - System version information");
                    Console.WriteLine("Prints system info to terminal");
                    Console.WriteLine("Nothing special about that...");
                    break;

                case "crash":
                    Console.WriteLine("crash - DEBUG: Used for testing the stop screen");
                    Console.WriteLine("Usage: crash <message>");
                    Console.WriteLine("<message>: Input from user");
                    break;

                case "graphics":
                    Console.WriteLine("graphics - Starts a test graphical environment");
                    Console.WriteLine("Currently it only runs in a 1024x768 resolution");
                    Console.WriteLine("Reboot if you get \"Out of range\" on your display");
                    break;

                default:
                    Console.WriteLine("Command not in man-db");
                    break;
            }
        }

        static bool Choice(string message)
        {
        repeat:
            Console.Write(message + " (Y/n): ");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    return true;

                case ConsoleKey.Enter:
                    return true;

                case ConsoleKey.N:
                    return false;

                default:
                    goto repeat;
            }
            //return false;

        }
    }
}
