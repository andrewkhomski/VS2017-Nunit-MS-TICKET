using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumTest.Utilities;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SeleniumTest.Documents
{
	class AllergyDocument:DocumentBase
	{
		private static Hashtable Data;
        private static String updateDocName;

		// Constructor to store all the data from the file specified (fileName).
        public AllergyDocument(String documentName, String fileName, String testName)
        {
            Data = FileReader.ReadGenericPathData(documentName, fileName);

            updateDocName = documentName;
			Reporting.testName = testName;
			Reporting.documentName = this.GetType().Name;
        } // end Constructor

        // Updates the stored data according to the fileName specified.
        public override void UpdateData(String fileName)
        {
            Data = FileReader.UpdateGenericPathData(updateDocName, fileName);
        }

		// Fill in the document according to the data stored for each field.
		public override void FillInDocument()
		{
            EnterFieldValue.EnterTextField(AllergyFields.ALLERGY0_TEXT_FIELD, (String)Data["ALLERGY0_TEXT_FIELD"]);
			EnterFieldValue.EnterTextField(AllergyFields.REACTION0_TEXT_FIELD, (String)Data["REACTION0_TEXT_FIELD"]);
            EnterFieldValue.EnterAllergySevModMildRadioButton(AllergyFields.D_SEVER_RADIO_BUTTON, (String)Data["D_SEVER_RADIO_BUTTON"]);
            EnterFieldValue.EnterLabeledRadioButton(AllergyFields.D_YE_RADIO_BUTTON, (String)Data["D_YE_RADIO_BUTTON"]);
			EnterFieldValue.EnterTextField(AllergyFields.DT_ACTIVE_DATE0_TEXT_FIELD, (String)Data["DT_ACTIVE_DATE0_TEXT_FIELD"]);
			EnterFieldValue.EnterTextField(AllergyFields.NOTES_TEXT_AREA, (String)Data["NOTES_TEXT_AREA"]);
		}// end FillInDocument()

		// Fill in the document according to the data stored for each field.
		public override void ModifyDocument()
		{
            EnterFieldValue.EnterTextField(AllergyFields.ALLERGY0_TEXT_FIELD, (String)Data["ALLERGY0_TEXT_FIELD"]);
			EnterFieldValue.EnterTextField(AllergyFields.REACTION0_TEXT_FIELD, (String)Data["REACTION0_TEXT_FIELD"]);
            EnterFieldValue.EnterAllergySevModMildRadioButton(AllergyFields.D_SEVER_RADIO_BUTTON, (String)Data["D_SEVER_RADIO_BUTTON"]);
            EnterFieldValue.EnterLabeledRadioButton(AllergyFields.D_YE_RADIO_BUTTON, (String)Data["D_YE_RADIO_BUTTON"]);
			EnterFieldValue.EnterTextField(AllergyFields.DT_ACTIVE_DATE0_TEXT_FIELD, (String)Data["DT_ACTIVE_DATE0_TEXT_FIELD"]);
			EnterFieldValue.EnterTextField(AllergyFields.NOTES_TEXT_AREA, (String)Data["NOTES_TEXT_AREA"]);
		}// end FillInDocument()

		// Verify the contents of the document editor according to specified data.
		public override void VerifyDocument()
		{
            AssertionItems.VerifyTextField(AllergyFields.ALLERGY0_TEXT_FIELD, (String)Data["ALLERGY0_TEXT_FIELD"]);
			AssertionItems.VerifyTextField(AllergyFields.REACTION0_TEXT_FIELD, (String)Data["REACTION0_TEXT_FIELD"]);
            AssertionItems.VerifyAllergySevModMildRadioButton(AllergyFields.D_SEVER_RADIO_BUTTON, (String)Data["D_SEVER_RADIO_BUTTON"]);
            AssertionItems.VerifyLabeledRadioButton(AllergyFields.D_YE_RADIO_BUTTON, (String)Data["D_YE_RADIO_BUTTON"]);
			AssertionItems.VerifyTextField(AllergyFields.DT_ACTIVE_DATE0_TEXT_FIELD, (String)Data["DT_ACTIVE_DATE0_TEXT_FIELD"]);
			AssertionItems.VerifyTextField(AllergyFields.NOTES_TEXT_AREA, (String)Data["NOTES_TEXT_AREA"]);
		}

		// Verify the contents of the document editor according to specified data.
		public override void VerifyModifiedDocument()
		{
            AssertionItems.VerifyTextField(AllergyFields.ALLERGY0_TEXT_FIELD, (String)Data["ALLERGY0_TEXT_FIELD"]);
			AssertionItems.VerifyTextField(AllergyFields.REACTION0_TEXT_FIELD, (String)Data["REACTION0_TEXT_FIELD"]);
            AssertionItems.VerifyAllergySevModMildRadioButton(AllergyFields.D_SEVER_RADIO_BUTTON, (String)Data["D_SEVER_RADIO_BUTTON"]);
            AssertionItems.VerifyLabeledRadioButton(AllergyFields.D_YE_RADIO_BUTTON, (String)Data["D_YE_RADIO_BUTTON"]);
			AssertionItems.VerifyTextField(AllergyFields.DT_ACTIVE_DATE0_TEXT_FIELD, (String)Data["DT_ACTIVE_DATE0_TEXT_FIELD"]);
			AssertionItems.VerifyTextField(AllergyFields.NOTES_TEXT_AREA, (String)Data["NOTES_TEXT_AREA"]);
		}

		// Verify the contents of the document editor according to specified data.
		public override void VerifyViewer()
		{
		} // end VerifyViewer()

		// will open the document editor
		public override void OpenEditor()
		{
			/* NEED TO PUT THE NAME OF THE DOCUMENT IN THE EMPTY STRING*/
            EnterFieldValue.OpenEditor("Allrgy", "Allergy List ");
		}

		// will click the Submit button
		public override void ClickSubmitButton()
		{
			EnterFieldValue.ClickConsoleSubmitButton();
            Browser.Driver.Sleep(1);
            if (Browser.Driver.FindElement(By.XPath(".//button[contains(@onclick, 'ContinueAllergyListSubmission')]")).Displayed)
            {
                Browser.Driver.FindElement(By.XPath(".//button[contains(@onclick, 'ContinueAllergyListSubmission')]")).Click();
            }
		}

		// will open the document viewer
		public override void OpenViewer()
		{
			/* NEED TO PUT THE NAME OF THE DOCUMENT IN THE EMPTY STRING*/
            EnterFieldValue.OpenConsoleViewer("Allrgy");
		}

		// will close the viewer
		public override void CloseViewer()
		{
			EnterFieldValue.ClickCloseViewer();
			WindowNavigation.ReturnToWindow();
		}// end CloseViewer()

	}
}
