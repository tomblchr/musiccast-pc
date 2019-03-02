using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace app
{
    class DeviceDiscovery
    {
        public DeviceDiscovery()
        {

        }

        public IEnumerable<SsdpMusicCastDeviceResponse> Find()
        {
            return null;
        }

        public static void ReallySimpleDiscovery()
        {
            Console.Write("Searching...");
            var responses = new List<SsdpMusicCastDeviceResponse>();

            try
            {
                var localEndPoint = new IPEndPoint(IPAddress.Any, 0);
                var ssdpEndPoint = new IPEndPoint(IPAddress.Parse("239.255.255.250"), 1900);
                using (var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    udpSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    udpSocket.Bind(localEndPoint);
                    udpSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ssdpEndPoint.Address, IPAddress.Any));

                    const string SearchString = "M-SEARCH * HTTP/1.1\r\nHost: 239.255.255.250:1900\r\nMan: \"ssdp:discover\"\r\nST: ssdp:all\r\nMX: 3\r\n\r\n";
                    udpSocket.SendTo(System.Text.Encoding.ASCII.GetBytes(SearchString), ssdpEndPoint);

                    var buffer = new byte[4096];
                    var timeout = DateTime.UtcNow + TimeSpan.FromSeconds(10);
                    while (timeout > DateTime.UtcNow)
                    {
                        if (udpSocket.Available > 0)
                        {
                            Console.Write(".");
                            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
                            var size = udpSocket.ReceiveFrom(buffer, ref remote);
                            var response = SsdpResponse.Parse<SsdpMusicCastDeviceResponse>(System.Text.Encoding.ASCII.GetString(buffer, 0, size), remote);
                            if (response != null) responses.Add(response);
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Search error: " + ex);
            }

            Console.WriteLine(Environment.NewLine + "Done!");

            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(responses.MusicCast()));
            responses
                .MusicCast()
                .ToList()
                .ForEach(c => 
                {
                    var locator = new SsdpReponseLocator(c);
                    Console.WriteLine($"{c.Name}{Environment.NewLine}    {c.Model} {locator.Locate().PresentationURL} {c.Location}");
                });
        }
    }
}
