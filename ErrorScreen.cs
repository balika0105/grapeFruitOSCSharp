using System;

namespace grapeFruitRebuild
{
    public class ErrorScreen
    {
        //This is for when an exception happens that can be caught
        //Real bugchecks are handled by Cosmos, those cannot be overwritten
        public static void GeneralError()
        {
            Logger.Log(4, "General Critical Failure. \nSystem integrity might be compromised. Press a key to continue");
            Console.ReadKey();
        }

        public static void SpecifiedError(Exception e)
        {
            Logger.Log(4, "Critical failure");
            Console.WriteLine("A critical error occured");
            Console.WriteLine("\nException message: " + e.Message);
            Console.WriteLine("Exception ToString: " + e.ToString());
            Console.WriteLine("\nSystem integrity might be compromised. Press a key to continue");

            Logger.Debug("Exception message: " + e.Message + "\nException ToString: " + e.ToString());

            Console.ReadKey();
        }

        public static void CustomError(string errormessage)
        {
            Logger.Log(4, errormessage + "\nSystem integrity might be compromised. Press a key to continue");
            Console.ReadKey();
        }
    }
}
