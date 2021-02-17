
namespace lesson2practice2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nudMinute = new System.Windows.Forms.NumericUpDown();
            this.lMinute = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lSecond = new System.Windows.Forms.Label();
            this.nudSecond = new System.Windows.Forms.NumericUpDown();
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // nudMinute
            // 
            this.nudMinute.Location = new System.Drawing.Point(35, 27);
            this.nudMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMinute.Name = "nudMinute";
            this.nudMinute.Size = new System.Drawing.Size(41, 20);
            this.nudMinute.TabIndex = 2;
            this.nudMinute.ValueChanged += new System.EventHandler(this.timeChanged);
            // 
            // lMinute
            // 
            this.lMinute.AutoSize = true;
            this.lMinute.Location = new System.Drawing.Point(6, 29);
            this.lMinute.Name = "lMinute";
            this.lMinute.Size = new System.Drawing.Size(23, 13);
            this.lMinute.TabIndex = 1;
            this.lMinute.Text = "min";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lSecond);
            this.groupBox1.Controls.Add(this.nudSecond);
            this.groupBox1.Controls.Add(this.lMinute);
            this.groupBox1.Controls.Add(this.nudMinute);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 58);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update time";
            // 
            // lSecond
            // 
            this.lSecond.AutoSize = true;
            this.lSecond.Location = new System.Drawing.Point(82, 29);
            this.lSecond.Name = "lSecond";
            this.lSecond.Size = new System.Drawing.Size(24, 13);
            this.lSecond.TabIndex = 3;
            this.lSecond.Text = "sec";
            // 
            // nudSecond
            // 
            this.nudSecond.Location = new System.Drawing.Point(112, 27);
            this.nudSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudSecond.Name = "nudSecond";
            this.nudSecond.Size = new System.Drawing.Size(41, 20);
            this.nudSecond.TabIndex = 4;
            this.nudSecond.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSecond.ValueChanged += new System.EventHandler(this.timeChanged);
            // 
            // dgvProcesses
            // 
            this.dgvProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Location = new System.Drawing.Point(12, 76);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.Size = new System.Drawing.Size(723, 429);
            this.dgvProcesses.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Location = new System.Drawing.Point(666, 57);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(13, 13);
            this.lCount.TabIndex = 5;
            this.lCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Count:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 517);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lCount);
            this.Controls.Add(this.dgvProcesses);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMinute;
        private System.Windows.Forms.Label lMinute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lSecond;
        private System.Windows.Forms.NumericUpDown nudSecond;
        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lCount;
        private System.Windows.Forms.Label label1;
    }
}

