namespace WpfApp.Infrastructure.Interfaces
{
    public interface IShowFlyout
    {
        void ShowFlyout(string flyoutName);

        bool CanShowFlyout(string flyoutName);

        void Raise(string flyoutName);
    }
}