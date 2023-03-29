using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapeFruit_CosmosRolling
{
    public class Mandb
    {
        public static void man(string command)
        {
            //"""""mandb"""""
            switch (command)
            {
                case "echo":
                    Console.WriteLine("Usage: echo <text>");
                    Console.WriteLine("\"Echoes\" back text after the command");
                    break;

                case "touch":
                    Console.WriteLine("Usage: touch <filename>");
                    Console.WriteLine("Creates empty file with the specified name");
                    break;

                case "ping":
                    Console.WriteLine("Usage: ping <IPv4 address>");
                    Console.WriteLine("Example: ping 1.1.1.1");
                    Console.WriteLine("Sends 4 ICMP echo requests to the specified address");
                    break;

                case "dnsping":
                    Console.WriteLine("Usage: dnsping <Domain name>");
                    Console.WriteLine("Example: dnsping archlinux.org");
                    Console.WriteLine("Sends 4 ICMP echo requests to the specified address");
                    break;

                case "http":
                    Console.WriteLine("EXPERIMENTAL COMMAND!");
                    Console.WriteLine("Usage: http <domain name>");
                    Console.WriteLine("Attempting to send an HTTP request header to the server of the domain (Port 80)");
                    break;

                case "resolvedns":
                    Console.WriteLine("Usage: resolvedns <domain name>");
                    Console.WriteLine("Resolve IPv4 address of domain manually (could be useful)");
                    break;

                default:
                    Console.WriteLine("No man entry for command");
                    break;
            }
        }
    }
}
