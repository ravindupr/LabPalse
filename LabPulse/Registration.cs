using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LabPulse
{
    public partial class Registration : Form
    {
        private string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";

        // Random instance used for generating unique IDs
        private static readonly Random random = new Random();
        public Registration()
        {
            InitializeComponent();
        }

        // Method to generate a unique 6-digit UserID that doesn't already exist in the database
        private int GenerateUniqueUserID(MySqlConnection conn)
        {
            while (true)
            {
                // Generates a random number between 100000 and 999999
                int potentialID = random.Next(100000, 1000000);

                // Check if this ID already exists in the User table
                string checkQuery = "SELECT COUNT(*) FROM User WHERE UserID = @UserID";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@UserID", potentialID);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());

                    // If count is 0, this ID is completely unique and safe to use!
                    if (count == 0)
                    {
                        return potentialID;
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameInput = textBox1.Text.Trim();
            string emailInput = textBox2.Text.Trim();
            
            string roleInput = textBox5.Text.Trim();

            string passwordInput = textBox3.Text.Trim();   // Main Password field
            string confirmPasswordInput = textBox4.Text.Trim(); // Re-enter Password field

           

            // Password Match Validation Check
            if (passwordInput != confirmPasswordInput)
            {
                MessageBox.Show("Passwords do not match! Please re-enter your password correctly.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Optional: Clear the confirm password box and refocus to let them type again
                textBox3.Clear();
                
                textBox4.Clear();
                textBox3.Focus();
                textBox4.Focus();
                return;
            }

            string roleInput1 = textBox5.Text.Trim().ToLower(); // Captures input from textBox5, trims spaces, and converts to lowercase

            // 1. Validate that the role is EXACTLY student, staff, or admin
            if (roleInput1 != "student" && roleInput1 != "staff" && roleInput1 != "admin")
            {
                MessageBox.Show("Invalid Role! You must enter exactly 'student', 'staff', or 'admin'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox5.Focus(); // Places the user's cursor back in textBox5
                return;          // Halts execution so it doesn't save to the database
            }

            // 1. Basic Empty Validation Check
            if (string.IsNullOrEmpty(nameInput) || string.IsNullOrEmpty(emailInput) ||
                string.IsNullOrEmpty(passwordInput) || string.IsNullOrEmpty(roleInput))
            {
                MessageBox.Show("All fields are required. Please fill in everything.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Email Format Validation Check (Ensures it contains '@')
            if (!emailInput.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Secure parameterized INSERT query including our manually generated UserID
            string query = "INSERT INTO User (UserID, Name, Email, Password, Role) VALUES (@UserID, @Name, @Email, @Password, @Role)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Generate the unique random ID using our helper function
                    int uniqueID = GenerateUniqueUserID(conn);

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Bind inputs and the generated unique ID to the parameters
                        cmd.Parameters.AddWithValue("@UserID", uniqueID);
                        cmd.Parameters.AddWithValue("@Name", nameInput);
                        cmd.Parameters.AddWithValue("@Email", emailInput);
                        cmd.Parameters.AddWithValue("@Password", passwordInput);
                        cmd.Parameters.AddWithValue("@Role", roleInput.ToLower());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Account successfully created!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Redirect to the login form
                            NavigateToLogin();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NavigateToLogin()
        {
            login loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToLogin();
        }
    }
}
