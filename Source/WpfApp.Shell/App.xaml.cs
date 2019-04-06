using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Logging;
using Prism.Unity;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WpfApp.Infrastructure.Constants;
using WpfApp.Infrastructure.Interfaces;
using WpfApp.Infrastructure.Services;
using WpfApp.Infrastructure.Commands;
using WpfApp.Infrastructure.Logging;
using WpfApp.UtilityViewsModule;
using WpfApp.UtilityViewsModule.Views;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    internal partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton(typeof(Window), typeof(MainWindow));
            containerRegistry.RegisterInstance<IAppStaticCommands>(Container.Resolve<AppStaticCommandsProxy>());
            containerRegistry.RegisterInstance<IShowFlyout>(Container.Resolve<ShowFlyoutService>());
            containerRegistry.RegisterInstance<ILocalizerService>(new LocalizerService());
            containerRegistry.RegisterInstance<ILoggerFacade>(Container.Resolve<NLogger>());
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<Window>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule(typeof(UtilityViewsModule.UtilityViewsModule));
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);

            var regionManager = Container.Resolve<IRegionManager>();
            //register at first to make ui effect when start up
            regionManager.RegisterViewWithRegion(RegionNames.ShellSettingsFlyoutRegion, typeof(ShellSettingsFlyoutView));
        }
    }
}
