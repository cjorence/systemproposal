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

namespace c__project_proposal
{
    public partial class UserControlDays : UserControl
    {
        String connString = "server=localhost;user id=root;pwd=admin;database=appointment";
        public static string static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            //displayEventInBox();

        }
        public void days(int numday)
        {
            lblDays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lblDays.Text;
            //start timer when clicked
            timer1.Start();
            EventForm eventform = new EventForm ();
            eventform.Show();
        }

        private void displayEventInBox() 
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                String sql = "SELECT * FROM appointment where date = ?";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("date", Calendar.static_year + "/" + Calendar.static_month + "/" + lblDays.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lbAppointment.Text = reader["appointment"].ToString();
                }
                //reader.DisposeAsync();
                reader.Dispose();
                cmd.Dispose();
                conn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
    private void timer1_Tick_1(object sender, EventArgs e) //timer for auto display if new event is added
        {
            displayEventInBox();    
        }
    }
}
