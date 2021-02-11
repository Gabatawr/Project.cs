using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace Barber
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
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

            return connect;
        }
        public SqlConnection Connection { get; private set; }
        //--------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            Connection = TryConnection();
            Connection.StateChange += (s, e) =>
            {
                DatabaseTitle.BackColor = Connection.State switch
                {
                    ConnectionState.Connecting => Color.FromArgb(255, 0, 0, 255),
                    ConnectionState.Open => Color.FromArgb(255, 0, 255, 0),
                    ConnectionState.Closed => Color.FromArgb(255, 255, 0, 0),

                    //ConnectionState.Executing => colorExecuting,
                    //ConnectionState.Fetching => colorFetching,
                    //ConnectionState.Broken => colorBroken,

                    _ => Color.FromArgb(255, 128, 128, 128)
                };
            };
            Connection.Open();

            DatabaseTitle.Text = Connection.Database.Substring((Connection.Database.LastIndexOf('\\') + 1), Connection.Database.Length - Connection.Database.LastIndexOf('\\') - 1);

            SqlCommand cmd = new(@"select Id, Name, Description from [Gender]", Connection);
            SqlDataReader reader = cmd.ExecuteReader();

            Genders = new();
            while (reader.Read())
            {
                Genders.Add(new Gender()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2)
                });
            }
            reader.Close();
        }
        //---------------------------------------------------------------------
        private void btnGender_Click(object sender, EventArgs e)
        {
            GendersForm genders = new();
            genders.ShowDialog(this);
        }
        private void btnBarbers_Click(object sender, EventArgs e)
        {
            BarbersForm barbers = new();
            barbers.ShowDialog(this);
        }
        private void btnClients_Click(object sender, EventArgs e)
        {
            ClientsForm clients = new();
            clients.ShowDialog(this);
        }
        private void btnClient_Click(object sender, EventArgs e)
        {
            ClientForm client = new();
            client.ShowDialog(this);
        }
        private void btnLINQ_Click(object sender, EventArgs e)
        {
            JournalForm journal = new();
            journal.ShowDialog(this);
        }
        private void bntFeedback_Click(object sender, EventArgs e)
        {
            FeedbackForm feedback = new();
            feedback.ShowDialog(this);
        }
        //---------------------------------------------------------------------
        public List<Gender> Genders;
        public class Gender
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        //---------------------------------------------------------------------
    }
}
