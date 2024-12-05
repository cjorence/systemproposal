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

                        // Add a column for the number key
                        dataTable.Columns.Add("Number Key", typeof(int));

                        // Populate the number key column
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataTable.Rows[i]["Number Key"] = i + 1;
                        }

                        DataTable formattedTable = dataTable.DefaultView.ToTable(false, "Number Key", "name", "date", "time", "appointmenttype");
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

            string[] typeOfAppointment =
            {
                "Routine or Preventive Appointment",
                "Annual Physical Exam",
                "Vaccination Appointment",
                "Specialist Appointment",
                "Follow-Up Appointment",
                "Acute Care Appointment",
                "Diagnostic Appointment",
                "Therapy Appointment",
                "Dental Appointment",
                "Pediatric Appointment",
                "Telemedicine Appointment",
                "Emergency Car",
                "Surgical Consultation",
                "Rehabilitation Appointment",
                "Fertility and Reproductive Health Appointment",
                "Vision and Eye Care Appointment"
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


    }
}
