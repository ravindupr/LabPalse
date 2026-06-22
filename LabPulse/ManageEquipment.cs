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
    public partial class ManageEquipment : Form
    {
        private Form dashboardInstance;

        private string connectionString = "Server=localhost;Database=labpulse_db;Uid=root;Pwd=;";

        private MySqlDataAdapter dataAdapter;
        private DataTable equipmentTable;

        public ManageEquipment()
        {
            InitializeComponent();
        }

        public ManageEquipment(Form callingForm)
        {
            InitializeComponent();
            this.dashboardInstance = callingForm;
        }

        private void ManageEquipment_Load(object sender, EventArgs e)
        {
            
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dashboardInstance != null)
            {
                dashboardInstance.Show(); 
                this.Close();             
            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 loginForm = (Form1)Application.OpenForms["Form1"];
            if (loginForm != null)
            {
                loginForm.Show();
            }
            else
            {
                Form1 newLoginForm = new Form1();
                newLoginForm.Show();
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string eqName = textBox1.Text.Trim();
            string eqQtyStr = textBox2.Text.Trim();
            string eqId = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(eqName) || string.IsNullOrEmpty(eqQtyStr) || string.IsNullOrEmpty(eqId))
            {
                MessageBox.Show("Please fill all input boxes (Name, Qty, ID).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(eqQtyStr, out int eqQty))
            {
                MessageBox.Show("Quantity must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO Equipment (EquipmentID, Name, `Remaining Quantity`) VALUES (@ID, @Name, @Qty)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", eqId);
                        command.Parameters.AddWithValue("@Name", eqName);
                        command.Parameters.AddWithValue("@Qty", eqQty);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Asset registered and saved to the MySQL database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to register asset: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            if (equipmentTable != null)
            {
                equipmentTable.Clear();
            }

            MessageBox.Show("Data grid cleared successfully.", "Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT EquipmentID, Name, `Remaining Quantity` FROM Equipment";
                    dataAdapter = new MySqlDataAdapter(query, connection);
                    MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);

                    equipmentTable = new DataTable();
                    dataAdapter.Fill(equipmentTable);

                    dataGridView1.DataSource = equipmentTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = true;
                }

                MessageBox.Show("Database loaded successfully into the grid view.", "Data Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAdapter != null && equipmentTable != null)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        dataAdapter.SelectCommand.Connection = connection;

                        MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);

                        connection.Open();

                        dataAdapter.Update(equipmentTable);

                        MessageBox.Show("All adjustments, deletions, and additions made in the grid have been saved to the database!",
                                        "Database Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No active database session found. Please click 'Load' before saving changes.",
                                    "Update Aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to sync alterations: {ex.Message}", "Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageEquipment_Load_1(object sender, EventArgs e)
        {

        }
    }
}
