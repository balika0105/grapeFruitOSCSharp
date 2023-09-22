using System;


namespace grapeFruitOSCSharp
{
    public class ErrorScreen
    {
        //Disables "unreachable code" while we're running the devbuild
#pragma warning disable CS0162
        public static void GeneralError()
        {
            if (!Globals.devBuild)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(" -------\n| x   x |\n|   -   |\n -------\n");
                Console.WriteLine("A general fatal error occured in the system");
                Console.WriteLine("If the problem persists, please contact the devs");

                Console.Write("\n\nPress a key to reboot!");
                Console.ReadKey();
                Cosmos.System.Power.Reboot();
            }
            else
            {
                Logger.Log(3, "General System Exception");
            }

        }

        public static void SpecifiedError(Exception e)
        {
            if (!Globals.devBuild)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(" -------\n| x   x |\n|   -   |\n -------\n");
                Console.WriteLine("A fatal error occured");
                if (e.Message != "")
                    Console.WriteLine("\nError information:\n" + e.Message);
                else
                    Console.WriteLine("Couldn't get error message");

                Console.WriteLine("If the problem persists, please contact the devs");

                Console.Write("\n\nPress a key to reboot!");
                Console.ReadKey();
                Cosmos.System.Power.Reboot();
            }
            else
            {
                Logger.Log(3, "System Exception | Exception: " + e.ToString()+ "\n\tMessage: " + e.Message);
            }

        }

        public static void CustomError(string errormessage)
        {
            if (!Globals.devBuild)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(" -------\n| x   x |\n|   -   |\n -------\n");
                Console.WriteLine("A fatal error occured and the system had to be halted");
                Console.WriteLine("\nError information:\n" + errormessage);
                Console.WriteLine("If the problem persists, please contact the devs");

                Console.Write("\n\nPress a key to reboot!");
                Console.ReadKey();
                Cosmos.System.Power.Reboot();
            }
            else
            {
                Logger.Log(3, "System Exception | Message: " + errormessage);
            }
        }
    }
}
