using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace GrapeFruitCSharp
{
    public class ErrorScreen
    {
        public static void Main(Exception exc)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.Write(" -------\n| x   x |\n|   -   |\n -------\n\n");
            Console.WriteLine("The system detected a critical failure and it had to be halted");
            Console.WriteLine("to prevent further damages.");
            Console.WriteLine("Unfortunately all unsaved work is lost");
            Console.WriteLine("\n\nError message: "+exc.Message);
            Console.WriteLine("\n\nPress I for more info, press any other key to reboot");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.I:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Clear();
                    Console.WriteLine(SystemVars.systemName + " " + SystemVars.systemBuild);
                    Console.WriteLine("- - - Kernel crash error report - - -");
                    Console.WriteLine("Cause of crash: " + exc.Message);

                    Console.WriteLine("Data:\n" + exc.Data);

                    Console.WriteLine("Press any key to reboot");
                    Console.ReadKey();
                    Sys.Power.Reboot();
                    break;

                default:
                    Sys.Power.Reboot();
                    break;
            }
        }
    }
}
