using System;
using System.Threading;
using System.Windows.Forms;

namespace OnlyThreeApp
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        void Form1_Load(object sender, EventArgs e)
        {
            Semaphore s;
            string sName = Application.ProductName + nameof(Semaphore);
            int msec = 5000;

            try { s = Semaphore.OpenExisting(sName); }
            catch (WaitHandleCannotBeOpenedException) { s = new(0, 3, sName); }

            try { lbRunCounter.Text = (s.Release() + 1).ToString(); }
            catch (SemaphoreFullException)
            {
                lbRunCounter.Text = "Only 3! App close after 5 sec..";
                System.Threading.Timer t = new((e) => Application.Exit(), null, msec, msec);
            }
        }
    }
}
