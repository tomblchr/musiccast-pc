using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    class SetVolumeExecutor : EndPointExecutor<YamahaMusicCast.SimpleResponse>
    {
        public SetVolumeExecutor(WebClient client, string ip, string value) : base(client, ip)
        {
            Path = $"main/setVolume?volume={value.ToLower()}";
        }
    }
}
