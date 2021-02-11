using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using static Barber.Form1;

namespace Barber
{
    public partial class FeedbackForm : Form
    {
        public FeedbackForm() => InitializeComponent();
        private void btnClose_Click(object sender, EventArgs e) => Close();
        //---------------------------------------------------------------------
        private void FeedbackForm_Load(object sender, EventArgs e)
        {
            using (BarberContextFeedback db = new((Owner as Form1).Connection.ConnectionString))
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
                
                //-------------------------------------------------
            }
        }
        //---------------------------------------------------------------------
        public class Feedback
        {
            public int Id { get; set; }
            public string? Text { get; set; }
            public int VisitId { get; set; }
            public int Rating { get; set; }
            public DateTime? Moment { get; set; }
        }
        public class BarberContextFeedback : BarberContext
        {
            public BarberContextFeedback(string connectionString)
                : base(connectionString) { }
            public DbSet<Feedback> Feedback { get; set; }
        }
        //---------------------------------------------------------------------
        private void cbBarber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Barber sBarber = cbBarber.SelectedItem as Barber;
            using (BarberContextFeedback db = new((Owner as Form1).Connection.ConnectionString))
            {
                var fbQ = from f in db.Feedback
                          join j in db.Journal on f.VisitId equals j.Id
                          join c in db.Clients on j.ClientId equals c.Id
                          join b in db.Barbers on j.BarberId equals b.Id
                          where j.BarberId == sBarber.Id
                          select new { f, c };

                lAvgRating.Text = ((double)fbQ.Sum(fbq => fbq.f.Rating) / fbQ.Count()).ToString();

                lbFeedback.Items.Clear();
                foreach (var a in fbQ)
                {
                    StringBuilder sb = new();

                    sb.Append(("[" + a.f.Rating + "]").PadRight(5));
                    sb.Append(a.f.Moment.ToString().PadRight(20));
                    sb.Append(("(" + a.f.Text + ")").PadRight(20));
                    sb.Append(a.c.ToString());

                    lbFeedback.Items.Add(sb.ToString());
                }
            }
        }
        //---------------------------------------------------------------------
    }
}
