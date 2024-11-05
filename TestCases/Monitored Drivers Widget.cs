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
    public class Monitored_Driver_Test: BaseClass
    {
      
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void AddVerifyRemoveANewDriver(Xpath__Monitored_Drivers Xpath, Values__Monitored_Drivers Value, Filter_Query_Params Filters)
        {

            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                js.ExecuteScript("document.body.style.zoom = '0.67'");
                

                //Scroll website
                Scroll(Xpath.AddDriverButton);
                var MonitoredDriverswidgetPosition = driver.FindElement(By.XPath(Xpath.AddDriverButton));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", MonitoredDriverswidgetPosition);

            // Remove all the possible vin inserted in the widget
            int n = 0;
            while (n == 0)
            {
                try
                {
                    // Find and click on circle fill button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ActionButton)));
                    IWebElement ActionButton = driver.FindElement(By.XPath(Xpath.ActionButton));
                    js.ExecuteScript("arguments[0].click();", ActionButton);
                    Console.WriteLine("Click on circle fill button, for a driver already added");

                    // Find and click on YES button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='monitoredDriversContent']//button[@class='button confirm padding-lr text-body']")));
                    IWebElement ConfirmRemoval = driver.FindElement(By.XPath("//div[@id='monitoredDriversContent']//button[@class='button confirm padding-lr text-body']"));
                    js.ExecuteScript("arguments[0].click();", ConfirmRemoval);
                    Console.WriteLine("Confirm driver removal");


                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Waited 2 s");
           
                }
                catch
                { n++; }
            }
           

            // To iterate over it.
            foreach (List<string> driverData in Value.GetdriverList())
                {
                    ///// ADD A NEW DRIVER /////

                    // Find and click on AGGIUNGI button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddDriverButton)));
                    IWebElement AddDriver = driver.FindElement(By.XPath(Xpath.AddDriverButton));
                    js.ExecuteScript("arguments[0].click();", AddDriver);
                    Console.WriteLine("Click on ADD driver and search driver: "+ driverData[0] );

                    // Click on ADD NEW DRIVER
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='monitored-drivers-dropdown']/div[2]/pfe-dropdown-item/p[contains( text(),'" + driverData[0] + "')]")));
                    IWebElement AddDriverPlusButton = driver.FindElement(By.XPath("//*[@id='monitored-drivers-dropdown']/div[2]/pfe-dropdown-item/p[contains( text(),'" + driverData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", AddDriverPlusButton);
                    Console.WriteLine("Confirm driver addition");



                    ///// CHECK NEW DRIVER INFORMATION /////

                    // Verify User ID
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='id padding-r'][contains(text(),'" + driverData[0] + "')]")));
                    Console.WriteLine("\r\n" + "Driver ID verified: " + driver.FindElement(By.XPath("//span[@class='id padding-r'][contains(text(),'" + driverData[0] + "')]")).Text);


                    // Verify Fuel saving score
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.FuelSavingScoreUserID)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.FuelSavingScoreUserID)).Text, Is.EqualTo("Fuel saving score"));
                    Console.WriteLine(("\r\n" + "Verified presence of correct text: Fuel saving score"));

                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.FuelSavingScoreValueUserID)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.FuelSavingScoreValueUserID)).Text, Is.EqualTo(driverData[1]));
                    Console.WriteLine("Fuel saving score value = ");


                    // Verify Vehicle care score
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.VehicleCareScoreUserID)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.VehicleCareScoreUserID)).Text, Is.EqualTo("Vehicle care score"));
                    Console.WriteLine(("\r\n" + "Verified presence of correct text: Vehicle care score"));

                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.VehicleCareScoreValueUserID)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.VehicleCareScoreValueUserID)).Text, Is.EqualTo(driverData[2]));
                    Console.WriteLine("Vehicle care score value = ");


                    // Verify Safe driving score
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.SafeDrivingScoreUserID)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.SafeDrivingScoreUserID)).Text, Is.EqualTo("Safe driving score"));
                    Console.WriteLine(("\r\n" + "Verified presence of correct text: Safe driving score"));

                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.SafeDrivingScoreValueUserID)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.SafeDrivingScoreValueUserID)).Text, Is.EqualTo(driverData[3]));
                    Console.WriteLine("Safe driving score value = ");



                    ///// REMORE INSERTED DRIVER /////

                    // Find and click on circle fill button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'row monitored-drivers-content margin-b ng-star-inserted')]//span[contains(@id,'" + driverData[0] + "')]")));
                    IWebElement CircleFill = driver.FindElement(By.XPath("//div[contains(@class, 'row monitored-drivers-content margin-b ng-star-inserted')]//span[contains(@id,'" + driverData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", CircleFill);
                    Console.WriteLine("Click on circle fill button");


                    // Find and click on YES button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='monitoredDriversContent']//button[@class='button confirm padding-lr text-body']")));
                    IWebElement ConfirmRemoval = driver.FindElement(By.XPath("//div[@id='monitoredDriversContent']//button[@class='button confirm padding-lr text-body']"));
                    js.ExecuteScript("arguments[0].click();", ConfirmRemoval);
                    Console.WriteLine("Confirm driver removal");

                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Waited 2 s");
                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }
    }
}

