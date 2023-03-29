﻿using Cosmos.System.FileSystem;
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
                    throw new DivideByZeroException();

                case "shutdown":
                    shutdown();
                    break;

                case "reboot":
                    reboot();
                    break;

                case "ls":
                case "dir":
                    FS.List();
                    break;

                case "touch":
                    FS.Touch(splitinput[1]);
                    break;

                case "cat":
                    FS.Cat(splitinput[1]);
                    break;

                case "gfdisk":
                    gfdisk.main();
                    break;

                case "ping":
                    GrapeFruitNW.ping(splitinput[1]);
                    break;

                case "dnsping":
                    GrapeFruitNW.dnsping(splitinput[1]);
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
                    GrapeFruitNW.resolvedns(splitinput[1]);
                    break;

                case "man":
                    Mandb.man(splitinput[1]);
                    break;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }

        //Always add every command here
        static void commands()
        {
            Console.WriteLine("help/commands - shows command list\necho - prints to screen\nclear - clears screen\ntime - shows current time (RTC)\nthrowex - throws text exception\n\nls/dir - list directory contents\ntouch - create empty file with specified name\ncat - print file contents\ngfdisk - disk utility\n\nping - pings IPv4 address\ndnsping - Pings to domain\ntrydhcp - Attempt to discover DHCP manually\nhttp - sending an http request to the specified server (experimental)\nresolvedns - resolve domain to IPv4 manually\n\nman <command> - more information about command\n\nshutdown - turns off computer\nreboot - reboots computer");
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
            return false;
        }
    }
}