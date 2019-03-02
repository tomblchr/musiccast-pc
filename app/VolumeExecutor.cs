using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    class VolumeExecutor : EndPointExecutor<int>
    {
        public VolumeExecutor(WebClient client, string ip) : base(client, ip)
        {
            Path = "main/setVolume";
        }
    }
}
