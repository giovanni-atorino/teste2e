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

    public class Ranking_Download_Test : BaseClassNoHead
    {
       
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void RankingDownloadFlow(Xpath__Ranking Xpath, Values__Widget_Export Value)
        {
            try
            {
                List<string> DashboardList = new List<string> { "11", "12", "51" };

                foreach (string Dashboard in DashboardList)
                {
                    Console.WriteLine("\r\n" + "Starting test for Dashbord " + Dashboard);
                    // Wait definition for element
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                    // Wait until dashboard is visible
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                    // Navigate to filtered data
                    DashboardChoice(Dashboard);


                    if (Dashboard=="51")
                    {
                        Console.WriteLine("\r\n" + "On Dashbord "+ Dashboard + " there isn't ranking driver widget" );
                    }
                    
                    else
                    { 
                    //Scroll website
                    Scroll(Xpath.DriversRankingTab);
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DriversRankingTab)));
                    var widgetPosition = driver.FindElement(By.XPath(Xpath.DriversRankingTab));
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);

                    // Verify the presence of Drivers Ranking tab
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DriversRankingTab)));
                    Assert.That(driver.FindElement(By.XPath(Xpath.DriversRankingTab)).Text, Is.EqualTo(Value.DriversRankingTab));
                    Console.WriteLine("Verified presence of Drivers Ranking tab");

                    Console.WriteLine("Download export for driver ranking");
                    DownloadExport(Xpath.ExportDataGreyDrivers, Xpath.ExportDataDrivers);

                    // Check presence of export file and delete it
                    Console.WriteLine("Check if file is availbale in /Download section");
                    bool DriversRankingExcel = CheckFileDownloaded(Value.DriversRankingExcel);
                    Assert.That(DriversRankingExcel == true);
                    Console.WriteLine("Check completed");
                    }

                    if (Dashboard == "51")
                    {
                        Scroll(Xpath.VehiclesRankingTab);
                    }

                    else
                    { 
                    }

                    //Click on Vehicles Ranking tab
                    IWebElement VehiclesRankingTab = driver.FindElement(By.XPath(Xpath.VehiclesRankingTab));
                    js.ExecuteScript("arguments[0].click();", VehiclesRankingTab);
                    Console.WriteLine("Click on Vehicles Ranking Tab");
                    System.Threading.Thread.Sleep(1000);

                    Console.WriteLine("Download export for vehicles ranking");
                    DownloadExport(Xpath.ExportDataGreyVehicles, Xpath.ExportDataVehicles);

                    // Check presence of export file and delete it
                    Console.WriteLine("Check if file is availbale in /Download section");
                    bool VehiclesRankingExcel = CheckFileDownloaded(Value.VehiclesRankingExcel);
                    Assert.That(VehiclesRankingExcel == true);
                    Console.WriteLine("Check completed");
                    
                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

            driver.Close();
        }
        public void RankingDownloadFlowHeavyBus(Xpath__Ranking Xpath, Values__Widget_Export Value)
        {
            try
            {
                List<string> DashboardList = new List<string> { "31", "32" };

                foreach (string Dashboard in DashboardList)
                {
                    Console.WriteLine("\r\n" + "Starting test for Dashbord " + Dashboard);
                    // Wait definition for element
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                    // Wait until dashboard is visible
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                    // Navigate to filtered data
                    DashboardChoice(Dashboard);
                  
                    Scroll(Xpath.VehiclesRankingTab);

                    //Click on Vehicles Ranking tab
                    IWebElement VehiclesRankingTab = driver.FindElement(By.XPath(Xpath.VehiclesRankingTab));
                    js.ExecuteScript("arguments[0].click();", VehiclesRankingTab);
                    Console.WriteLine("Click on Vehicles Ranking Tab");
                    System.Threading.Thread.Sleep(1000);

                    Console.WriteLine("Download export for vehicles ranking");
                    DownloadExport(Xpath.ExportDataGreyVehicles, Xpath.ExportDataVehicles);

                    // Check presence of export file and delete it
                    Console.WriteLine("Check if file is availbale in /Download section");
                    bool VehiclesRankingExcel = CheckFileDownloaded(Value.VehiclesRankingExcel);
                    Assert.That(VehiclesRankingExcel == true);
                    Console.WriteLine("Check completed");
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
