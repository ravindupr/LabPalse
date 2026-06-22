namespace LabPulse
{
    partial class FrmLabRules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLabRules));
            lblTitle = new Label();
            label1 = new Label();
            pnlLeftCard = new Panel();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            pnlRightCard = new Panel();
            richTextBox2 = new RichTextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            pnlLeftCard.SuspendLayout();
            pnlRightCard.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(104, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(506, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lab Operational Guidelines and Rules";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(42, 37);
            label1.Name = "label1";
            label1.Size = new Size(56, 38);
            label1.TabIndex = 1;
            label1.Text = "📋";
            // 
            // pnlLeftCard
            // 
            pnlLeftCard.BackColor = Color.FromArgb(30, 41, 59);
            pnlLeftCard.Controls.Add(richTextBox1);
            pnlLeftCard.Controls.Add(label5);
            pnlLeftCard.Controls.Add(label4);
            pnlLeftCard.Controls.Add(label3);
            pnlLeftCard.Controls.Add(label2);
            pnlLeftCard.Location = new Point(20, 100);
            pnlLeftCard.Name = "pnlLeftCard";
            pnlLeftCard.Size = new Size(450, 400);
            pnlLeftCard.TabIndex = 2;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(30, 41, 59);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.FromArgb(148, 163, 184);
            richTextBox1.Location = new Point(3, 87);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(408, 214);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "• Weekdays : 08:30 AM – 05:30 PM\n\n• Saturdays : 09:00 AM – 01:00 PM\n\n• Sundays / Holidays : Closed\n\n• Note : Late equipment drop-offs will not be processed outside these official operational hours.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(56, 189, 248);
            label5.Location = new Point(183, 23);
            label5.Name = "label5";
            label5.Size = new Size(198, 23);
            label5.TabIndex = 3;
            label5.Text = "Operational Timetables";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(152, 23);
            label4.Name = "label4";
            label4.Size = new Size(34, 23);
            label4.TabIndex = 2;
            label4.Text = "⏰";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(56, 189, 248);
            label3.Location = new Point(82, 23);
            label3.Name = "label3";
            label3.Size = new Size(73, 23);
            label3.TabIndex = 1;
            label3.Text = "Card 1 :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(55, 23);
            label2.Name = "label2";
            label2.Size = new Size(34, 23);
            label2.TabIndex = 0;
            label2.Text = "📦";
            // 
            // pnlRightCard
            // 
            pnlRightCard.BackColor = Color.FromArgb(30, 41, 59);
            pnlRightCard.Controls.Add(richTextBox2);
            pnlRightCard.Controls.Add(label9);
            pnlRightCard.Controls.Add(label8);
            pnlRightCard.Controls.Add(label7);
            pnlRightCard.Controls.Add(label6);
            pnlRightCard.Location = new Point(490, 100);
            pnlRightCard.Name = "pnlRightCard";
            pnlRightCard.Size = new Size(450, 400);
            pnlRightCard.TabIndex = 3;
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.FromArgb(30, 41, 59);
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.ForeColor = Color.FromArgb(148, 163, 184);
            richTextBox2.Location = new Point(3, 87);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(444, 298);
            richTextBox2.TabIndex = 6;
            richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Yellow;
            label9.Location = new Point(162, 23);
            label9.Name = "label9";
            label9.Size = new Size(34, 23);
            label9.TabIndex = 5;
            label9.Text = "⚠️";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(56, 189, 248);
            label8.Location = new Point(198, 23);
            label8.Name = "label8";
            label8.Size = new Size(249, 23);
            label8.TabIndex = 4;
            label8.Text = "Safety and Borrowing Policies";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(56, 189, 248);
            label7.Location = new Point(83, 23);
            label7.Name = "label7";
            label7.Size = new Size(73, 23);
            label7.TabIndex = 2;
            label7.Text = "Card 2 :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(255, 128, 0);
            label6.Location = new Point(53, 23);
            label6.Name = "label6";
            label6.Size = new Size(34, 23);
            label6.TabIndex = 1;
            label6.Text = "📦";
            // 
            // FrmLabRules
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(964, 524);
            Controls.Add(pnlRightCard);
            Controls.Add(pnlLeftCard);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Name = "FrmLabRules";
            Padding = new Padding(20);
            Text = "FrmLabRules";
            pnlLeftCard.ResumeLayout(false);
            pnlLeftCard.PerformLayout();
            pnlRightCard.ResumeLayout(false);
            pnlRightCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label1;
        private Panel pnlLeftCard;
        private Label label5;
        private Label label4;
        private Label label3;
        private Panel pnlRightCard;
        private Label label2;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
    }
}