using myiveco_selenium.Functions;
using myiveco_selenium.Xpath;
using myiveco_selenium.Values;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Chrome;
using System.Windows;
using myiveco_selenium.Filters;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;




namespace myiveco_selenium
{

	public class Change_Fleet_Manager : BaseClass
	{

		static string countryName_changeFleetManager = NUnit.Framework.TestContext.Parameters["countryName_changeFleetManager"].ToString();
		static string countryId_changeFleetManager = NUnit.Framework.TestContext.Parameters["countryId_changeFleetManager"].ToString();
		static string companyName_changeFleetManager = NUnit.Framework.TestContext.Parameters["companyName_changeFleetManager"].ToString();
		public Change_Fleet_Manager(Account Account) : base(Account) { }


		public void ChangeFleetManagerInsertsNewMFM(Xpath__ChangeFleetManager Xpath, Values__ChangeFleetManager Value)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				// Verify the presence of menu
				wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
				Console.WriteLine("Verified presence of Menu");

                //Click on Menu + Click on Company Management
                OpenSectionMenu(Xpath.Menu, Xpath.CompanyManagement, Value.CompanyManagement, 1000);
				
				js.ExecuteScript("document.body.style.zoom = '0.40'");

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.CompanyManagementTitle, Value.CompanyManagement);

				//Find country used and click
				ClickDropdownChoice("//*[@id='pfe-select-1']/*[@value='"+ countryId_changeFleetManager + "']", countryName_changeFleetManager, 2000);

				//Filter column for drivers ID in order to find the element
				JSClickDropdownChoice(Xpath.FilterForCompanyNameColumn, "Filter for Company Name",1000 ) ;

				wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TextBoxForCompanyName)));
				driver.FindElement(By.XPath(Xpath.TextBoxForCompanyName)).SendKeys(companyName_changeFleetManager);
				System.Threading.Thread.Sleep(1000);

				//Click on Apply
				JSClickDropdownChoice(Xpath.ApplyButton, "Xpath.ApplyButton", 3000);

				//click on Change Fleet Manager tooltip for the first row
				JSClickDropdownChoice(Xpath.ChangeFleetManagerTooltip, "", 3000);

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.ChangeFleetManagerTitle, Value.ChangeFleetManagerTitle);

				//Verify Presence of Master Fleet Manager Label
				AssertElementIsEqualTo(Xpath.MasterFleetManagerLabel, Value.MasterFleetManagerLabel);

				//Click on modify icon
				JSClickDropdownChoice(Xpath.EditMFMIcon, "", 500);

				//Take the data of the current master fleet manager 
				String OldMFMEmail = RetrieveAttribute(Xpath.AccountFleetManager);
				String OldMFMLanguage = RetrieveAttribute(Xpath.LanguageFleetManager); // to be managed 
				String OldMFMPrefix = RetrieveAttribute(Xpath.PrefixFleetManager);
				String OldMFMPhone = RetrieveAttribute(Xpath.PhoneFleetManager);
				String OldMFMName = RetrieveAttribute(Xpath.NameFleetManager);
				String OldMFMSurname = RetrieveAttribute(Xpath.SurnameFleetManager);

				List<string> CurrentMFM = new List<string>(new string[] { OldMFMEmail, OldMFMLanguage, OldMFMPrefix, OldMFMPhone, OldMFMName, OldMFMSurname });
				Random rnd = new Random();
				String RandomInt = (rnd.Next(9999)).ToString();
				String NewAccountNotRegisteredEmail = "TestAutomationChangeMFM" + RandomInt + "@yopmail.com";

				List<string> NewMFM = new List<string>(new string[] { NewAccountNotRegisteredEmail, Value.LanguageNewFleetManager, Value.NewPrefixNotRegisteredEmail, Value.NewPhoneNotRegisteredEmail, Value.NewNameNotRegisteredEmail, Value.NewSurnameNotRegisteredEmail });
				List<List<string>> MFM = new List<List<string>>(new List<string>[] { NewMFM, CurrentMFM });
				int ii = 0;
				foreach (List<string> MFMData in MFM)
				{
					if (ii != 0)  // the first time the user is already on the section 
					{
						//Click on modify icon
						JSClickDropdownChoice(Xpath.EditMFMIcon, "", 1000);
					}
					else
					{
						Console.WriteLine("Change fleet manager section already opened");
					}
					{
						//Verify Presence of title
						AssertElementIsEqualTo(Xpath.ChangeFleetManagerTitle, Value.ChangeFleetManagerTitle);

						//Verify Presence of Master Fleet Manager Label
						AssertElementIsEqualTo(Xpath.MasterFleetManagerLabel, Value.MasterFleetManagerLabel);

						//Click on modify icon
						JSClickDropdownChoice(Xpath.EditMFMIcon, "", 500);

						//Verify Presence of new account and insert a regitered email 
						ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewMfmField, "[id=input]", MFMData[0]);

						//Click on Search
						JSClickDropdownChoice(Xpath.SearchButton, "", 1000);

						try  //CASE FLEET MANGER NOT REGISTERED 
						{
							InsertsNewMFMNotRegistered(Xpath, Value, MFMData);
						}
						catch
						{
							//CASE FLEET MANGER REGISTERED 
							InsertsNewMFMRegistered(Xpath, Value, MFMData);
						}
						//click on SAVE button
						JSFindElementAndClick(Xpath.SaveButton, Value.SaveButton, 1000);

					//Click on yes to confirm change MFM
					JSClickDropdownChoice(Xpath.YesConfirmButton, Value.YesConfirmButton, 4000);

					//Verify successful pop-up
					AssertElementIsEqualTo(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Close successull pop-up
                    ExpandShadowElementClickNew(Xpath.Xbutton, "button[class='pfe-modal__close']", "Close Button");
                    System.Threading.Thread.Sleep(2000);
					ii++;


					}
				}
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}

		public void InsertsNewMFMNotRegistered(Xpath__ChangeFleetManager Xpath, Values__ChangeFleetManager Value, List<string> MFMData)
		{
			//CASE FLEET MANGER NOT REGISTERED 
			//Verify Email language enabled
			VerifyElement(Xpath.LanguageDropDownEnabled);
			Console.WriteLine("The fleet manager " + MFMData[0] + " inserted is not registered");
			//Click on Search
			ClickDropdownChoice("//*[@id='pfe-select']/option[contains (text(),'" + MFMData[1] + "')]", MFMData[1], 1000);

			//Expand prefix for Phone number
			JSClickDropdownChoice(Xpath.SelectPrefixArrow, "Arrow clicked", 500);
			JSClickDropdownChoice(Xpath.NewPrefix + MFMData[2] + "')]", MFMData[2], 500);

			//Verify phone enabled 
			AssertElementIsEqualTo(Xpath.PhoneEnabled, Value.PhoneNewFleetManager);

			//Verify Presence of new phone and insert a phone
			ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewPhoneField, "[id=input]", MFMData[3]);

			//Verify name enabled 
			AssertElementIsEqualTo(Xpath.NameEnabled, Value.NameNewFleetManager);

			//Verify Presence of new name and insert it
			ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewNameField, "[id=input]", MFMData[4]);

			//Verify surname enabled 
			AssertElementIsEqualTo(Xpath.SurnameEnabled, Value.SurnameNewFleetManager);

			//Verify Presence of new surname and insert it
			ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewSurnameField, "[id=input]", MFMData[5]);
		}

		public void InsertsNewMFMRegistered(Xpath__ChangeFleetManager Xpath, Values__ChangeFleetManager Value, List<string> MFMData)
		{
			//CASE FLEET MANGER REGISTERED 
			VerifyElement(Xpath.LanguageDropDownDisabled);
			VerifyElement(Xpath.NameDisabled);
			VerifyElement(Xpath.SurnameDisabled);
			Console.WriteLine("The fleet manager " + MFMData[0] + " inserted is registered");
			//Check on the phone
			try
			//PHONE not PRESENT 
			{
				VerifyElement(Xpath.PhoneEnabled);
				//Verify phone enabled 
				AssertElementIsEqualTo(Xpath.PhoneEnabled, Value.PhoneNewFleetManager);

				//Verify Presence of new phone and insert a phone
				ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewPhoneField, "[id=input]", MFMData[3]);
			}
			catch
			{
				VerifyElement(Xpath.PhoneDisabled);
			}
		}


		public void ChangeFleetManagerInsertsSameMFM(Xpath__ChangeFleetManager Xpath, Values__ChangeFleetManager Value)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				// Verify the presence of menu
				wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
				Console.WriteLine("Verified presence of Menu");

                //Click on Menu + Click on Company Management
                OpenSectionMenu(Xpath.Menu, Xpath.CompanyManagement, Value.CompanyManagement, 1000);

				js.ExecuteScript("document.body.style.zoom = '0.40'");

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.CompanyManagementTitle, Value.CompanyManagement);

				//Find country AUSTRIA and click
				ClickDropdownChoice(Xpath.CountryAustria, "AUSTRIA", 2000);

				//click on Change Fleet Manager tooltip for the first row
				JSClickDropdownChoice(Xpath.ChangeFleetManagerTooltip, "", 2000);

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.ChangeFleetManagerTitle, Value.ChangeFleetManagerTitle);

				//Verify Presence of Master Fleet Manager Label
				AssertElementIsEqualTo(Xpath.MasterFleetManagerLabel, Value.MasterFleetManagerLabel);

				//Click on modify icon
				JSClickDropdownChoice(Xpath.EditMFMIcon, "", 1000);

				//Take the email of the current master fleet manager 
				String OldMasterFleetManager = RetrieveAttribute(Xpath.AccountFleetManager);

				//Verify Presence of new account and insert the old master fleet manager
				ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewMfmField, "[id=input]", OldMasterFleetManager);

				//Click on Search
				JSClickDropdownChoice(Xpath.SearchButton, "", 2000);

				//Verify error pop-up for the same mfm
				VerifyElement(Xpath.ErrorPopUpSameMFM);
				Console.WriteLine("Verified presence of " + Value.ErrorPopUpSameMFM);




			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);

			}

		}

		public void ChangeFleetManagerNotRegisteredUser(Xpath__ChangeFleetManager Xpath, Values__ChangeFleetManager Value)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				// Verify the presence of menu
				wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
				Console.WriteLine("Verified presence of Menu");

                //Click on Menu + Click on Company Management
                OpenSectionMenu(Xpath.Menu, Xpath.CompanyManagement, Value.CompanyManagement, 1000);

                js.ExecuteScript("document.body.style.zoom = '0.40'");

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.CompanyManagementTitle, Value.CompanyManagement);

				//Find country AUSTRIA and click
				ClickDropdownChoice(Xpath.CountryAustria, "AUSTRIA", 1000);

				//click on Change Fleet Manager tooltip for the first row
				JSClickDropdownChoice(Xpath.ChangeFleetManagerTooltip, "", 1000);

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.ChangeFleetManagerTitle, Value.ChangeFleetManagerTitle);

				//Verify Presence of Master Fleet Manager Label
				AssertElementIsEqualTo(Xpath.MasterFleetManagerLabel, Value.MasterFleetManagerLabel);

				//Click on modify icon
				JSClickDropdownChoice(Xpath.EditMFMIcon, "", 1000);

				//Verify Presence of new account and insert a regitered email 
				ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewMfmField, "[id=input]", Value.NewAccountNotRegisteredEmail2);
				
				//Click on Search
				JSClickDropdownChoice(Xpath.SearchButton, "", 2000);

				//Verify Email language disabled
				VerifyElement(Xpath.LanguageDropDownEnabled);

				//Verify phone disabled 
				AssertElementIsEqualTo(Xpath.PhoneEnabled, Value.PhoneNewFleetManager);

				//Verify name disabled 
				AssertElementIsEqualTo(Xpath.NameEnabled, Value.NameNewFleetManager);

				//Verify surname disabled 
				AssertElementIsEqualTo(Xpath.SurnameEnabled, Value.SurnameNewFleetManager);


			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);

			}

		}

		public void ChangeFleetManagerRegisteredUser(Xpath__ChangeFleetManager Xpath, Values__ChangeFleetManager Value)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				// Verify the presence of menu
				wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
				Console.WriteLine("Verified presence of Menu");

                //Click on Menu + Click on Company Management
                OpenSectionMenu(Xpath.Menu, Xpath.CompanyManagement, Value.CompanyManagement, 1000);

                js.ExecuteScript("document.body.style.zoom = '0.40'");

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.CompanyManagementTitle, Value.CompanyManagement);

				//Find country AUSTRIA and click
				ClickDropdownChoice(Xpath.CountryAustria, "AUSTRIA", 1000);

				//click on Change Fleet Manager tooltip for the first row
				JSClickDropdownChoice(Xpath.ChangeFleetManagerTooltip, "", 1000);

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.ChangeFleetManagerTitle, Value.ChangeFleetManagerTitle);

				//Verify Presence of Master Fleet Manager Label
				AssertElementIsEqualTo(Xpath.MasterFleetManagerLabel, Value.MasterFleetManagerLabel);

				//Click on modify icon
				JSClickDropdownChoice(Xpath.EditMFMIcon, "", 100);

				//Verify Presence of new account and insert a regitered email 
				ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewMfmField, "[id=input]", Value.NewAccountRegisteredEmail);

				//Click on Search
				JSClickDropdownChoice(Xpath.SearchButton, "", 2000);

				//Verify Email language disabled
				VerifyElement(Xpath.LanguageDropDownDisabled);

				//Verify phone disabled 
				//AssertElementIsEqualTo(Xpath.PhoneDisabled, Value.PhoneNewFleetManager); //phone can be enabled even if the user is not registered

				//Verify name disabled 
				AssertElementIsEqualTo(Xpath.NameDisabled, Value.NameNewFleetManager);

				//Verify surname disabled 
				AssertElementIsEqualTo(Xpath.SurnameDisabled, Value.SurnameNewFleetManager);


			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);

			}

		}



	}

}

