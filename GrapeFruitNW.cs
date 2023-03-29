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
using Cosmos.System.Network.IPv4.TCP;

namespace GrapeFruit_CosmosRolling
{
    public class GrapeFruitNW
    {
        public static void DHCPDiscovery()
        {
            Logger.Debug("DHCPDiscovery called");
            using (var xClient = new DHCPClient())
            {
                Logger.Debug("using xClient DHCP");
                /** Send a DHCP Discover packet **/
                //This will automatically set the IP config after DHCP response
                if (xClient.SendDiscoverPacket() > -1)
                    Logger.Log(1, "IP Set with DHCP: " + NetworkConfiguration.CurrentAddress.ToString());
                else
                    Logger.Log(2, "Failed to set IP with DHCP");
            }
        }

        public static void ping(string address)
        {
            Console.WriteLine("PING " + address);
            byte successful = 0;

            using (var xClient = new ICMPClient())
            {
                Sys.Network.IPv4.EndPoint endPoint = new Sys.Network.IPv4.EndPoint(Address.Zero, 0);
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
                Sys.Network.IPv4.EndPoint endPoint = new Sys.Network.IPv4.EndPoint(Address.Zero, 0);
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
            Address destination = dnsresolve(address);
            #endregion
            Console.WriteLine(address + " resolved to " + destination.ToString());
            ping(destination);
        }

        public static void http(string url)
        {
            using (var xClient = new TcpClient(80))
            {
                //Resolving domain to IPv4
                Address destination = dnsresolve(url);
                xClient.Connect(destination, 80);

                //Sending a HTTP request
                string message = "POST / HTTP/1.1\nHost: localhost:80\nUser-Agent: httpCommand/0.1 (GrapeFruit)\nAccept: text/html\nAccept-Language: en-US,en;q=0.5\nConnection: keep-alive";
                xClient.Send(Encoding.ASCII.GetBytes(message));

                //Receiving data
                var endpoint = new Sys.Network.IPv4.EndPoint(Address.Zero, 0);
                var data = xClient.Receive(ref endpoint);
                var data2 = xClient.NonBlockingReceive(ref endpoint);

                Console.WriteLine("Received data as follows: ");
                foreach (byte item in data2)
                {
                    Console.Write(item);
                }
            }
        }

        static Address dnsresolve(string address)
        {
            #region Resolving DNS
            Address destination;
            using (var xClient = new DnsClient())
            {
                Logger.Debug("Attempting to connect to OpenDNS (208.67.222.222");
                xClient.Connect(new Address(208, 67, 222, 222)); //DNS Server address

                /** Send DNS ask for a single domain name **/
                Logger.Debug("Asking DNS server to resolve domain name");
                xClient.SendAsk(address);

                /** Receive DNS Response **/
                destination = xClient.Receive(); //can set a timeout value
            }
            #endregion
            return destination;
        }
        public static void resolvedns(string address)
        {
            Address server = dnsresolve(address);
            Console.WriteLine(address + " resolved to " + server.ToString());
        }
    }
}
