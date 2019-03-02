using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;

namespace app
{
    class GetFeaturesExecutor : EndPointExecutor<YamahaMusicCast.Features>
    {
        public GetFeaturesExecutor(WebClient client, string ip) : base(client, ip)
        {
            Path = "system/getFeatures";
        }
    }
}
