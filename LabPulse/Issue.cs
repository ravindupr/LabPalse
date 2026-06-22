using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Correct MySQL provider namespaces used exclusively

namespace LabPulse
{
    public partial class Issue : Form
    {
        private Form dashboardInstance;

        // Configured for your local XAMPP/WAMP MySQL Database
        // FIXED: Added Allow Zero Datetime=True to handle unassigned/blank date fields safely
        private string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;Allow Zero Datetime=True;";

        // Shifted references to MySQL Data Pipeline types
        private MySqlDataAdapter dataAdapter;
        private DataTable transactionTable;

        public Issue()
        {
            InitializeComponent();
        }

        public Issue(Form callingForm)
        {
            InitializeComponent();
            this.dashboardInstance = callingForm;
        }

        // Runs automatically when the screen opens
        private void Issue_Load(object sender, EventArgs e)
        {
            // Set up Grid View UI behaviors on window startup
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            // Load records into the screen immediately
            RefreshInterfaceData();
        }

        // --- PIPELINE: Refresh Data Grid View & Core Request Counter ---
        private void RefreshInterfaceData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. Calculate and update the 'No of Pending Requests' box (textBox1)
                    string countQuery = "SELECT COUNT(*) FROM Transaction WHERE Status = 'Pending'";
                    using (MySqlCommand countCommand = new MySqlCommand(countQuery, connection))
                    {
                        int pendingCount = Convert.ToInt32(countCommand.ExecuteScalar());
                        textBox1.Text = pendingCount.ToString(); // Displays count in textBox1
                    }

                    // 2. Load the actual transaction tracking rows into the main data grid view
                    string gridQuery = "SELECT TransactionID, UserID, EquipmentID, Quantity, IssueDate, ActualReturnDate, Status FROM Transaction";
                    dataAdapter = new MySqlDataAdapter(gridQuery, connection);

                    transactionTable = new DataTable();
                    dataAdapter.Fill(transactionTable);
                    dataGridView1.DataSource = transactionTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to synchronize workspace records: {ex.Message}", "Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- GRID EVENT: Clicking a row auto-populates all details textboxes ---
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verify click lands on an actual record row, not header cells
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Keep TransactionID saved in the Tag property for the update process query string
                string transactionId = selectedRow.Cells["TransactionID"].Value.ToString();
                this.Tag = transactionId;

                // Map row fields directly into input text boxes
                textBox2.Text = selectedRow.Cells["UserID"].Value.ToString();
                // ...        // Student ID Box
                textBox3.Text = "Student Profile";                                   // Static placeholder or expand via SQL JOIN
                textBox4.Text = "Resource Asset";                                    // Static placeholder
                textBox5.Text = selectedRow.Cells["EquipmentID"].Value.ToString();  // Equipment ID Box

                if (selectedRow.Cells["IssueDate"].Value != DBNull.Value)
                {
                    textBox6.Text = Convert.ToDateTime(selectedRow.Cells["IssueDate"].Value).ToString("yyyy-MM-dd"); // Start Date Box
                }
            }
        }

        // --- BUTTON 1: APPROVE ISSUE REQUEST ---
        private void button1_Click(object sender, EventArgs e)
        {
            // Validate that a specific request target has been selected via grid interaction
            if (this.Tag == null || string.IsNullOrEmpty(this.Tag.ToString()))
            {
                MessageBox.Show("Please select a transaction record from the table list first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetTransactionID = this.Tag.ToString();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Update statement matching the MySQL trigger logic
                    string updateQuery = "UPDATE Transaction SET Status = 'Approved' WHERE TransactionID = @TxID AND Status = 'Pending'";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TxID", targetTransactionID);
                        connection.Open();

                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Resource allocation approved successfully! Inventory stocks adjusted.", "Allocation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearDetailFields();
                        }
                        else
                        {
                            MessageBox.Show("This transaction is either already processed or no longer valid.", "Action Aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Force interface synchronization instantly
                RefreshInterfaceData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database processing failure: {ex.Message}", "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BUTTON 2: REFRESH WORKSPACE DATA ---
        private void button2_Click(object sender, EventArgs e)
        {
            RefreshInterfaceData();
            ClearDetailFields();
            MessageBox.Show("Database tracking information synchronized and refreshed successfully.", "Workspace Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearDetailFields()
        {
            this.Tag = null; // Clear active transaction marker memory
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        // --- NAVIGATION BACK LINK ---
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dashboardInstance != null)
            {
                dashboardInstance.Show();
                this.Close();
            }
            else
            {
                adminDashboard dashboard = (adminDashboard)Application.OpenForms["adminDashboard"];
                if (dashboard != null) dashboard.Show();
                else new adminDashboard().Show();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Optional layout callback
        }
    }
}