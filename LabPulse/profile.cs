using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LabPulse
{
    public partial class profile : Form
    {
        string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";
        int userID;

        public profile(int id)
        {
            InitializeComponent();
            userID = id;
        }

        private void profile_Load(object sender, EventArgs e)
        {
            txtName.ReadOnly = true;
            txtemail.ReadOnly = true;
            txtphone.ReadOnly = true;

            txtnewpass.Visible = false;
            txtcompass.Visible = false;
            newpassLab.Visible = false;
            ConfpassLab.Visible = false;
            checkBoxShowPassword.Visible = false;
            btnsubmit.Visible = false;

            txtnewpass.PasswordChar = '*';
            txtcompass.PasswordChar = '*';

            LoadUserData();
        }

        private void LoadUserData()
        {
            string query = "SELECT Name, Email, PhoneNo, Role FROM User WHERE UserID=@id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", userID);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                        txtemail.Text = reader["Email"].ToString();
                        txtphone.Text = reader["PhoneNo"].ToString();

                        lblname.Text = reader["Name"].ToString();
                        //lblRol.Text = reader["Role"].ToString();
                        string role = reader["Role"].ToString();

                        if (role == "student")
                        {
                            lblRol.Text = "Student";
                        }
                        else if (role == "admin")
                        {
                            lblRol.Text = "Admin";
                        }
                        else if (role == "staff")
                        {
                            lblRol.Text = "Staff";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void checkBoxEdit_CheckedChanged(object sender, EventArgs e)
        {
            bool edit = checkBoxEdit.Checked;

            txtName.ReadOnly = !edit;
            txtemail.ReadOnly = !edit;
            txtphone.ReadOnly = !edit;

            txtnewpass.Visible = edit;
            txtcompass.Visible = edit;
            newpassLab.Visible = edit;
            ConfpassLab.Visible = edit;
            checkBoxShowPassword.Visible = edit;
            btnsubmit.Visible = edit;

            if (!edit)
            {
                txtnewpass.Clear();
                txtcompass.Clear();
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                txtnewpass.PasswordChar = '\0';
                txtcompass.PasswordChar = '\0';
            }
            else
            {
                txtnewpass.PasswordChar = '*';
                txtcompass.PasswordChar = '*';
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" || txtemail.Text.Trim() == "")
            {
                MessageBox.Show("Fill all required fields");
                return;
            }

            if (txtnewpass.Text != txtcompass.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            string query;

            if (txtnewpass.Text.Trim() == "")
            {
                query = "UPDATE User SET Name=@name, Email=@email, PhoneNo=@phone WHERE UserID=@id";
            }
            else
            {
                query = "UPDATE User SET Name=@name, Email=@email, PhoneNo=@phone, Password=@pass WHERE UserID=@id";
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@id", userID);

                    if (txtnewpass.Text.Trim() != "")
                    {
                        cmd.Parameters.AddWithValue("@pass", txtnewpass.Text);
                    }

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Profile Updated Successfully");

                        lblname.Text = txtName.Text;

                        checkBoxEdit.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
         private void txtnewpass_TextChanged (object sender, EventArgs e)
        {
         
        }
    }
}