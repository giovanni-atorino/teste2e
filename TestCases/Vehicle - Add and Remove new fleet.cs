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
    public class Vehicles_Add_Remove_New_Fleet: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void VehiclesAddRemoveNewFleet(Xpath__Vehicles Xpath, Values__Vehicles Value)

        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Verify the presence of menu
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.Menu)).Text, Is.EqualTo(Value.Menu));
                Console.WriteLine("Verified presence of Menu");

                //Open Menu
                IWebElement MenuButton = driver.FindElement(By.XPath(Xpath.Menu));
                js.ExecuteScript("arguments[0].click();", MenuButton);
                Console.WriteLine("Open Menu");
                /**
                //Verify the presence of Vehicle section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Vehicles)));
                System.Threading.Thread.Sleep(2000);
                Assert.That(driver.FindElement(By.XPath(Xpath.Vehicles)).Text, Is.EqualTo(Value.Vehicles));
                Console.WriteLine("Verified presence of Vehicles section");

                //Open Vehicles section
                IWebElement VehiclesButton = driver.FindElement(By.XPath(Xpath.Vehicles));
                js.ExecuteScript("arguments[0].click();", VehiclesButton);
                Console.WriteLine("Open Vehicles section");
                **/

                driver.Navigate().GoToUrl(weburl_runsettings + "fleets");
                Console.WriteLine("Navigating to: fleets");
                System.Threading.Thread.Sleep(2000);

                // Expand Add Fleet
                ExpandShadowElementAndClick("pfe-cta", 40, "[class=label-btn]");
                Console.WriteLine("Click on Add Fleet Button");

                // Verify the presence of Insert Fleet Name Text Box
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.InsertFleetNameLabelTextBox)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.InsertFleetNameLabelTextBox)).Text, Is.EqualTo(Value.InsertFleetNameLabelTextBox));
                Console.WriteLine("Verified presence of Insert Fleet Name Text Box");
           
                //Insert fleet name
                driver.FindElement(By.XPath(Xpath.InsertFleetNameTextBox)).SendKeys("Test");

                //Insert at least one vehicle
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddIcon)));
                Console.WriteLine("Verified presence of Add icon");
                IWebElement AddIconButton = driver.FindElement(By.XPath(Xpath.AddIcon));
                js.ExecuteScript("arguments[0].click();", AddIconButton);
                Console.WriteLine("Click on Add Icon Button");


                // Verify the presence of Submit button 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Submit)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Submit)).Text, Is.EqualTo(Value.Submit));
                Console.WriteLine("Verified presence of Ssubmit");

                //Click on Submit Button
                IWebElement SubmitButton = driver.FindElement(By.XPath(Xpath.Submit));
                js.ExecuteScript("arguments[0].click();", SubmitButton);
                Console.WriteLine("Click on Submit Button");

                /**
                //Verify insertion fleet
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Submit)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Submit)).Text, Is.EqualTo(Value.Submit));
                Console.WriteLine("Verified presence of Submit");

                Assert.That(driver.FindElement(By.XPath("//app-root[@id='root']/div[2]/app-fleets-page/div/div/app-fleet-summary/div/div/div/div/div")).Text, Is.EqualTo("ciao"));
               
                //Fleet Deletion
                var elements = driver.FindElements(By.CssSelector("#action-tooltip-0 svg"));
                Assert.True(elements.Count > 0);
                driver.FindElement(By.CssSelector("#action-tooltip-0 svg")).Click();
                Assert.That(driver.FindElement(By.XPath("//ngb-popover-window[@id=\'ngb-popover-15\']/div[2]/div[3]/div")).Text, Is.EqualTo("Delete fleet"));
                driver.FindElement(By.XPath("//ngb-popover-window[@id=\'ngb-popover-15\']/div[2]/div[3]/div")).Click();
               
                **/
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}