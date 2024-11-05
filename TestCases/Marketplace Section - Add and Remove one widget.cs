using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using myiveco_selenium.Xpath;
using myiveco_selenium.Values;
using myiveco_selenium.Filters;
using myiveco_selenium.Functions;


namespace myiveco_selenium
{
    public class Marketplace_Section_Add_Remove_One_Widget: BaseClass
    {
        public void MarketplaceSectionAddRemoveOneWidget(Xpath__Marketplace Xpath, Values__Marketplace Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
   
                // Verify the presence of menu
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.Menu)).Text, Is.EqualTo(Value.Menu));
                Console.WriteLine("Verified presence of Menu");

                //Open Menu + click on MarketPlace
                OpenSectionMenu(Xpath.Menu, Xpath.Marketplace, Value.Marketplace, 1000);

                //Verify the presence of Remove button for Fuel Consumption
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddRemoveFuelConsumption)));
                System.Threading.Thread.Sleep(1000);
                
                if (Equals(driver.FindElement(By.XPath(Xpath.AddRemoveFuelConsumption)).Text, Value.Remove) ==true)
                {
                    Console.WriteLine("Verified presence of remove button for Fuel Consumption: the widget is currently on dashboard");
                    //Click on Remove
                    IWebElement RemoveFuelConsumptionButton = driver.FindElement(By.XPath(Xpath.AddRemoveFuelConsumption));
                    js.ExecuteScript("arguments[0].click();", RemoveFuelConsumptionButton);
                    Console.WriteLine("Click on Remove Fuel Consumption");
                }

                else if(Equals(driver.FindElement(By.XPath(Xpath.AddRemoveFuelConsumption)).Text, Value.Add) == true)
                {
                    Console.WriteLine("Fuel Consumption widget is already removed from the dashboard");
                }

                else
                {
                    Assert.Fail("Test failed: add or remove button was found");
                }
               
                // Verify the presence of menu
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.Menu)).Text, Is.EqualTo(Value.Menu));
                Console.WriteLine("Verified presence of Menu");

                //Click on Menu + Click on Trucks
                OpenSecondSectionMenu(Xpath.Menu, Xpath.Trucks, Value.Trucks, Xpath.TrucksDiesel, Value.DashboardHeavyDiesel, 1000);

                // Verify the presence of menu
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.Menu)).Text, Is.EqualTo(Value.Menu));
                Console.WriteLine("Verified presence of Menu");

                //Open Menu + click on MarketPlace
                OpenSectionMenu(Xpath.Menu, Xpath.Marketplace, Value.Marketplace, 1000);

                //Verify the presence of Add button for Fuel Consumption
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddRemoveFuelConsumption)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.AddRemoveFuelConsumption)).Text, Is.EqualTo(Value.Add));
                Console.WriteLine("Verified presence of add button for Fuel Consumption");

                //Click on Add
                IWebElement AddFuelConsumptionButton = driver.FindElement(By.XPath(Xpath.AddRemoveFuelConsumption));
                js.ExecuteScript("arguments[0].click();", AddFuelConsumptionButton);
                Console.WriteLine("Click on Add Fuel Consumption");

                //Verify the presence of Go to dashboard button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.GotoDashboard)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.GotoDashboard)).Text, Is.EqualTo(Value.GotoDashboard));
                Console.WriteLine("The pop-up is opened to confirm the widget addition");

                //Click on Go to dashboard button
                IWebElement GotoDashboardButton = driver.FindElement(By.XPath(Xpath.GotoDashboard));
                js.ExecuteScript("arguments[0].click();", GotoDashboardButton);
                Console.WriteLine("Click on Go to dashboard button");

                // REMOVED FOR TEST WITHOUT DATA
                //Verify the presence of Fuel Consumption widget
                //wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelConsumptionTitle)));
                //System.Threading.Thread.Sleep(3000);
                //Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsumptionTitle)).Text, Is.EqualTo(Value.FuelConsumptionTitle));
                //Console.WriteLine("Verified presence of Fuel Consumption widget");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}