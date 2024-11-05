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

    public class Company_Management: BaseClass
	{
		 
		public Company_Management(Account Account) : base(Account) { }


		public void CompanyManagement(Xpath__CompanyManagement Xpath, Values__CompanyManagement Value )
		{
			try
			{
			// Wait definition for element
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            //Open Menu + Click on Company Management
            OpenSectionMenu(Xpath.Menu, Xpath.CompanyManagement, Value.CompanyManagement, 1000);

			js.ExecuteScript("document.body.style.zoom = '0.40'");
			
			//Verify Presence of title
			AssertElementIsEqualTo(Xpath.CompanyManagementTitle, Value.CompanyManagement);

		    //Verify Presence of CompanyName
		    AssertElementIsEqualTo(Xpath.CompanyName, Value.CompanyName);
		    
		    //Verify Presence of VatNumberEurope
		    AssertElementIsEqualTo(Xpath.VatNumberEurope, Value.VatNumberEurope);
		    
		    //Verify Presence of VatNumberA
		    AssertElementIsEqualTo(Xpath.VatNumberA, Value.VatNumberA);
		    
		    //Verify Presence of VatNumberB
		    AssertElementIsEqualTo(Xpath.VatNumberB, Value.VatNumberB);

			//Verify Presence of Country
			//AssertElementIsEqualTo(Xpath.Country, Value.Country);

			//Verify Presence of Main Account
			AssertElementIsEqualTo(Xpath.MainAccount, Value.MainAccount);

			//Verify Presence of Fleet Manager
			AssertElementIsEqualTo(Xpath.FleetManager, Value.FleetManager);

			//Find country AUSTRIA and click
			ClickDropdownChoice(Xpath.CountryAustria, "AUSTRIA", 1000);

			//Click on Manage Service Accounts
			JSClickDropdownChoice(Xpath.ManageServiceAccountsTooltip, "", 2000);

			//Verify Presence of Account label
			AssertElementIsEqualTo(Xpath.Account, Value.Account);

			//Verify Presence of Name label
			AssertElementIsEqualTo(Xpath.Name, Value.Name);

			//Verify Presence of Phone
			AssertElementIsEqualTo(Xpath.Phone, Value.Phone);

			//Verify Presence of Email
			AssertElementIsEqualTo(Xpath.Email, Value.Email);

			//Verify Presence of Last update
			AssertElementIsEqualTo(Xpath.LastUpdate, Value.LastUpdate);

			//Verify Presence of FleetManagerId
			//AssertElementIsEqualTo(Xpath.FleetManagerId, Value.FleetManagerId);

			//Verify Presence of FleetManagerFirstname
			//AssertElementIsEqualTo(Xpath.FleetManagerFirstname, Value.FleetManagerFirstname);

			//Verify Presence of FleetManagerLastname
			//AssertElementIsEqualTo(Xpath.FleetManagerLastname, Value.FleetManagerLastname);

			//Verify Presence of FleetManagerPhone
			//AssertElementIsEqualTo(Xpath.FleetManagerPhone, Value.FleetManagerPhone);

			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}
	}
}