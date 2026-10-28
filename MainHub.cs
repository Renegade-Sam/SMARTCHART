using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTCHART
{
    public partial class MainHub : Form
    {
        public MainHub()
        {
            InitializeComponent();
        }

        private void btnPatientHub_Click(object sender, EventArgs e)
        {
            var patientHub = new PatientHub();
            patientHub.FormClosed += (s, args) => Show();
            patientHub.Show();
            this.Hide();
        }

        private void btnLogsHub_Click(object sender, EventArgs e)
        {
            var logsHub = new LogsHub();
            logsHub.FormClosed += (s, args) => Show();
            logsHub.Show();
            this.Hide();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tutorial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the SMARTCHART application! This application allows you to manage patient records and view logs." + 
                " Use the 'Patient Hub' button to access patient information and the 'Logs Hub' button to view system logs.",
                " Click 'Quit' to exit the application.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
