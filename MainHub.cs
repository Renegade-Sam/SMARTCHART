using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SMARTCHART
{
    public partial class MainHub : Form
    {
        public AppUser CurrentUser { get; private set; }
        public MainHub()
        {
            InitializeComponent();
            GetUserName();
        }

        private void btnPatientHub_Click(object sender, EventArgs e)
        {
            PatientHub patientHub = new PatientHub(CurrentUser);
            patientHub.Show();
            this.Hide();
        }

        private void btnLogsHub_Click(object sender, EventArgs e)
        {
            LogsHub logsHub = new LogsHub(CurrentUser);
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

        private void GetUserName()
        {
            string userName;

            do
            {
                userName = Microsoft.VisualBasic.Interaction.InputBox("Please enter your name:","SMARTCHART - User Identification");

                if (string.IsNullOrWhiteSpace(userName))
                {
                    MessageBox.Show("You must enter your name to access SMARTCHART.","Name Required",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }

            } while (string.IsNullOrWhiteSpace(userName));

            CurrentUser = new AppUser(userName.Trim());

            MessageBox.Show(
                $"Welcome to SMARTCHART, {CurrentUser.Name}!",
                "Welcome",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
