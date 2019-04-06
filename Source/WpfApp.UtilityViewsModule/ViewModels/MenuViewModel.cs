using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Infrastructure.Base;
using WpfApp.Infrastructure.Interfaces;
using Prism.Commands;
using WpfApp.Infrastructure.Constants;

namespace WpfApp.UtilityViewsModule.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ILocalizerService localizerService;

        private static readonly string aboutKey = "About";
        private static readonly string helpKey = "Help";

        public MenuViewModel()
        {
            MainPageCommand = new DelegateCommand(ClickMainPageMenu);
            AboutCommand = new DelegateCommand(ClickAboutMenu);
            HelpCommand = new DelegateCommand(ClickHelpMenu);

            localizerService = Resolve<ILocalizerService>();
        }

        public DelegateCommand MainPageCommand { get; private set; }
        public DelegateCommand AboutCommand { get; private set; }
        public DelegateCommand HelpCommand { get; private set; }

        private void ClickMainPageMenu()
        {
            RegionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.MainRegionView);
        }

        private void ClickAboutMenu()
        {

        }

        private void ClickHelpMenu()
        {

        }
    }
}
