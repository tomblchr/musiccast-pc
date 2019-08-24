using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    class SetPowerExecutor : EndPointExecutor<YamahaMusicCast.SimpleResponse>
    {
        public SetPowerExecutor(WebClient client, string ip, string value) : base(client, ip)
        {
            string option = value?.ToLower();
            switch (option)
            {
                case "off":
                case "standby": Path = "main/setPower?power=standby"; break;
                case "toggle": Path = "main/setPower?power=toggle"; break;
                case "on":
                default: Path = "main/setPower?power=on"; break;
            }
        }
    }
}
