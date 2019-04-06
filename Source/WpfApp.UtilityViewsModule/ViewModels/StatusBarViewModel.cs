using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Infrastructure.Base;
using WpfApp.Infrastructure.Events;

namespace WpfApp.UtilityViewsModule.ViewModels
{
    public class StatusBarViewModel : ViewModelBase
    {
        public StatusBarViewModel()
        {
            EventAggregator.GetEvent<StatusMessageEvent>().Subscribe(OnStatusMessageReceived);
        }

        private void OnStatusMessageReceived(string message)
        {
            this.StatusBarMessage = message;
        }

        private string statusBarMessage;
        public string StatusBarMessage
        {
            get { return statusBarMessage; }
            set { SetProperty(ref statusBarMessage, value); }
        }
    }
}
