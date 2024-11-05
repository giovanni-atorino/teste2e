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

namespace myiveco_selenium.TestCases
{
    public class PayPerUse: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void PayPerUseView(Xpath__PayPerUse Xpath, Values__PayPerUse Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Add additional zoom out
                js.ExecuteScript("document.body.style.zoom = '0.50'");

                //Scroll to down and top the website
                ScrollDown();

                //Scroll website until title of widget is found
                Scroll(Xpath.TitlePayPerUse); 

                //Verify the label TitleLastPosition
                AssertElementIsEqualTo(Xpath.TitlePayPerUse, Value.TitlePayPerUse);

                List<string> VINList = new List<string> { };
                List<string> NextMaintenanceValue = new List<string> { };
                
                //Evaluate the total number of vehicles 
                int NumVin = Int32.Parse (driver.FindElement(By.XPath(Xpath.TotVehicleinFilterBar)).Text);

                //put a maximum of 10 vins to check
                if (NumVin>10){
                    NumVin = 10; //
                    Console.WriteLine("The verification will be performed for the fist 10 vins instead of  " + driver.FindElement(By.XPath(Xpath.TotVehicleinFilterBar)).Text);
                }
                else
                {
                    Console.WriteLine("The verification will be performed for " + driver.FindElement(By.XPath(Xpath.TotVehicleinFilterBar)).Text+ " vins");

                }

                for (int i = 0; i < NumVin; i++)
                {
                    String VinToChoose = "//*[@id='widgetContainer39']//option[" + (i + 1) + "]";

                    ClickDropdownChoice(VinToChoose, (i + 1).ToString(), 1000);

                    //Wait spinner

                    //Verify vin data
                    AssertElementIsEqualTo(Xpath.VIN,Value.VIN);

                    AssertElementIsEqualTo(Xpath.Plate, Value.Plate);

                    AssertElementIsEqualTo(Xpath.Model, Value.Model);

                    AssertElementIsEqualTo(Xpath.Fuel, Value.Fuel);
                   try
                    {   //Verify presence of Discover more button
                        VerifyElement(Xpath.DiscoverMoreButton);
                        if (i==0)
                        {  
                            //verify pop-up of discover more
                            ClickDropdownChoice(Xpath.DiscoverMoreButton, Value.DiscoverMoreButton, 1000);
                            AssertElementIsEqualTo(Xpath.TitlePopUP, Value.TitlePayPerUse);

                            VerifyElement(Xpath.EmailField); 
                            VerifyElement(Xpath.PhoneField);

                            //close pop-up of discover more
                            ClickDropdownChoice(Xpath.DiscoverMoreButton, Value.DiscoverMoreButton, 1000);


                        }


                   }
                    catch 
                   {
                      //verify the data of pay per use


                   }
                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

        }
    }
}
