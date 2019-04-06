using MahApps.Metro.Controls;
using Prism.Commands;
using Prism.Regions;
using System.Linq;
using System.Windows.Input;
using WpfApp.Infrastructure.Commands;
using WpfApp.Infrastructure.Constants;
using WpfApp.Infrastructure.Interfaces;

namespace WpfApp.Infrastructure.Services
{
    public class ShowFlyoutService : IShowFlyout
    {
        private IRegionManager _regionManager;

        public ICommand ShowFlyoutCommand { get; private set; }

        public ShowFlyoutService(IRegionManager regionManager, IAppStaticCommands applicationCommands)
        {
            _regionManager = regionManager;

            ShowFlyoutCommand = new DelegateCommand<string>(ShowFlyout, CanShowFlyout);
            applicationCommands.ShowFlyoutCommand.RegisterCommand(ShowFlyoutCommand);
        }

        public void ShowFlyout(string flyoutName)
        {
            var region = _regionManager.Regions[RegionNames.ShellSettingsFlyoutRegion];

            if (region != null)
            {
                var flyout = region.Views.Where(v => v is IFlyoutView && ((IFlyoutView)v).FlyoutName.Equals(flyoutName)).FirstOrDefault() as Flyout;

                if (flyout != null)
                {
                    flyout.IsOpen = !flyout.IsOpen;
                }
            }
        }

        public bool CanShowFlyout(string flyoutName)
        {
            return true;
        }

        public void Raise(string flyoutName)
        {
            ShowFlyoutCommand.Execute(flyoutName);
        }
    }
}