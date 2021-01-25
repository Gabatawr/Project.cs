using ADONET_WPF.Models;
using ADONET_WPF.ViewModels.Base;

namespace ADONET_WPF.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        public ConnectionMethods ConnectionMethod;
        public MainWindowViewModel()
        {
            ConnectionMethod = ConnectionMethods.Windows;

            _IsUserAuthParam = ConnectionMethod == ConnectionMethods.SqlServer;
        }
    }
}
