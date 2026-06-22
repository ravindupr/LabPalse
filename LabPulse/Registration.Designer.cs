namespace LabPulse
{
    partial class Registration
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
            label1 = new Label();
            panel1 = new Panel();
            textBox5 = new TextBox();
            label7 = new Label();
            linkLabel1 = new LinkLabel();
            label6 = new Label();
            button1 = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(175, 42);
            label1.Name = "label1";
            label1.Size = new Size(176, 26);
            label1.TabIndex = 0;
            label1.Text = "CREATE ACCOUNT";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(190, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(535, 701);
            panel1.TabIndex = 1;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(50, 460);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(430, 27);
            textBox5.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(50, 437);
            label7.Name = "label7";
            label7.Size = new Size(141, 20);
            label7.TabIndex = 12;
            label7.Text = "Role (Staff/Student)";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(303, 604);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(79, 20);
            linkLabel1.TabIndex = 11;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Login here";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(128, 604);
            label6.Name = "label6";
            label6.Size = new Size(179, 20);
            label6.TabIndex = 10;
            label6.Text = "Have already an account?";
            // 
            // button1
            // 
            button1.BackColor = Color.MediumTurquoise;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(50, 526);
            button1.Name = "button1";
            button1.Size = new Size(430, 29);
            button1.TabIndex = 9;
            button1.Text = "SIGN UP";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(50, 380);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(430, 27);
            textBox4.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(50, 298);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(430, 27);
            textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(50, 210);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(430, 27);
            textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(50, 128);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(430, 27);
            textBox1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 357);
            label5.Name = "label5";
            label5.Size = new Size(139, 20);
            label5.TabIndex = 4;
            label5.Text = "Re enter passwaord";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 275);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 3;
            label4.Text = "Password";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 187);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Your Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 105);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 1;
            label2.Text = "Your Name";
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(941, 725);
            Controls.Add(panel1);
            Name = "Registration";
            Text = "Registration";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Button button1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private LinkLabel linkLabel1;
        private Label label6;
        private TextBox textBox5;
        private Label label7;
    }
}