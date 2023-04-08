using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace SmartDigitalPsico.Domains.Helpers
{
    public class CultureDateTimeHelper
    {

        public CultureDateTimeHelper() { }

        private static List<CultureInfo> getCulturesEnable()
        {
            List<CultureInfo> list = new List<CultureInfo>();

            list.Add(new CultureInfo("en-US"));
            list.Add(new CultureInfo("pt-BR"));
            list.Add(new CultureInfo("es-ES"));

            return list;
        }

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
            var culturesEnables = getCulturesEnable().Select(cie => cie.Name).ToList();
            result = result.Where(p => culturesEnables.Contains(p.Name)).ToList();

            return result;
        }

        public static List<CultureInfo> TranslateCulture(List<CultureDisplay> cultureDisplays)
        {
            return cultureDisplays.Select(cd => new CultureInfo(cd.Id)).ToList();
        }

        public static string GetNameAndCulture(string localizedStringKeyName)
        {

            string culturenameCurrent = CultureInfo.CurrentCulture.Name;

            //  return $"{localizedStringKeyName}.{culturenameCurrent}";
            return $"{localizedStringKeyName}";

        }
        public static string GetKeyLocalizationRecordFormat(string LanguageKey, string Language)
        {
            //return $"{LanguageKey}.{Language}";
            return $"{LanguageKey}";
        }

        public static string GetLocalizer<T>(Microsoft.Extensions.Localization.IStringLocalizer<T> localizer, string key)
        {
            string result = "NotFoundLocalization";
            try
            {
                var culturenameCurrent = CultureInfo.CurrentCulture;

                var findKey = CultureDateTimeHelper.GetNameAndCulture(key);
                string message = localizer.GetString(findKey);

                result = message;
            }
            catch (Exception)
            {

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
