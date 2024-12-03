using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace c__project_proposal
{
    public partial class EventForm : Form
    {
        String connString = "server=localhost;user id=root;pwd=M@xene17;database=appointment";
        
        
        public EventForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = Calendar.static_year + "/" + Calendar.static_month + "/"+UserControlDays.static_day ;
            txtDate.Text = Calendar.static_year + "/" + Calendar.static_month + "/"+UserControlDays.static_day ;

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
                cbAppointment.Items.Add(typeOfAppointment[app]);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "INSERT INTO appointment(name,date,time,appointmenttype)values(?,?,?,?)";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("name", txtName.Text);
            cmd.Parameters.AddWithValue("date",txtDate.Text);
            string schedTime = $"{cbHour.Text}:{cbMinute.Text} {cbTimePeriod.Text}";
            cmd.Parameters.AddWithValue("time", schedTime);
            cmd.Parameters.AddWithValue("appointmenttype",cbAppointment.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");

            cmd.Dispose();
            conn.Close();

            this.DialogResult = DialogResult.OK; // Notify the calling form
            Close();
            
        }
    }
}
