using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sys = Cosmos.System;

using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.UDP.DNS;

namespace GrapeFruit_CosmosDevKit
{
    public class GrapeFruitNW
    {
        public static void DHCPDiscovery()
        {
            var xClient = new DHCPClient();
            if (xClient.SendDiscoverPacket() > -1)
                Logger.Log(1, "IP Set with DHCP: " + NetworkConfiguration.CurrentAddress.ToString());
            else
                Logger.Log(2, "Failed to set IP with DHCP");

        }

        public static void ping(string address)
        {
            Console.WriteLine("PING " + address);
            byte successful = 0;

            using (var xClient = new ICMPClient())
            {
                EndPoint endPoint = new EndPoint(Address.Zero, 0);
                xClient.Connect(Address.Parse(address));

                for (int i = 0; i < 4; i++)
                {
                    xClient.SendEcho();
                    int time = xClient.Receive(ref endPoint);
                    if (time >= 0)
                    {
                        Console.Write("Reply from " + address + ": icmp_seq=" + (i + 1) + " time=" + time);
                        successful++;
                    }
                    else
                    {
                        Console.Write("Request timed out");
                    }

                    Console.Write("\n");
                }
            }
            Console.WriteLine("\n\n--- " + address + " ping statistics ---");
            Console.WriteLine("4 packets transmitted, " + successful + " received, " + (4 - successful) + " lost");
        }

        static void ping(Address address)
        {
            Console.WriteLine("PING " + address.ToString());
            byte successful = 0;

            using (var xClient = new ICMPClient())
            {
                EndPoint endPoint = new EndPoint(Address.Zero, 0);
                xClient.Connect(address);

                for (int i = 0; i < 4; i++)
                {
                    xClient.SendEcho();
                    int time = xClient.Receive(ref endPoint);
                    if (time >= 0)
                    {
                        Console.Write("Reply from " + address + ": icmp_seq=" + (i + 1) + " time=" + time);
                        successful++;
                    }
                    else
                    {
                        Console.Write("Request timed out");
                    }

                    Console.Write("\n");
                }
            }
            Console.WriteLine("\n\n--- " + address + " ping statistics ---");
            Console.WriteLine("4 packets transmitted, " + successful + " received, " + (4 - successful) + " lost");
        }

        public static void dnsping(string address)
        {
            Logger.Debug("Called DNSPing, attempting to ping " + address);
            Console.WriteLine("Pinging " + address);
            #region Resolving DNS
            Address destination;
            using (var xClient = new DnsClient())
            {
                Logger.Debug("Attempting to connect to DNS Server 1.1.1.1");
                xClient.Connect(new Address(1, 1, 1, 1)); //DNS Server address

                /** Send DNS ask for a single domain name **/
                Logger.Debug("Asking DNS server to resolve domain name");
                xClient.SendAsk(address);

                /** Receive DNS Response **/
                destination = xClient.Receive(); //can set a timeout value
            }
            #endregion
            Console.WriteLine(address + " resolved to " + destination.ToString());
            ping(destination);
        }
    }
}
