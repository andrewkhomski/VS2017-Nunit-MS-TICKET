using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using System.IO;
using System.Reflection;
using SeleniumTest.Utilities;
//using SeleniumTest.Allergy_Console;
using SeleniumTest.Documents;

namespace SeleniumTest
{
	[TestFixture]
	public class AllergyDocumentTests_Console
	{

		private static Login login;
		private static PatientVisit visit;
		private static PatientDocument patient;
		string patientFName = "Patient";
		string patientMName = "L";
		string patientLName = "Created" + Dates.tAffix();
		private AllergyDocument AllergyDocumentExample;

		[SetUp]
		public void SetupTest()
        {
            Reporting.documentName = "TestSetup";
            login = new Login("Login.csv");
            login.SetupAndLogin();
            patient = new PatientDocument("Patient", "PatientData1.csv");
            patient.CreateSimplePatient();
            visit = new PatientVisit("Patient", "PatientVisit1.csv");
            visit.ScheduleSimpleVisit();
		} // end SetUp()

		[Test]
		//[Category ("")]
		public void TestAddAllergyDocument()
		{
			

			PatientVisit.OpenVisitInPhysicianConsole();

            AllergyDocumentExample = new AllergyDocument("Allergy", "AllergyDocument1.csv", MethodBase.GetCurrentMethod().Name);
			AllergyDocumentExample.OpenEditor();
			AllergyDocumentExample.FillInDocument();
			AllergyDocumentExample.ClickSubmitButton();

            AllergyDocumentExample.OpenViewer();
            AllergyDocumentExample.VerifyViewer();
            AllergyDocumentExample.CloseViewer();

			AllergyDocumentExample.OpenEditor();
			AllergyDocumentExample.VerifyDocument();
			AllergyDocumentExample.UpdateData("AllergyDocument2.csv");
			AllergyDocumentExample.ModifyDocument();
			AllergyDocumentExample.ClickSubmitButton();
			AllergyDocumentExample.OpenEditor();
			AllergyDocumentExample.VerifyModifiedDocument();

            AllergyDocumentExample.OpenViewer();
            AllergyDocumentExample.VerifyViewer();
            AllergyDocumentExample.CloseViewer();

			Reporting.AssertVerificationErrors();
		}

		[TearDown]
		public void TearDownTest()
		{
			
			try
			{
				Browser.Driver.Navigate().GoToUrl(login.GetBaseURL() + "/Calendar/Calendar.aspx");
				PatientVisit.DeleteVisit(login.GetBaseURL());
			}

			catch (Exception)
			{
				Console.WriteLine("Visit could not be deleted.");
			}

			try
			{
				patient.DeletePatient(ref login);
			}

			catch (Exception)
			{
				Console.WriteLine("Patient could not be deleted.");
			}

			Browser.Driver.Quit();
			Reporting.Commit();
		}
	}
}
