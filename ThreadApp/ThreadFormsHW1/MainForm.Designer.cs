
namespace ThreadFormsHW1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lPrime = new System.Windows.Forms.Label();
            this.lFibonacci = new System.Windows.Forms.Label();
            this.gRange = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lMax = new System.Windows.Forms.Label();
            this.nudMax = new System.Windows.Forms.NumericUpDown();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.gPrime = new System.Windows.Forms.GroupBox();
            this.lPrimeCount = new System.Windows.Forms.Label();
            this.lbPrime = new System.Windows.Forms.ListBox();
            this.btnPrimePause = new System.Windows.Forms.Button();
            this.btnPrimeResume = new System.Windows.Forms.Button();
            this.btnPrimeStop = new System.Windows.Forms.Button();
            this.gFibonacci = new System.Windows.Forms.GroupBox();
            this.lFibonacciCount = new System.Windows.Forms.Label();
            this.lbFibonacci = new System.Windows.Forms.ListBox();
            this.btnFibonacciPause = new System.Windows.Forms.Button();
            this.btnFibonacciResume = new System.Windows.Forms.Button();
            this.btnFibonacciStop = new System.Windows.Forms.Button();
            this.gRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            this.gPrime.SuspendLayout();
            this.gFibonacci.SuspendLayout();
            this.SuspendLayout();
            // 
            // lPrime
            // 
            this.lPrime.AutoSize = true;
            this.lPrime.Location = new System.Drawing.Point(6, 77);
            this.lPrime.Name = "lPrime";
            this.lPrime.Size = new System.Drawing.Size(35, 15);
            this.lPrime.TabIndex = 0;
            this.lPrime.Text = "PLast";
            // 
            // lFibonacci
            // 
            this.lFibonacci.AutoSize = true;
            this.lFibonacci.Location = new System.Drawing.Point(6, 77);
            this.lFibonacci.Name = "lFibonacci";
            this.lFibonacci.Size = new System.Drawing.Size(34, 15);
            this.lFibonacci.TabIndex = 0;
            this.lFibonacci.Text = "FLast";
            // 
            // gRange
            // 
            this.gRange.Controls.Add(this.btnStop);
            this.gRange.Controls.Add(this.btnGo);
            this.gRange.Controls.Add(this.label1);
            this.gRange.Controls.Add(this.lMax);
            this.gRange.Controls.Add(this.nudMax);
            this.gRange.Controls.Add(this.nudMin);
            this.gRange.Location = new System.Drawing.Point(16, 12);
            this.gRange.Name = "gRange";
            this.gRange.Size = new System.Drawing.Size(191, 106);
            this.gRange.TabIndex = 1;
            this.gRange.TabStop = false;
            this.gRange.Text = "Range";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(99, 15);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(6, 15);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(87, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max";
            // 
            // lMax
            // 
            this.lMax.AutoSize = true;
            this.lMax.Location = new System.Drawing.Point(155, 50);
            this.lMax.Name = "lMax";
            this.lMax.Size = new System.Drawing.Size(28, 15);
            this.lMax.TabIndex = 1;
            this.lMax.Text = "Min";
            // 
            // nudMax
            // 
            this.nudMax.Location = new System.Drawing.Point(6, 73);
            this.nudMax.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(143, 23);
            this.nudMax.TabIndex = 0;
            this.nudMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMax.Value = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            // 
            // nudMin
            // 
            this.nudMin.Location = new System.Drawing.Point(6, 44);
            this.nudMin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(143, 23);
            this.nudMin.TabIndex = 0;
            this.nudMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMin.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // gPrime
            // 
            this.gPrime.Controls.Add(this.lPrimeCount);
            this.gPrime.Controls.Add(this.lbPrime);
            this.gPrime.Controls.Add(this.btnPrimePause);
            this.gPrime.Controls.Add(this.btnPrimeResume);
            this.gPrime.Controls.Add(this.btnPrimeStop);
            this.gPrime.Controls.Add(this.lPrime);
            this.gPrime.Location = new System.Drawing.Point(213, 12);
            this.gPrime.Name = "gPrime";
            this.gPrime.Size = new System.Drawing.Size(191, 399);
            this.gPrime.TabIndex = 2;
            this.gPrime.TabStop = false;
            this.gPrime.Text = "Prime";
            // 
            // lPrimeCount
            // 
            this.lPrimeCount.AutoSize = true;
            this.lPrimeCount.Location = new System.Drawing.Point(139, 77);
            this.lPrimeCount.Name = "lPrimeCount";
            this.lPrimeCount.Size = new System.Drawing.Size(47, 15);
            this.lPrimeCount.TabIndex = 3;
            this.lPrimeCount.Text = "PCount";
            // 
            // lbPrime
            // 
            this.lbPrime.FormattingEnabled = true;
            this.lbPrime.ItemHeight = 15;
            this.lbPrime.Location = new System.Drawing.Point(6, 104);
            this.lbPrime.Name = "lbPrime";
            this.lbPrime.Size = new System.Drawing.Size(179, 289);
            this.lbPrime.TabIndex = 2;
            // 
            // btnPrimePause
            // 
            this.btnPrimePause.Location = new System.Drawing.Point(6, 15);
            this.btnPrimePause.Name = "btnPrimePause";
            this.btnPrimePause.Size = new System.Drawing.Size(87, 23);
            this.btnPrimePause.TabIndex = 1;
            this.btnPrimePause.Text = "Pause";
            this.btnPrimePause.UseVisualStyleBackColor = true;
            this.btnPrimePause.Click += new System.EventHandler(this.btnPrimePause_Click);
            // 
            // btnPrimeResume
            // 
            this.btnPrimeResume.Location = new System.Drawing.Point(98, 15);
            this.btnPrimeResume.Name = "btnPrimeResume";
            this.btnPrimeResume.Size = new System.Drawing.Size(87, 23);
            this.btnPrimeResume.TabIndex = 1;
            this.btnPrimeResume.Text = "Resume";
            this.btnPrimeResume.UseVisualStyleBackColor = true;
            this.btnPrimeResume.Click += new System.EventHandler(this.btnPrimeResume_Click);
            // 
            // btnPrimeStop
            // 
            this.btnPrimeStop.Location = new System.Drawing.Point(6, 46);
            this.btnPrimeStop.Name = "btnPrimeStop";
            this.btnPrimeStop.Size = new System.Drawing.Size(179, 23);
            this.btnPrimeStop.TabIndex = 1;
            this.btnPrimeStop.Text = "Stop";
            this.btnPrimeStop.UseVisualStyleBackColor = true;
            this.btnPrimeStop.Click += new System.EventHandler(this.btnPrimeStop_Click);
            // 
            // gFibonacci
            // 
            this.gFibonacci.Controls.Add(this.lFibonacciCount);
            this.gFibonacci.Controls.Add(this.lbFibonacci);
            this.gFibonacci.Controls.Add(this.btnFibonacciPause);
            this.gFibonacci.Controls.Add(this.btnFibonacciResume);
            this.gFibonacci.Controls.Add(this.btnFibonacciStop);
            this.gFibonacci.Controls.Add(this.lFibonacci);
            this.gFibonacci.Location = new System.Drawing.Point(410, 12);
            this.gFibonacci.Name = "gFibonacci";
            this.gFibonacci.Size = new System.Drawing.Size(191, 399);
            this.gFibonacci.TabIndex = 2;
            this.gFibonacci.TabStop = false;
            this.gFibonacci.Text = "Fibonacci";
            // 
            // lFibonacciCount
            // 
            this.lFibonacciCount.AutoSize = true;
            this.lFibonacciCount.Location = new System.Drawing.Point(139, 77);
            this.lFibonacciCount.Name = "lFibonacciCount";
            this.lFibonacciCount.Size = new System.Drawing.Size(46, 15);
            this.lFibonacciCount.TabIndex = 3;
            this.lFibonacciCount.Text = "FCount";
            // 
            // lbFibonacci
            // 
            this.lbFibonacci.FormattingEnabled = true;
            this.lbFibonacci.ItemHeight = 15;
            this.lbFibonacci.Location = new System.Drawing.Point(6, 104);
            this.lbFibonacci.Name = "lbFibonacci";
            this.lbFibonacci.Size = new System.Drawing.Size(179, 289);
            this.lbFibonacci.TabIndex = 2;
            // 
            // btnFibonacciPause
            // 
            this.btnFibonacciPause.Location = new System.Drawing.Point(6, 15);
            this.btnFibonacciPause.Name = "btnFibonacciPause";
            this.btnFibonacciPause.Size = new System.Drawing.Size(87, 23);
            this.btnFibonacciPause.TabIndex = 1;
            this.btnFibonacciPause.Text = "Pause";
            this.btnFibonacciPause.UseVisualStyleBackColor = true;
            this.btnFibonacciPause.Click += new System.EventHandler(this.btnFibonacciPause_Click);
            // 
            // btnFibonacciResume
            // 
            this.btnFibonacciResume.Location = new System.Drawing.Point(98, 15);
            this.btnFibonacciResume.Name = "btnFibonacciResume";
            this.btnFibonacciResume.Size = new System.Drawing.Size(87, 23);
            this.btnFibonacciResume.TabIndex = 1;
            this.btnFibonacciResume.Text = "Resume";
            this.btnFibonacciResume.UseVisualStyleBackColor = true;
            this.btnFibonacciResume.Click += new System.EventHandler(this.btnFibonacciResume_Click);
            // 
            // btnFibonacciStop
            // 
            this.btnFibonacciStop.Location = new System.Drawing.Point(6, 46);
            this.btnFibonacciStop.Name = "btnFibonacciStop";
            this.btnFibonacciStop.Size = new System.Drawing.Size(179, 23);
            this.btnFibonacciStop.TabIndex = 1;
            this.btnFibonacciStop.Text = "Stop";
            this.btnFibonacciStop.UseVisualStyleBackColor = true;
            this.btnFibonacciStop.Click += new System.EventHandler(this.btnFibonacciStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 419);
            this.Controls.Add(this.gFibonacci);
            this.Controls.Add(this.gPrime);
            this.Controls.Add(this.gRange);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gRange.ResumeLayout(false);
            this.gRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            this.gPrime.ResumeLayout(false);
            this.gPrime.PerformLayout();
            this.gFibonacci.ResumeLayout(false);
            this.gFibonacci.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lPrime;
        private System.Windows.Forms.Label lFibonacci;
        private System.Windows.Forms.GroupBox gRange;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lMax;
        private System.Windows.Forms.NumericUpDown nudMax;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.GroupBox gPrime;
        private System.Windows.Forms.ListBox lbPrime;
        private System.Windows.Forms.Button btnPrimePause;
        private System.Windows.Forms.Button btnPrimeResume;
        private System.Windows.Forms.Button btnPrimeStop;
        private System.Windows.Forms.GroupBox gFibonacci;
        private System.Windows.Forms.ListBox lbFibonacci;
        private System.Windows.Forms.Button btnFibonacciPause;
        private System.Windows.Forms.Button btnFibonacciResume;
        private System.Windows.Forms.Button btnFibonacciStop;
        private System.Windows.Forms.Label lPrimeCount;
        private System.Windows.Forms.Label lFibonacciCount;
        private System.Windows.Forms.Button btnStop;
    }
}

