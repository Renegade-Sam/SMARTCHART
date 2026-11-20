using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SMARTCHART.UnitTests")]

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
            string directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(filePath,JsonConvert.SerializeObject(patients, Formatting.Indented));
        }

        internal static bool CreatePatient(
            string name,
            string lastName,
            string address,
            string phoneNumber,
            string insuredInput,
            string dobInput,
            out Patients patient,
            out string error)
        {
            patient = null;
            error = null;

            if (string.IsNullOrWhiteSpace(name))
                return Fail("Name is required.", out error);

            if (string.IsNullOrWhiteSpace(lastName))
                return Fail("Last name is required.", out error);

            if (string.IsNullOrWhiteSpace(address))
                return Fail("Address is required.", out error);

            if (string.IsNullOrWhiteSpace(phoneNumber))
                return Fail("Phone number is required.", out error);

            if (!ParseInsurance(insuredInput, out bool insured))
                return Fail("Insurance must be yes or no.", out error);

            if (!DateTime.TryParseExact(
                    dobInput,
                    "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime dob))
            {
                return Fail(
                    "Date of birth must be in MM/DD/YYYY format.",
                    out error);
            }

            patient = new Patients
            {
                Name = name.Trim(),
                LastName = lastName.Trim(),
                Address = address.Trim(),
                PhoneNumber = phoneNumber.Trim(),
                Insured = insured,
                DateOfBirth = dob.Date
            };

            return true;
        }

        private static bool ParseInsurance(string input, out bool insured)
        {
            string value = input?.Trim() ?? "";

            if (value.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                insured = true;
                return true;
            }

            if (value.Equals("no", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                insured = false;
                return true;
            }

            insured = false;
            return false;
        }

        private static bool Fail(string message, out string error)
        {
            error = message;
            return false;
        }
        //Method Refactored to use PatientRegistration method for better separation of concerns and maintainability.
        private void btnRegPatient_Click(object sender, EventArgs e)
        {// Prompt the user for patient information.
            string name = Microsoft.VisualBasic.Interaction.InputBox(
         "Enter patient's name:", "Register Patient");

            string lastName = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter last name:", "Register Patient");

            string address = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter address:", "Register Patient");

            string phoneNumber = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter phone number:", "Register Patient");

            string insuredInput = Microsoft.VisualBasic.Interaction.InputBox(
                "Is the patient insured? (yes/no):", "Register Patient");

            string dobInput = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter date of birth (MM/DD/YYYY):", "Register Patient");


            if (!CreatePatient(
                    name,
                    lastName,
                    address,
                    phoneNumber,
                    insuredInput,
                    dobInput,
                    out Patients patient,
                    out string error))
            {
                MessageBox.Show(error);
                return;
            }

            try
            {
                patients.Add(patient);
                SavePatients();

                logManager.AddLog(
                    currentUser.Name,
                    $"Registered patient: {patient.Name} {patient.LastName}",
                    patient.Id);

                LoadPatients();

                MessageBox.Show("Patient registered successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while saving patient data: {ex.Message}");
            }
        }
       
        private bool EditPatientField(Patients patient, out string updatedField, out string oldValue, out string newValue)
        {
            updatedField = "";
            oldValue = "";
            newValue = "";


            string field = Microsoft.VisualBasic.Interaction.InputBox("Which field to edit?\n" + 
                "Enter: first name, last name, address, phone number, insurance, or date of birth(dob)", 
                "edit patient");

            if (string.IsNullOrEmpty(field))
                return false;

            switch (field.Trim().ToLowerInvariant()) 
            {
                case "first name":
                case "name":
                    oldValue = patient.Name ?? "";
                    string name = Microsoft.VisualBasic.Interaction.InputBox("First name:", "Edit Patient", oldValue);

                    if (string.IsNullOrWhiteSpace(name)) return false;

                    newValue = name.Trim();
                    patient.Name = newValue;
                    updatedField = "First Name";
                    return true;

                case "last name":
                    oldValue = patient.LastName ?? "";
                    string lastName = Microsoft.VisualBasic.Interaction.InputBox("Last name:", "Edit Patient", oldValue);

                    if (string.IsNullOrWhiteSpace(lastName)) return false;

                    newValue = lastName.Trim();
                    patient.LastName = newValue;
                    updatedField = "Last Name";
                    return true;

                case "address":
                    oldValue = patient.Address ?? "";
                    string address = Microsoft.VisualBasic.Interaction.InputBox("Address:", "Edit Patient", oldValue);
                    if (string.IsNullOrWhiteSpace(address)) return false;
                    
                    newValue = address.Trim();
                    patient.Address = newValue;
                    updatedField = "Address";
                    return true;    

                case "phone number":
                    oldValue = patient.PhoneNumber ?? "";
                    string phoneNumber = Microsoft.VisualBasic.Interaction.InputBox("Phone number:", "Edit Patient", oldValue);
                    if (string.IsNullOrWhiteSpace(phoneNumber)) return false;
                    
                    newValue = phoneNumber.Trim();
                    patient.PhoneNumber = newValue;
                    updatedField = "Phone Number";
                    return true;

                case "insurance status":
                case "insurance":
                case "insured":

                    oldValue = patient.Insured ? "Yes" : "No";

                    string answer = Microsoft.VisualBasic.Interaction.InputBox("Is the patient insured? Enter yes or no:", 
                        "Edit Patient", 
                        oldValue);

                    if (answer.Equals("yes", StringComparison.OrdinalIgnoreCase) || answer.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        patient.Insured = true;
                        newValue = "Yes";
                    }
                    else if (answer.Equals("no", StringComparison.OrdinalIgnoreCase) || answer.Equals("n", StringComparison.OrdinalIgnoreCase))
                    {
                        patient.Insured = false;
                        newValue = "No";
                    }
                    else
                    {
                        MessageBox.Show("Enter yes or no.");
                        return false;
                    }

                    updatedField = "Insurance Status";
                    return true;

                case "date of birth":
                case "dob":

                    oldValue = patient.DateOfBirth.ToString("MM/dd/yyyy");

                    string dobInput = Microsoft.VisualBasic.Interaction.InputBox("Date of birth (MM/DD/YYYY):",
                        "Edit Patient", oldValue);

                    if (!DateTime.TryParse(dobInput, out DateTime dob))
                    {
                        MessageBox.Show("Enter a valid date of birth.");
                        return false;
                    }

                    patient.DateOfBirth = dob.Date;
                    newValue = patient.DateOfBirth.ToString("MM/dd/yyyy");
                    updatedField = "Date of Birth";
                    return true;

                default:
                    MessageBox.Show("Choose one of listed fields.");
                    return false;
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

            //Prompt for method and edit the selected field.
            if (!EditPatientField(patient, out string updatedField, out string oldValue, out string newValue))
                return;

            // Save the updated patient list and log the action.
            try
            {
                SavePatients();
                LoadPatients();
                logManager.AddLog(currentUser.Name, $"Updated patient field: {updatedField}: '{oldValue}' -> '{newValue}'", patient.Id);
                MessageBox.Show("Patient updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update patient: " + ex.Message);
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

        private void PatientHub_Load(object sender, EventArgs e)
        {

        }
    }
}
