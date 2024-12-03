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

namespace c__project_proposal
{
    public partial class frmEditSched : Form
    {
        String connString = "server=localhost;user id=root;pwd=M@xene17;database=appointment";

        public frmEditSched()
        {
            InitializeComponent();

        }

        private void dataGridViewAllSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        
        //private void LoadData() //method
        //{
        //    // Replace with your actual MySQL connection details
            
            
        //}

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

                        // Rearrange columns to match desired DataGridView structure
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

            for (int hr = 01; hr <= 12; hr++)
            {
                cbHour.Items.Add(hr);
            }
            for (int min = 01; min <= 59; min++)
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

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            string schedTime = $"{cbHour.Text}:{cbMinute.Text} {cbTimePeriod.Text}";
            // Validate input
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(dateTimePickerDate.Text) ||
                string.IsNullOrWhiteSpace(schedTime) ||
                comboBoxAppointmentType.SelectedItem == null)
            {
                MessageBox.Show("Please complete all fields before saving.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = @"UPDATE appointment 
                                 SET name = @name, date = @date, time = @time, appointment = @appointment 
                                 WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePickerDate.Text);
                cmd.Parameters.AddWithValue("@time", schedTime);
                cmd.Parameters.AddWithValue("@appointment", comboBoxAppointmentType.SelectedItem.ToString());
                //cmd.Parameters.AddWithValue("@id", scheduleId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Schedule updated successfully!");
                this.Close(); // Close the form after saving
            }
        }

        private void cbKeyTBEdited_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
