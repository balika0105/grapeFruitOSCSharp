using Cosmos.System.FileSystem;
using Cosmos.System.Network.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapeFruit_CosmosRolling
{
    public class Command
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Globals.currentuser + "@" + Globals.hostname + " > ");
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

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }

        //Always add every command here
        static void commands()
        {
            Console.WriteLine("help/commands - shows command list");
            Console.WriteLine("echo <message> - prints to screen");
            Console.WriteLine("clear - clears screen");
            Console.WriteLine("time - shows current time (RTC)");
            Console.WriteLine("throwex - throws test exception");
            Console.WriteLine("kblayout - Change keyboard layout (shows dialog)");
            Console.WriteLine("\nls/dir - list directory contents");
            Console.WriteLine("touch <filename> - create empty file with specified name");
            Console.WriteLine("cat <filename> - print file contents");
            Console.WriteLine("mkdir/md <name> - creates directory with name");
            Console.WriteLine("gfdisk - disk utility");
            Console.WriteLine("\nping <address> - pings IPv4 address");
            Console.WriteLine("dnsping <domain name> - pings domain");
            Console.WriteLine("trydhcp - attempt to set dhcp with discover");
            Console.WriteLine("http <server address> - send http request to specified server (experimental)");
            Console.WriteLine("resolvedns <domain name> - resolve domain to IPv4 manually");
            Console.WriteLine("\nwhatis <command> - information about command");
            Console.WriteLine("\nshutdown - turns off computer (asks for confirmation)");
            Console.WriteLine("reboot - reboots computer (asks for confirmation)");
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
                        choice();
                        break;
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
                        choice();
                        break;
                }
            }
            return false;
        }
    }
}
