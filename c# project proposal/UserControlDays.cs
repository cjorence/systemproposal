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
    public partial class UserControlDays : UserControl
    {
        String connString = "server=localhost;user id=root;pwd=admin;database=dbevent;";
        public static string static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        public void days(int numday)
        {
            lblDays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lblDays.Text;
            timer1.Start();
            EventForm eventform = new EventForm ();
            eventform.Show();
        }

        private void displayEvent()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "SELECT * FROM event where date = ?";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date",Calendar.static_year + "/" + Calendar.static_month + "/" +lblDays.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblEvent.Text = reader["event"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }
    }
}
