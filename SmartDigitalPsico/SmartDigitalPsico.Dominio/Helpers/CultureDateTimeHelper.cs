using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Domains.Helpers
{
    public class CultureDateTimeHelper
    {

        public CultureDateTimeHelper() { }

        public static List<TimeZoneDisplay> GetTimeZonesIds()
        {
            List<TimeZoneDisplay> result = new List<TimeZoneDisplay>();

            ReadOnlyCollection<TimeZoneInfo> tz = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo tzInfo in tz)
            {
                result.Add(new TimeZoneDisplay() { Id = tzInfo.Id, Name = tzInfo.DisplayName });
            }
            return result;
        }
        public static List<CultureDisplay> GetCultures()
        {
            List<CultureDisplay> result = new List<CultureDisplay>();
            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);

            foreach (CultureInfo cul in cinfo)

            {
                result.Add(new CultureDisplay() { Id = cul.Name, Name = cul.DisplayName });
            }
            return result;
        }
    }
    public class CultureDisplay : TimeZoneDisplay
    {
    }

    public class TimeZoneDisplay
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
