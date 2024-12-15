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
            string timePeriod = cbTimePeriod.Text;
            int hour = int.Parse(cbHour.Text);
            int minute = int.Parse(cbMinute.Text);

            Console.WriteLine($"Time: {hour}:{minute} {timePeriod}");

            // Check if the selected time is within the allowed range: 8 AM to 11:59 AM or 12 PM to 5 PM
            bool isValidTime =
              (timePeriod == "AM" && hour >= 8 && hour <= 11) ||
              (timePeriod == "PM" && hour >= 12 && hour <= 5);

            if (!isValidTime)
            {
                MessageBox.Show("Appointments can only be scheduled between 8:00 AM - 11:59 AM and 12:00 PM - 5:00 PM.");
                return; 
            }
            else
            {

                MySqlConnection conn = new MySqlConnection(connString);
                string checkSql = "SELECT COUNT(*) FROM appointment WHERE LOWER(name) = LOWER(?) AND date = ? AND time = ?"; // ignore case
                string insertSql = "INSERT INTO appointment(name, date, time, appointmenttype) VALUES (?, ?, ?, ?)";

                try
                {
                    conn.Open();

                    // checkCmd - to check for duplicate entries
                    MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("name", txtName.Text.Trim());
                    checkCmd.Parameters.AddWithValue("date", txtDate.Text.Trim());
                    string schedTime = $"{cbHour.Text}:{cbMinute.Text} {cbTimePeriod.Text}";
                    checkCmd.Parameters.AddWithValue("time", schedTime);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("This schedule already exists. Please choose a different time or date.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    MySqlCommand insertCmd = new MySqlCommand(insertSql, conn);
                    insertCmd.Parameters.AddWithValue("name", txtName.Text.Trim());
                    insertCmd.Parameters.AddWithValue("date", txtDate.Text.Trim());
                    insertCmd.Parameters.AddWithValue("time", schedTime);
                    insertCmd.Parameters.AddWithValue("appointmenttype", cbAppointment.SelectedItem.ToString());

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Saved successfully!");
                    this.DialogResult = DialogResult.OK; // Notify the calling form
                    insertCmd.Dispose();
                    Close();
                    Calendar mainForm = new Calendar();
                    mainForm.DisplayCalendar(); 
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close(); ;
                    
                }
            }
        }

        private void cbHour_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
