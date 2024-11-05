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
    public class Driver_Section_AddDriverPopUp: BaseClass
    {
        public void DriveSectionAddDriverPopUp(Xpath__Drivers Xpath, Values__Drivers Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Verify the presence of menu
                AssertElementIsEqualTo(Xpath.Menu, Value.Menu);

                //Open Menu + Click on Driver Section
                OpenSectionMenu(Xpath.Menu, Xpath.Drivers, Value.Drivers, 1000);

                // Verify the presence of Add Driver Button
                AssertElementIsEqualTo(Xpath.AddNewDriver, Value.AddNewDriver);

                //Click on Add New Driver Button
                JSClickDropdownChoice(Xpath.AddNewDriver, Value.AddNewDriver, 2000);

                // Verify the presence of Driver name
                AssertElementIsEqualTo(Xpath.DriverNameLabel, Value.DriverName);

                // Verify the presence of Driver ID
                AssertElementIsEqualTo(Xpath.DriverIDLabel, Value.DriverID);

                // Verify the presence of Driver Email
                AssertElementIsEqualTo(Xpath.DriverEmailLabel, Value.DriverEmail);

                // Verify the presence of Driver Surname
                AssertElementIsEqualTo(Xpath.DriverSurnameLabel, Value.DriverSurname);

                // Verify the presence of Driver phone
                AssertElementIsEqualTo(Xpath.DriverPhoneLabel, Value.DriverPhone);

                //Click on Cancel Button
                JSClickDropdownChoice(Xpath.Cancel, Value.Cancel, 2000);

            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        driver.Close();
        }
    }
}