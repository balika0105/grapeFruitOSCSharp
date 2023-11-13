using System;

using System.Text;


using Sys = Cosmos.System;

using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.UDP.DNS;
using Cosmos.System.Network.IPv4.TCP;

namespace grapeFruitOSCSharp
{
    public class GrapeFruitNW
    {
        static Address LocalIP = new Address(127, 0, 0, 1);
        public static void DHCPDiscovery()
        {
            if (Globals.nic == null)
            {
                Console.WriteLine("GrapeFruitNW.DHCPDiscovery: Network device is not initialised");
            }
            else
            {
                Logger.Debug("DHCPDiscovery called");
                using var xClient = new DHCPClient();
                Logger.Debug("using xClient DHCP");
                /** Send a DHCP Discover packet **/
                //This will automatically set the IP config after DHCP response
                if (xClient.SendDiscoverPacket() > -1)
                    Logger.Log(1, "IP Set with DHCP: " + NetworkConfiguration.CurrentAddress.ToString());
                else
                    Logger.Log(2, "Failed to set IP with DHCP");
            }
        }

        public static void Ping(string address)
        {
            if (Globals.nic == null)
            {
                Console.WriteLine("GrapeFruitNW.ping: Network device is not initialised");
            }
            else
            {
                Console.WriteLine("PING " + address);
                byte successful = 0;

                using (var xClient = new ICMPClient())
                {
                    EndPoint endPoint = new (Address.Zero, 0);
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
        }

        static void Ping(Address address)
        {
            if (Globals.nic == null)
            {
                Console.WriteLine("GrapeFruitNW.ping: Network device is not initialised");
            }
            else
            {
                Console.WriteLine("PING " + address.ToString());
                byte successful = 0;

                using (var xClient = new ICMPClient())
                {
                    EndPoint endPoint = new(Address.Zero, 0);
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
        }

        public static void Dnsping(string address)
        {
            if (Globals.nic == null)
            {
                Console.WriteLine("GrapeFruitNW.dnsping: Network device is not initialised");
            }
            else
            {
                Logger.Debug("Called DNSPing, attempting to ping " + address);
                Console.WriteLine("Pinging " + address);
                #region Resolving DNS
                Address destination = Dnsresolve(address);
                #endregion
                Console.WriteLine(address + " resolved to " + destination.ToString());
                Ping(destination);
            }
        }

        public static void Http(string url)
        {
            if (Globals.nic == null)
            {
                Console.WriteLine("GrapeFruitNW.http: Network device is not initialised");
            }
            else
            {
                
                //Resolving domain to IPv4
                Address destination = Dnsresolve(url);
                using var xClient = new TcpClient(destination, 80);
                //xClient.Connect(destination, 80);

                //Sending a HTTP request
                string message = "POST / HTTP/1.1\nHost: localhost:80\nUser-Agent: httpCommand/0.1 (GrapeFruit)\nAccept: text/html\nAccept-Language: en-US,en;q=0.5\nConnection: keep-alive";
                xClient.Send(Encoding.ASCII.GetBytes(message));

                //Receiving data
                var endpoint = new EndPoint(LocalIP, 0);
                var data = xClient.Receive(ref endpoint);
                var data2 = xClient.NonBlockingReceive(ref endpoint);

                Console.WriteLine("Received data as follows: ");
                foreach (byte item in data2)
                {
                    Console.Write(item);
                }
            }
        }

        static Address Dnsresolve(string address)
        {
            #region Resolving DNS
            Address destination;
            using (var xClient = new DnsClient())
            {
                Logger.Debug("Attempting to connect to OpenDNS (208.67.222.222)");
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
        public static void Resolvedns(string address)
        {
            if (Globals.nic == null)
            {
                Console.WriteLine("GrapeFruitNW.resolvedns: Network device is not initialised");
            }
            else
            {
                Address server = Dnsresolve(address);
                Console.WriteLine(address + " resolved to " + server.ToString());
            }
        }
    }
}
