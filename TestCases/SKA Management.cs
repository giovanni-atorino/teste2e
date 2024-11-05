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

    public class SKA_Management: BaseClass
	{
		 
		public SKA_Management(Account Account) : base(Account) { }


		public void SKAManagement(Xpath__SKAManagement Xpath, Values__SKAManagement Value )
		{
			try
			{
			// Wait definition for element
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

		    // Verify the presence of menu
			wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
			Console.WriteLine("Verified presence of Menu");

			//Click on Menu
			JSFindElementAndClick(Xpath.Menu, Value.Menu, 1000);

		    //Verify Presence of SKAManagement
			AssertElementIsEqualTo(Xpath.SKAManagement,Value.SKAManagement);

			//Click on SKA Management
			JSFindElementAndClick(Xpath.SKAManagement, Value.SKAManagement, 2000);

		    //Double click on Menu
			JSFindElementAndClick(Xpath.Menu, Value.Menu, 1000);      
			JSFindElementAndClick(Xpath.Menu, Value.Menu, 1000);

			//Verify Presence of title
			AssertElementIsEqualTo(Xpath.ServiceKeyAccountManagerTitle, Value.ServiceKeyAccountManagerTitle);

			//Verify Presence of id column
			AssertElementIsEqualTo(Xpath.Id, Value.Id);
			
			//Verify Presence of Name
			AssertElementIsEqualTo(Xpath.Name, Value.Name);
			
			//Verify Presence of Surname
			AssertElementIsEqualTo(Xpath.Surname, Value.Surname);
			
			//Verify Presence of PhoneNumber
			AssertElementIsEqualTo(Xpath.PhoneNumber, Value.PhoneNumber);
			
			//Verify Presence of Email
			AssertElementIsEqualTo(Xpath.Email, Value.Email);
			
			//Verify Presence of Country
			AssertElementIsEqualTo(Xpath.Country, Value.Country);
			
			//Verify Presence of Active
			AssertElementIsEqualTo(Xpath.Active, Value.Active);
			System.Threading.Thread.Sleep(1000);
			/*
			//Verify Presence of AddSKA Button
			AssertElementIsEqualTo(Xpath.AddSKA, Value.AddSKA, 20);
			//Click on  AddSKA Button
			JSFindElementAndClick(Xpath.AddSKA, Value.AddSKA, 1000);

			//Verify Presence of Country Dropdown
			VerifyPresence(Xpath.CountryDropDown, 20);

			//Click on  AddSKA Button
			Click2(Xpath.ItalyCountry, 1000);
			System.Threading.Thread.Sleep(10000);
			*/

			/*
			//Select Italy 
			Click2(Xpath.ITALYCountry, 1000);
			System.Threading.Thread.Sleep(10000);
			System.Threading.Thread.Sleep(10000);
			*/
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			
			}

		}



	}
}