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
    public class MyDaily_Widget: BaseClass
    {
       
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public List<List<string>> MyDailyWidget(Xpath__MyDaily Xpath, Values__MyDaily Value)
        {
            List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { });
            try
            { 
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Scroll website
                Scroll(Xpath.MyDaily);

             
                List<string> VINList = new List<string> {};
                List<string> NextMaintenanceValue = new List<string> { };

                //Evaluate the total number of vehicles 
                int NumVin = Int32.Parse(driver.FindElement(By.XPath(Xpath.TotVehicleinFilterBar)).Text);

                //put a maximum of 10 vins to check
                if (NumVin > 10)
                {
                    NumVin = 10; //
                    Console.WriteLine("The verification will be performed for the fist 10 vins instead of  " + driver.FindElement(By.XPath(Xpath.TotVehicleinFilterBar)).Text);
                }
                else
                {
                    Console.WriteLine("The verification will be performed for " + driver.FindElement(By.XPath(Xpath.TotVehicleinFilterBar)).Text + " vins");

                }

                //int pass = 0;
                for (int i = 0; i < NumVin; i++)
                {
                    String VinToChoose = "//*[@id='widgetContainer21']//option["+ (i+1) +"]";
                    
                    ClickDropdownChoice(VinToChoose,(i+1).ToString(), 10000);
                    
                    //Wait spinner
                
                    String CompleteNextMaintenance = driver.FindElement(By.XPath(Xpath.NextMaintenance)).Text;
                    int characters = 18;//number of characters of "Next maintenance: "
                    String NextMaintenance = CompleteNextMaintenance.Remove(0,characters); //To Remove 

                    NextMaintenanceValue.Add(NextMaintenance);

                    VINList.Add(driver.FindElement(By.XPath(Xpath.VinCode)).Text);

                    if (NextMaintenanceValue[i]!="N/A")
                    {
                        //pass = 1;
                        Console.WriteLine("The value for next maintenance for vin " + VINList[i] + " is " + NextMaintenanceValue[i]);
                    }
                    else
                    {
                        Console.WriteLine("The value for next maintenance for vin "+VINList[i]+" is "+ NextMaintenanceValue[i]);
                    }
                }

                Vehicles = new List<List<string>>(new List<string>[] { VINList, NextMaintenanceValue });
               
                /*if (pass == 0)
                {
                   Console.WriteLine("All the values for next maintenance are N/A: so the test fails");
                   Assert.Fail();
                    
                }*/

                return Vehicles;
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
                return Vehicles;
            }
          
        }
        public void VehicleSection(Xpath__Vehicles Xpath, Values__Vehicles Value, List<List<string>> Vehicles)
        {
            try
            {
            driver.Navigate().GoToUrl(weburl_runsettings + "fleets");
            Console.WriteLine("Navigating to: fleets");
            System.Threading.Thread.Sleep(2000);

            RefreshCheck(Xpath.YourVehicleHeavy);

            JSFindElementAndClick(Xpath.LightTab, Value.LightTab, 4000);
          
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
                
            }
        }
    }
}