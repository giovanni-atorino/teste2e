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

    public class Dealer_Management: BaseClass
	{
		 
		public Dealer_Management(Account Account) : base(Account) { }


		public void DealerManagement(Xpath__DealerManagement Xpath, Values__DealerManagement Value )
		{
			try
			{
			// Wait definition for element
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

		    // Verify the presence of menu
			wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
			Console.WriteLine("Verified presence of Menu");

			//Click on Menu + Click on Dealer Management
			OpenSectionMenu(Xpath.Menu, Xpath.DealerManagement, Value.DealerManagement, 1000);

			//Verify Presence of title
			//To remove AssertElementIsEqualTo(Xpath.DealerManagementTitle, Value.DealerManagementTitle);

			//Verify Presence of Name
			AssertElementIsEqualTo(Xpath.Name, Value.Name);

			//Verify Presence of City
			AssertElementIsEqualTo(Xpath.City, Value.City);

			//Verify Presence of Country
			AssertElementIsEqualTo(Xpath.Country, Value.Country);

			//Verify Presence of SapCode
			AssertElementIsEqualTo(Xpath.SapCode, Value.SapCode);

			//Verify Presence of IsHDS
			AssertElementIsEqualTo(Xpath.IsHDS, Value.IsHDS);

			//Verify Presence of SalesPoint
			AssertElementIsEqualTo(Xpath.SalesPoint, Value.SalesPoint);


			//Verify Presence of Parent Dealer ID
			//to remove and fix AssertElementIsEqualTo(Xpath.ParentDealerSapCode, Value.ParentDealerSapCode);

		    //Verify Presence of Range
			//to remove and fix AssertElementIsEqualTo(Xpath.Range, Value.Range);

			//Verify Presence of Fuel
			//to remove and fix AssertElementIsEqualTo(Xpath.Fuel, Value.Fuel);

			//Verify Presence of Active
			AssertElementIsEqualTo(Xpath.Active, Value.Active);


			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			
			}

		}



	}
}