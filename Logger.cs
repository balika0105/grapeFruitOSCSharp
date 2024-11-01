﻿using Cosmos.System.Network.IPv4.TCP;
using System;
using Sys = Cosmos.System;

namespace grapeFruitRebuild
{
    
    public class Logger
    {
        /// <summary>
        /// This class is for the global logger
        /// </summary>
        /// <param name="type">Type of message; 1- info, 2 - warning, 3 - error, 4 - critical (reserved for bugcheck)</param>
        /// <param name="message">Log message</param>
        static string output = "";
        public static void Log(byte type, string message)
        {
            output = "";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('[');
            switch (type)
            {
                case 2:
                    output = "[WARN] ";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("WARN");
                    break;

                case 3:
                    output = "[FAIL] ";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("FAIL");
                    break;
                case 4:
                    output = "[CRIT] ";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("CRIT");
                    break;

                case 1:
                default:
                    output = "[INFO] ";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("INFO");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]\t");
            Console.WriteLine(message);
            Sys.Global.Debugger.Send(output + message);
        }
        public static void Debug(string message)
        {
            Sys.Global.Debugger.Send("[DEBUG]\t" + message);
        }
    }
}
