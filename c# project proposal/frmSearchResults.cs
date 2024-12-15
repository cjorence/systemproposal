using MySqlX.XDevAPI.Common;
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
    public partial class frmSearchResults : Form
    {
        public frmSearchResults(DataTable results)
        {
            InitializeComponent();
            dataGridViewResults.DataSource = results;
        }
    }
}
