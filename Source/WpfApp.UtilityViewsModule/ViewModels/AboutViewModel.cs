using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Infrastructure.Base;
using System.Reflection;

namespace WpfApp.UtilityViewsModule.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel()
        {
            SoftwareName = "WpfApp";
            GetMainAssemblyInfo();
        }
        private void GetMainAssemblyInfo()
        {
            try
            {
                Product = Assembly.Load("WpfApp").GetCustomAttribute<AssemblyProductAttribute>().Product;
                Copyright = Assembly.Load("WpfApp").GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
                Version = Assembly.Load("WpfApp").GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
                Description = Assembly.Load("WpfApp").GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            }
            catch
            {
                ;
            }
        }

        private string softwareName;
        public string SoftwareName
        {
            get { return softwareName; }
            set { SetProperty(ref softwareName, value); }
        }

        private string product;
        public string Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private string copyright;
        public string Copyright
        {
            get { return copyright; }
            set { SetProperty(ref copyright, value); }
        }

        private string version;
        public string Version
        {
            get { return version; }
            set { SetProperty(ref version, value); }
        }
    }
}
