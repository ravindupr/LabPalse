using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabPulse
{
    public partial class adminDashboard : Form
    {
        // -------------------------------------------------------
        // Fields
        // -------------------------------------------------------
        private readonly string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";

        /// <summary>Display name of the currently logged-in admin.</summary>
        private string currentUserName = string.Empty;

        /// <summary>Primary key of the currently logged-in admin.</summary>
        private int currentUserID = 0;

        // -------------------------------------------------------
        // Constructors
        // -------------------------------------------------------

        /// <summary>Parameterless constructor kept for designer compatibility.</summary>
        public adminDashboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called by login.cs — receives the admin's name and
        /// resolves the UserID from the database automatically.
        /// </summary>
        public adminDashboard(string userName)
        {
            InitializeComponent();
            currentUserName = userName ?? string.Empty;
            textBox1.Text = currentUserName;
            textBox1.ReadOnly = true;

            if (!string.IsNullOrEmpty(currentUserName))
                currentUserID = FetchUserID(currentUserName);
        }

        /// <summary>
        /// Extended constructor — receives both the name and the
        /// UserID directly, skipping the extra DB round-trip.
        /// </summary>
        public adminDashboard(string userName, int userID)
        {
            InitializeComponent();
            currentUserName = userName ?? string.Empty;
            currentUserID = userID;
            textBox1.Text = currentUserName;
            textBox1.ReadOnly = true;
        }

        // -------------------------------------------------------
        // UserID resolution helper
        // -------------------------------------------------------

        /// <summary>
        /// Queries the database for the UserID matching the given
        /// name with Role = 'admin'. Returns 0 on failure.
        /// </summary>
        private int FetchUserID(string name)
        {
            const string query =
                "SELECT UserID FROM User WHERE Name = @name AND Role = 'admin' LIMIT 1";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            return Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error resolving admin session: " + ex.Message,
                        "Session Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            return 0;
        }

        // -------------------------------------------------------
        // Log Out (linkLabel1)
        // -------------------------------------------------------
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 welcomeScreen = new Form1();
                welcomeScreen.Show();
                this.Close();
            }
        }

        // -------------------------------------------------------
        // Profile (linkLabel2)
        // -------------------------------------------------------
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentUserID == 0)
            {
                MessageBox.Show(
                    "Unable to load profile: user session not found. Please log in again.",
                    "Session Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            profile profileForm = new profile(currentUserID);
            profileForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            profileForm.Show();
        }

        // -------------------------------------------------------
        // textBox1_TextChanged — required by designer event binding
        // -------------------------------------------------------
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Intentionally empty
        }

        // -------------------------------------------------------
        // button1 — Equipment Registry / Manage Equipment
        // -------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            ManageEquipment manageForm = new ManageEquipment(this);
            manageForm.Show();
            this.Hide();
        }

        // -------------------------------------------------------
        // button2 — Issue / Check Out
        // -------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            Issue issueForm = new Issue();
            issueForm.Show();
            this.Hide();
        }

        // -------------------------------------------------------
        // systemAnalyticsToolStripMenuItem_Click
        // -------------------------------------------------------
        private void systemAnalyticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reserved for future implementation
        }

        // -------------------------------------------------------
        // button3 — Returns / Check Ins
        // -------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            Return returnForm = new Return(this);
            returnForm.Show();
            this.Hide();
        }

        // -------------------------------------------------------
        // button4 — Profile Settings Layout Link
        // -------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            if (currentUserID == 0)
            {
                MessageBox.Show(
                    "Unable to load profile: user session not found. Please log in again.",
                    "Session Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            profile profileForm = new profile(currentUserID);
            profileForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            profileForm.Show();
        }
    }
}