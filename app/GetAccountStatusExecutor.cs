using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    class GetAccountStatusExecutor : EndPointExecutor<YamahaMusicCast.AccountStatus>
    {
        public GetAccountStatusExecutor(WebClient client, string ip) : base(client, ip)
        {
            Path = "netusb/getAccountStatus";
        }
    }
}
