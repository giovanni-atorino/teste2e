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
    public class Driver_Section_Add_Data : BaseClass
    {
        public void DriversSectionAddData(Xpath__Drivers Xpath, Values__Drivers Value)
        {
           Random rnd = new Random();
            String RandomInt = (rnd.Next(9999)).ToString();
            String EmailValue = "test_driver_section" + RandomInt + "@yopmail.com";
            String EmailValueModified = "test_driver_section" + RandomInt + "modified@yopmail.com";

            try
            {
                js.ExecuteScript("document.body.style.zoom = '0.80'");

                // Verify the presence of menu
                AssertElementIsEqualTo(Xpath.Menu, Value.Menu);

                //Open Menu + Click on Driver Section
                OpenSectionMenu(Xpath.Menu, Xpath.Drivers, Value.Drivers, 1000);

                // Verify the presence of Email Column
                AssertElementIsEqualTo(Xpath.Email, Value.Email);

                // Verify the presence of Driver First Name  Column
                AssertElementIsEqualTo(Xpath.DriverFirstName, Value.DriverFirstName);

                // Verify the presence of Driver Last Name Column
                AssertElementIsEqualTo(Xpath.DriverLastName, Value.DriverLastName);

               
                List<string> DriverFieldsEmail = new List<string>(new string[] { Xpath.EmailPencilButton, Xpath.EmailField, Xpath.EmailSaveButton, EmailValue, Xpath.EmailRetrieved});
                List<string> DriverFieldsName = new List<string>(new string[] { Xpath.NamePencilButton, Xpath.NameField, Xpath.NameSaveButton, Value.NameValue, Xpath.NameRetrieved });
                List<string> DriverFieldsSurname = new List<string>(new string[] { Xpath.SurnamePencilButton, Xpath.SurnameField, Xpath.NameSaveButton, Value.SurnameValue, Xpath.SurnameRetrieved });
                List<List<string>> TotalDriver = new List<List<string>>(new List<string>[] { DriverFieldsEmail, DriverFieldsName, DriverFieldsSurname });
                
                Console.WriteLine("\r\nStart to inserts all the values for email, name and surname");
                InsertingAndVerifyDataCycle(TotalDriver, Xpath);

                VerifyDataCycle(TotalDriver);
     
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

            finally
            {
                List<string> DriverFieldsEmailDeleted = new List<string>(new string[] { Xpath.EmailPencilButton, Xpath.EmailField, Xpath.EmailSaveButton, "", Xpath.EmailRetrieved });
                List<string> DriverFieldsNameDeleted = new List<string>(new string[] { Xpath.NamePencilButton, Xpath.NameField, Xpath.NameSaveButton, "", Xpath.NameRetrieved });
                List<string> DriverFieldsSurnameDeleted = new List<string>(new string[] { Xpath.SurnamePencilButton, Xpath.SurnameField, Xpath.NameSaveButton, "", Xpath.SurnameRetrieved });
                List<List<string>> TotalDriverDeleted = new List<List<string>>(new List<string>[] { DriverFieldsSurnameDeleted, DriverFieldsNameDeleted, DriverFieldsEmailDeleted });

                Console.WriteLine("\r\nStart to remove all the values for email, name and surname");
                System.Threading.Thread.Sleep(1500);
                InsertingAndVerifyDataCycle(TotalDriverDeleted, Xpath);

                VerifyDataCycle(TotalDriverDeleted);

            }
            driver.Close();
        }

        public void InsertingAndVerifyDataCycle(List<List<string>> TotalDriverData, Xpath__Drivers Xpath)
        {
            // Add driver details
            foreach (List<string> DriverData in TotalDriverData)
            {
                // Click on pencil icon to insert data
                VerifyElement(DriverData[0]);
                IWebElement PensilButton = driver.FindElement(By.XPath(DriverData[0]));
                js.ExecuteScript("arguments[0].click();", PensilButton);
                Console.WriteLine("Click on pencil icon to insert value");
                System.Threading.Thread.Sleep(1500);

                // Inserting test data
                VerifyElement(DriverData[1]);
                driver.FindElement(By.XPath(DriverData[1])).Clear();
                Console.WriteLine("Click on cancel to remove the field inserted");
                System.Threading.Thread.Sleep(1500);

                driver.FindElement(By.XPath(DriverData[1])).SendKeys(DriverData[3]);
                Console.WriteLine("Inserting value: " + DriverData[3]);
                System.Threading.Thread.Sleep(1500);

                // Save inserted data
                VerifyElement(DriverData[2]);
                IWebElement SaveButton = driver.FindElement(By.XPath(DriverData[2]));
                js.ExecuteScript("arguments[0].click();", SaveButton);
                Console.WriteLine("Click on save icon");
                System.Threading.Thread.Sleep(500);
                
                WaitingSpinner(Xpath.ExportDataGreyButton, 1000);

                // Verifying correct data has been insterted
                VerifyElement(DriverData[4]);
                Assert.That(driver.FindElement(By.XPath(DriverData[4])).Text, Is.EqualTo(DriverData[3]));
                Console.WriteLine("Verifying correct insertion: " + driver.FindElement(By.XPath(DriverData[4])).Text);
                System.Threading.Thread.Sleep(1500);

            }
        }

        public void VerifyDataCycle(List<List<string>> TotalDriverData)
        {

            foreach (List<string> DriverData in TotalDriverData)
            {
                VerifyElement(DriverData[4]);
                Assert.That(driver.FindElement(By.XPath(DriverData[4])).Text, Is.EqualTo(DriverData[3]));
                // Verifying values are mantained after refrshing the page
                Console.WriteLine("Verifying correct insertion: " + driver.FindElement(By.XPath(DriverData[4])).Text);
            }

        }
    }
}