using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    class SetMuteExecutor : EndPointExecutor<YamahaMusicCast.SimpleResponse>
    {
        public SetMuteExecutor(WebClient client, string ip, bool value) : base(client, ip)
        {
            Path = $"main/setMute?enable={value.ToString().ToLower()}";
        }
    }
}
