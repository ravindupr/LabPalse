namespace LabPulse
{
    partial class adminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminDashboard));
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            button6 = new Button();
            button4 = new Button();
            button1 = new Button();
            button5 = new Button();
            button3 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Red;
            linkLabel1.Location = new Point(1177, 16);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(62, 20);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Log Out";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.BackColor = Color.FromArgb(64, 64, 64);
            linkLabel2.LinkColor = Color.White;
            linkLabel2.Location = new Point(1338, 16);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(52, 20);
            linkLabel2.TabIndex = 1;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Profile";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1300, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(linkLabel2);
            panel1.Location = new Point(41, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(1409, 125);
            panel1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.CalendarTitleBackColor = Color.FloralWhite;
            dateTimePicker1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(1132, 60);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(242, 30);
            dateTimePicker1.TabIndex = 5;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(172, 91);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI Historic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.FromArgb(192, 255, 255);
            textBox1.Location = new Point(224, 60);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(538, 36);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 255, 255);
            label1.Location = new Point(224, 16);
            label1.Name = "label1";
            label1.Size = new Size(444, 41);
            label1.TabIndex = 3;
            label1.Text = "Welcome to Staff Dashboard !";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Navy;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(41, 204);
            panel2.Name = "panel2";
            panel2.Size = new Size(1409, 508);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightSkyBlue;
            panel3.Controls.Add(button6);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(button5);
            panel3.Location = new Point(638, 65);
            panel3.Name = "panel3";
            panel3.Size = new Size(643, 347);
            panel3.TabIndex = 5;
            // 
            // button6
            // 
            button6.BackColor = Color.LightGray;
            button6.Cursor = Cursors.Hand;
            button6.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(148, 192);
            button6.Name = "button6";
            button6.Size = new Size(373, 49);
            button6.TabIndex = 7;
            button6.Text = "System Analytics";
            button6.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.LightGray;
            button4.Cursor = Cursors.Hand;
            button4.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(148, 113);
            button4.Name = "button4";
            button4.Size = new Size(373, 49);
            button4.TabIndex = 6;
            button4.Text = "User Control Panel";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(148, 36);
            button1.Name = "button1";
            button1.Size = new Size(373, 49);
            button1.TabIndex = 5;
            button1.Text = "Equipment Registry";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.Cursor = Cursors.Hand;
            button5.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(148, 264);
            button5.Name = "button5";
            button5.Size = new Size(373, 49);
            button5.TabIndex = 4;
            button5.Text = "Check Late Students";
            button5.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(128, 255, 128);
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(85, 272);
            button3.Name = "button3";
            button3.Size = new Size(333, 134);
            button3.TabIndex = 2;
            button3.Text = "Returns / Check Ins";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 255, 128);
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(85, 61);
            button2.Name = "button2";
            button2.Size = new Size(333, 129);
            button2.TabIndex = 1;
            button2.Text = "Issue / Check Out";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // adminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1506, 756);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "adminDashboard";
            Text = "Staff Dashboard";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Button button3;
        private Button button2;
        private DateTimePicker dateTimePicker1;
        private Button button5;
        private Panel panel3;
        private Button button4;
        private Button button1;
        private Button button6;
    }
}