using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace Barber
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        //---------------------------------------------------------------------
        private SqlConnection TryConnection()
        {
            ConfigurationBuilder builder = new();
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            IConfigurationSection connectionString = config.GetSection("ConnectionStrings");
            SqlConnectionStringBuilder connectionStringBuilder = new();

            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.DataSource = connectionString.GetSection("DataSource").Value;
            connectionStringBuilder.AttachDBFilename = connectionString.GetSection("AttachDBFilename").Value;

            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = connectionStringBuilder.ConnectionString;

            try { connect.Open(); }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            //MessageBox.Show("Connection: OK");

            return connect;
        }
        public SqlConnection Connection { get; private set; }
        //--------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            Connection = TryConnection();
            #region
            //connection.StateChange += (s, e) => 
            //{
            //    if (s is SqlConnection connect)
            //    {
            //        label1.ForeColor = connect.State switch
            //        {
            //            ConnectionState.Connecting => new Color() { A = 255, R = 0, G = 125, B = 255 },
            //            ConnectionState.Open => new Color() { A = 255, R = 68, G = 168, B = 29 },
            //            ConnectionState.Closed => new Color() { A = 255, R = 168, G = 29, B = 29 },

            //            //ConnectionState.Executing => colorExecuting,
            //            //ConnectionState.Fetching => colorFetching,
            //            //ConnectionState.Broken => colorBroken,

            //            _ => Colors.White
            //        };
            //    }
            //};
            #endregion
            DatabaseTitle.Text = Connection.Database.Substring((Connection.Database.LastIndexOf('\\') + 1), Connection.Database.Length - Connection.Database.LastIndexOf('\\') - 1);
        }
        //---------------------------------------------------------------------
        private void btnGender_Click(object sender, EventArgs e)
        {
            GendersForm genders = new GendersForm();
            genders.ShowDialog(this);
        }
        //---------------------------------------------------------------------
        private void btnBarbers_Click(object sender, EventArgs e)
        {
            BarbersForm barbers = new BarbersForm();
            barbers.ShowDialog(this);
        }
    }
}
