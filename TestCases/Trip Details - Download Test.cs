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

    public class TripDetails_Download_Test : BaseClassNoHead
    {
        public TripDetails_Download_Test(Account Account) : base(Account) { }
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void TripDetailsDownloadFlow(Xpath__Trip_Details Xpath, Values__Widget_Export Value)
        {
            try
            {
                List<string> DashboardList = new List<string> { "21", "22" };

                foreach (string Dashboard in DashboardList)
                {
                    Console.WriteLine("\r\n" + "Starting test for Dashbord " + Dashboard);
                    // Wait definition for element
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));


                    // Navigate to dashboard
                    DashboardChoice(Dashboard);

                    RefreshCheck(Xpath.FuelSavingScorePath);
                    Console.WriteLine("Verified presence of dashboard opened");

                    //Scroll website
                    Scroll(Xpath.TripDetailsTab);
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TripDetailsTab)));
                    var widgetPosition = driver.FindElement(By.XPath(Xpath.TripDetailsTab));
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);

                    // Verify the presence of Trip Details tab
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TripDetailsTab)));
                    Assert.That(driver.FindElement(By.XPath(Xpath.TripDetailsTab)).Text, Is.EqualTo(Value.TripDetailsTab));
                    Console.WriteLine("Verified presence of Trip Details tab");

                    DownloadExport(Xpath.ExportDataGrey, Xpath.ExportDataTripDetails);

                    // Check presence of export file and delete it
                    Console.WriteLine("Check if file is availbale in /Download section");
                    bool TripDetailsExcel = CheckFileDownloaded(Value.TripDetailsExcel);
                    Assert.That(TripDetailsExcel == true);
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
