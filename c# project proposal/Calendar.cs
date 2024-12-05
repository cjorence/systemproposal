using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c__project_proposal
{
    public partial class Calendar : Form
    {
        int month, year;

        public static int static_month, static_year;
        public Calendar()
        {
            InitializeComponent();
        }

        private void Calendar_Load(object sender, EventArgs e)
        {
            displayDays();
            LoadRecentDates();
        }


        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblDate.Text = monthname + " " + year;

            static_month = month;
            static_year = year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);
            int daysoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) +1;
            
            for(int i = 1; i < daysoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            for(int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }


        private void buttonEditSched_Click(object sender, EventArgs e)
        {
            frmEditSched frmEdit = new frmEditSched();
            frmEdit.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            month--;

            if (month < 1) // Wrap around to December and decrement year
            {
                month = 12;
                year--;
            }

            static_month = month;
            static_year = year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblDate.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);
            int daysoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < daysoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonRstSched_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connString = "server=localhost;user id=root;pwd=admin;database=appointment";

            // Confirmation message before deletion
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete all data? This action cannot be undone.",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();

                        // Disable safe update mode for this session
                        string disableSafeUpdate = "SET SQL_SAFE_UPDATES = 0;";
                        MySqlCommand disableCmd = new MySqlCommand(disableSafeUpdate, conn);
                        disableCmd.ExecuteNonQuery();

                        // Delete all records from the database
                        string deleteQuery = "DELETE FROM appointment";
                        MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        // Notify user of success and rows deleted
                        MessageBox.Show(
                            rowsAffected + " record(s) deleted successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Re-enable safe update mode (optional, to restore original state)
                        string enableSafeUpdate = "SET SQL_SAFE_UPDATES = 1;";
                        MySqlCommand enableCmd = new MySqlCommand(enableSafeUpdate, conn);
                        enableCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Notify user of any errors
                        MessageBox.Show(
                            "An error occurred while deleting records: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }
                }

                // Clear the listbox
                listBoxRecentDates.Items.Clear();
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            month++;
            if (month > 12) // Wrap around to January and increment year
            {
                month = 1;
                year++;
            }
            static_month = month;
            static_year = year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblDate.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);
            int daysoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < daysoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays); 
            }
        }
        private void LoadRecentDates() //for listBox
        {
            listBoxRecentDates.Items.Clear(); // Clear previous items
            string connString = "server=localhost;user id=root;pwd=admin;database=appointment";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT date, name, appointmenttype FROM appointment WHERE date >= CURDATE() ORDER BY date ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string date = Convert.ToDateTime(reader["date"]).ToString("yyyy-MM-dd");
                        string name = reader["name"].ToString();
                        string appointmentType = reader["appointmenttype"].ToString(); 
                        listBoxRecentDates.Items.Add($"{appointmentType}  ");
                        listBoxRecentDates.Items.Add($"{date} - {name}");
                        listBoxRecentDates.Items.Add(""); 
                    }
                }
            }
        }


    }
}
