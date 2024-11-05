using myiveco_selenium.Functions;
using myiveco_selenium.Xpath;
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

    public class Advanced_Filters_Multi_Contracts: Basic_Test
	{
		static string multi_country_truck_diesel = TestContext.Parameters["multi_country_truck_diesel"].ToString();
		static string multi_company_truck_diesel_name_1 = TestContext.Parameters["multi_company_truck_diesel_name_1"].ToString();
        static string multi_company_truck_diesel_id_1 = TestContext.Parameters["multi_company_truck_diesel_id_1"].ToString();
		static string multi_contract_truck_diesel_id_1 = TestContext.Parameters["multi_contract_truck_diesel_id_1"].ToString();
		static string multi_company_truck_diesel_name_2 = TestContext.Parameters["multi_company_truck_diesel_name_2"].ToString();
		static string multi_company_truck_diesel_id_2 = TestContext.Parameters["multi_company_truck_diesel_id_2"].ToString();
		
		static string multi_country_truck_NP = TestContext.Parameters["multi_country_truck_NP"].ToString();
		static string multi_company_truck_NP_name = TestContext.Parameters["multi_company_truck_NP_name"].ToString();
		static string multi_company_truck_NP_id = TestContext.Parameters["multi_company_truck_NP_id"].ToString();
		static string multi_contract_truck_NP_id = TestContext.Parameters["multi_contract_truck_NP_id"].ToString();

		static string multi_country_light_diesel = TestContext.Parameters["multi_country_light_diesel"].ToString();
		static string multi_company_light_diesel_name = TestContext.Parameters["multi_company_light_diesel_name"].ToString();
		static string multi_company_light_diesel_id = TestContext.Parameters["multi_company_light_diesel_id"].ToString();
		static string multi_contract_light_diesel_id = TestContext.Parameters["multi_contract_light_diesel_id"].ToString();

		static string multi_country_light_NP = TestContext.Parameters["multi_country_light_NP"].ToString();
		static string multi_company_light_NP_name = TestContext.Parameters["multi_company_light_NP_name"].ToString();
		static string multi_company_light_NP_id = TestContext.Parameters["multi_company_light_NP_id"].ToString();
		static string multi_contract_light_NP_id = TestContext.Parameters["multi_contract_light_NP_id"].ToString();

		static string multi_country_heavybus_diesel = TestContext.Parameters["multi_country_heavybus_diesel"].ToString();
		static string multi_company_heavybus_diesel_name_1 = TestContext.Parameters["multi_company_heavybus_diesel_name_1"].ToString();
		static string multi_company_heavybus_diesel_id_1 = TestContext.Parameters["multi_company_heavybus_diesel_id_1"].ToString();
		static string multi_contract_heavybus_diesel_id_1 = TestContext.Parameters["multi_contract_heavybus_diesel_id_1"].ToString();
		static string multi_company_heavybus_diesel_name_2 = TestContext.Parameters["multi_company_heavybus_diesel_name_2"].ToString();
		static string multi_company_heavybus_diesel_id_2 = TestContext.Parameters["multi_company_heavybus_diesel_id_2"].ToString();

		static string multi_country_heavybus_NP = TestContext.Parameters["multi_country_heavybus_NP"].ToString();
		static string multi_company_heavybus_NP_name_1 = TestContext.Parameters["multi_company_heavybus_NP_name_1"].ToString();
		static string multi_company_heavybus_NP_id_1 = TestContext.Parameters["multi_company_heavybus_NP_id_1"].ToString();
		static string multi_contract_heavybus_NP_id_1 = TestContext.Parameters["multi_contract_heavybus_NP_id_1"].ToString();
		static string multi_company_heavybus_NP_name_2 = TestContext.Parameters["multi_company_heavybus_NP_name_2"].ToString();
		static string multi_company_heavybus_NP_id_2 = TestContext.Parameters["multi_company_heavybus_NP_id_2"].ToString();

		public Advanced_Filters_Multi_Contracts(Account Account) : base(Account) { }
		public int AdvancedFiltersMultiContracts(Xpath__AdvancedFilters Xpath, String Dashboard)
		{
			try
			{
			// Wait definition for element
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

			Console.WriteLine("Dashboard opened");

			System.Threading.Thread.Sleep(2000);

			// Verify the presence of Country
			wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Country)));
			Console.WriteLine("Verify the presence of Country");
			System.Threading.Thread.Sleep(1000);

			switch (Dashboard)
			{
				case "11":
					if(multi_company_truck_diesel_name_1 != "" || multi_company_truck_diesel_name_2 != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + multi_country_truck_diesel + "')]"))).Click();
						Console.WriteLine("Selected market: " + multi_country_truck_diesel);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(multi_company_truck_diesel_name_1);
						Console.WriteLine("inserted as company "+ multi_company_truck_diesel_name_1);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + multi_company_truck_diesel_id_1 + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + multi_company_truck_diesel_id_1 + "']/p")));
						Console.WriteLine("Selected company " + multi_company_truck_diesel_id_1);
						System.Threading.Thread.Sleep(2000);

						// click on one contract
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + multi_contract_truck_diesel_id_1 + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + multi_contract_truck_diesel_id_1 + "']/p")));
						Console.WriteLine("Selected contract " + multi_contract_truck_diesel_id_1);
						System.Threading.Thread.Sleep(2000);

						// click on deselect all option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeselectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.DeselectAllButton)));
						Console.WriteLine("Deselected all contracts");
						System.Threading.Thread.Sleep(2000);

						// click on 'select all' option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SelectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.SelectAllButton)));
						Console.WriteLine("Selected all contracts");
						System.Threading.Thread.Sleep(2000);

						// clear selection
						driver.FindElement(By.XPath(Xpath.CompanyField)).Clear();
						System.Threading.Thread.Sleep(2000);

						// search company 2
						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(multi_company_truck_diesel_name_2);
						Console.WriteLine("inserted as company "+ multi_company_truck_diesel_name_2);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + multi_company_truck_diesel_id_2 + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + multi_company_truck_diesel_id_2 + "']/p")));
						Console.WriteLine("Selected company " + multi_company_truck_diesel_id_2);
						System.Threading.Thread.Sleep(2000);

						// click on deselect all option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeselectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.DeselectAllButton)));
						Console.WriteLine("Deselected all contracts");
						System.Threading.Thread.Sleep(2000);

						// click on 'select all' option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SelectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.SelectAllButton)));
						Console.WriteLine("Selected all contracts");
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard Truck Diesel not verified because there aren't contract");
						return 1;
					}
					break;
				case "12":
					if (multi_company_truck_NP_name != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + multi_country_truck_NP + "')]"))).Click();
						Console.WriteLine("Selected market: " + multi_country_truck_NP);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(multi_company_truck_NP_name);
						Console.WriteLine("inserted as company " + multi_company_truck_NP_name);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + multi_company_truck_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + multi_company_truck_NP_id + "']/p")));
						Console.WriteLine("Selected company " + multi_company_truck_NP_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + multi_contract_truck_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + multi_contract_truck_NP_id + "']/p")));
						Console.WriteLine("Selected contract " + multi_contract_truck_NP_id);
						System.Threading.Thread.Sleep(2000);

						// click on deselect all option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeselectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.DeselectAllButton)));
						Console.WriteLine("Deselected all contracts");
						System.Threading.Thread.Sleep(2000);

						// click on 'select all' option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SelectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.SelectAllButton)));
						Console.WriteLine("Selected all contracts");
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard Truck NP not verified, because there aren't contract");
						return 1;
					}
					break;
				case "21":
					if (multi_company_light_diesel_name != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + multi_country_light_diesel + "')]"))).Click();
						Console.WriteLine("Selected market: " + multi_country_light_diesel);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(multi_company_light_diesel_name);
						Console.WriteLine("inserted as company " + multi_company_light_diesel_name);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + multi_company_light_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + multi_company_light_diesel_id + "']/p")));
						Console.WriteLine("Selected company " + multi_company_light_diesel_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + multi_contract_light_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + multi_contract_light_diesel_id + "']/p")));
						Console.WriteLine("Selected contract " + multi_contract_light_diesel_id);
						System.Threading.Thread.Sleep(2000);

						// click on deselect all option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeselectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.DeselectAllButton)));
						Console.WriteLine("Deselected all contracts");
						System.Threading.Thread.Sleep(2000);

						// click on 'select all' option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SelectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.SelectAllButton)));
						Console.WriteLine("Selected all contracts");
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard Light Diesel not verified, because there aren't contract");
						return 1;
					}
					break;
				case "22":
					if (multi_company_light_NP_name != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + multi_country_light_NP + "')]"))).Click();
						Console.WriteLine("Selected market: " + multi_country_light_NP);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(multi_company_light_NP_name);
						Console.WriteLine("inserted as company " + multi_company_light_NP_name);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + multi_company_light_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + multi_company_light_NP_id + "']/p")));
						Console.WriteLine("Selected company " + multi_company_light_NP_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + multi_contract_light_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + multi_contract_light_NP_id + "']/p")));
						Console.WriteLine("Selected contract " + multi_contract_light_NP_id);
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard Light NP not verified, because there aren't contract");
						return 1;
					}
					break;
				case "31":
					if(multi_company_heavybus_diesel_name_1 != "" || multi_company_heavybus_diesel_name_2 != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + multi_country_heavybus_diesel + "')]"))).Click();
						Console.WriteLine("Selected market: " + multi_country_heavybus_diesel);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(multi_company_heavybus_diesel_name_1);
						Console.WriteLine("inserted as company "+ multi_company_heavybus_diesel_name_1);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + multi_company_heavybus_diesel_id_1 + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + multi_company_heavybus_diesel_id_1 + "']/p")));
						Console.WriteLine("Selected company " + multi_company_heavybus_diesel_id_1);
						System.Threading.Thread.Sleep(2000);

						// click on one contract
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + multi_contract_heavybus_diesel_id_1 + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + multi_contract_heavybus_diesel_id_1 + "']/p")));
						Console.WriteLine("Selected contract " + multi_contract_heavybus_diesel_id_1);
						System.Threading.Thread.Sleep(2000);

						// click on deselect all option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeselectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.DeselectAllButton)));
						Console.WriteLine("Deselected all contracts");
						System.Threading.Thread.Sleep(2000);

						// click on 'select all' option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SelectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.SelectAllButton)));
						Console.WriteLine("Selected all contracts");
						System.Threading.Thread.Sleep(2000);

						// clear selection
						driver.FindElement(By.XPath(Xpath.CompanyField)).Clear();
						System.Threading.Thread.Sleep(2000);

						// search company 2
						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(multi_company_heavybus_diesel_name_2);
						Console.WriteLine("inserted as company "+ multi_company_heavybus_diesel_name_2);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + multi_company_heavybus_diesel_id_2 + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + multi_company_heavybus_diesel_id_2 + "']/p")));
						Console.WriteLine("Selected company " + multi_company_heavybus_diesel_id_2);
						System.Threading.Thread.Sleep(2000);

						// click on deselect all option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeselectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.DeselectAllButton)));
						Console.WriteLine("Deselected all contracts");
						System.Threading.Thread.Sleep(2000);

						// click on 'select all' option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SelectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.SelectAllButton)));
						Console.WriteLine("Selected all contracts");
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard HeavyBus Diesel not verified because there aren't contract");
						return 1;
					}
					break;
				case "32":
					if(multi_company_heavybus_NP_name_1 != "" || multi_company_heavybus_NP_name_2 != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + multi_country_heavybus_NP + "')]"))).Click();
						Console.WriteLine("Selected market: " + multi_country_heavybus_NP);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(multi_company_heavybus_NP_name_1);
						Console.WriteLine("inserted as company "+ multi_company_heavybus_NP_name_1);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + multi_company_heavybus_NP_id_1 + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + multi_company_heavybus_NP_id_1 + "']/p")));
						Console.WriteLine("Selected company " + multi_company_heavybus_NP_id_1);
						System.Threading.Thread.Sleep(2000);

						// click on one contract
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + multi_contract_heavybus_NP_id_1 + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + multi_contract_heavybus_NP_id_1 + "']/p")));
						Console.WriteLine("Selected contract " + multi_contract_heavybus_NP_id_1);
						System.Threading.Thread.Sleep(2000);

						// click on deselect all option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeselectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.DeselectAllButton)));
						Console.WriteLine("Deselected all contracts");
						System.Threading.Thread.Sleep(2000);

						// click on 'select all' option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SelectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.SelectAllButton)));
						Console.WriteLine("Selected all contracts");
						System.Threading.Thread.Sleep(2000);

						// clear selection
						driver.FindElement(By.XPath(Xpath.CompanyField)).Clear();
						System.Threading.Thread.Sleep(2000);

						// search company 2
						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(multi_company_heavybus_NP_name_2);
						Console.WriteLine("inserted as company "+ multi_company_heavybus_NP_name_2);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + multi_company_heavybus_NP_id_2 + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + multi_company_heavybus_NP_id_2 + "']/p")));
						Console.WriteLine("Selected company " + multi_company_heavybus_NP_id_2);
						System.Threading.Thread.Sleep(2000);

						// click on deselect all option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeselectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.DeselectAllButton)));
						Console.WriteLine("Deselected all contracts");
						System.Threading.Thread.Sleep(2000);

						// click on 'select all' option
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SelectAllButton)));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.SelectAllButton)));
						Console.WriteLine("Selected all contracts");
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard HeavyBus NP not verified because there aren't contract");
						return 1;
					}
					break;
			}
			wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ApplyAdvancedFiltersButton)));
			js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(Xpath.ApplyAdvancedFiltersButton)));
			System.Threading.Thread.Sleep(10000);
			return 0;
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
				return 0;
			}
		}
	}
}