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
                "General check-up",
                "Physical examination (annual physical)",
                "Pediatric consultation",
                "Immunization/vaccination",
                "Prenatal check-up",
                "Postnatal check-up",
                "Blood pressure monitoring",
                "Diabetes management consultation",
                "Cholesterol check-up",
                "Weight management consultation",
                "Allergy testing or consultation",
                "Eye examination",
                "Ear, nose, and throat (ENT) consultation",
                "Dental check-up",
                "Skin consultation (dermatology)",
                "Cardiologist consultation (heart health)",
                "Gastroenterology consultation (digestive health)",
                "Orthopedic consultation (bones and joints)",
                "Physiotherapy session",
                "Mental health counseling (psychologist/psychiatrist)",
                "Gynecological consultation (e.g., Pap smear)",
                "Family planning consultation",
                "Blood work or laboratory tests",
                "Ultrasound or imaging appointment",
                "Vaccine booster shots",
                "Follow-up appointment for chronic conditions",
                "Flu or cold treatment",
                "COVID-19 testing or follow-up",
                "Minor wound care or dressing change",
                "Prescription refill or medication review"
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

            // Extract hour and time period (AM/PM)
            int hour = int.Parse(cbHour.Text);
            string timePeriod = cbTimePeriod.Text;

            // Check if the selected time is within the allowed range: 8 AM to 11:59 AM or 12 PM to 5 PM
            //bool isValidTime = (timePeriod == "AM" && hour >= 8 && hour <= 11) ||
            //       (timePeriod == "PM" && hour >= 12 && hour <= 5);

            //if (!isValidTime)
            //{
            //    MessageBox.Show("Appointments can only be scheduled between 8:00 AM - 11:59 AM and 12:00 PM - 5:00 PM.");
            //    return;
            //}


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
