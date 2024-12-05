using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace c__project_proposal
{
    public partial class EventForm : Form
    {
        String connString = "server=localhost;user id=root;pwd=admin;database=appointment";

        public EventForm()
        {
            InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = Calendar.static_year + "/" + Calendar.static_month + "/" + UserControlDays.static_day;

            for (int hr = 1; hr <= 12; hr++)
            {
                cbHour.Items.Add(hr.ToString("D2")); // Format as 2 digits
            }
            for (int min = 0; min < 60; min++) // Fixed minutes range to include 0
            {
                cbMinute.Items.Add(min.ToString("D2"));
            }
            string[] timePeriods = { "AM", "PM" };
            cbTimePeriod.Items.AddRange(timePeriods);

            string[] typeOfAppointment = {
                "Routine or Preventive Appointment", "Annual Physical Exam",
                "Vaccination Appointment", "Specialist Appointment",
                "Follow-Up Appointment", "Acute Care Appointment",
                "Diagnostic Appointment", "Therapy Appointment",
                "Dental Appointment", "Pediatric Appointment",
                "Telemedicine Appointment", "Emergency Car",
                "Surgical Consultation", "Rehabilitation Appointment",
                "Fertility and Reproductive Health Appointment",
                "Vision and Eye Care Appointment"
            };
            cbAppointment.Items.AddRange(typeOfAppointment);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs first
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDate.Text) ||
                string.IsNullOrWhiteSpace(cbHour.Text) ||
                string.IsNullOrWhiteSpace(cbMinute.Text) ||
                string.IsNullOrWhiteSpace(cbTimePeriod.Text) ||
                cbAppointment.SelectedItem == null)
            {
                MessageBox.Show("Please fill out all fields before saving.");
                return;
            }

            MySqlConnection conn = new MySqlConnection(connString);
            string sql = "INSERT INTO appointment(name, date, time, appointmenttype) VALUES (?, ?, ?, ?)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // Prepare parameters
                cmd.Parameters.AddWithValue("name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("date", txtDate.Text.Trim());
                string schedTime = $"{cbHour.Text}:{cbMinute.Text} {cbTimePeriod.Text}";
                cmd.Parameters.AddWithValue("time", schedTime);
                cmd.Parameters.AddWithValue("appointmenttype", cbAppointment.SelectedItem.ToString());

                // Open connection and execute
                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Saved successfully!");
                this.DialogResult = DialogResult.OK; // Notify the calling form
                Close(); // Close the form after successful save
            }
            catch (MySqlException ex)
            {
                // Show the error message once and prevent infinite looping
                //MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"An error occurred: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Dispose resources and close connection
                cmd.Dispose();
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
