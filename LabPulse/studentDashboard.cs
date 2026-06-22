using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace LabPulse
{
    public partial class studentDashboard : Form
    {
        private string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";
        private string currentUserName;
        private int currentUserID = 0;

        public studentDashboard()
        {
            InitializeComponent();
        }
        public studentDashboard(string userName)
        {
            InitializeComponent();
            currentUserName = userName;
            if (!string.IsNullOrEmpty(currentUserName))
            {
                currentUserID = FetchUserID(currentUserName);
            }
        }

        private int FetchUserID(string name)
        {
            string query = "SELECT UserID FROM User WHERE Name = @name AND Role = 'student' LIMIT 1";
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            return Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error resolving student session: " + ex.Message);
                }
            }
            return 0;
        }

        /// <summary>
        /// THE MASTER SWITCHING FUNCTION
        /// Strips top-level borders from sub-forms and embeds them directly into the pnlContent container.
        /// </summary>
        /// <param name="childForm">The instance of the target inner form to load.</param>
        private void DisplaySubForm(Form childForm)
        {
            // 1. If a form is already showing in the workspace panel, close it to free up memory
            if (pnlContent.Controls.Count > 0)
            {
                Form currentForm = pnlContent.Controls[0] as Form;
                if (currentForm != null)
                {
                    currentForm.Close();
                    currentForm.Dispose();
                }
                pnlContent.Controls.Clear();
            }

            // 2. Configure the incoming form to act as an embedded panel control
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // 3. Inject the form into the panel's active control collection
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.Show();
        }

        /// <summary>
        /// Form Load event execution flow.
        /// Runs automatically the moment the studentDashboard finishes initial rendering.
        /// </summary>
        private void studentDashboard_Load(object sender, EventArgs e)
        {
            DisplaySubForm(new FrmEquipmentCatalog());
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            DisplaySubForm(new FrmEquipmentCatalog());
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            // Initialize the Booking History window form, passing 'this' dashboard reference
            FrmBookingHistory historyForm = new FrmBookingHistory(this);

            // Display the historical tracking grid screen 
            historyForm.Show();

            // Hide the student dashboard interface to keep the desktop workspace clean
            this.Hide();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            DisplaySubForm(new FrmLabRules());
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (currentUserID == 0)
            {
                MessageBox.Show("Unable to load profile: user session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DisplaySubForm(new profile(currentUserID));

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out of LabPulse?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            DisplaySubForm(new reservation());

        }
    }
}