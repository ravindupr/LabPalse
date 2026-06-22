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
    public partial class staffDashboard : Form
    {
        // -------------------------------------------------------
        // Fields
        // -------------------------------------------------------
        private readonly string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";

        /// <summary>Display name of the currently logged-in staff member.</summary>
        private string currentUserName = string.Empty;

        /// <summary>Primary key of the currently logged-in staff member.</summary>
        private int currentUserID = 0;

        // -------------------------------------------------------
        // Constructors
        // -------------------------------------------------------

        /// <summary>Parameterless constructor kept for designer compatibility.</summary>
        public staffDashboard()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called by login.cs — receives the staff member's name and
        /// resolves the UserID from the database automatically.
        /// </summary>
        public staffDashboard(string? dbName)
        {
            InitializeComponent();
            currentUserName = dbName ?? string.Empty;

            if (!string.IsNullOrEmpty(currentUserName))
                currentUserID = FetchUserID(currentUserName);
        }

        /// <summary>
        /// Extended constructor — receives both the name and the
        /// UserID directly, skipping the extra DB round-trip.
        /// </summary>
        public staffDashboard(string userName, int userID)
        {
            InitializeComponent();
            currentUserName = userName ?? string.Empty;
            currentUserID   = userID;
        }

        // -------------------------------------------------------
        // UserID resolution helper
        // -------------------------------------------------------

        /// <summary>
        /// Queries the database for the UserID matching the given
        /// name with Role = 'staff'. Returns 0 on failure.
        /// </summary>
        private int FetchUserID(string name)
        {
            const string query =
                "SELECT UserID FROM User WHERE Name = @name AND Role = 'staff' LIMIT 1";

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
                        "Error resolving staff session: " + ex.Message,
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
            Form1 welcomeScreen = new Form1();
            welcomeScreen.Show();
            this.Close();
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
    }
}
