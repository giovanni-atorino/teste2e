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


namespace myiveco_selenium
{

    public class Change_Main_Account_Section : BaseClass
	{
		 
		public Change_Main_Account_Section(Account Account) : base(Account) { }


		public void ChangeMainAccount(Xpath__ChangeMainAccount Xpath, Values__ChangeMainAccount Value )
		{
			try
			{
			// Wait definition for element
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

		    // Verify the presence of menu
			wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
			Console.WriteLine("Verified presence of Menu");

            //Click on Menu + CompanyManagement
            OpenSectionMenu(Xpath.Menu, Xpath.CompanyManagement, Value.CompanyManagement, 1000);

			js.ExecuteScript("document.body.style.zoom = '0.40'");
			
			//Verify Presence of title
			AssertElementIsEqualTo(Xpath.CompanyManagementTitle, Value.CompanyManagement);

			//Find country AUSTRIA and click
			ClickDropdownChoice(Xpath.CountryAustria, "AUSTRIA", 1000);

			//click on Change Fleet Manager tooltip for the first row
			JSClickDropdownChoice(Xpath.ChangeMainAccountTooltip, "", 3000);

			//Verify Presence of title
			AssertElementIsEqualTo(Xpath.ChangeMainAccountTitle, Value.ChangeMainAccountTitle);
	
			//Verify Presence of Company
			AssertElementIsEqualTo(Xpath.Company, Value.Company);

			//Verify Presence of VAT label
			AssertElementIsEqualTo(Xpath.VATnumber, Value.VATnumber);

			//Verify Presence of Main Account Label
			AssertElementIsEqualTo(Xpath.MainAccountLabel, Value.MainAccountLabel);
				
			//Verify Presence of Master Fleet Manager Label
			AssertElementIsEqualTo(Xpath.MasterFleetManagerLabel, Value.MasterFleetManagerLabel);

			//Click on modify icon
			JSClickDropdownChoice(Xpath.EditMAicon, "", 2000);

			//Verify  Presence of TITLE Main Account: Account Change
			AssertElementIsEqualTo(Xpath.PopupMainChange, Value.PopupMainChange);

            //Verify Presence of NameMainAccount label
            AssertElementIsEqualTo(Xpath.NameMainAccount, Value.NameMainAccount);

            //Verify Presence of NameMainAccount label
            AssertElementIsEqualTo(Xpath.NameMainAccount, Value.NameMainAccount);

            //Verify Presence of SurnameMainAccount
            AssertElementIsEqualTo(Xpath.SurnameMainAccount, Value.SurnameMainAccount);

			//Verify Presence of Account
			AssertElementIsEqualTo(Xpath.AccountMainAccount, Value.AccountMainAccount);

			//Verify Presence of Prefix
			AssertElementIsEqualTo(Xpath.PrefixMainAccount, Value.PrefixMainAccount);

            //Verify Presence of Phone NumberPhoneMainAccount
            AssertElementIsEqualTo(Xpath.PhoneMainAccount, Value.PhoneMainAccount);

            //Verify Presence of Language MainAccount
            AssertElementIsEqualTo(Xpath.LanguageMainAccount, Value.LanguageMainAccount);
			
			//Verify Presence of Change in Title
			AssertElementIsEqualTo(Xpath.ChangeInTitle, Value.ChangeInTitle);
			
		    //Verify Presence of new account
			AssertElementIsEqualTo(Xpath.NewAccount, Value.NewAccountMandatory);
	
		    //Verify Presence of Currently Service active
			AssertElementIsEqualTo(Xpath.CurrentlyActiveServicesTitle, Value.CurrentlyActiveServicesTitle);


			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			
			}
		}
	}
}