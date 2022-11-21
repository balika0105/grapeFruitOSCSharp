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
            if(xClient.SendDiscoverPacket() > -1)
                Logger.Log(1, "IP Set with DHCP: " + NetworkConfiguration.CurrentAddress.ToString());
            else
                Logger.Log(2, "Failed to set IP with DHCP");

        }

        public static void ping(string address)
        {
            Console.WriteLine("Pinging " + address);

            Cosmos.System.Global.mDebugger.Send("Trying to split address to ping");

            string[] address_ = address.Split('.');
            byte[] realAddress = { };

            Cosmos.System.Global.mDebugger.Send("Converting address to an array");
            for (int i = 0; i < 4; i++)
            {
                realAddress[i] = byte.Parse(address_[i]);
            }

            using (var xClient = new ICMPClient())
            {
                Cosmos.System.Global.mDebugger.Send("Setting frAddress");
                Address frAddress = new Address(realAddress[0], realAddress[1], realAddress[2], realAddress[3]);
                Cosmos.System.Global.mDebugger.Send("Trying to connect");
                xClient.Connect(frAddress);

                Cosmos.System.Network.IPv4.EndPoint endPoint = new Sys.Network.IPv4.EndPoint(frAddress, 7);

                for (int i = 0; i < 4; i++)
                {
                    xClient.SendEcho();
                    int time = xClient.Receive(ref endPoint);
                    Console.Write("\nReplied in " + time + "s");
                }
            }
        }

        static void ping(Address address)
        {
            using (var xClient = new ICMPClient())
            {
                
                xClient.Connect(address);

                Cosmos.System.Network.IPv4.EndPoint endPoint = new Sys.Network.IPv4.EndPoint(address, 7);

                for (int i = 0; i < 4; i++)
                {
                    xClient.SendEcho();
                    int time = xClient.Receive(ref endPoint);
                    Console.Write("\nReplied in " + time + "s");
                }
            }
        }

        public static void dnsping(string address)
        {
            Console.WriteLine("Pinging " + address);
            #region Resolving DNS
            Address destination;
            using (var xClient = new DnsClient())
            {
                xClient.Connect(new Address(1, 1, 1, 1)); //DNS Server address

                /** Send DNS ask for a single domain name **/
                xClient.SendAsk(address);

                /** Receive DNS Response **/
                destination = xClient.Receive(); //can set a timeout value
            }
            #endregion
            ping(destination);
        }
    }
}
