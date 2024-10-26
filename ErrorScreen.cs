using System;

namespace grapeFruitRebuild
{
    public class ErrorScreen
    {
        public static void GeneralError()
        {
            Logger.Log(4, "General Critical Failure. \nSystem halted. Press a key to reboot");
            Console.ReadKey();
            Cosmos.System.Power.Reboot();
        }

        public static void SpecifiedError(Exception e)
        {
            Logger.Log(4, "Critical failure\n");
            Console.WriteLine("\nA critical error occured and the system was halted.");
            Console.WriteLine("\nException message: " + e.Message);
            Console.WriteLine("Exception ToString: " + e.ToString());
            Console.WriteLine("\nPress any key to reboot");

            Logger.Debug("Exception message: " + e.Message + "\nException ToString: " + e.ToString());

            Console.ReadKey();
            Cosmos.System.Power.Reboot();
        }

        public static void CustomError(string errormessage)
        {
            Logger.Log(4, errormessage + "\nSystem halted. Press a key to reboot.");
            Console.ReadKey();
            Cosmos.System.Power.Reboot();
        }
    }
}
