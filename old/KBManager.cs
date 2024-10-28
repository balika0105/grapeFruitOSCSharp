using Cosmos.System.ScanMaps;
using System;

namespace grapeFruitOSCSharp
{
    public class KBManager
    {
        static bool ChangeLayout(string layout)
        {
            switch (layout)
            {
                case "enus":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new USStandardLayout());
                    Globals.swapYZ = false;
                    return true;
                case "huhu":
                    //Cosmos.System.KeyboardManager.SetKeyLayout(new HUStandardLayout());
                    Cosmos.System.KeyboardManager.SetKeyLayout(new HUNewLayout());
                    Globals.swapYZ = true;
                    return true;
                case "dede":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new DEStandardLayout());
                    Globals.swapYZ = true;
                    return true;
                default:
                    return false;
            }
        }

        public static bool AskForLayout()
        {
            loopthing:
            Console.WriteLine("Choose keyboard layout:\n\t[1] en_US\n\t[2] hu_HU\n\t[3] de_DE");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    if (ChangeLayout("enus"))
                        return true;
                    else
                        return false;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    if (ChangeLayout("huhu"))
                        return true;
                    else
                        return false;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    if (ChangeLayout("dede"))
                        return true;
                    else
                        return false;

                default:
                    goto loopthing;
            }
        }
    }
}
