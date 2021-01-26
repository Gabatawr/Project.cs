using System.Text;
using System.Windows.Media;
using ADONET_WPF.Infrastructure.Commands;
using ADONET_WPF.Infrastructure.Commands.Base;
using ADONET_WPF.Models;

namespace ADONET_WPF.ViewModels
{
    partial class MainWindowViewModel
    {
        #region string : LoginParam

        private string _LoginParam;
        public string LoginParam
        {
            get => _LoginParam;
            set => Set(ref _LoginParam, value);
        }

        #endregion string : LoginParam
        //--------------------------------------------------------------------
        #region string : PasswordParam

        private string _PasswordParam;
        public string PasswordParam
        {
            get => _PasswordParam;
            set => Set(ref _PasswordParam, value);
        }

        #endregion string : PasswordParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : ConnectColorParam

        private SolidColorBrush _ConnectColorParam;
        public SolidColorBrush ConnectColorParam
        {
            get => _ConnectColorParam ??= new SolidColorBrush(Colors.White);
            set => Set(ref _ConnectColorParam, value);
        }

        #endregion SolidColorBrush : ConnectColorParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : WinAuthParam

        private SolidColorBrush _WinAuthParam;
        public SolidColorBrush WinAuthParam
        {
            get => _WinAuthParam ??= new SolidColorBrush(Palitra.GetAuthMethodColor(ConnectionMethod, ConnectionMethods.Windows));
            set => Set(ref _WinAuthParam, value);
        }

        #endregion SolidColorBrush : WinAuthParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : SqlAuthParam

        private SolidColorBrush _SqlAuthParam;
        public SolidColorBrush SqlAuthParam
        {
            get => _SqlAuthParam ??= new SolidColorBrush(Palitra.GetAuthMethodColor(ConnectionMethod, ConnectionMethods.SqlServer));
            set => Set(ref _SqlAuthParam, value);
        }

        #endregion SolidColorBrush : SqlAuthParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : IsUserAuthParam

        private bool _IsUserAuthParam;
        public bool IsUserAuthParam
        {
            get => _IsUserAuthParam;
            set => Set(ref _IsUserAuthParam, value);
        }

        #endregion SolidColorBrush : SqlAuthParam
    }
}
