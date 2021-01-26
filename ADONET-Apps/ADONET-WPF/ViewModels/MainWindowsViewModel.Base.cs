using System.Windows.Media;
using ADONET_WPF.Infrastructure.Services;
using ADONET_WPF.Models;
using ADONET_WPF.ViewModels.Base;

namespace ADONET_WPF.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        public ConnectionMethods ConnectionMethod { get; }
        public SqlService SqlServer { get; }

        public MainWindowViewModel()
        {
            ConnectionMethod = ConnectionMethods.Windows;

            _IsUserAuthParam = ConnectionMethod == ConnectionMethods.SqlServer;
            SqlServer = new SqlService();
        }
    }
}
