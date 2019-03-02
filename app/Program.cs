using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Net;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            string ipaddress = string.Empty;
            WebClient client = new WebClient();

            try
            {
                var app = new CommandLineApplication(false)
                {
                    Name = "MusicCastCLI",
                    Description = "Command line support for Yamaha MusicCast devices",
                    FullName = "Yamaha MusicCast Command Line Interface"
                };

                var ip = app.Option("-i", "IP Address", CommandOptionType.SingleValue);
                var value = app.Option("-v", "Value", CommandOptionType.SingleValue);

                app.Command("discover", config => 
                {
                    config.OnExecute(() =>
                    {
                        DeviceDiscovery.ReallySimpleDiscovery();
                        return 0;
                    });
                });
                app.Command("system/getfeatures", config =>
                {
                    config.OnExecute(() =>
                    {
                        var e = new GetFeaturesExecutor(client, IPAddress(ip));
                        Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(e.Execute()));
                        return 0;
                    });
                });
                app.Command("system/getdeviceinfo", config =>
                {
                    config.OnExecute(() =>
                    {
                        var e = new GetDeviceInfoExecutor(client, IPAddress(ip));
                        Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(e.Execute()));
                        return 0;
                    });
                });
                app.Command("system/getnetworkstatus", config =>
                {
                    config.OnExecute(() =>
                    {
                        var e = new GetNetworkStatusExecutor(client, IPAddress(ip));
                        Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(e.Execute()));
                        return 0;
                    });
                });
                app.Command("netusb/getaccountstatus", config =>
                {
                    config.OnExecute(() =>
                    {
                        var e = new GetAccountStatusExecutor(client, IPAddress(ip));
                        Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(e.Execute()));
                        return 0;
                    });
                });
                app.Command("netusb/getplayinfo", config =>
                {
                    config.OnExecute(() =>
                    {
                        var e = new GetPlayInfoExecutor(client, IPAddress(ip));
                        Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(e.Execute()));
                        return 0;
                    });
                });
                app.Command("main/setmute", config =>
                {
                    config.OnExecute(() =>
                    {
                        var e = new SetMuteExecutor(client, IPAddress(ip), Convert.ToBoolean(value.Value()));
                        Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(e.Execute()));
                        return 0;
                    });
                });
                app.Command("main/setvolume", config =>
                {
                    config.OnExecute(() =>
                    {
                        var e = new SetVolumeExecutor(client, IPAddress(ip), value.Value());
                        Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(e.Execute()));
                        return 0;
                    });
                });
                

                if (args == null || args.Length == 0)
                {
                    app.ShowHelp();
                }
                else
                {
                    Console.WriteLine("Hello MusicCast!");
                    app.Execute(args);
                }
            }
            catch (Exception  e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        static string IPAddress(CommandOption option)
        {
            if (!option.HasValue())
            {
                throw new ArgumentNullException("-i", "This command is not useful without an IP address");
            }

            Console.WriteLine($"Using IP Address {option.Value()}");

            return option.Value();
        }
    }
}
