using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app
{
    static class SsdpResponseExtensions
    {
        public static IEnumerable<T> MusicCast<T>(this IEnumerable<T> list) where T : SsdpResponse
        {
            return list.Where(c => c.Headers.Any(d => d.Key == "X-ModelName")).Distinct();
        }
    }
}
