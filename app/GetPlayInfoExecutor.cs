using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    class GetPlayInfoExecutor : EndPointExecutor<YamahaMusicCast.PlayInfo>
    {
        public GetPlayInfoExecutor(WebClient client, string ip) : base(client, ip)
        {
            Path = "netusb/getPlayInfo";
        }
    }
}
