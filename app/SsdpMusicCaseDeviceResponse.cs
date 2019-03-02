using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace app
{
    class SsdpMusicCastDeviceResponse : SsdpResponse
    {
        const string _separator = ":";
        const string _empty = "Unknown";
        const string _xModelName = "X-ModelName";
        const string _usn = "USN";

        public string ModelName
        {
            get
            {
                return Headers.FirstOrDefault(c => c.Key.Equals(_xModelName, StringComparison.InvariantCultureIgnoreCase)).Value ?? _empty;
            }
        }
        public string Name
        {
            get
            {
                var parts = ModelName.Split(_separator);
                if (parts.Length == 3)
                {
                    return parts[2];
                }
                return _empty;
            }
        }
        public string Model
        {
            get
            {
                var parts = ModelName.Split(_separator);
                if (parts.Length == 3)
                {
                    return parts[0];
                }
                return _empty;
            }
        }
        public string SystemUdid
        {
            get
            {
                var value = Headers.FirstOrDefault(c => c.Key.Equals(_usn, StringComparison.InvariantCultureIgnoreCase)).Value ?? _empty;
                var parts = value.Split(_separator);
                if (parts.Length > 2)
                {
                    return $"{parts[0]}{_separator}{parts[1]}";
                }
                return _empty;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is SsdpMusicCastDeviceResponse)
            {
                return SystemUdid == ((SsdpMusicCastDeviceResponse)obj).SystemUdid;
            }
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return SystemUdid.GetHashCode();
        }
    }
}
