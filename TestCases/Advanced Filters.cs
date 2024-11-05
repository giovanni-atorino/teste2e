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

    public class Advanced_Filters: Basic_Test
	{
		static string country_truck_diesel = TestContext.Parameters["country_truck_diesel"].ToString();
		static string company_truck_diesel_name = TestContext.Parameters["company_truck_diesel_name"].ToString();
        static string company_truck_diesel_id = TestContext.Parameters["company_truck_diesel_id"].ToString();
        static string contract_truck_diesel_id = TestContext.Parameters["contract_truck_diesel_id"].ToString();
		
		static string country_truck_NP = TestContext.Parameters["country_truck_NP"].ToString();
		static string company_truck_NP_name = TestContext.Parameters["company_truck_NP_name"].ToString();
		static string company_truck_NP_id = TestContext.Parameters["company_truck_NP_id"].ToString();
		static string contract_truck_NP_id = TestContext.Parameters["contract_truck_NP_id"].ToString();

		static string country_light_diesel = TestContext.Parameters["country_light_diesel"].ToString();
		static string company_light_diesel_name = TestContext.Parameters["company_light_diesel_name"].ToString();
		static string company_light_diesel_id = TestContext.Parameters["company_light_diesel_id"].ToString();
		static string contract_light_diesel_id = TestContext.Parameters["contract_light_diesel_id"].ToString();

		static string country_light_NP = TestContext.Parameters["country_light_NP"].ToString();
		static string company_light_NP_name = TestContext.Parameters["company_light_NP_name"].ToString();
		static string company_light_NP_id = TestContext.Parameters["company_light_NP_id"].ToString();
		static string contract_light_NP_id = TestContext.Parameters["contract_light_NP_id"].ToString();

		static string country_light_Electric = TestContext.Parameters["country_light_Electric"].ToString();
		static string company_light_Electric_name = TestContext.Parameters["company_light_Electric_name"].ToString();
		static string company_light_Electric_id = TestContext.Parameters["company_light_Electric_id"].ToString();
		static string contract_light_Electric_id = TestContext.Parameters["contract_light_Electric_id"].ToString();

		static string country_heavybus_diesel = TestContext.Parameters["country_heavybus_diesel"].ToString();
		static string company_heavybus_diesel_name = TestContext.Parameters["company_heavybus_diesel_name"].ToString();
		static string company_heavybus_diesel_id = TestContext.Parameters["company_heavybus_diesel_id"].ToString();
		static string contract_heavybus_diesel_id = TestContext.Parameters["contract_heavybus_diesel_id"].ToString();
		
		static string country_heavybus_NP = TestContext.Parameters["country_heavybus_NP"].ToString();
		static string company_heavybus_NP_name = TestContext.Parameters["company_heavybus_NP_name"].ToString();
		static string company_heavybus_NP_id = TestContext.Parameters["company_heavybus_NP_id"].ToString();
		static string contract_heavybus_NP_id = TestContext.Parameters["contract_heavybus_NP_id"].ToString();

		static string country_heavybus_Electric = TestContext.Parameters["country_heavybus_Electric"].ToString();
		static string company_heavybus_Electric_name = TestContext.Parameters["company_heavybus_Electric_name"].ToString();
		static string company_heavybus_Electric_id = TestContext.Parameters["company_heavybus_Electric_id"].ToString();
		static string contract_heavybus_Electric_id = TestContext.Parameters["contract_heavybus_Electric_id"].ToString();

		static string country_tway_diesel = TestContext.Parameters["country_tway_diesel"].ToString();
		static string company_tway_diesel_name = TestContext.Parameters["company_tway_diesel_name"].ToString();
		static string company_tway_diesel_id = TestContext.Parameters["company_tway_diesel_id"].ToString();
		static string contract_tway_diesel_id = TestContext.Parameters["contract_tway_diesel_id"].ToString();

		public Advanced_Filters(Account Account) : base(Account) { }


		public int AdvancedFilters(Xpath__AdvancedFilters Xpath, String Dashboard)
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
					if(company_truck_diesel_name!="")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + country_truck_diesel + "')]"))).Click();
						Console.WriteLine("Selected market: " + country_truck_diesel);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(company_truck_diesel_name);
						Console.WriteLine("inserted as company "+ company_truck_diesel_name);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + company_truck_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + company_truck_diesel_id + "']/p")));
						Console.WriteLine("Selected company " + company_truck_diesel_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + contract_truck_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + contract_truck_diesel_id + "']/p")));
						Console.WriteLine("Selected contract " + contract_truck_diesel_id);
						System.Threading.Thread.Sleep(2000);
					
					}
					else
					{
						Console.WriteLine("Dashboard Truck Diesel not verified because there aren't contract");
						return 1;
					}
					break;

				case "12":
					if (company_truck_NP_name != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + country_truck_NP + "')]"))).Click();
						Console.WriteLine("Selected market: " + country_truck_NP);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);
					    
						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(company_truck_NP_name);
						Console.WriteLine("inserted as company "+ company_truck_NP_name);
						System.Threading.Thread.Sleep(2000);
						
						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + company_truck_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + company_truck_NP_id + "']/p")));
						Console.WriteLine("Selected company " + company_truck_NP_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + contract_truck_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + contract_truck_NP_id + "']/p")));
						Console.WriteLine("Selected contract " + contract_truck_NP_id);
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard Truck NP not verified");
						return 1;
					}
					break;

				case "21":
					if (company_light_diesel_name != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + country_light_diesel + "')]"))).Click();
						Console.WriteLine("Selected market: " + country_light_diesel);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(company_light_diesel_name);
						Console.WriteLine("inserted as company " + company_light_diesel_name);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + company_light_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + company_light_diesel_id + "']/p")));
						Console.WriteLine("Selected company " + company_light_diesel_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + contract_light_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + contract_light_diesel_id + "']/p")));
						Console.WriteLine("Selected contract " + contract_light_diesel_id);
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard Light Diesel not verified, because there aren't contract");
						return 1;
					}
					break;

				case "22":
					if (company_light_NP_name != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + country_light_NP + "')]"))).Click();
						Console.WriteLine("Selected market: " + country_light_NP);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(company_light_NP_name);
						Console.WriteLine("inserted as company " + company_light_NP_name);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + company_light_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + company_light_NP_id + "']/p")));
						Console.WriteLine("Selected company " + company_light_NP_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + contract_light_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + contract_light_NP_id + "']/p")));
						Console.WriteLine("Selected contract " + contract_light_NP_id);
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard Light NP not verified, because there aren't contract");
						return 1;
					}
					break;

					case "23":
						if (company_light_Electric_name != "")
						{
							//select country
							wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + country_light_Electric + "')]"))).Click();
							Console.WriteLine("Selected market: " + country_light_Electric);
							System.Threading.Thread.Sleep(2000);

							// Verify the presence of company 
							wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
							Console.WriteLine("Verify the presence of company");
							System.Threading.Thread.Sleep(2000);

							driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(company_light_Electric_name);
							Console.WriteLine("inserted as company " + company_light_Electric_name);
							System.Threading.Thread.Sleep(2000);

							driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
							System.Threading.Thread.Sleep(2000);

							wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + company_light_Electric_id + "']/p")));
							js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + company_light_Electric_id + "']/p")));
							Console.WriteLine("Selected company " + company_light_Electric_id);
							System.Threading.Thread.Sleep(2000);

							wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + contract_light_Electric_id + "']/p")));
							js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + contract_light_Electric_id + "']/p")));
							Console.WriteLine("Selected contract " + contract_light_Electric_id);
							System.Threading.Thread.Sleep(2000);
						}
						else
						{
							Console.WriteLine("Dashboard Light Electric not verified, because there aren't contract");
							return 1;
						}
						break;

					case "31":
					if (company_heavybus_diesel_name != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + country_heavybus_diesel + "')]"))).Click();
						Console.WriteLine("Selected market: " + country_heavybus_diesel);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(company_heavybus_diesel_name);
						Console.WriteLine("inserted as company " + company_heavybus_diesel_name);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + company_heavybus_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + company_heavybus_diesel_id + "']/p")));
						Console.WriteLine("Selected company " + company_heavybus_diesel_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + contract_heavybus_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + contract_heavybus_diesel_id + "']/p")));
						Console.WriteLine("Selected contract " + contract_heavybus_diesel_id);
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard HeavyBus Diesel not verified because there aren't contract");
						return 1;
					}
					break;

				case "32":
					if (company_heavybus_NP_name != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + country_heavybus_NP + "')]"))).Click();
						Console.WriteLine("Selected market: " + country_heavybus_NP);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(company_heavybus_NP_name);
						Console.WriteLine("inserted as company " + company_heavybus_NP_name);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + company_heavybus_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + company_heavybus_NP_id + "']/p")));
						Console.WriteLine("Selected company " + company_heavybus_NP_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + contract_heavybus_NP_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + contract_heavybus_NP_id + "']/p")));
						Console.WriteLine("Selected contract " + contract_heavybus_NP_id);
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard HeavyBus NP not verified because there aren't contract");
						return 1;
					}
					break;

					case "33":
						if (company_heavybus_NP_name != "")
						{
							//select country
							wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + country_heavybus_Electric + "')]"))).Click();
							Console.WriteLine("Selected market: " + country_heavybus_Electric);
							System.Threading.Thread.Sleep(2000);

							// Verify the presence of company 
							wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
							Console.WriteLine("Verify the presence of company");
							System.Threading.Thread.Sleep(2000);

							driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(company_heavybus_Electric_name);
							Console.WriteLine("inserted as company " + company_heavybus_Electric_name);
							System.Threading.Thread.Sleep(2000);

							driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
							System.Threading.Thread.Sleep(2000);

							wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + company_heavybus_Electric_id + "']/p")));
							js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + company_heavybus_Electric_id + "']/p")));
							Console.WriteLine("Selected company " + company_heavybus_NP_id);
							System.Threading.Thread.Sleep(2000);

							wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + contract_heavybus_Electric_id + "']/p")));
							js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + contract_heavybus_Electric_id + "']/p")));
							Console.WriteLine("Selected contract " + contract_heavybus_Electric_id);
							System.Threading.Thread.Sleep(2000);
						}
						else
						{
							Console.WriteLine("Dashboard HeavyBus Electric not verified because there aren't contract");
							return 1;
						}
						break;

					case "51":
					if (company_tway_diesel_name != "")
					{
						//select country
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[1]//option[contains (text(),'" + country_tway_diesel + "')]"))).Click();
						Console.WriteLine("Selected market: " + country_tway_diesel);
						System.Threading.Thread.Sleep(2000);

						// Verify the presence of company 
						wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyField)));
						Console.WriteLine("Verify the presence of company");
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(company_tway_diesel_name);
						Console.WriteLine("inserted as company " + company_tway_diesel_name);
						System.Threading.Thread.Sleep(2000);

						driver.FindElement(By.XPath(Xpath.CompanyField)).SendKeys(Keys.Enter);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='company-" + company_tway_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='company-" + company_tway_diesel_id + "']/p")));
						Console.WriteLine("Selected company " + company_tway_diesel_id);
						System.Threading.Thread.Sleep(2000);

						wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='contract-" + contract_tway_diesel_id + "']/p")));
						js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='contract-" + contract_tway_diesel_id + "']/p")));
						Console.WriteLine("Selected contract " + contract_tway_diesel_id);
						System.Threading.Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Dashboard Tway Diesel not verified, because there aren't contract");
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