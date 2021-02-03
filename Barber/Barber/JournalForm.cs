using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Barber.Form1;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Barber
{
    public partial class JournalForm : Form
    {
        public JournalForm() => InitializeComponent();
        //---------------------------------------------------------------------
        private void JournalForm_Load(object sender, System.EventArgs e)
        {
            List<DataGridView> views = new() { dataGridView1, dataGridView2, dataGridView3 };
            foreach (var g in views)  g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //-------------------------------------------------
            List<object> lists = new();
            //-------------------------------------------------
            using (BarberContext db = new((Owner as Form1).Connection.ConnectionString))
            {
                lists.Add(db.Clients.ToList());
                lists.Add(db.Gender.ToList());
                lists.Add(db.Barbers.ToList());
            }
            //-------------------------------------------------
            for (int i = 0; i < lists.Count; i++) views[i].DataSource = lists[i];
            //-------------------------------------------------
            foreach (var g in views) g.Columns["Id"].ReadOnly = true;
        }
        //---------------------------------------------------------------------
    }
    public class BarberContext : DbContext
    {
        private readonly string _connectionString;
        public BarberContext(string connectionString) => _connectionString = connectionString;
        //---------------------------------------------------------------------
        public DbSet<Client> Clients { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        //---------------------------------------------------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(_connectionString);
    }
}
