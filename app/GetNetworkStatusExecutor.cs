using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    class GetNetworkStatusExecutor : EndPointExecutor<YamahaMusicCast.NetworkStatus>
    {
        public GetNetworkStatusExecutor(WebClient client, string ip) : base(client, ip)
        {
            Path = "system/getNetworkStatus";
        }
    }
}
