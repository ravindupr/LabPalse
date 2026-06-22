using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LabPulse
{
    public partial class reservation : Form
    {
        private Form dashboardInstance;
        private string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";
        private static readonly Random random = new Random();

        public reservation()
        {
            InitializeComponent();
        }

        public reservation(string equipmentName, string equipmentId, Form callingDashboard)
        {
            InitializeComponent();
            this.dashboardInstance = callingDashboard;

            // Pre-fill fields if navigated to directly from a selection matrix
            textBox1.Text = equipmentId;
            textBox4.Text = equipmentId;
        }

        private void reservation_Load(object sender, EventArgs e)
        {
            // Configure DatePicker default to current system date
            dateTimePicker1.Value = DateTime.Today;
        }

        // Helper method to retrieve a UserID from an email address match
        private int GetUserIDByEmail(string email, MySqlConnection conn)
        {
            string query = "SELECT UserID FROM User WHERE Email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            return -1; // Email address not found inside index mapping
        }

        // Method to generate a unique random 6-digit Transaction ID
        private int GenerateUniqueTransactionID(MySqlConnection conn)
        {
            while (true)
            {
                int potentialID = random.Next(10000, 100000); // Generates 5-6 digit space IDs
                string checkQuery = "SELECT COUNT(*) FROM Transaction WHERE TransactionID = @TxID";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@TxID", potentialID);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                    if (count == 0) return potentialID;
                }
            }
        }

        // --- BUTTON 1: BOOK NOW (Immediate Checkout - Today's Date) ---
        private void button1_Click(object sender, EventArgs e)
        {
            string eqId = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string qtyStr = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(eqId) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(qtyStr))
            {
                MessageBox.Show("Please fill all inputs under the Book Now section.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcessBooking(eqId, email, qtyStr, DateTime.Today);
        }

        // --- BUTTON 2: PROCEED TO RESERVE (Scheduled Checkout - Custom Date) ---
        private void button2_Click(object sender, EventArgs e)
        {
            string eqId = textBox4.Text.Trim();
            string email = textBox5.Text.Trim();
            string qtyStr = textBox6.Text.Trim();
            DateTime selectedIssueDate = dateTimePicker1.Value.Date;

            if (string.IsNullOrEmpty(eqId) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(qtyStr))
            {
                MessageBox.Show("Please fill all inputs under the Reserve A Booking section.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcessBooking(eqId, email, qtyStr, selectedIssueDate);
        }

        // --- CORE LOGIC BLOCK: Executes the MySQL Insertion ---
        private void ProcessBooking(string eqId, string email, string qtyStr, DateTime issueDate)
        {
            if (!int.TryParse(qtyStr, out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity requested must be a valid positive integer number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Automatically project return rules 14 days out from issue timeline sequence
            DateTime returnDate = issueDate.AddDays(14);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Resolve the true system UserID from the profile account pool index
                    int userId = GetUserIDByEmail(email, conn);
                    if (userId == -1)
                    {
                        MessageBox.Show("No account profile found matching that email address identifier.", "Account Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int txId = GenerateUniqueTransactionID(conn);
                    string query = "INSERT INTO Transaction (TransactionID, UserID, EquipmentID, Quantity, IssueDate, ActualReturnDate, Status) " +
                                   "VALUES (@TxID, @UserID, @EqID, @Qty, @Issue, @Return, 'Pending')";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TxID", txId);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@EqID", eqId);
                        cmd.Parameters.AddWithValue("@Qty", qty);
                        cmd.Parameters.AddWithValue("@Issue", issueDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Return", returnDate.ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Request filed successfully!. System status: Pending Admin Authorization.",
                                    "Allocation Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to file allocation allocation row: {ex.Message}", "Database Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputFields()
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            dateTimePicker1.Value = DateTime.Today;
        }

        // --- LINK LABEL 1: BACK TO STUDENT DASHBOARD ---
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.dashboardInstance != null)
            {
                this.dashboardInstance.Show();
                this.Close();
            }
            else
            {
                // Fallback instantiation if sequence was skipped
                studentDashboard fallbackDash = new studentDashboard();
                fallbackDash.Show();
                this.Close();
            }
        }

        

        private void reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.dashboardInstance != null)
            {
                this.dashboardInstance.Show();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit and return to the main home screen?",
                "Return Home",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Form1 welcomeScreen = new Form1();
                welcomeScreen.Show();

                if (this.dashboardInstance != null)
                {
                    this.FormClosed -= reservation_FormClosed;
                    this.dashboardInstance.Close();
                }
                this.Close();
            }
        }

        private void reservation_Load_1(object sender, EventArgs e) { }
    }
}