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
        string connString = "server=localhost;user id=root;pwd=admin;database=appointment";
        public Calendar()
        {
            InitializeComponent();
        }

        private void Calendar_Load(object sender, EventArgs e)
        {
            displayDays();
            LoadSchedPanel(); 
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

        public void DisplayCalendar()
        {
            displayDays(); // Call the private method internally
            LoadSchedPanel();
        }


        private void buttonEditSched_Click(object sender, EventArgs e)
        {
            frmEditSched frmEdit = new frmEditSched();
            frmEdit.Show();
        }
        private void btnDeleteSched_Click(object sender, EventArgs e)
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

                
            }
        }

        private void daycontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCalendar();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("Please enter a search term.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string sql = "SELECT name, date, time, appointmenttype " +
                             "FROM appointment " +
                             "WHERE LOWER(name) LIKE @searchQuery " +
                             "   OR LOWER(appointmenttype) LIKE @searchQuery";

                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@searchQuery", $"%{searchQuery.ToLower()}%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Pass results to the new form and display it
                        frmSearchResults resultsForm = new frmSearchResults(dt);
                        resultsForm.ShowDialog(); // Show as a dialog box
                    }
                    else
                    {
                        MessageBox.Show("No results found for the search query.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}\\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        private void LoadSchedPanel()
        {
            string query = "SELECT date, name, appointmenttype FROM appointment WHERE date >= CURDATE() ORDER BY date ASC  "; // Get all future appointments

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear(); // Clear existing controls

                        while (reader.Read())
                        {
                            // Create and configure a card panel for each appointment
                            Panel card = new Panel
                            {
                                Size = new Size(150, 96),
                                BackColor = Color.White,
                                Padding = new Padding(10),
                                Margin = new Padding(5)

                            };

                            // Create and configure Title Label
                            Label titleLabel = new Label
                            {
                                Text = reader["name"].ToString(),
                                Font = new Font("Century Gothic", 12, FontStyle.Bold),
                                ForeColor = Color.Black,
                                Dock = DockStyle.Top
                            };

                            // Create and configure Date Label
                            Label dateLabel = new Label
                            {
                                Text = DateTime.Parse(reader["date"].ToString()).ToString("MMM dd, yyyy"),
                                Font = new Font("Century Gothic", 10),
                                Dock = DockStyle.Top
                            };

                            // Create and configure Appointment Type Label
                            Label typeLabel = new Label
                            {
                                Text = $"Type: {reader["appointmenttype"]}",
                                Font = new Font("Century Gothic", 8),
                                Dock = DockStyle.Top
                            };

                            // Add labels to the panel
                            card.Controls.Add(typeLabel);
                            card.Controls.Add(dateLabel);
                            card.Controls.Add(titleLabel);

                            // Add the card panel to FlowLayoutPanel
                            flowLayoutPanel1.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }



    }
}
