using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SMARTCHART
{
    public partial class PatientHub : Form
    {
        // creating a list for form grid so we can edit and update patients in the future.
        private BindingList<Patients> patients = new BindingList<Patients>();

        //making sure to look at the project directory.
        private readonly string filePath = Path.Combine(Application.StartupPath,"patients.json");

        // creating objects to log actions in the patient hub.
        private AppUser currentUser;
        private LogManager logManager = new LogManager();

        public PatientHub(AppUser user)
        {
            InitializeComponent();
            currentUser = user;
            LoadPatients();
        }

        private void btnMainHub_Click(object sender, EventArgs e)
        {
            var mainHub = Application.OpenForms.OfType<MainHub>().FirstOrDefault();
            if (mainHub != null)
            {
                mainHub.Show();
                this.Close();
            }
        }

        private void LoadPatients()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    List<Patients> loadedPatients = JsonConvert.DeserializeObject<List<Patients>>(json) ?? new List<Patients>();

                    patients = new BindingList<Patients>(loadedPatients);
                }
                else
                {
                    patients = new BindingList<Patients>();
                }

                PatientGrid.AutoGenerateColumns = true;
                PatientGrid.DataSource = null;
                PatientGrid.DataSource = patients;

                //MessageBox.Show("Patients loaded: " + patients.Count); debugging purposes.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load patients: " + ex.Message);
            }
        }

        private void SavePatients()
        {
            File.WriteAllText(filePath,JsonConvert.SerializeObject(patients, Formatting.Indented));
        }

        private void btnRegPatient_Click(object sender, EventArgs e)
        {// Prompt the user for patient information using input boxes, then we store it into a .json file.
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter patient's name:", "Register Patient");
            if (string.IsNullOrWhiteSpace(name)) return;

            string LastName = Microsoft.VisualBasic.Interaction.InputBox("Enter last name:", "Register Patient");
            if (string.IsNullOrWhiteSpace(LastName)) return;

            string Address = Microsoft.VisualBasic.Interaction.InputBox("Enter address:", "Register Patient");
            if (string.IsNullOrWhiteSpace(Address)) return;

            string PhoneNumber = Microsoft.VisualBasic.Interaction.InputBox("Enter phone number:", "Register Patient");
            if (string.IsNullOrWhiteSpace(PhoneNumber)) return;

            string insuredInput = Microsoft.VisualBasic.Interaction.InputBox("Is the patient insured? (yes/no):", "Register Patient");
            if (insuredInput.Equals("Yes") || insuredInput.Equals("yes") || insuredInput.Equals("Y") || insuredInput.Equals("y")){}
            else if (insuredInput.Equals("No") || insuredInput.Equals("no") || insuredInput.Equals("N") || insuredInput.Equals("n")){}
            else
            {
                MessageBox.Show("Invalid input for insurance status. Please enter 'yes' or 'no'.");
                return;
            }

            string dobInput = Microsoft.VisualBasic.Interaction.InputBox("Enter date of birth (MM/DD/YYYY):", "Register Patient");
            if (!DateTime.TryParse(dobInput, out DateTime DOB)) //small expection that tries to parse bod.
            {
                MessageBox.Show("Invalid input for date of birth. Please enter a valid date (MM/DD/YYYY).");
                return;
            }
            // created a patient object using json we store the info below.
            var patient = new Patients
            {
                Name = name.Trim(),
                LastName = LastName.Trim(),
                Address = Address.Trim(),
                PhoneNumber = PhoneNumber.Trim(),
                Insured = insuredInput.Equals("Yes") || insuredInput.Equals("yes") || insuredInput.Equals("Y") || insuredInput.Equals("y"),
                DateOfBirth = DOB.Date
            };

            // Throwing an exception if the file doesn't exist or not in correct file path.
            try
            {
                patients.Add(patient);
                SavePatients();

                logManager.AddLog(currentUser.Name, "Registered patient", patient.Id);

                LoadPatients();

                MessageBox.Show("Patient registered successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving patient data: {ex.Message}");
            }
        }

        private void btnUpdPatient_Click(object sender, EventArgs e)
        {
            if (PatientGrid.CurrentRow == null)
            {
                MessageBox.Show("Select a patient first.");
                return;
            }

            Patients patient = PatientGrid.CurrentRow.DataBoundItem as Patients;

            if (patient == null)
            {
                MessageBox.Show("Could not read the selected patient.");
                return;
            }

            string name = Microsoft.VisualBasic.Interaction.InputBox("First name:", "Edit Patient", patient.Name);
            if (string.IsNullOrWhiteSpace(name)) return;

            string lastName = Microsoft.VisualBasic.Interaction.InputBox("Last name:", "Edit Patient", patient.LastName);
            if (string.IsNullOrWhiteSpace(lastName)) return;

            string address = Microsoft.VisualBasic.Interaction.InputBox("Address:", "Edit Patient", patient.Address);
            if (string.IsNullOrWhiteSpace(address)) return;

            string phoneNumber = Microsoft.VisualBasic.Interaction.InputBox("Phone number:", "Edit Patient", patient.PhoneNumber);
            if (string.IsNullOrWhiteSpace(phoneNumber)) return;

            string insuredInput = Microsoft.VisualBasic.Interaction.InputBox("Is the patient insured? Enter yes or no:","Edit Patient",
                patient.Insured ? "yes" : "no");

            bool insured;
            if (insuredInput.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                insuredInput.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                insured = true;
            }
            else if (insuredInput.Equals("no", StringComparison.OrdinalIgnoreCase) ||
                     insuredInput.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                insured = false;
            }
            else
            {
                MessageBox.Show("Enter yes or no for insurance status.");
                return;
            }

            string dobInput = Microsoft.VisualBasic.Interaction.InputBox("Date of birth (MM/DD/YYYY):","Edit Patient",
                patient.DateOfBirth.ToString("MM/dd/yyyy"));

            DateTime dob;
            if (!DateTime.TryParse(dobInput, out dob))
            {
                MessageBox.Show("Enter a valid date of birth.");
                return;
            }

            patient.Name = name.Trim();
            patient.LastName = lastName.Trim();
            patient.Address = address.Trim();
            patient.PhoneNumber = phoneNumber.Trim();
            patient.Insured = insured;
            patient.DateOfBirth = dob.Date;

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.WriteAllText(filePath,JsonConvert.SerializeObject(patients, Formatting.Indented));
                LoadPatients();
                MessageBox.Show("Patient updated and saved.");
                logManager.AddLog(currentUser.Name, "Updated patient", patient.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the patient: " + ex.Message);
            }
        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            // Check if a row is selected and not blank.
            if (PatientGrid.CurrentRow == null)
            {
                MessageBox.Show("Select a patient first.");
                return;
            }

            // Get the selected patient that isn't blank.
            Patients patient = PatientGrid.CurrentRow.DataBoundItem as Patients;
            if (patient == null)
            {
                MessageBox.Show("Could not read the selected patient.");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {patient.Name} {patient.LastName}?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    patients.Remove(patient);

                    SavePatients();
                    logManager.AddLog(currentUser.Name, "Deleted patient", patient.Id);
                    LoadPatients();

                    MessageBox.Show("Patient deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not delete patient: " + ex.Message);
                }
            }
        }

        private void SearchPatients()
        {
            string searchText = txtSearchPatient.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadPatients();
                return;
            }

            // Find matching patients. Contains() didn't work. Had to use IndexOf.
            var filteredPatients = patients
                .Where(p =>
                    p.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.LastName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.PhoneNumber.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.Id.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            // Display matching patients.
            PatientGrid.DataSource = null;
            PatientGrid.DataSource = filteredPatients;

            if (filteredPatients.Count == 0)
            {
                MessageBox.Show("No matching patients found.");
            }
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            SearchPatients();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchPatient.Clear();

            PatientGrid.DataSource = null;
            PatientGrid.DataSource = patients;
        }
    }
}
