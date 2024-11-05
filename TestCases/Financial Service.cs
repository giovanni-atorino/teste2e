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

	public class Financial_Service : BaseClass
	{

		public Financial_Service(Account Account) : base(Account) { }


		public void FinancialService(Xpath__FinancialService Xpath, Values__FinancialService Value)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

				// Verify the presence of menu
				wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
				Console.WriteLine("Verified presence of Menu");

                System.Threading.Thread.Sleep(1000);

                //Click on Menu + Click on Invoice Management
                OpenSectionMenu(Xpath.Menu, Xpath.InvoicesManagement, Value.InvoicesManagement, 1000);

				//Verify Presence of title Invoices Management
				AssertElementIsEqualTo(Xpath.InvoicesManagementTitle, Value.InvoicesManagementTitle);

				//Verify Presence of Legal entity
				AssertElementIsEqualTo(Xpath.LegalEntity, Value.LegalEntity);

				//Verify Presence of Creditor
				AssertElementIsEqualTo(Xpath.Creditor, Value.Creditor);

				//Verify Presence of Invoice number
				AssertElementIsEqualTo(Xpath.InvoiceNumber, Value.InvoiceNumber);

				//Verify Presence of Invoice date
				AssertElementIsEqualTo(Xpath.InvoiceDate, Value.InvoiceDate);

				//Verify Presence of Due date
				AssertElementIsEqualTo(Xpath.DueDate, Value.DueDate);

				//Verify Presence of Sign
				AssertElementIsEqualTo(Xpath.Sign, Value.Sign);

				//Verify Presence of Currency
				AssertElementIsEqualTo(Xpath.Currency, Value.Currency);

				//Verify Presence of TotalAmount
				AssertElementIsEqualTo(Xpath.TotalAmount, Value.TotalAmount);

				//Verify Presence of OutstandingAmount 
				AssertElementIsEqualTo(Xpath.OutstandingAmount, Value.OutstandingAmount);

				//Verify Presence of Asset
				AssertElementIsEqualTo(Xpath.Asset, Value.Asset);

				//Verify Presence of Status
				AssertElementIsEqualTo(Xpath.Status, Value.Status);

				//Verify Presence of PaymentDate
				AssertElementIsEqualTo(Xpath.PaymentDate, Value.PaymentDate);

			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);

			}

		}

		public void DirectX(Xpath__FinancialService Xpath, Values__FinancialService Value)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				// Verify the presence of menu
				wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
				Console.WriteLine("Verified presence of Menu");

                //Click on Menu + Click on Invoice Management
                OpenSectionMenu(Xpath.Menu, Xpath.InvoicesManagement, Value.InvoicesManagement, 1000);

                //Verify Presence of title Invoices Management
                AssertElementIsEqualTo(Xpath.InvoicesManagementTitle, Value.InvoicesManagementTitle);
				
				//Reduce the zooom
				js.ExecuteScript("document.body.style.zoom = '0.30'");

				//Verify and click on 
				JSFindElementAndClick(Xpath.DirectXButton, Value.DirectXButton, 3000);

				// Switch to window
				driver.SwitchTo().Window(driver.WindowHandles.Last());


				//Veriy the correct opening of direct x
				VerifyElement(Xpath.LogoDirectX);

			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);

			}

		}

		public void FinancialServiceFilters(Xpath__FinancialService Xpath, Values__FinancialService Value)
		{
			try
			{
                //Click on Menu + Click on Invoice Management
                OpenSectionMenu(Xpath.Menu, Xpath.InvoicesManagement, Value.InvoicesManagement, 1000);

                //Verify Presence of title Invoices Management
                AssertElementIsEqualTo(Xpath.InvoicesManagementTitle, Value.InvoicesManagementTitle);

				//Filter OPEN INVOICES
				JSFindElementAndClick(Xpath.OPENIVOICESButton, Value.OPENIVOICESButton, 2000);
				
				/* 
					for (int ii=0; ii<15; ii++)
					{
					int linepresence;
                       try
				       {
						linepresence = 0;
						VerifyElement("//*[@id='invoicesListTable']//div[@row-index='" + ii.ToString() + "']//span[@aria-colindex='11']/span");
					   }
					   catch
					   {
						linepresence = 1;
					   }

					   if (linepresence==0)
					   {
						AssertElementIsEqualTo("//*[@id='invoicesListTable']//div[@row-index='"+ ii.ToString() + "']//span[@aria-colindex='11']/span", Value.OPEN);
					   }

					   else
				       {
						Console.WriteLine("The line " + ii.ToString() + " is not present");
						ii = 15;
				       }
			     	}


			*/



			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);

			}

		}

	}
}