using Cosmos.System.ScanMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapeFruit_CosmosRolling
{
    public class KBManager
    {
        static bool ChangeLayout(string layout)
        {
            switch (layout)
            {
                case "enus":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new USStandardLayout());
                    return true;
                case "huhu":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new HUStandardLayout());
                    return true;
                case "dede":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new DEStandardLayout());
                    return true;
                default:
                    return false;
            }
        }

        public static bool AskForLayout()
        {
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
                    return false;
            }
        }
    }
}
