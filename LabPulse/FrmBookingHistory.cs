using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LabPulse
{
    public partial class FrmBookingHistory : Form
    {
        // -------------------------------------------------------
        // Fields & Data Pipelines
        // -------------------------------------------------------
        private Form dashboardInstance;
        private readonly string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";
        private MySqlDataAdapter dataAdapter;
        private DataTable historyTable;

        // -------------------------------------------------------
        // Constructors
        // -------------------------------------------------------

        /// <summary>Parameterless constructor required for standard WinForms Designer support.</summary>
        public FrmBookingHistory()
        {
            InitializeComponent();
        }

        /// <summary>Extended constructor that captures the calling form reference for back-navigation pathing.</summary>
        public FrmBookingHistory(Form callingDashboard)
        {
            InitializeComponent();
            this.dashboardInstance = callingDashboard;
        }

        // -------------------------------------------------------
        // Form Load Event (Populates the Grid automatically)
        // -------------------------------------------------------
        private void FrmBookingHistory_Load(object sender, EventArgs e)
        {
            LoadHistoryLogMatrix();
        }

        /// <summary>
        /// Queries the Transaction table for all records matching 'Pending' or 'Returned' 
        /// statuses and populates dataGridView1 cleanly.
        /// </summary>
        private void LoadHistoryLogMatrix()
        {
            const string query = "SELECT TransactionID, UserID, EquipmentID, Quantity, IssueDate, actualreturnDate, Status " +
                                 "FROM Transaction " +
                                 "WHERE Status = 'Pending' OR Status = 'Returned'";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Process dataset through standard MySQL data adapter pipeline
                    dataAdapter = new MySqlDataAdapter(query, conn);
                    historyTable = new DataTable();
                    dataAdapter.Fill(historyTable);

                    // Bind memory data engine results to the grid interface component
                    dataGridView1.DataSource = historyTable;

                    // UI Polish Configuration Mappings
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;

                    // Provide user feedback notification if zero transactions exist
                    if (historyTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No historical or pending records found inside the laboratory database logs.", "Status Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to synchronize transaction history: {ex.Message}", "Database Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // -------------------------------------------------------
        // Navigation & Cleanup Events
        // -------------------------------------------------------

        // --- BACK LINK CLICKS ---
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.dashboardInstance != null)
            {
                this.dashboardInstance.Show(); // Reveal hidden dashboard window frame
                this.Close();                 // Close out history form fully
            }
            else
            {
                this.Close(); // Fallback direct window close closure
            }
        }

        // --- SYSTEM X BUTTON ESCAPE ---
        private void FrmBookingHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Ensures the application context doesn't leave the main dashboard stranded invisible in system memory
            if (this.dashboardInstance != null)
            {
                this.dashboardInstance.Show();
            }
        }

        // --- INTERNAL DATA GRID CLICK HANDLER STUB ---
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kept intact for your existing form structural designer element mappings
        }
    }
}