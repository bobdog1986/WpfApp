using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using WpfApp.Infrastructure.Interfaces;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;

namespace WpfApp.Infrastructure.Services
{
    public class LocalizerService : ILocalizerService
    {
        public LocalizerService()
        {
            SupportedLanguages = GetAvailableCultures();
        }

        private IEnumerable<CultureInfo> GetAvailableCultures()
        {
            var programLocation = Process.GetCurrentProcess().MainModule.FileName;
            var resourceFileName = Path.GetFileNameWithoutExtension(programLocation) + ".resources.dll";
            var rootDir = new DirectoryInfo(Path.GetDirectoryName(programLocation));
            return from c in CultureInfo.GetCultures(CultureTypes.AllCultures)
                   join d in rootDir.EnumerateDirectories() on c.IetfLanguageTag equals d.Name
                   where d.EnumerateFiles(resourceFileName).Any()
                   select c;
        }

        public void SetLocale(string locale)
        {
            SetLocale(CultureInfo.GetCultureInfo(locale));
        }

        public void SetLocale(CultureInfo culture)
        {
            LocalizeDictionary.Instance.Culture = culture;
        }

        public IEnumerable<CultureInfo> SupportedLanguages { get; }

        public CultureInfo SelectedLanguage
        {
            get { return LocalizeDictionary.Instance.Culture; }
            set { SetLocale(value); }
        }

        public string GetLocalizedValue(string key)
        {
            return LocExtension.GetLocalizedValue<string>(Assembly.GetCallingAssembly().GetName().Name + ":Resources:" + key);
        }

        public T GetLocalizedValue<T>(string key)
        {
            return LocExtension.GetLocalizedValue<T>(Assembly.GetCallingAssembly().GetName().Name + ":Resources:" + key);
        }
    }
}