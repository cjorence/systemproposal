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
        String connString = "server=localhost;user id=root;pwd=admin;database=dbevent";
        
        
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "INSERT INTO event(date,event)values(?,?)";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date",txtDate.Text);
            cmd.Parameters.AddWithValue("event",txtEvent.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");
            cmd.Dispose();
            conn.Close();
        }
    }
}
