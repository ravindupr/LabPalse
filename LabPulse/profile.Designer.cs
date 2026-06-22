
namespace LabPulse
{
    partial class profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(profile));
            pictureusertype = new PictureBox();
            panel1 = new Panel();
            label5 = new Label();
            lblBrand = new Label();
            lblname = new Label();
            lblRol = new Label();
            checkBoxEdit = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            txtemail = new TextBox();
            txtphone = new TextBox();
            txtAddress = new TextBox();
            btnsubmit = new Button();
            newpassLab = new Label();
            ConfpassLab = new Label();
            txtnewpass = new TextBox();
            txtcompass = new TextBox();
            checkBoxShowPassword = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureusertype).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureusertype
            // 
            pictureusertype.Image = (Image)resources.GetObject("pictureusertype.Image");
            pictureusertype.Location = new Point(96, 109);
            pictureusertype.Name = "pictureusertype";
            pictureusertype.Size = new Size(117, 148);
            pictureusertype.SizeMode = PictureBoxSizeMode.Zoom;
            pictureusertype.TabIndex = 0;
            pictureusertype.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 41, 59);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblBrand);
            panel1.Controls.Add(lblname);
            panel1.Controls.Add(lblRol);
            panel1.Controls.Add(pictureusertype);
            panel1.Location = new Point(2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(340, 1095);
            panel1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(255, 128, 0);
            label5.Location = new Point(11, 32);
            label5.Name = "label5";
            label5.Size = new Size(53, 31);
            label5.TabIndex = 17;
            label5.Text = "⚡ ";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBrand.ForeColor = Color.FromArgb(56, 189, 248);
            lblBrand.ImageAlign = ContentAlignment.MiddleRight;
            lblBrand.Location = new Point(69, 32);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(109, 31);
            lblBrand.TabIndex = 16;
            lblBrand.Text = "LabPulse";
            // 
            // lblname
            // 
            lblname.AutoSize = true;
            lblname.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblname.ForeColor = Color.White;
            lblname.Location = new Point(59, 300);
            lblname.Name = "lblname";
            lblname.Size = new Size(68, 28);
            lblname.TabIndex = 15;
            lblname.Text = "Name";
            lblname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblRol.ForeColor = Color.FromArgb(56, 189, 248);
            lblRol.Location = new Point(175, 32);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(61, 31);
            lblRol.TabIndex = 7;
            lblRol.Text = "Role";
            // 
            // checkBoxEdit
            // 
            checkBoxEdit.AutoSize = true;
            checkBoxEdit.BackColor = SystemColors.ActiveCaption;
            checkBoxEdit.Location = new Point(719, 79);
            checkBoxEdit.Name = "checkBoxEdit";
            checkBoxEdit.Size = new Size(57, 24);
            checkBoxEdit.TabIndex = 3;
            checkBoxEdit.Text = "Edit";
            checkBoxEdit.UseVisualStyleBackColor = false;
            checkBoxEdit.CheckedChanged += checkBoxEdit_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(386, 127);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 6;
            label1.Text = "Name: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(386, 183);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 7;
            label2.Text = "Email: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(386, 311);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 8;
            label3.Text = "Address: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(386, 240);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 9;
            label4.Text = "Phone No: ";
            // 
            // txtName
            // 
            txtName.Location = new Point(461, 124);
            txtName.Name = "txtName";
            txtName.Size = new Size(315, 27);
            txtName.TabIndex = 10;
            // 
            // txtemail
            // 
            txtemail.Location = new Point(461, 176);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(315, 27);
            txtemail.TabIndex = 11;
            // 
            // txtphone
            // 
            txtphone.Location = new Point(461, 237);
            txtphone.Name = "txtphone";
            txtphone.Size = new Size(315, 27);
            txtphone.TabIndex = 12;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(461, 308);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(315, 27);
            txtAddress.TabIndex = 13;
            // 
            // btnsubmit
            // 
            btnsubmit.Location = new Point(631, 475);
            btnsubmit.Name = "btnsubmit";
            btnsubmit.Size = new Size(132, 48);
            btnsubmit.TabIndex = 14;
            btnsubmit.Text = "Submit";
            btnsubmit.UseVisualStyleBackColor = true;
            btnsubmit.Click += btnsubmit_Click;
            // 
            // newpassLab
            // 
            newpassLab.AutoSize = true;
            newpassLab.Location = new Point(386, 381);
            newpassLab.Name = "newpassLab";
            newpassLab.Size = new Size(107, 20);
            newpassLab.TabIndex = 15;
            newpassLab.Text = "New Password:";
            // 
            // ConfpassLab
            // 
            ConfpassLab.AutoSize = true;
            ConfpassLab.Location = new Point(386, 414);
            ConfpassLab.Name = "ConfpassLab";
            ConfpassLab.Size = new Size(134, 20);
            ConfpassLab.TabIndex = 16;
            ConfpassLab.Text = "Confirm Password: ";
            // 
            // txtnewpass
            // 
            txtnewpass.Location = new Point(529, 378);
            txtnewpass.Name = "txtnewpass";
            txtnewpass.PasswordChar = '*';
            txtnewpass.Size = new Size(247, 27);
            txtnewpass.TabIndex = 17;
            // 
            // txtcompass
            // 
            txtcompass.Location = new Point(529, 411);
            txtcompass.Name = "txtcompass";
            txtcompass.PasswordChar = '*';
            txtcompass.Size = new Size(247, 27);
            txtcompass.TabIndex = 18;
            // 
            // checkBoxShowPassword
            // 
            checkBoxShowPassword.AutoSize = true;
            checkBoxShowPassword.Location = new Point(529, 444);
            checkBoxShowPassword.Name = "checkBoxShowPassword";
            checkBoxShowPassword.Size = new Size(132, 24);
            checkBoxShowPassword.TabIndex = 19;
            checkBoxShowPassword.Text = "Show Password";
            checkBoxShowPassword.UseVisualStyleBackColor = true;
            checkBoxShowPassword.CheckedChanged += checkBoxShowPassword_CheckedChanged;
            // 
            // profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(844, 571);
            Controls.Add(checkBoxShowPassword);
            Controls.Add(txtcompass);
            Controls.Add(txtnewpass);
            Controls.Add(ConfpassLab);
            Controls.Add(newpassLab);
            Controls.Add(btnsubmit);
            Controls.Add(txtAddress);
            Controls.Add(txtphone);
            Controls.Add(txtemail);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBoxEdit);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "profile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Profile";
            Load += profile_Load;
            ((System.ComponentModel.ISupportInitialize)pictureusertype).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureusertype;
        private Panel panel1;
        private CheckBox checkBoxEdit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblRol;
        private TextBox txtName;
        private TextBox txtemail;
        private TextBox txtphone;
        private TextBox txtAddress;
        private Button btnsubmit;
        private Label lblname;
        private Label newpassLab;
        private Label ConfpassLab;
        private TextBox txtnewpass;
        private TextBox txtcompass;
        private CheckBox checkBoxShowPassword;
        private Label label5;
        private Label lblBrand;
    }

}