﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapeFruit_CosmosRolling
{
    public class Logger
    {
        /// <summary>
        /// This class is for the global logger
        /// </summary>
        /// <param name="type">Type of message; 1- info, 2 - warning, 3 - error</param>
        /// <param name="message">Log message</param>
        public static void Log(byte type, string message)
        {
            Console.Write('[');
            switch (type)
            {
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("WARN");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("FAIL");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("INFO");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.Write("]\t");
            Console.WriteLine(message);
        }
        public static void Debug(string message)
        {
            Cosmos.System.Global.mDebugger.Send("[DEBUG]\t" + message);
        }
    }
}