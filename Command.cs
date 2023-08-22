using Cosmos.System.Network.Config;
using grapeFruitOSCSharp.Filesystem;
using System;

namespace GrapeFruit_CosmosRolling
{
    public class Command
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{Globals.currentuser}@{Globals.hostname} {Globals.workingdir}]> ");
            Console.ForegroundColor = ConsoleColor.White;
            string command = Console.ReadLine();
            Process(command);

        }

        static void Process(string input)
        {
            //Splitting input to words
            string[] splitinput = input.Split(' ');
            switch (splitinput[0])
            {
                case "echo":
                    echo(splitinput);
                    break;

                case "clear":
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    break;

                case "time":
                    time();
                    break;

                case "help":
                case "commands":
                    if (splitinput.Length > 1)
                        commands(splitinput[1]);
                    else
                        commands();
                    break;

                case "throwex":
                    throw new ArgumentOutOfRangeException();

                case "shutdown":
                    shutdown();
                    break;

                case "reboot":
                    reboot();
                    break;

                case "ls":
                case "dir":
                    if (splitinput.Length > 1)
                        FS.List(splitinput[1]);
                    else
                        FS.List();
                    break;

                case "cd":
                    if (splitinput.Length > 1)
                        FS.Chdir(splitinput[1]);
                    else
                        Console.WriteLine("Not enough parameters");
                    break;

                case "pwd":
                    Console.WriteLine(Globals.workingdir);
                    break;

                case "touch":
                    if (splitinput.Length > 1)
                        FS.Touch(splitinput[1]);
                    else
                        Console.WriteLine("Not enough parameters");
                    break;

                case "cat":
                    if (splitinput.Length > 1)
                        FS.Cat(splitinput[1]);
                    else
                        Console.WriteLine("Not enough parameters");
                    break;

                case "mkdir":
                case "md":
                    if (splitinput.Length > 1)
                        FS.Mkdir(splitinput[1]);
                    else
                        Console.WriteLine("Not enough parameters");
                    break;

                case "gfdisk":
                    gfdisk.main();
                    break;

                case "ping":
                    if (splitinput.Length > 1)
                        GrapeFruitNW.ping(splitinput[1]);
                    else
                        Console.WriteLine("Not enough parameters");
                    break;

                case "dnsping":
                    if (splitinput.Length > 1)
                        GrapeFruitNW.dnsping(splitinput[1]);
                    else
                        Console.WriteLine("Not enough parameters");
                    break;

                case "trydhcp":
                    Logger.Debug("Clearing network configurations");
                    NetworkConfiguration.ClearConfigs();
                    Logger.Debug("Attempting DHCP Discovery");
                    GrapeFruitNW.DHCPDiscovery();
                    break;

                case "http":
                    GrapeFruitNW.http(splitinput[1]);
                    break;

                case "resolvedns":
                    if(splitinput.Length > 1)
                        GrapeFruitNW.resolvedns(splitinput[1]);
                    else
                        Console.WriteLine("Not enough parameters");
                    break;

                case "whatis":
                    if (splitinput.Length > 1)
                        Mandb.man(splitinput[1]);
                    else
                        Console.WriteLine("Not enough parameters");
                    break;

                case "kblayout":
                    KBManager.AskForLayout();
                    break;

                case "nano":
                    if (splitinput.Length > 1)
                        nano.nanomain.Main(splitinput[1]);
                    else
                        nano.nanomain.Main();
                    break;

                case "rm":
                    if (splitinput.Length > 1)
                        FS.Remove(splitinput[1]);
                    else
                        Console.WriteLine("Not enough parameters");
                    break;

                case "desktop":
                    desktop();
                    break;

                default:
                    Console.WriteLine("gfsh> Unknown command");
                    break;
            }
        }

        //Always add every command here
        static void commands(string category = "")
        {
            switch (category)
            {
                case "":
                default:
                    Console.WriteLine("Commands have been organised into categories");
                    Console.WriteLine("To access categories, type in the following:");
                    Console.WriteLine("\t- help <category>");
                    Console.WriteLine("\t- commands <category>");

                    Console.WriteLine("\nAvailable categories:");
                    Console.WriteLine("\t- system");
                    Console.WriteLine("\t- network");
                    Console.WriteLine("\t- fs (as in filesystem)");
                    break;

                case "system":
                    Console.WriteLine("Available commands in \"system\" category:\n");
                    Console.WriteLine("help/commands - shows command list");
                    Console.WriteLine("echo <message> - prints to screen");
                    Console.WriteLine("clear - clears screen");
                    Console.WriteLine("time - shows current time (RTC)");
                    Console.WriteLine("throwex - throws test exception");
                    Console.WriteLine("kblayout - Change keyboard layout (shows dialog)");
                    Console.WriteLine("desktop - Enters desktop mode (IN DEVELOPMENT)");
                    Console.WriteLine("shutdown - turns off computer (asks for confirmation)");
                    Console.WriteLine("reboot - reboots computer (asks for confirmation)");
                    Console.WriteLine("whatis <command> - information about command");
                    break;

                case "network":
                    Console.WriteLine("Available commands in \"network\" category:\n");
                    Console.WriteLine("ping <address> - pings IPv4 address");
                    Console.WriteLine("dnsping <domain name> - pings domain");
                    Console.WriteLine("trydhcp - attempt to set dhcp with discover");
                    Console.WriteLine("http <server address> - send http request to specified server (experimental)");
                    Console.WriteLine("resolvedns <domain name> - resolve domain to IPv4 manually");
                    break;

                case "fs":
                    Console.WriteLine("Available commands in \"fs\" category:\n");
                    Console.WriteLine("ls/dir - list directory contents");
                    Console.WriteLine("rm - remove file");
                    Console.WriteLine("touch <filename> - create empty file with specified name");
                    Console.WriteLine("cat <filename> - print file contents");
                    Console.WriteLine("mkdir/md <name> - creates directory with name");
                    Console.WriteLine("gfdisk - disk utility");
                    Console.WriteLine("nano <filename> - text editor");
                    break;
            }
            
            
            
            
            
            
        }

        static void echo(string[] input)
        {
            string output = "";
            for (int i = 1; i < input.Length; i++)
            {
                output += input[i] + ' ';
            }
            Console.WriteLine(output);
        }

        static void time()
        {
            string timeout_ = Cosmos.HAL.RTC.Year.ToString() + '/' + Cosmos.HAL.RTC.Month.ToString() + '/' + Cosmos.HAL.RTC.DayOfTheMonth.ToString() + ' ' + Cosmos.HAL.RTC.Hour.ToString() + ':' + Cosmos.HAL.RTC.Minute.ToString() + ':' + Cosmos.HAL.RTC.Second.ToString();

            Console.WriteLine(timeout_);
        }

        static void shutdown()
        {
            //choice
            if (choice())
            {
                Cosmos.System.Power.Shutdown();
            }
        }

        static void reboot()
        {
            //choice
            if (choice())
            {
                Cosmos.System.Power.Reboot();
            }
        }

        static bool choice()
        {
            redochoice:
            Console.Write("Are you sure? (Y/n)");
            if (!Globals.swapYZ)
            {
                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.Enter:
                    case ConsoleKey.Y:
                        return true;

                    case ConsoleKey.N:
                        Console.Write('\n');
                        return false;

                    default:
                        Console.Write('\n');
                        goto redochoice;
                }
            }
            else
            {
                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.Enter:
                    case ConsoleKey.Z:
                        return true;

                    case ConsoleKey.N:
                        Console.Write('\n');
                        return false;

                    default:
                        Console.Write('\n');
                        goto redochoice;
                }
            }
        }
        static void desktop()
        {
            Console.Clear();
            Console.WriteLine("You will now enter the desktop mode.");
            Console.WriteLine("The system has to be restarted to leave desktop mode");
            if (choice())
            {
                Console.Clear();
                Desktop.DesktopEnvironment.Init();
            }
        }
    }
}
