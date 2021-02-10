using System.Windows.Forms;
using System;
using System.Linq;
using static Barber.Form1;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Barber
{
    public partial class JournalForm : Form
    {
        public JournalForm() => InitializeComponent();
        //---------------------------------------------------------------------
        int x = 8, y = 8;
        StringBuilder sb = new();
        //---------------------------------------------------------------------
        private void JournalForm_Load(object sender, System.EventArgs e)
        {
            using (BarberContext db = new((Owner as Form1).Connection.ConnectionString))
            {
                //-------------------------------------------------
                void InitItems(ComboBox cb, Array arr)
                {
                    cb.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cb.Items.AddRange((object[])arr);
                }
                InitItems(cbBarber, db.Barbers.ToArray());
                InitItems(cbClient, db.Clients.ToArray());
                //-------------------------------------------------
                var journal = from j in db.Journal
                              join c in db.Clients on j.ClientId equals c.Id
                              join b in db.Barbers on j.BarberId equals b.Id
                              select new { j, b, c };

                foreach (var a in journal) AddLabel(a);
                //-------------------------------------------------
            }
        }
        //---------------------------------------------------------------------
        void AddLabel(dynamic a)
        {
            sb.AppendJoin(" : ", a.j.Id, a.b.Name, a.c.Name);
            sb.AppendLine();

            Label lb = new()
            {
                Text = sb.ToString(),
                Location = new Point(x, y),
                AutoSize = true,
                Tag = a.j.Moment
            };
            lb.Click += (s, e) => MessageBox.Show((s as Label).Tag.ToString());

            y += 16;
            sb.Clear();
            Controls.Add(lb);
        }
        //---------------------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------
            int clientId, barberId;

            if (cbClient.SelectedIndex > -1)
                clientId = (cbClient.SelectedItem as Client).Id;
            else { MessageBox.Show("Select Client!"); return; }

            if (cbBarber.SelectedIndex > -1) barberId = (cbBarber.SelectedItem as Barber).Id;
            else { MessageBox.Show("Select Barber!"); return; }

            DateTime moment = dtpMoment.Value;
            //-------------------------------------------------
            using (BarberContext db = new((Owner as Form1).Connection.ConnectionString))
            {
                db.Journal.Add(new()
                {
                    BarberId = barberId,
                    ClientId = clientId,
                    Moment = moment
                });
                db.SaveChanges();

                var journal = from j in db.Journal
                              join c in db.Clients on j.ClientId equals c.Id
                              join b in db.Barbers on j.BarberId equals b.Id
                              select new { j, b, c };

                AddLabel(journal.OrderBy(a => a.j.Id).Last());
            }
            //-------------------------------------------------
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
        public DbSet<Journal> Journal { get; set; }
        //---------------------------------------------------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(_connectionString);
    }
    public class Journal
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BarberId { get; set; }
        public DateTime Moment { get; set; }
    }
}
