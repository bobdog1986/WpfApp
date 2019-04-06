using System.Collections.Generic;
using System.Globalization;

namespace WpfApp.Infrastructure.Interfaces
{
    public interface ILocalizerService
    {
        void SetLocale(string locale);

        void SetLocale(CultureInfo culture);

        string GetLocalizedValue(string key);

        T GetLocalizedValue<T>(string key);

        IEnumerable<CultureInfo> SupportedLanguages { get; }

        CultureInfo SelectedLanguage { get; set; }
    }
}