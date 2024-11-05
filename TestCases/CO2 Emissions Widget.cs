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
using Org.BouncyCastle.Asn1.IsisMtt.X509;


namespace myiveco_selenium
{
    public class CO2_emissions_Widget: BaseClass
    {
       
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void CO2testKPIandColumnsHeavy(Xpath__CO2_Emissions Xpath, Values__CO2_Emissions Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.CO2Emissions);
                var CO2widgetPosition = driver.FindElement(By.XPath(Xpath.CO2Emissions));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", CO2widgetPosition);

                // JS method to move mouse pointer on specific object. Used to trigger CO2 popups over coluns.
                String strJavaScript = "var element = arguments[0]; var mouseEventObj = document.createEvent('MouseEvents'); mouseEventObj.initEvent( 'mouseover', true, true ); element.dispatchEvent(mouseEventObj);";

                // Verified KPI emissions
                AssertElementIsEqualTo(Xpath.CO2Emissions, "CO2 emissions");

                // Verified KPI emissions
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Emissions)));

                Assert.That(driver.FindElement(By.XPath(Xpath.EmissionsValue)).Text, Is.EqualTo(Value.EmissionKPI));
                Console.WriteLine("KPI Emission value verified: " + driver.FindElement(By.XPath(Xpath.EmissionsValue)).Text + " t \r\n");

                foreach (List<string> co2Data in Value.GetCO2Datalist())
                {

                    // First column analysis
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.GenericColumn + "[" + co2Data[0] + "]")));
                    Console.WriteLine("Verified presence of column n." + co2Data[0]);

                    IWebElement FirstColumn = driver.FindElement(By.XPath(Xpath.GenericColumn + "[" + co2Data[0] + "]"));

                    js.ExecuteScript(strJavaScript, FirstColumn);
                    Console.WriteLine("Click on column n." + co2Data[0]);

                    System.Threading.Thread.Sleep(3000);

                    Assert.That(driver.FindElement(By.XPath(Xpath.ColumnValue)).Text,
                        Is.EqualTo("Tons: " + co2Data[1] + " t\r\nN° vehicles: " + co2Data[2] + "\r\nTotal distance: " + co2Data[3] + " km\r\nTotal trip time: " + co2Data[4] + " h"));


                    Console.WriteLine("Column number " + co2Data[0] + ": CO2 content verified");

                    Console.WriteLine("\r\nVerified data in string " + co2Data[0] + ": \r\n" + driver.FindElement(By.XPath(Xpath.ColumnValue)).Text + "\r\n");

                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        driver.Close();
        }

        public void CO2testKPIandColumnsLight(Xpath__CO2_Emissions Xpath, Values__CO2_Emissions Value, Filter_Query_Params Filters)

        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.CO2Emissions);
                var CO2widgetPosition = driver.FindElement(By.XPath(Xpath.CO2Emissions));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", CO2widgetPosition);

                // JS method to move mouse pointer on specific object. Used to trigger CO2 popups over coluns.
                String strJavaScript = "var element = arguments[0]; var mouseEventObj = document.createEvent('MouseEvents'); mouseEventObj.initEvent( 'mouseover', true, true ); element.dispatchEvent(mouseEventObj);";

                // Verified widget presence: CO2 Emissions
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CO2Emissions)));
                Assert.That(driver.FindElement(By.XPath(Xpath.CO2Emissions)).Text, Is.EqualTo("CO2 emissions"));
                Console.WriteLine("Verified presence of text: CO2 emissions");

                // Verified KPI emissions
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Emissions)));
                Console.WriteLine("Verified presence of text:" + driver.FindElement(By.XPath(Xpath.Emissions)));//??

                Assert.That(driver.FindElement(By.XPath(Xpath.EmissionsValue)).Text, Is.EqualTo(Value.EmissionKPI));
                Console.WriteLine("KPI Emission value verified: " + driver.FindElement(By.XPath(Xpath.EmissionsValue)).Text + " kg \r\n");


                foreach (List<string> co2Data in Value.GetCO2Datalist())
                {

                    // First column analysis
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.GenericColumn + "[" + co2Data[0] + "]")));
                    Console.WriteLine("Verified presence of column n." + co2Data[0]);

                    IWebElement FirstColumn = driver.FindElement(By.XPath(Xpath.GenericColumn + "[" + co2Data[0] + "]"));

                    js.ExecuteScript(strJavaScript, FirstColumn);
                    Console.WriteLine("Click on column n." + co2Data[0]);

                    System.Threading.Thread.Sleep(3000);

                    Assert.That(driver.FindElement(By.XPath(Xpath.ColumnValue)).Text,
                   Is.EqualTo("Kg: " + co2Data[1] + " kg\r\nN° vehicles: " + co2Data[2] + "\r\nTotal distance: " + co2Data[3] + " km\r\nTotal trip time: " + co2Data[4] + " h"));

                    /**  Assert.That(driver.FindElement(By.XPath(Xpath.ColumnValue)).Text,
                    Is.EqualTo("Kg: " + co2Data[1] + " kg\r\nTotal distance: " + co2Data[2] + " km\r\nN° vehicles: " + co2Data[3] + "\r\nTotal trip time: " + co2Data[4] + " h"));**/
                    Console.WriteLine("Column number " + co2Data[0] + ": CO2 content verified");

                    Console.WriteLine("\r\nVerified data in string " + co2Data[0] + ": \r\n" + driver.FindElement(By.XPath(Xpath.ColumnValue)).Text + "\r\n");

                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

            driver.Close();
        }

        public void CO2testKPIandColumnsElectric(Xpath__CO2_Emissions Xpath, Values__CO2_Emissions Value, Filter_Query_Params Filters)

        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);
                
                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.CO2Saved);
                var CO2widgetPosition = driver.FindElement(By.XPath(Xpath.CO2Saved));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", CO2widgetPosition);

                // JS method to move mouse pointer on specific object. Used to trigger CO2 popups over coluns.
                String strJavaScript = "var element = arguments[0]; var mouseEventObj = document.createEvent('MouseEvents'); mouseEventObj.initEvent( 'mouseover', true, true ); element.dispatchEvent(mouseEventObj);";

                // Verified widget presence: CO2 saved
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CO2Saved)));
                Assert.That(driver.FindElement(By.XPath(Xpath.CO2Emissions)).Text, Is.EqualTo("CO2 saved"));
                Console.WriteLine("Verified presence of text: CO2 saved");

                // Verified KPI saved
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Emissions)));
                Console.WriteLine("Verified presence of text:" + driver.FindElement(By.XPath(Xpath.Emissions)));//??

                Assert.That(driver.FindElement(By.XPath(Xpath.EmissionsValue)).Text, Is.EqualTo(Value.EmissionKPI));
                Console.WriteLine("KPI Emission value verified: " + driver.FindElement(By.XPath(Xpath.EmissionsValue)).Text + " kg \r\n");


                foreach (List<string> co2Data in Value.GetCO2Datalist())
                {

                    // First column analysis
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.GenericColumn + "[" + co2Data[0] + "]")));
                    Console.WriteLine("Verified presence of column n." + co2Data[0]);

                    IWebElement FirstColumn = driver.FindElement(By.XPath(Xpath.GenericColumn + "[" + co2Data[0] + "]"));

                    js.ExecuteScript(strJavaScript, FirstColumn);
                    Console.WriteLine("Click on column n." + co2Data[0]);

                    System.Threading.Thread.Sleep(3000);

                    Assert.That(driver.FindElement(By.XPath(Xpath.ColumnValue)).Text,
                    Is.EqualTo("Kg: " + co2Data[1] + " kg\r\nN° vehicles: " + co2Data[2] + "\r\nTotal distance: " + co2Data[3] + " km\r\nTotal trip time: " + co2Data[4] + " h"));

                    Console.WriteLine("Column number " + co2Data[0] + ": CO2 content verified");

                    Console.WriteLine("\r\nVerified data in string " + co2Data[0] + ": \r\n" + driver.FindElement(By.XPath(Xpath.ColumnValue)).Text + "\r\n");

                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

            driver.Close();
        }
    }
}