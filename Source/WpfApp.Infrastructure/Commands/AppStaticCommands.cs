using Prism.Commands;

namespace WpfApp.Infrastructure.Commands
{
    public static class AppStaticCommands
    {
        public static CompositeCommand ShowFlyoutCommand = new CompositeCommand();

        public static CompositeCommand MainRegionNavigateCommand = new CompositeCommand();
    }

    public interface IAppStaticCommands
    {
        CompositeCommand ShowFlyoutCommand { get; }

        CompositeCommand MainRegionNavigateCommand { get; }
    }

    public class AppStaticCommandsProxy : IAppStaticCommands
    {
        public CompositeCommand ShowFlyoutCommand => AppStaticCommands.ShowFlyoutCommand;

        public CompositeCommand MainRegionNavigateCommand => AppStaticCommands.MainRegionNavigateCommand;
    }
}
