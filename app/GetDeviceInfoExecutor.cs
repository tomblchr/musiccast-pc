using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    class GetDeviceInfoExecutor : EndPointExecutor<YamahaMusicCast.DeviceInfo>
    {
        public GetDeviceInfoExecutor(WebClient client, string ip) : base(client, ip)
        {
            Path = "system/getDeviceInfo";
        }
    }
}
