using System.Text;
using System.Windows.Media;
using ADONET_WPF.Infrastructure.Commands;
using ADONET_WPF.Infrastructure.Commands.Base;
using ADONET_WPF.Models;

namespace ADONET_WPF.ViewModels
{
    partial class MainWindowViewModel
    {
        //--------------------------------------------------------------------
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
            get => _ConnectColorParam ??= new SolidColorBrush(ConnectColor.Disconnect);
            set => Set(ref _ConnectColorParam, value);
        }

        #endregion SolidColorBrush : ConnectColorParam
    }
}
