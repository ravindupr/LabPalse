using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabPulse
{
    public partial class login : Form
    {
        private string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";
        public login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string emailInput = textBox1.Text.Trim();
            string passwordInput = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(emailInput) || string.IsNullOrEmpty(passwordInput))
            {
                MessageBox.Show("Please enter both email and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Change your query to select both Name and Role
            string query = "SELECT Name, Role FROM User WHERE Email = @Email AND Password = @Password";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", emailInput);
                        cmd.Parameters.AddWithValue("@Password", passwordInput);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string dbName = reader["Name"].ToString();
                                string userRole = reader["Role"].ToString().ToLower().Trim();

                                // Pass the retrieved name into the dashboard constructor
                                if (userRole == "student")
                                {
                                    studentDashboard studentDash = GetStudentDash(dbName);
                                    studentDash.Show();
                                }
                                else if (userRole == "staff")
                                {
                                    adminDashboard staffDash = new adminDashboard(dbName);
                                    staffDash.Show();
                                }
                                else if (userRole == "admin")
                                {
                                    adminDashboard adminDash = new adminDashboard(dbName);
                                    adminDash.Show();
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Email or Password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static studentDashboard GetStudentDash(string dbName)
        {
            return new studentDashboard(dbName);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration regForm = new Registration();
            regForm.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 welcomePage = new Form1();
            welcomePage.Show();
            this.Hide();
        }
    }
}

