using System;

using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.UDP.DNS;

namespace grapeFruitRebuild
{
    public class nw
    {
        static Address LocalIP = new Address(127, 0, 0, 1);

        public static void DHCPSetup()
        {
            if(Globals.nic != null)
            {
                Logger.Debug("Starting setup with DHCP Discovery");

                using var dhcpclient = new DHCPClient();
                if(dhcpclient.SendDiscoverPacket() > -1)
                {
                    Logger.Log(1, "DHCP Setup OK, acquired IP: " + NetworkConfiguration.CurrentAddress.ToString());
                    //Logger.Debug("More info:\nDefault Gateway:" + NetworkConfiguration.CurrentNetworkConfig.IPConfig.DefaultGateway.ToString() + "\nSubnet mask: " + NetworkConfiguration.CurrentNetworkConfig.IPConfig.SubnetMask.ToString() + "\nMAC Address: " + NetworkConfiguration.CurrentNetworkConfig.Device.MACAddress.ToString());
                }
            }
            else
            {
                Logger.Log(3, "nw.DHCPSetup: Network device not initialised!");
            }
        }
    }
}
