
namespace OnlyThreeApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lbRunCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbRunCounter
            // 
            this.lbRunCounter.AutoSize = true;
            this.lbRunCounter.Location = new System.Drawing.Point(12, 9);
            this.lbRunCounter.Name = "lbRunCounter";
            this.lbRunCounter.Size = new System.Drawing.Size(13, 15);
            this.lbRunCounter.TabIndex = 0;
            this.lbRunCounter.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 33);
            this.Controls.Add(this.lbRunCounter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRunCounter;
    }
}

