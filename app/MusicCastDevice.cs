using System;
using System.Collections.Generic;
using System.Text;

namespace app
{
    class MusicCastDevice : Device
    {
        IEnumerable<MusicCastDeviceService> _serviceList = new List<MusicCastDeviceService>();

        [System.Xml.Serialization.XmlElement(ElementName = "X_URLBase")]
        public string URLBase;

        [System.Xml.Serialization.XmlElement(ElementName = "X_serviceList")]
        public IEnumerable<MusicCastDeviceService> ServiceList
        {
            get
            {
                return _serviceList;
            }
        }
    }
}
