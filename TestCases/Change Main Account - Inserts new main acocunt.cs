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

	public class Change_Main_Account : BaseClass
	{

		static string countryName_changeFleetManager = NUnit.Framework.TestContext.Parameters["countryName_changeFleetManager"].ToString();
		static string countryId_changeFleetManager = NUnit.Framework.TestContext.Parameters["countryId_changeFleetManager"].ToString();
		static string companyName_changeFleetManager = NUnit.Framework.TestContext.Parameters["companyName_changeFleetManager"].ToString();
		public Change_Main_Account(Account Account) : base(Account) { }


		public void ChangeMainAccountInsertsNewMA(Xpath__ChangeMainAccount Xpath, Values__ChangeMainAccount Value)
		{
			//try
			//{
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

                //click on Change MAIN ACCOUNT tooltip for the first row
                JSClickDropdownChoice(Xpath.ChangeMainAccountTooltip, "", 3000);

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.ChangeMainAccountTitle, Value.ChangeMainAccountTitle);

                //Verify Presence of MAIN ACCOUNT Label
                AssertElementIsEqualTo(Xpath.MainAccountLabel, Value.MainAccountLabel);

				//Click on modify icon
				JSClickDropdownChoice(Xpath.EditMAicon, "", 500);

                //Take the data of the current MAIN ACCOUNT
                String OldMAEmail = RetrieveAttribute(Xpath.AccountMainAccount);
				String OldMALanguage = RetrieveAttribute(Xpath.LanguageMainAccount);
				String OldMAPrefix = RetrieveAttribute(Xpath.PrefixMainAccount);
				String OldMAPhone = RetrieveAttribute(Xpath.PhoneMainAccount);
				String OldMAName = RetrieveAttribute(Xpath.NameMainAccount);
				String OldMASurname = RetrieveAttribute(Xpath.SurnameMainAccount);

				List<string> CurrentMA = new List<string>(new string[] { OldMAEmail, OldMALanguage, OldMAPrefix, OldMAPhone, OldMAName, OldMASurname });
				Random rnd = new Random();
				String RandomInt = (rnd.Next(9999)).ToString();
				String NewAccountNotRegisteredEmail = "TestAutomationChangeMA" + RandomInt + "@yopmail.com";

				List<string> NewMA = new List<string>(new string[] { NewAccountNotRegisteredEmail, Value.LanguageNewMainAccount, Value.NewPrefixNotRegisteredEmail, Value.NewPhoneNotRegisteredEmail, Value.NewNameNotRegisteredEmail, Value.NewSurnameNotRegisteredEmail });
				List<List<string>> MA = new List<List<string>>(new List<string>[] { NewMA, CurrentMA });
				int ii = 0;
				foreach (List<string> MAData in MA)
				{
					if (ii != 0)  // the first time the user is already on the section 
					{
						//Click on modify icon
						JSClickDropdownChoice(Xpath.EditMAicon, "", 1000);
					}
					else
					{
						Console.WriteLine("Change main account section already opened");
					}
					{
						//Verify Presence of title
						AssertElementIsEqualTo(Xpath.ChangeMainAccountTitle, Value.ChangeMainAccountTitle);

						//Verify Presence of Master Fleet Manager Label
						AssertElementIsEqualTo(Xpath.MainAccountLabel, Value.MainAccountLabel);

						//Click on modify icon
						JSClickDropdownChoice(Xpath.EditMAicon, "", 500);

						//Verify Presence of new account and insert a regitered email 
						ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewMAfield, "[id=input]", MAData[0]);

						//Click on Search
						JSClickDropdownChoice(Xpath.SearchButton, "", 1000);

                        try  //CASE MAIN ACCOUNT NOT REGISTERED 
                        {
							InsertsNewMANotRegistered(Xpath, Value, MAData);
						}
						catch
						{
							//CASE MAIN ACCOUNT REGISTERED 
							InsertsNewMARegistered(Xpath, Value, MAData);
						}
						//click on SAVE button
						JSFindElementAndClick(Xpath.SaveButton, Value.SaveButton, 1000);

					//Click on yes to confirm change MA
					JSClickDropdownChoice(Xpath.YesConfirmButton, Value.YesConfirmButton, 3000);

                    //Verify successful pop-up
                    AssertElementIsEqualTo(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

					//Close successull pop-up
					ExpandShadowElementClickNew(Xpath.Xbutton, "button[class='pfe-modal__close']", "Close Button");
                    //ExpandShadowElementAndClick("pfe-modal", 12, "[class='pfe-modal__close']");
                    System.Threading.Thread.Sleep(2000);
                    ii++;

                }
				}
			/*}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}*/
		}

		public void InsertsNewMANotRegistered(Xpath__ChangeMainAccount Xpath, Values__ChangeMainAccount Value, List<string> MAData)
		{
			//CASE FLEET MANGER NOT REGISTERED 
			//Verify Email language enabled
			VerifyElement(Xpath.LanguageDropDownEnabled);
			Console.WriteLine("The Main Account " + MAData[0] + " inserted is not registered");
			//Click on Search
			ClickDropdownChoice("//*[@id='pfe-select']/option[contains (text(),'" + MAData[1] + "')]", MAData[1], 1000);

			//Expand prefix for Phone number
			JSClickDropdownChoice(Xpath.SelectPrefixArrow, "Arrow clicked", 500);
			JSClickDropdownChoice(Xpath.NewPrefix + MAData[2] + "')]", MAData[2], 500);

			//Verify phone enabled 
			AssertElementIsEqualTo(Xpath.PhoneEnabled, Value.PhoneNewMainAccount);

			//Verify Presence of new phone and insert a phone
			ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewPhoneField, "[id=input]", MAData[3]);

			//Verify name enabled 
			AssertElementIsEqualTo(Xpath.NameEnabled, Value.NameNewMainAccount);

			//Verify Presence of new name and insert it
			ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewNameField, "[id=input]", MAData[4]);

			//Verify surname enabled 
			AssertElementIsEqualTo(Xpath.SurnameEnabled, Value.SurnameNewMainAccount);

			//Verify Presence of new surname and insert it
			ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewSurnameField, "[id=input]", MAData[5]);
		}

		public void InsertsNewMARegistered(Xpath__ChangeMainAccount Xpath, Values__ChangeMainAccount Value, List<string> MAData)
		{
			//CASE FLEET MANGER REGISTERED 
			VerifyElement(Xpath.LanguageDropDownDisabled);
			VerifyElement(Xpath.NameDisabled);
			VerifyElement(Xpath.SurnameDisabled);
			Console.WriteLine("The Main Account " + MAData[0] + " inserted is registered");
			//Check on the phone
			try
			//PHONE not PRESENT 
			{
				VerifyElement(Xpath.PhoneEnabled);
				//Verify phone enabled MainAccountFleetManager);

				//Verify Presence of new phone and insert a phone
				ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewPhoneField, "[id=input]", MAData[3]);
			}
			catch
			{
				VerifyElement(Xpath.PhoneDisabled);
			}
		}


        public void ChangeMainAccountInsertsSameMA(Xpath__ChangeMainAccount Xpath, Values__ChangeMainAccount Value)
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

                //click on Change Main Account tooltip for the first row
                JSClickDropdownChoice(Xpath.ChangeMainAccountTooltip, "", 2000);

                //Verify Presence of title
                AssertElementIsEqualTo(Xpath.ChangeMainAccountTitle, Value.ChangeMainAccountTitle);

                //Verify Presence of Main Account Label
                AssertElementIsEqualTo(Xpath.MainAccountLabel, Value.MainAccountLabel);

                //Click on modify icon
                JSClickDropdownChoice(Xpath.EditMAicon, "", 1000);

                //Take the email of the current Main Account
                String OldMainAccount = RetrieveAttribute(Xpath.AccountMainAccount);

                //Verify Presence of new account and insert the old Main Account
                ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewMAfield, "[id=input]", OldMainAccount);

                //Click on Search
                JSClickDropdownChoice(Xpath.SearchButton, "", 2000);

                //Verify error pop-up for the same Main Account
                VerifyElement(Xpath.ErrorPopUpSameMA);
                Console.WriteLine("Verified presence of " + Value.ErrorPopUpSameMA);




            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);

            }

        }

        public void ChangeMainAccountNotRegisteredUser(Xpath__ChangeMainAccount Xpath, Values__ChangeMainAccount Value)
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
				JSClickDropdownChoice(Xpath.ChangeMainAccountTooltip, "", 1000);

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.ChangeMainAccountTitle, Value.ChangeMainAccountTitle);

				//Verify Presence of Master Fleet Manager Label
				AssertElementIsEqualTo(Xpath.MainAccountLabel, Value.MainAccountLabel);

				//Click on modify icon
				JSClickDropdownChoice(Xpath.EditMAicon, "", 1000);

				//Verify Presence of new account and insert a regitered email 
				ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewMAfield, "[id=input]", Value.NewAccountNotRegisteredEmail2);
				
				//Click on Search
				JSClickDropdownChoice(Xpath.SearchButton, "", 2000);

				//Verify Email language disabled
				VerifyElement(Xpath.LanguageDropDownEnabled);

				//Verify phone disabled 
				AssertElementIsEqualTo(Xpath.PhoneEnabled, Value.PhoneNewMainAccount);

				//Verify name disabled 
				AssertElementIsEqualTo(Xpath.NameEnabled, Value.NameNewMainAccount);

				//Verify surname disabled 
				AssertElementIsEqualTo(Xpath.SurnameEnabled, Value.SurnameNewMainAccount);


			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);

			}

		}

		public void ChangeMainAccountRegisteredUser(Xpath__ChangeMainAccount Xpath, Values__ChangeMainAccount Value)
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
				JSClickDropdownChoice(Xpath.ChangeMainAccountTooltip, "", 1000);

				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.ChangeMainAccountTitle, Value.ChangeMainAccountTitle);

				//Verify Presence of Master Fleet Manager Label
				AssertElementIsEqualTo(Xpath.MainAccountLabel, Value.MainAccountLabel);

				//Click on modify icon
				JSClickDropdownChoice(Xpath.EditMAicon, "", 100);

				//Verify Presence of new account and insert a regitered email 
				ExpandShadowElementClickClearAndSendKeysNew(Xpath.NewMAfield, "[id=input]", Value.NewAccountRegisteredEmail);

				//Click on Search
				JSClickDropdownChoice(Xpath.SearchButton, "", 2000);

				//Verify Email language disabled
				VerifyElement(Xpath.LanguageDropDownDisabled);

				//Verify name disabled 
				AssertElementIsEqualTo(Xpath.NameDisabled, Value.NameNewMainAccount);

				//Verify surname disabled 
				AssertElementIsEqualTo(Xpath.SurnameDisabled, Value.SurnameNewMainAccount);


			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);

			}

		}



	}

}

