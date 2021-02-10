
namespace Barber
{
    partial class JournalForm
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
            this.gbRecord = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtpMoment = new System.Windows.Forms.DateTimePicker();
            this.cbBarber = new System.Windows.Forms.ComboBox();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lbrMoment = new System.Windows.Forms.Label();
            this.lbrBarber = new System.Windows.Forms.Label();
            this.lbrClient = new System.Windows.Forms.Label();
            this.gbRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRecord
            // 
            this.gbRecord.Controls.Add(this.btnAdd);
            this.gbRecord.Controls.Add(this.dtpMoment);
            this.gbRecord.Controls.Add(this.cbBarber);
            this.gbRecord.Controls.Add(this.cbClient);
            this.gbRecord.Controls.Add(this.lbrMoment);
            this.gbRecord.Controls.Add(this.lbrBarber);
            this.gbRecord.Controls.Add(this.lbrClient);
            this.gbRecord.Location = new System.Drawing.Point(497, 12);
            this.gbRecord.Name = "gbRecord";
            this.gbRecord.Size = new System.Drawing.Size(291, 426);
            this.gbRecord.TabIndex = 0;
            this.gbRecord.TabStop = false;
            this.gbRecord.Text = "Record";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(70, 112);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(200, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtpMoment
            // 
            this.dtpMoment.Location = new System.Drawing.Point(70, 83);
            this.dtpMoment.Name = "dtpMoment";
            this.dtpMoment.Size = new System.Drawing.Size(200, 23);
            this.dtpMoment.TabIndex = 3;
            // 
            // cbBarber
            // 
            this.cbBarber.FormattingEnabled = true;
            this.cbBarber.Location = new System.Drawing.Point(70, 54);
            this.cbBarber.Name = "cbBarber";
            this.cbBarber.Size = new System.Drawing.Size(200, 23);
            this.cbBarber.TabIndex = 2;
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(70, 25);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(200, 23);
            this.cbClient.TabIndex = 2;
            // 
            // lbrMoment
            // 
            this.lbrMoment.AutoSize = true;
            this.lbrMoment.Location = new System.Drawing.Point(11, 89);
            this.lbrMoment.Name = "lbrMoment";
            this.lbrMoment.Size = new System.Drawing.Size(53, 15);
            this.lbrMoment.TabIndex = 1;
            this.lbrMoment.Text = "Moment";
            // 
            // lbrBarber
            // 
            this.lbrBarber.AutoSize = true;
            this.lbrBarber.Location = new System.Drawing.Point(11, 57);
            this.lbrBarber.Name = "lbrBarber";
            this.lbrBarber.Size = new System.Drawing.Size(41, 15);
            this.lbrBarber.TabIndex = 1;
            this.lbrBarber.Text = "Barber";
            // 
            // lbrClient
            // 
            this.lbrClient.AutoSize = true;
            this.lbrClient.Location = new System.Drawing.Point(11, 28);
            this.lbrClient.Name = "lbrClient";
            this.lbrClient.Size = new System.Drawing.Size(38, 15);
            this.lbrClient.TabIndex = 1;
            this.lbrClient.Text = "Client";
            // 
            // JournalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbRecord);
            this.Name = "JournalForm";
            this.Text = "JournalForm";
            this.Load += new System.EventHandler(this.JournalForm_Load);
            this.gbRecord.ResumeLayout(false);
            this.gbRecord.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRecord;
        private System.Windows.Forms.Label lbrClient;
        private System.Windows.Forms.Label lbrMoment;
        private System.Windows.Forms.Label lbrBarber;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpMoment;
        private System.Windows.Forms.ComboBox cbBarber;
        private System.Windows.Forms.ComboBox cbClient;
    }
}