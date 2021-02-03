using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Barber.Form1;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Barber
{
    public partial class JournalForm : Form
    {
        public JournalForm() => InitializeComponent();
        //---------------------------------------------------------------------
        private void JournalForm_Load(object sender, System.EventArgs e)
        {
            //List<DataGridView> views = new() { dataGridView1, dataGridView2, dataGridView3 };
            //foreach (var v in views)  v.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ////-------------------------------------------------
            //List<object> lists = new();
            ////-------------------------------------------------
            //using (BarberContext db = new((Owner as Form1).Connection.ConnectionString))
            //{
            //    lists.Add(db.Clients.ToList());
            //    lists.Add(db.Gender.ToList());
            //    lists.Add(db.Barbers.ToList());
            //}
            ////-------------------------------------------------
            //for (int i = 0; i < lists.Count; i++) views[i].DataSource = lists[i];
            ////-------------------------------------------------
            //foreach (var v in views) v.Columns["Id"].ReadOnly = true;

            using (BarberContext db = new((Owner as Form1).Connection.ConnectionString))
            {
                StringBuilder sb = new();
                //-------------------------------------------------
                //var q = from c in db.Clients
                //        where c.Id < 3
                //        select c;
                //
                //foreach(Client c in q.ToList())
                //{
                //    label1.Text += c.Id + " : "
                //                + c.SurName + " " + c.Name + " " + c.SecName + " : "
                //                + c.GenderId + " : "
                //                + c.Phone + " : " + c.Email + '\n';
                //}
                //-------------------------------------------------
                //var q = from c in db.Clients
                //        join g in db.Gender on c.GenderId equals g.Id
                //        where c.Id < 4 && g.Id < 10
                //        orderby c.Id descending
                //        select new
                //        {
                //            Id = c.Id,
                //            Name = c.Name,
                //            Gender = g.Name
                //        };
                //
                //foreach (var a in q.ToList())
                //{
                //    sb.AppendJoin(" : ", a.Id, a.Name, a.Gender);
                //    sb.AppendLine();
                //}
                //label1.Text = sb.ToString();
                //-------------------------------------------------
                foreach (var c in db.Clients.ToList())
                {
                    sb.Append(c.Name);
                    sb.Append(" : ");
                    try
                    {
                        sb.Append(db.Gender.Where(g => g.Id == c.GenderId)
                                           .First()
                                           .Name
                        );
                    }
                    catch   { sb.Append('-');  }
                    finally { sb.AppendLine(); }
                }

                label1.Text = sb.ToString();
                //-------------------------------------------------
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
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        //---------------------------------------------------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(_connectionString);
    }
}
