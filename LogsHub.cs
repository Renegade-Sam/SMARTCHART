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
    public partial class LogsHub : Form
    {
        private AppUser currentUser;
        private LogManager logManager = new LogManager();
        public LogsHub(AppUser user)
        {
            InitializeComponent();
            currentUser = user;
            lblCurrentUser.Text = "Logged in as: " + currentUser.Name;
            LoadLogs();
        }

        private void LoadLogs()
        {
            try
            {
                var logs = logManager.LoadLogs();

                LogsGrid.AutoGenerateColumns = true;
                LogsGrid.ReadOnly = true;
                LogsGrid.AllowUserToAddRows = false;
                LogsGrid.AllowUserToDeleteRows = false;
                LogsGrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

                LogsGrid.DataSource = null;

                LogsGrid.DataSource = logs
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load logs: " + ex.Message);
            }
        }

        private void btnLmainHub_Click(object sender, EventArgs e)
        {
            var mainHub = Application.OpenForms.OfType<MainHub>().FirstOrDefault();
            if (mainHub != null)
            {
                mainHub.Show();
                this.Close();
            }
        }

        private void lblCurrentUser_Click(object sender, EventArgs e)
        {

        }

        private void LogsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
