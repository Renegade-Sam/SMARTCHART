using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMARTCHART;

namespace SMARTCHART.UnitTests
{
    [TestClass]
    public class CreatePatientTests
    {
        [TestMethod]
        public void CreatePatient_ValidInputs_ReturnsTrue()
        {
            // Arrange
            string name = "John";
            string lastName = "Smith";
            string address = "123 Main Street";
            string phoneNumber = "1234567890";
            string insuredInput = "yes";
            string dobInput = "05/15/1990";

            // Act
            bool result = PatientHub.CreatePatient(
                name,
                lastName,
                address,
                phoneNumber,
                insuredInput,
                dobInput,
                out Patients patient,
                out string error);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(patient);
            Assert.IsNull(error);

            Assert.AreEqual("John", patient.Name);
            Assert.AreEqual("Smith", patient.LastName);
            Assert.AreEqual("123 Main Street", patient.Address);
            Assert.AreEqual("1234567890", patient.PhoneNumber);
            Assert.IsTrue(patient.Insured);
            Assert.AreEqual(
                new System.DateTime(1990, 5, 15),
                patient.DateOfBirth);
        }
        // TEST 2: Missing name
        [TestMethod]
        public void CreatePatient_EmptyName_ReturnsFalse()
        {
            // Act
            bool result = PatientHub.CreatePatient(
                "",
                "Smith",
                "123 Main Street",
                "1234567890",
                "yes",
                "05/15/1990",
                out Patients patient,
                out string error);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(patient);
            Assert.AreEqual("Name is required.", error);
        }

        // TEST 3: Missing last name
        [TestMethod]
        public void CreatePatient_EmptyLastName_ReturnsFalse()
        {
            bool result = PatientHub.CreatePatient(
                "John",
                "",
                "123 Main Street",
                "1234567890",
                "yes",
                "05/15/1990",
                out Patients patient,
                out string error);

            Assert.IsFalse(result);
            Assert.IsNull(patient);
            Assert.AreEqual("Last name is required.", error);
        }

        // TEST 4: Missing address
        [TestMethod]
        public void CreatePatient_EmptyAddress_ReturnsFalse()
        {
            bool result = PatientHub.CreatePatient(
                "John",
                "Smith",
                "",
                "1234567890",
                "yes",
                "05/15/1990",
                out Patients patient,
                out string error);

            Assert.IsFalse(result);
            Assert.IsNull(patient);
            Assert.AreEqual("Address is required.", error);
        }

        // TEST 5: Missing phone number
        [TestMethod]
        public void CreatePatient_EmptyPhoneNumber_ReturnsFalse()
        {
            bool result = PatientHub.CreatePatient(
                "John",
                "Smith",
                "123 Main Street",
                "",
                "yes",
                "05/15/1990",
                out Patients patient,
                out string error);

            Assert.IsFalse(result);
            Assert.IsNull(patient);
            Assert.AreEqual("Phone number is required.", error);
        }

        // TEST 6: Invalid insurance input
        [TestMethod]
        public void CreatePatient_InvalidInsurance_ReturnsFalse()
        {
            bool result = PatientHub.CreatePatient(
                "John",
                "Smith",
                "123 Main Street",
                "1234567890",
                "maybe",
                "05/15/1990",
                out Patients patient,
                out string error);

            Assert.IsFalse(result);
            Assert.IsNull(patient);
            Assert.AreEqual(
                "Insurance must be yes or no.",
                error);
        }

        // TEST 7: Invalid date of birth
        [TestMethod]
        public void CreatePatient_InvalidDateOfBirth_ReturnsFalse()
        {
            bool result = PatientHub.CreatePatient(
                "John",
                "Smith",
                "123 Main Street",
                "1234567890",
                "yes",
                "1990-05-15",
                out Patients patient,
                out string error);

            Assert.IsFalse(result);
            Assert.IsNull(patient);
            Assert.AreEqual(
                "Date of birth must be in MM/DD/YYYY format.",
                error);
        }

        // TEST 8: Accept insurance input "no"
        [TestMethod]
        public void CreatePatient_NotInsured_ReturnsFalseInsuranceStatus()
        {
            bool result = PatientHub.CreatePatient(
                "John",
                "Smith",
                "123 Main Street",
                "1234567890",
                "no",
                "05/15/1990",
                out Patients patient,
                out string error);

            Assert.IsTrue(result);
            Assert.IsNotNull(patient);
            Assert.IsFalse(patient.Insured);
            Assert.IsNull(error);
        }

        // TEST 9: Trim whitespace from inputs
        [TestMethod]
        public void CreatePatient_InputsWithWhitespace_TrimsValues()
        {
            bool result = PatientHub.CreatePatient(
                " John ",
                " Smith ",
                " 123 Main Street ",
                " 1234567890 ",
                " YES ",
                "05/15/1990",
                out Patients patient,
                out string error);

            Assert.IsTrue(result);
            Assert.AreEqual("John", patient.Name);
            Assert.AreEqual("Smith", patient.LastName);
            Assert.AreEqual("123 Main Street", patient.Address);
            Assert.AreEqual("1234567890", patient.PhoneNumber);
            Assert.IsTrue(patient.Insured);
            Assert.IsNull(error);
        }
    }
}
