﻿using System;
using System.Linq;
using System.Windows.Forms;

namespace ThreadFormsHW1
{
    public partial class MainForm : Form
    {
        #region Fields
        //---------------------------------------------------------------------
        int size;

        NumberType[] numberType;

        Label[] lastNumber;
        Label[] countNumbers;
        ListBox[] listBox;
        //---------------------------------------------------------------------
        #endregion Fields

        #region Initialize
        //---------------------------------------------------------------------
        public MainForm() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
            lastNumber = new[] { lPrime, lFibonacci };
            countNumbers = new[] { lPrimeCount, lFibonacciCount };
            listBox = new[] { lbPrime, lbFibonacci };

            numberType = new NumberType[]
            {
                new Prime(),
                new Fibonacci()
            };
            size = numberType.Length;

            foreach (var nt in numberType)
                nt.Callback += Response_Callback;

            btnStop.Enabled = false;

            btnPrimePause.Enabled = false;
            btnPrimeResume.Enabled = false;
            btnPrimeStop.Enabled = false;

            btnFibonacciPause.Enabled = false;
            btnFibonacciResume.Enabled = false;
            btnFibonacciStop.Enabled = false;
        }
        #endregion Initialize

        #region Response_Callback
        //---------------------------------------------------------------------
        private void Response_Callback(object sender, Response e)
        {
            for (int i = 0; i < size; i++)
            {
                if (sender is NumberType s && s.GetType() == numberType[i].GetType())
                {
                    lastNumber[i].Text = e.Number.ToString();
                    lastNumber[i].Refresh();

                    listBox[i].Items.Add(e.Number);

                    countNumbers[i].Text = listBox[i].Items.Count.ToString();
                    countNumbers[i].Refresh();
                }
            }
        }
        //---------------------------------------------------------------------
        #endregion Response_Callback

        #region Button Range
        //---------------------------------------------------------------------
        private void btnGo_Click(object sender, EventArgs e)
        {
            foreach (ListBox lb in listBox) lb.Items.Clear();

            foreach (Label l in lastNumber.Concat(countNumbers))
            {
                l.Text = "0";
                l.Refresh();
            }

            this.Refresh();

            foreach (var nt in numberType)
                nt.Start(new int[] { (int)nudMin.Value, (int)nudMax.Value });

            btnGo.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (var nt in numberType)
                nt.Stop();

            btnGo.Enabled = true;
            btnStop.Enabled = false;
        }
        //---------------------------------------------------------------------
        #endregion Button Range
    }
}
