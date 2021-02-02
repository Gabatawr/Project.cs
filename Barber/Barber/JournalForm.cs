using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Barber.Form1;
using Microsoft.EntityFrameworkCore;

namespace Barber
{
    public partial class JournalForm : Form
    {
        public JournalForm() => InitializeComponent();
        //---------------------------------------------------------------------
        private void JournalForm_Load(object sender, System.EventArgs e)
        {
            using (BarberContext db = new((Owner as Form1).Connection.ConnectionString))
            {
                var clients = db.Clients.ToList();
                foreach(Client c in clients)
                {
                    label1.Text += (c.Id + " : "
                                  + c.SurName + " " + c.Name + " " + c.SecName + " : "
                                  + c.GenderId + " : "
                                  + c.Phone + " : " + c.Email + '\n');
                }
            }
        }
        //---------------------------------------------------------------------
    }
    public class BarberContext : DbContext
    {
        private readonly string _connectionString;
        public BarberContext(string connectionString) => _connectionString = connectionString;
        //---------------------------------------------------------------------
        public DbSet<Client> Clients { get; set; }
        //---------------------------------------------------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(_connectionString);
    }
}
