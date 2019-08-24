using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    class SetInputExecutor : EndPointExecutor<YamahaMusicCast.SimpleResponse>
    {
        public SetInputExecutor(WebClient client, string ipaddress, string value) : base(client, ipaddress)
        {
            Path = $"main/setInput?input={value}";
        }
    }
}
