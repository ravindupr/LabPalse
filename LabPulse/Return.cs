using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Integrated MySQL Client references

namespace LabPulse
{
    public partial class Return : Form
    {
        private Form dashboardInstance;
        private string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";
        private static readonly Random random = new Random();

        public Return()
        {
            InitializeComponent();
        }

        // Custom constructor to accept the dashboard reference cleanly
        public Return(Form callingDashboard)
        {
            InitializeComponent();
            this.dashboardInstance = callingDashboard;
        }

        private void Return_Load(object sender, EventArgs e)
        {
            // Configure status dropdown settings matching layout labels
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Perfect");
            comboBox1.Items.Add("Broken");
            comboBox1.SelectedIndex = 0; // Default selection state

            dateTimePicker1.Value = DateTime.Today;
        }

        // Helper method to generate a unique random 6-digit FineID
        private int GenerateUniqueFineID(MySqlConnection conn)
        {
            while (true)
            {
                int potentialID = random.Next(100000, 1000000);
                string checkQuery = "SELECT COUNT(*) FROM Fine WHERE FineID = @FineID";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@FineID", potentialID);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                    if (count == 0) return potentialID;
                }
            }
        }

        // --- BUTTON 1: VERIFY RETURN ---
        private void button1_Click(object sender, EventArgs e)
        {
            string txIdInput = textBox1.Text.Trim();
            string conditionStatus = comboBox1.SelectedItem?.ToString();
            string actualReturnDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // Mapping state variables to your form's checkboxes
            bool physicalDamage = checkBox1.Checked; // Physical damage
            bool minorDamage = checkBox2.Checked;    // Minor Damage
            bool moderateDamage = checkBox3.Checked; // Moderate Damage
            bool severeDamage = checkBox4.Checked;   // Severe Damage

            if (string.IsNullOrEmpty(txIdInput))
            {
                MessageBox.Show("Please enter a valid Transaction ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Evaluation Rule: Pass ONLY if status is Perfect or ONLY Minor Damage is ticked
            bool isPerfectOrOnlyMinor = (conditionStatus == "Perfect" && !physicalDamage && !moderateDamage && !severeDamage);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Step A: Extract basic properties from transaction record entry
                    int equipmentId = 0;
                    int quantityToReturn = 0;

                    string selectTxQuery = "SELECT EquipmentID, Quantity FROM Transaction WHERE TransactionID = @TxID";
                    using (MySqlCommand selectCmd = new MySqlCommand(selectTxQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@TxID", txIdInput);
                        using (MySqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                equipmentId = Convert.ToInt32(reader["EquipmentID"]);
                                quantityToReturn = Convert.ToInt32(reader["Quantity"]);
                            }
                            else
                            {
                                MessageBox.Show("Transaction ID not found inside database records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    if (isPerfectOrOnlyMinor)
                    {
                        // --- CASE A: PASS (Restock inventory to Equipment & set state to 'not assigned') ---
                        using (MySqlTransaction sqlTx = conn.BeginTransaction())
                        {
                            // 1. Restock standard equipment matrix values
                            string restockQuery = "UPDATE Equipment SET `Remaining Quantity` = `Remaining Quantity` + @Qty WHERE EquipmentID = @EqID";
                            using (MySqlCommand restockCmd = new MySqlCommand(restockQuery, conn, sqlTx))
                            {
                                restockCmd.Parameters.AddWithValue("@Qty", quantityToReturn);
                                restockCmd.Parameters.AddWithValue("@EqID", equipmentId);
                                restockCmd.ExecuteNonQuery();
                            }

                            // 2. Clear transactional allocation marker fields
                            string updateTxQuery = "UPDATE Transaction SET ActualReturnDate = @RetDate, Status = 'Returned' WHERE TransactionID = @TxID";
                            using (MySqlCommand updateTxCmd = new MySqlCommand(updateTxQuery, conn, sqlTx))
                            {
                                updateTxCmd.Parameters.AddWithValue("@RetDate", actualReturnDate);
                                updateTxCmd.Parameters.AddWithValue("@TxID", txIdInput);
                                updateTxCmd.ExecuteNonQuery();
                            }

                            sqlTx.Commit();
                            MessageBox.Show("Asset return approved successfully! Quantities returned to active tracking pool.", "Return Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // --- CASE B: DAMAGE/BROKEN OVERRIDE (Skip DB restock, prompt for fine input, insert fine) ---
                        MessageBox.Show("Equipment damage or broken status flagged. Inventory update bypassed.", "Inspection Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Capture input value via standard Microsoft Visual Basic dialog container
                        string fineAmountInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the structural damage fine amount (LKR):", "Issue Fine Allocation", "0");

                        if (string.IsNullOrEmpty(fineAmountInput) || !double.TryParse(fineAmountInput, out double fineAmount) || fineAmount < 0)
                        {
                            MessageBox.Show("Invalid fine amount entered. Return verification aborted.", "Execution Aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int fineId = GenerateUniqueFineID(conn);

                        // 1. Log payment parameter definitions into Fine Table
                        string fineInsertQuery = "INSERT INTO Fine (FineID, TransactionID, Amount, DaysLate) VALUES (@FineID, @TxID, @Amount, 0)";
                        using (MySqlCommand fineCmd = new MySqlCommand(fineInsertQuery, conn))
                        {
                            fineCmd.Parameters.AddWithValue("@FineID", fineId);
                            fineCmd.Parameters.AddWithValue("@TxID", txIdInput);
                            fineCmd.Parameters.AddWithValue("@Amount", fineAmount);
                            fineCmd.ExecuteNonQuery();
                        }

                        // 2. Flag the transaction history track record as Damaged/Fine Issued
                        string updateTxQuery = "UPDATE Transaction SET ActualReturnDate = @RetDate, Status = 'Damaged/Fine Issued' WHERE TransactionID = @TxID";
                        using (MySqlCommand updateTxCmd = new MySqlCommand(updateTxQuery, conn))
                        {
                            updateTxCmd.Parameters.AddWithValue("@RetDate", actualReturnDate);
                            updateTxCmd.Parameters.AddWithValue("@TxID", txIdInput);
                            updateTxCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Fine successfully updated! Fine ID Generated: {fineId}. Row saved.", "Fine Tracked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ClearFormInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to execute verify process: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- NAVIGATION LINK LABEL: BACK TO ADMIN DASHBOARD ---
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.dashboardInstance != null)
            {
                this.dashboardInstance.Show();
                this.Close();
            }
            else
            {
                adminDashboard adminDash = (adminDashboard)Application.OpenForms["adminDashboard"];
                if (adminDash != null) adminDash.Show();
                else new adminDashboard().Show();
                this.Close();
            }
        }

        private void ClearFormInputs()
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            dateTimePicker1.Value = DateTime.Today;
        }

        // Placeholder layout handlers left clean to keep designer configuration mappings intact
        private void label3_Click(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox4_CheckedChanged(object sender, EventArgs e) { }
    }
}