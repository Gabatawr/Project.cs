using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace lesson2practice2
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e) => timer_Tick(null, null);
        

        private void timeChanged(object sender, EventArgs e)
            => timer.Interval = (int)nudMinute.Value * 60 * 1000 + (int)nudSecond.Value * 1000;

        private List<DataModel> source = new List<DataModel>();
        private void timer_Tick(object sender, EventArgs e)
        {
            source.Clear();
            foreach (var p in Process.GetProcesses())
                source.Add(new DataModel() { Id = p.Id, ProcessName = p.ProcessName, BasePriority = p.BasePriority });

            dgvProcesses.DataSource = source;
            lCount.Text = source.Count.ToString();

            dgvProcesses.Update();
            dgvProcesses.Refresh();
        }
    }

    public class DataModel
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public int BasePriority { get; set; }
    }
}
