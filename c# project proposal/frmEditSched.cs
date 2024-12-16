using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace c__project_proposal
{
    public partial class frmEditSched : Form
    {
        String connString = "server=localhost;user id=root;pwd=admin;database=appointment";
       
        public frmEditSched()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmEditSched_FormClosing);
        }

        private void dataGridViewAllSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure a row is selected
            {
                // Get the selected row
                DataGridViewRow row = dataGridViewAllSched.Rows[e.RowIndex];

                // Get the name (or another unique identifier) from the row and display it in textBoxName
                textBoxName.Text = row.Cells["name"].Value.ToString();
            }
        }
    

        private void frmEditSched_Load(object sender, EventArgs e)
        {
            string query = "SELECT name, date, time, appointmenttype FROM appointment ORDER BY date ASC";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        DataTable formattedTable = dataTable.DefaultView.ToTable(false, "Name", "Date", "Time", "AppointmentType");
                        // Bind to DataGridView
                        dataGridViewAllSched.DataSource = formattedTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            for (int hr = 1; hr <= 12; hr++)
            {
                cbHour.Items.Add(hr);
            }
            for (int min = 1; min <= 59; min++)
            {
                cbMinute.Items.Add(min);
            }

            string[] time = { "AM", "PM" };
            for (int i = 0; i < time.Length; i++)
            {
                cbTimePeriod.Items.Add(time[i]);
            }

            string[] typeOfAppointment = {
                "General Check-Up",
                "Physical Examination",
                "Pediatric Check-Up",
                "Prenatal Visit",
                "Postnatal Check-Up",
                "Immunization Appointment",
                "Dental Cleaning",
                "Eye Examination",
                "Hearing Test",
                "Blood Test",
                "Urine Test",
                "X-Ray",
                "MRI Scan",
                "CT Scan",
                "Ultrasound",
                "Mammogram",
                "Pap Smear",
                "Dermatology Consultation",
                "Cardiology Consultation",
                "Orthopedic Consultation",
                "Psychiatric Evaluation",
                "Therapy Session (Mental Health)",
                "Nutrition Counseling",
                "Physical Therapy Session",
                "Chiropractic Adjustment",
                "Allergy Testing",
                "Vaccination (e.g., Flu Shot, COVID-19)",
                "Diabetes Management Appointment",
                "Cancer Screening",
                "Follow-Up Appointment"
            };
            for (int app = 0; app < typeOfAppointment.Length; app++)
            {
                comboBoxAppointmentType.Items.Add(typeOfAppointment[app]);
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            string nameToDelete = textBoxName.Text; // Get the name from the textbox


            if (string.IsNullOrEmpty(nameToDelete))
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            // Confirmation before deleting
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete the record for {nameToDelete}?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // SQL DELETE query to remove the record from the database
                string deleteQuery = "DELETE FROM appointment WHERE name = @name";

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connString))
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                        {
                            // Use parameters to avoid SQL injection
                            command.Parameters.AddWithValue("@name", nameToDelete);

                            // Execute the DELETE command
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No record found with the provided name.");
                            }
                        }
                    }

                    // Reload the data in the DataGridView
                    frmEditSched_Load(sender, e); // This reloads the DataGridView after deletion
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewAllSched.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            // Get the selected row from the DataGridView
            DataGridViewRow selectedRow = dataGridViewAllSched.SelectedRows[0];



            // Retrieve the values from the DataGridView row
            string currentName = selectedRow.Cells["name"].Value.ToString();
            string updatedName = textBoxName.Text;
            string updatedDate = dateTimePickerDate.Value.ToString("yyyy-MM-dd");
            string updatedTime = $"{cbHour.Text}:{cbMinute.Text} {cbTimePeriod.Text}";
            string updatedAppointmentType = comboBoxAppointmentType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(updatedName) || string.IsNullOrEmpty(updatedTime) || string.IsNullOrEmpty(updatedAppointmentType))
            {
                MessageBox.Show("Please fill out all fields before updating.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "Confirm Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string updateQuery = "UPDATE appointment SET name = @updatedName, date = @updatedDate, time = @updatedTime, appointmenttype = @updatedAppointmentType WHERE name = @currentName";

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connString))
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                        {
                       
                            command.Parameters.AddWithValue("@updatedName", updatedName);
                            command.Parameters.AddWithValue("@updatedDate", updatedDate);
                            command.Parameters.AddWithValue("@updatedTime", updatedTime);
                            command.Parameters.AddWithValue("@updatedAppointmentType", updatedAppointmentType);
                            command.Parameters.AddWithValue("@currentName", currentName);

                            // Execute the update command and check how many rows were affected
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record updated successfully.");

                                frmEditSched_Load(sender, e); // Refresh the DataGridView and reset the form fields

                                // Optionally, clear the input fields
                                textBoxName.Clear();
                                dateTimePickerDate.Value = DateTime.Now;
                                cbHour.SelectedIndex = -1;
                                cbMinute.SelectedIndex = -1;
                                cbTimePeriod.SelectedIndex = -1;
                                comboBoxAppointmentType.SelectedIndex = -1;
                            }
                            else
                            {
                                MessageBox.Show("No records were updated. Please try again.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
        private void frmEditSched_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Calendar.Instance != null)
                {
                    Calendar.Instance.DisplayCalendar();
                }
            }
            else
            {
                e.Cancel = true; // Prevent form closure
            }
        }
    }
}
