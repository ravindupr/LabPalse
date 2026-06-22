using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabPulse
{
    public partial class search : Form
    {
        private Form dashboardInstance;
        public search()
        {
            InitializeComponent();
        }

        // Custom constructor that catches the search details instantly
        public search(string name, string id, string status, Form callingForm)
        {
            InitializeComponent();

            this.dashboardInstance = callingForm;

            // Fill the textboxes automatically as requested
            textBox1.Text = name;   // Displays Equipment Name
            textBox2.Text = id;     // Displays Equipment ID
            textBox3.Text = status; // Displays In Stock / Out of Stock status

            // Make textboxes read-only so students can't manually edit data records
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void search_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dashboardInstance != null)
            {
                dashboardInstance.Show(); // Show the student dashboard again
                this.Close();             // Close this results form completely
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string eqName = textBox1.Text;
            string eqID = textBox2.Text;

            // 2. Initialize the reservation form using our custom constructor, 
            // passing the item details along with the active dashboard tracking link
            reservation reservationForm = new reservation(eqName, eqID, this.dashboardInstance);

            // 3. Display the reservation screen
            reservationForm.Show();

            // 4. Temporarily detach the search form close event so it doesn't conflict
            this.FormClosed -= search_FormClosed;

            // 5. Close the search results page cleanly
            this.Close();
        }

        private void search_FormClosed(object? sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
