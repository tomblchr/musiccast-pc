using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace app
{
    class SsdpReponseLocator
    {
        SsdpResponse _response;
        const string _ns = "urn:schemas-upnp-org:device-1-0";
        const string _yamamans = "urn:schemas-yamaha-com:device-1-0";

        public SsdpReponseLocator(SsdpResponse response)
        {
            _response = response ?? throw new ArgumentNullException(nameof(response));
        }

        public MusicCastDevice Locate()
        {
            using (WebClient w = new WebClient())
            {
                var xml = w.DownloadString(_response.Location);
                var result = XElement.Parse(xml);
                var device = result.Element(XName.Get("device", _ns));
                var yam = result.Element(XName.Get("X_device", _yamamans));
                return new MusicCastDevice()
                {
                    DeviceType = device.Element(XName.Get("deviceType", _ns)).Value,
                    FriendlyName = device.Element(XName.Get("friendlyName", _ns)).Value,
                    Manufacturer = device.Element(XName.Get("manufacturer", _ns)).Value,
                    ManufacturerURL = device.Element(XName.Get("manufacturerURL", _ns)).Value,
                    ModelDescription = device.Element(XName.Get("modelDescription", _ns)).Value,
                    ModelName = device.Element(XName.Get("modelName", _ns)).Value,
                    ModelNumber = device.Element(XName.Get("modelNumber", _ns)).Value,
                    ModelURL = device.Element(XName.Get("modelURL", _ns)).Value,
                    SerialNumber = device.Element(XName.Get("serialNumber", _ns)).Value,
                    UDN = device.Element(XName.Get("UDN", _ns)).Value,
                    PresentationURL = device.Element(XName.Get("presentationURL", _ns)).Value,

                    URLBase = yam.Element(XName.Get("X_URLBase", _yamamans)).Value
                };
                //return result
                //    .Element(XName.Get("X_device", _yamamans))?
                //    .Element(XName.Get("X_URLBase", _yamamans))?
                //    .Value;
            }
        }
    }
}
