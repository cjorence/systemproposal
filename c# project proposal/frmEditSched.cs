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
        SqlConnection con = new SqlConnection(@"");
        String connString = "server=localhost;user id=root;pwd=admin;database=appointment";

        public frmEditSched()
        {
            InitializeComponent();

        }

        private void dataGridViewAllSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }



        //private void cbKeyTBEdited_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbKeyTBEdited.SelectedValue == null)
        //    {
        //        MessageBox.Show("Please select a record to edit.");
        //        return;
        //    }

        //    int selectedKey = Convert.ToInt32(cbKeyTBEdited.SelectedValue);

        //    // Filter the DataTable to find the record with the matching "Number Key"
        //    DataRow[] selectedRows = ((DataTable)cbKeyTBEdited.DataSource).Select($"[Number Key] = {selectedKey}");
        //    if (selectedRows.Length > 0)
        //    {
        //        DataRow selectedRow = selectedRows[0];
        //        textBoxName.Text = selectedRow["name"].ToString();
        //        dateTimePickerDate.Value = Convert.ToDateTime(selectedRow["date"]);
        //        string[] timeParts = selectedRow["time"].ToString().Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //        cbHour.Text = timeParts[0];
        //        cbMinute.Text = timeParts[1];
        //        cbTimePeriod.Text = timeParts[2];
        //        comboBoxAppointmentType.SelectedItem = selectedRow["appointmenttype"].ToString();


        //    }
        //}
    }
}
