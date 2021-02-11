
namespace Barber
{
    partial class FeedbackForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbBarber = new System.Windows.Forms.ComboBox();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lbrBarber = new System.Windows.Forms.Label();
            this.lbrClient = new System.Windows.Forms.Label();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.lText = new System.Windows.Forms.Label();
            this.lbFeedback = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lAvgRating = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(59, 184);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(200, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // cbBarber
            // 
            this.cbBarber.FormattingEnabled = true;
            this.cbBarber.Location = new System.Drawing.Point(59, 35);
            this.cbBarber.Name = "cbBarber";
            this.cbBarber.Size = new System.Drawing.Size(200, 23);
            this.cbBarber.TabIndex = 8;
            this.cbBarber.SelectedIndexChanged += new System.EventHandler(this.cbBarber_SelectedIndexChanged);
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(59, 6);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(200, 23);
            this.cbClient.TabIndex = 9;
            // 
            // lbrBarber
            // 
            this.lbrBarber.AutoSize = true;
            this.lbrBarber.Location = new System.Drawing.Point(12, 38);
            this.lbrBarber.Name = "lbrBarber";
            this.lbrBarber.Size = new System.Drawing.Size(41, 15);
            this.lbrBarber.TabIndex = 6;
            this.lbrBarber.Text = "Barber";
            // 
            // lbrClient
            // 
            this.lbrClient.AutoSize = true;
            this.lbrClient.Location = new System.Drawing.Point(12, 9);
            this.lbrClient.Name = "lbrClient";
            this.lbrClient.Size = new System.Drawing.Size(38, 15);
            this.lbrClient.TabIndex = 7;
            this.lbrClient.Text = "Client";
            // 
            // rtbText
            // 
            this.rtbText.Location = new System.Drawing.Point(59, 64);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(200, 114);
            this.rtbText.TabIndex = 12;
            this.rtbText.Text = "";
            // 
            // lText
            // 
            this.lText.AutoSize = true;
            this.lText.Location = new System.Drawing.Point(12, 67);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(28, 15);
            this.lText.TabIndex = 13;
            this.lText.Text = "Text";
            // 
            // lbFeedback
            // 
            this.lbFeedback.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbFeedback.FormattingEnabled = true;
            this.lbFeedback.ItemHeight = 14;
            this.lbFeedback.Location = new System.Drawing.Point(265, 6);
            this.lbFeedback.Name = "lbFeedback";
            this.lbFeedback.Size = new System.Drawing.Size(523, 172);
            this.lbFeedback.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Avg rating:";
            // 
            // lAvgRating
            // 
            this.lAvgRating.AutoSize = true;
            this.lAvgRating.Location = new System.Drawing.Point(327, 188);
            this.lAvgRating.Name = "lAvgRating";
            this.lAvgRating.Size = new System.Drawing.Size(13, 15);
            this.lAvgRating.TabIndex = 16;
            this.lAvgRating.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(713, 183);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 218);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lAvgRating);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFeedback);
            this.Controls.Add(this.lText);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbBarber);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.lbrBarber);
            this.Controls.Add(this.lbrClient);
            this.Name = "FeedbackForm";
            this.Text = "FeedbackForm";
            this.Load += new System.EventHandler(this.FeedbackForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbBarber;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lbrBarber;
        private System.Windows.Forms.Label lbrClient;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.Label lText;
        private System.Windows.Forms.ListBox lbFeedback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lAvgRating;
        private System.Windows.Forms.Button btnClose;
    }
}