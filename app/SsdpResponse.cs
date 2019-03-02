using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;

namespace app
{
    class SsdpResponse
    {
        private List<KeyValuePair<string, string>> _headers = new List<KeyValuePair<string, string>>();
        protected SsdpResponse() { }
        public string HttpVersion { get; private set; }
        public int StatusCode { get; private set; }
        public string ReasonPhrase { get; private set; }
        public IPEndPoint RemoteEndPoint { get; private set; }
        public ReadOnlyCollection<KeyValuePair<string, string>> Headers
        {
            get
            {
                return _headers.AsReadOnly();
            }
        }
        public string ServiceType
        {
            get
            {
                return _headers.FirstOrDefault(h => h.Key.ToLowerInvariant() == "st").Value ?? "Unknown service type";
            }
        }
        public string Location
        {
            get
            {
                return _headers.FirstOrDefault(h => h.Key.ToLowerInvariant() == "location").Value ?? "Unknown location";
            }
        }
        public override string ToString()
        {
            return RemoteEndPoint.Address.ToString() + " -> " + ServiceType + Environment.NewLine
                + string.Join(Environment.NewLine, _headers.Select(c => $"    {c.Key} : {c.Value}"));
        }
        public static T Parse<T>(string data, EndPoint remote) where T : SsdpResponse
        {
            T response = Activator.CreateInstance<T>();

            try
            {
                var parts = new List<string>(data.Split(new string[] { "\r\n" }, StringSplitOptions.None));
                var statusLine = parts[0].Split(' ');
                response.HttpVersion = statusLine[0];
                response.StatusCode = int.Parse(statusLine[1]);
                response.ReasonPhrase = statusLine[2];
                for (var i = 1; i < parts.Count; i++)
                {
                    if (parts[i].Length > 0)
                    {
                        var headerParts = parts[i].Split(new char[] { ':' }, 2);
                        response._headers.Add(new KeyValuePair<string, string>(headerParts[0].Trim(), headerParts[1].Trim()));
                    }
                    else
                    {
                        break;
                    }
                }

                response.RemoteEndPoint = (IPEndPoint)remote;
            }
            catch (Exception)
            {
                Console.WriteLine("Error parsing a response; skipping...");
                return null;
            }

            return response;
        }
    }

}
