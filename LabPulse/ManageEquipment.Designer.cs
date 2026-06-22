namespace LabPulse
{
    partial class ManageEquipment
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
            panel1 = new Panel();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            panel2 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            label6 = new Label();
            label5 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            label4 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            linkLabel2 = new LinkLabel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(802, 47);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(399, 28);
            label1.TabIndex = 1;
            label1.Text = "Equipment Registry and Stock Controller";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(12, 50);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(40, 20);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Back";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(20, 48);
            label2.Name = "label2";
            label2.Size = new Size(157, 25);
            label2.TabIndex = 3;
            label2.Text = "Equipment Name";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(15, 23, 42);
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 84);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 651);
            panel2.TabIndex = 4;
            // 
            // button4
            // 
            button4.BackColor = Color.RoyalBlue;
            button4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(529, 557);
            button4.Name = "button4";
            button4.Size = new Size(197, 46);
            button4.TabIndex = 15;
            button4.Text = "UPDATE ASSET";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.RoyalBlue;
            button3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(53, 557);
            button3.Name = "button3";
            button3.Size = new Size(197, 46);
            button3.TabIndex = 14;
            button3.Text = "LOAD";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.RoyalBlue;
            button2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(292, 557);
            button2.Name = "button2";
            button2.Size = new Size(197, 46);
            button2.TabIndex = 13;
            button2.Text = "CLEAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(20, 11);
            label6.Name = "label6";
            label6.Size = new Size(249, 23);
            label6.TabIndex = 12;
            label6.Text = "Register new Equipment Here :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(32, 260);
            label5.Name = "label5";
            label5.Size = new Size(311, 23);
            label5.TabIndex = 11;
            label5.Text = "Update, Add , Delete Equipment Here :";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.LightSlateGray;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 292);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(717, 231);
            dataGridView1.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(277, 194);
            button1.Name = "button1";
            button1.Size = new Size(197, 46);
            button1.TabIndex = 9;
            button1.Text = "REGISTER ASSET";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(431, 48);
            label4.Name = "label4";
            label4.Size = new Size(126, 25);
            label4.TabIndex = 8;
            label4.Text = "Equipment ID";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.LightSlateGray;
            textBox3.Location = new Point(416, 76);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(288, 27);
            textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.LightSlateGray;
            textBox2.Location = new Point(20, 148);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(288, 27);
            textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightSlateGray;
            textBox1.Location = new Point(20, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(288, 27);
            textBox1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(20, 120);
            label3.Name = "label3";
            label3.Size = new Size(164, 25);
            label3.TabIndex = 4;
            label3.Text = "Initial Stock Count";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(748, 50);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(50, 20);
            linkLabel2.TabIndex = 5;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Home";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked_1;
            // 
            // ManageEquipment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(800, 733);
            Controls.Add(linkLabel2);
            Controls.Add(panel2);
            Controls.Add(linkLabel1);
            Controls.Add(panel1);
            Name = "ManageEquipment";
            Text = "ManageEquipment";
            Load += ManageEquipment_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private LinkLabel linkLabel1;
        private Label label2;
        private Panel panel2;
        private Button button1;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private DataGridView dataGridView1;
        private Label label5;
        private Label label6;
        private LinkLabel linkLabel2;
        private Button button2;
        private Button button4;
        private Button button3;
    }
}