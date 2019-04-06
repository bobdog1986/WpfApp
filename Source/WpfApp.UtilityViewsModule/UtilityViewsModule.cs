using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Infrastructure.Constants;
using WpfApp.Infrastructure.Base;
using Prism.Ioc;
using WpfApp.UtilityViewsModule.Views;

namespace WpfApp.UtilityViewsModule
{
    public class UtilityViewsModule : ModuleBase
    {
        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegionManager.RegisterViewWithRegion(RegionNames.LeftWindowCommandsRegion, typeof(LeftWindowCommandsView));
            RegionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightWindowCommandsView));
            RegionManager.RegisterViewWithRegion(RegionNames.StatusBarRegion, typeof(StatusBarView));
            RegionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(MenuView));
            containerRegistry.RegisterForNavigation<AboutView>();
            containerRegistry.RegisterForNavigation<HelpView>();
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            LogInfo("UtilityViewsModule.OnInitialized()");
        }
    }
}
