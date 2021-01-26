using System.Data;
using System.Data.SqlClient;
using System.Windows.Media;
using ADONET_WPF.ViewModels;

namespace ADONET_WPF.Infrastructure.Services
{
    internal class SqlService
    {
        private MainWindowViewModel vm;
        public SqlConnection Connection { get; private set; }

        public SqlService(MainWindowViewModel vm) { this.vm = vm; }

        public void Connect(SqlConnectionStringBuilder sb)
        {
            Connection = new SqlConnection(sb.ConnectionString);

            Connection.StateChange += (s, e) =>
            {
                if (s is SqlConnection connect)
                {
                    vm.ConnectColorParam.Color = connect.State switch
                    {
                        ConnectionState.Connecting => new Color() { A = 255, R = 0  , G = 125, B = 255 },
                        ConnectionState.Open       => new Color() { A = 255, R = 68 , G = 168, B = 29  },
                        ConnectionState.Closed     => new Color() { A = 255, R = 168, G = 29 , B = 29  },

                        //ConnectionState.Executing => colorExecuting,
                        //ConnectionState.Fetching => colorFetching,
                        //ConnectionState.Broken => colorBroken,

                        _ => Colors.White
                    };
                }
            };
        }
    }
}
