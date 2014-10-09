using System;
using System.Net;
using System.Net.Sockets;
using System.Linq;

namespace AspNetVNext.ServiceDashboard
{
    public static class NetworkExtensions
    {
        public static string GetIpAddress(string hostName)
        {
            var ipaddr = string.Empty;
            try
            {
                var ipAddress = Dns.GetHostEntry(hostName).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                if (ipAddress != null)
                {
                    ipaddr = ipAddress.ToString();
                }
            }
            catch (Exception)
            {
                // suppress error on purpose - return empty string when not being able to retrieve ip address.
            }

            return ipaddr;
        }
    }
}
