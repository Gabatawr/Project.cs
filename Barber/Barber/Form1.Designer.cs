
namespace Barber
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.DatabaseTitle = new System.Windows.Forms.Label();
            this.btnGenders = new System.Windows.Forms.Button();
            this.btnBarbers = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnLINQ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DatabaseTitle
            // 
            this.DatabaseTitle.AutoSize = true;
            this.DatabaseTitle.Location = new System.Drawing.Point(40, 9);
            this.DatabaseTitle.Name = "DatabaseTitle";
            this.DatabaseTitle.Size = new System.Drawing.Size(22, 15);
            this.DatabaseTitle.TabIndex = 0;
            this.DatabaseTitle.Text = "---";
            // 
            // btnGenders
            // 
            this.btnGenders.Location = new System.Drawing.Point(12, 47);
            this.btnGenders.Name = "btnGenders";
            this.btnGenders.Size = new System.Drawing.Size(145, 23);
            this.btnGenders.TabIndex = 1;
            this.btnGenders.Text = "Genders";
            this.btnGenders.UseVisualStyleBackColor = true;
            this.btnGenders.Click += new System.EventHandler(this.btnGender_Click);
            // 
            // btnBarbers
            // 
            this.btnBarbers.Location = new System.Drawing.Point(12, 76);
            this.btnBarbers.Name = "btnBarbers";
            this.btnBarbers.Size = new System.Drawing.Size(145, 23);
            this.btnBarbers.TabIndex = 2;
            this.btnBarbers.Text = "Barbers";
            this.btnBarbers.UseVisualStyleBackColor = true;
            this.btnBarbers.Click += new System.EventHandler(this.btnBarbers_Click);
            // 
            // btnClients
            // 
            this.btnClients.Location = new System.Drawing.Point(12, 105);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(71, 23);
            this.btnClients.TabIndex = 3;
            this.btnClients.Text = "Clients";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(89, 105);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(68, 23);
            this.btnClient.TabIndex = 4;
            this.btnClient.Text = "Client";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnLINQ
            // 
            this.btnLINQ.Location = new System.Drawing.Point(13, 135);
            this.btnLINQ.Name = "btnLINQ";
            this.btnLINQ.Size = new System.Drawing.Size(144, 23);
            this.btnLINQ.TabIndex = 5;
            this.btnLINQ.Text = "LINQ";
            this.btnLINQ.UseVisualStyleBackColor = true;
            this.btnLINQ.Click += new System.EventHandler(this.btnLINQ_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 172);
            this.Controls.Add(this.btnLINQ);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnClients);
            this.Controls.Add(this.btnBarbers);
            this.Controls.Add(this.btnGenders);
            this.Controls.Add(this.DatabaseTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DatabaseTitle;
        private System.Windows.Forms.Button btnGenders;
        private System.Windows.Forms.Button btnBarbers;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnLINQ;
    }
}

