using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace app
{
    abstract class EndPointExecutor<T>
    {
        const string _pathPrefix = "/YamahaExtendedControl/v1/";
        private string _ipaddress { get; set; }

        private WebClient _client;
        public string Path { get; protected set; }
        
        public EndPointExecutor(WebClient client, string ipaddress)
        {
            _client = client;
            _ipaddress = ipaddress;
        }

        public virtual T Execute()
        {
            Console.WriteLine($"Getting features from {_ipaddress}");
            Uri u = new Uri($"http://{_ipaddress}{_pathPrefix}{Path}");
            Console.WriteLine(u.OriginalString);
            string response = "not set";
            try
            {
                response = _client.DownloadString(u);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            }
            catch
            {
                Console.WriteLine($"Error: {response}");
                throw;
            }
        }
    }
}
