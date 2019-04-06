using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using WpfApp.Infrastructure.Interfaces;
using WpfApp.Infrastructure.Constants;

namespace WpfApp.UtilityViewsModule.Views
{
    /// <summary>
    /// Interaction logic for ShellSettingsFlyoutView.xaml
    /// </summary>
    public partial class ShellSettingsFlyoutView : Flyout, IFlyoutView
    {
        public ShellSettingsFlyoutView()
        {
            InitializeComponent();
        }
        public string FlyoutName
        {
            get
            {
                return FlyoutNames.ShellSettingsFlyout;
            }
        }
    }
}
