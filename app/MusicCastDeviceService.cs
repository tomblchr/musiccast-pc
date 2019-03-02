using System;
using System.Collections.Generic;
using System.Text;

namespace app
{
    class MusicCastDeviceService
    {
        public string SpecTypeField;

        [System.Xml.Serialization.XmlElement(ElementName = "x_yxcControlURLField or x_controlURLField")]
        public string ControlURL;

        [System.Xml.Serialization.XmlElement(ElementName = "x_yxcVersionField")]
        public ushort? Version;

        [System.Xml.Serialization.XmlElement(ElementName = "x_unitDescURLField")]
        public string UnitDescURLField;
    }
}
