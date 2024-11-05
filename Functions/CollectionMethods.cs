using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using myiveco_selenium.Xpath;
using myiveco_selenium.Filters;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.Net;


namespace myiveco_selenium.Functions
{
    public class CollectionMethods
    {
        public IWebDriver driver;
        public IJavaScriptExecutor js;
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        static string enviroment_runsettings = TestContext.Parameters["enviroment"].ToString();
        static string OcpApimSubscriptionKey_runsettings = TestContext.Parameters["OcpApimSubscriptionKey"].ToString();

        public void OpenSectionMenu(String XpathMenu, String XpathSection, String ValueSection, int Timer)
        {
            //Open Menu
            JSClickDropdownChoice(XpathMenu, "Menu", 2000);

            //Verify the presence of Section
            JSFindElementAndClick(XpathSection, ValueSection, Timer);

            //Open Menu
            JSClickDropdownChoice(XpathMenu, "Menu", 1000);
            JSClickDropdownChoice(XpathMenu, "Menu", 1000);
        }

        public void OpenSecondSectionMenu(String XpathMenu, String XpathSection, String ValueSection, String XpathSection2, String ValueSection2, int Timer)
        {
            //Open Menu
            JSClickDropdownChoice(XpathMenu, "Menu", 2000);

            //Click on first Section
            JSClickDropdownChoice(XpathSection, ValueSection, Timer);

            //Click on second Section
            JSClickDropdownChoice(XpathSection2, ValueSection2, Timer);

            //Open Menu
            JSClickDropdownChoice(XpathMenu, "Menu", 1000);
            JSClickDropdownChoice(XpathMenu, "Menu", 1000);
        }

        public void ScrollFunction()
        {
            for (int pageLength = 0; pageLength < 6000; pageLength += 250)
            {
                System.Threading.Thread.Sleep(2000);
                js.ExecuteScript("window.scrollTo(0," + pageLength + ")");

            }
            js.ExecuteScript("window.scrollTo(0,0)");
        }


        public void Scroll(String XpathTitle)
        {
            js.ExecuteScript("document.body.style.zoom = '0.67'");

            for (int pageLength = 0; pageLength < 4000; pageLength += 250)
            {
                System.Threading.Thread.Sleep(2000);
                js.ExecuteScript("window.scrollTo(0," + pageLength + ")");
                try
                {
                    driver.FindElement(By.XPath(XpathTitle));
                    int scrollpix = pageLength + 250;
                    js.ExecuteScript("window.scrollTo(0," + scrollpix + ")");
                    Console.WriteLine("Scroll stopped at" + scrollpix + "pixel");
                    break;
                }
                catch
                {
                }
            }
        }


        public void ScrollDown()
        {
            js.ExecuteScript("document.body.style.zoom = '0.70'");
            // Scrolling to the end
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            System.Threading.Thread.Sleep(3000);
            // Scroll to up the page
            js.ExecuteScript("window.scrollTo(0, 0)");
            // Scrolling to the end
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            System.Threading.Thread.Sleep(3000);
            // Scroll to up the page
            js.ExecuteScript("window.scrollTo(0, 0)");
        }

        public int VerifyData()
        {
            int NoDataFlag = 0;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='scoreSummaryError']//label[contains(text(),'Data not available')]")));
                Console.WriteLine("The default dashboard hasn't any data: no check can be performed on default values");
                NoDataFlag = 1;
            }
            catch
            {
                Console.WriteLine("The default dashboard has data: all checks can be performed on default values");
            }
            return NoDataFlag;
        }

        public void FilterData(String weburl_runsettings, String FiltersDashboard, String FiltersFrequency, String FiltersVehicle_list, String FiltersFrom_date, String FiltersTo_date, String FiltersVehicle_type, String FiltersFuel_type)
        {
            try
            {
                // Navigate to filtered data
                driver.Navigate().GoToUrl(weburl_runsettings + "dashboard?db=" + FiltersDashboard + "&frequency=" + FiltersFrequency + "&vehicleList=" + FiltersVehicle_list + "&from=" + FiltersFrom_date + "&to=" + FiltersTo_date + "&vehicleType=" + FiltersVehicle_type + "&fuelType=" + FiltersFuel_type);


                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }


        public void GoToUrl(String weburl_runsettings )
            {
                try
                {
                    // Navigate to filtered data
                    driver.Navigate().GoToUrl(weburl_runsettings);
                    System.Threading.Thread.Sleep(1000);


                   //Click two times on Menu
                   JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                   JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                }
                catch (Exception e)
                {
                    GetScreenshotAndPrintError(e);
                }
            }


            // Method to refresh the page and check if an element is visible (through Xpath)
            public void RefreshCheck(String XpathToCheck)
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                        wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathToCheck)));
                        break;
                    }
                    catch
                    {
                        driver.Navigate().Refresh();
                        Console.WriteLine("Repeating refresh");

                        if (i == 3)
                        {
                            Assert.Fail("3 refresh, page not loaded, fail test");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }

        // Method to verify if an element identified through the Xpath "XpathVar" contains a specific test "ValueVar" and then click on it
        public void FindElementAndClick(String XpathVar, String ValueVar, int timer)
        {
            Console.WriteLine("Start to verify presence of element with Xpath: " + XpathVar);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathVar)));
            Console.WriteLine("Element found with Xpath: " + XpathVar);
            Assert.That(driver.FindElement(By.XPath(XpathVar)).Text, Is.EqualTo(ValueVar));
            Console.WriteLine("Assert element value coherent with expectation: " + ValueVar);
            IWebElement ElementToClick = driver.FindElement(By.XPath(XpathVar));
            ElementToClick.Click();
            Console.WriteLine("Clicking on button: " + ValueVar + ", by Xpath: " + XpathVar);
            System.Threading.Thread.Sleep(timer);
        }

        // Method to verify if an element identified through the Xpath "XpathVar" contains a specific test "ValueVar" and then click on it in JAVASCRIPT
        public void JSFindElementAndClick(String XpathVar, String ValueVar, int timer)
        {
            Console.WriteLine("Start to verify presence of element with Xpath: " + XpathVar);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathVar)));
            Console.WriteLine("Element found with Xpath: " + XpathVar);
            Assert.That(driver.FindElement(By.XPath(XpathVar)).Text, Is.EqualTo(ValueVar));
            Console.WriteLine("Assert element value coherent with expectation: " + ValueVar);
            IWebElement ElementToClick = driver.FindElement(By.XPath(XpathVar));
            js.ExecuteScript("arguments[0].click();", ElementToClick);
            Console.WriteLine("Clicking on button: " + ValueVar + ", by Xpath: " + XpathVar);
            System.Threading.Thread.Sleep(timer);
        }

        // Method to verify if an element identified through the Xpath "XpathVar" contains a specific test "ValueVar"
        public void AssertElementIsEqualTo(String XpathVar, String ValueVar)
        {
            Console.WriteLine("Start to verify presence of element: " + ValueVar);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathVar)));
            Assert.That(driver.FindElement(By.XPath(XpathVar)).Text, Is.EqualTo(ValueVar));
            Console.WriteLine("Verified presence of " + ValueVar + " label");
        }

        // Method to verify if an element is visible through the Xpath "XpathVar" 
        public void VerifyElement(String XpathVar)

        {
            Console.WriteLine("Start to verify presence of element with xpath: " + XpathVar);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathVar)));
            Console.WriteLine("Verified presence of element by xpath " + XpathVar);
        }

        // Method to click and insert a text "ValueToInsert" onto and element identified through the Xpath "XpathVar"
        public void FindElementClickAndSendText(String XpathVar, String ValueToInsert, int timer)
        {
            Console.WriteLine("Start to verify presence of element with xpath: " + XpathVar);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathVar)));
            IWebElement ElementToClick = driver.FindElement(By.XPath(XpathVar));
            ElementToClick.Click();
            System.Threading.Thread.Sleep(timer);
            Console.WriteLine("Clicking on element by Xpath: " + XpathVar);
            ElementToClick.SendKeys(ValueToInsert);
            Console.WriteLine("Inserting value: " + ValueToInsert);
            System.Threading.Thread.Sleep(timer);
        }

        // Method to click on dropdown choice "ValueToSelect" by Xpath "XpathVar"
        public void JSClickDropdownChoice(String XpathVar, String ValueToInsert, int timer)
        {
            Console.WriteLine("Start to verify presence of element with xpath: " + XpathVar);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathVar)));
            IWebElement DropdownChoice = driver.FindElement(By.XPath(XpathVar));
            js.ExecuteScript("arguments[0].click();", DropdownChoice);
            System.Threading.Thread.Sleep(timer);
            Console.WriteLine("Verify the presence and click on: " + ValueToInsert);
        }

        // Method to click on dropdown choice "ValueToSelect" by Xpath "XpathVar"
        public void ClickDropdownChoice(String XpathVar, String ValueToInsert, int timer)
        {
            Console.WriteLine("Start to verify presence of element with xpath: " + XpathVar);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathVar)));
            Console.WriteLine("Found element by xpath: " + XpathVar);
            IWebElement VehicleDropdownChoice = driver.FindElement(By.XPath(XpathVar));
            VehicleDropdownChoice.Click();
            Console.WriteLine("Selecting first dropdown value proposed by inserting: " + ValueToInsert);
            System.Threading.Thread.Sleep(timer);

        }

        public void AssertValueIsEqualTo(String XpathVar, String ValueVar)
        {
            Console.WriteLine("Start to verify presence of element : " + ValueVar);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathVar)));
            Console.WriteLine("Attribute = " + driver.FindElement(By.XPath(XpathVar)).GetAttribute("value"));
            Assert.That(driver.FindElement(By.XPath(XpathVar)).GetAttribute("value").ToString(), Is.EqualTo(ValueVar));
            Console.WriteLine("Verified presence of " + ValueVar + " label");
        }

        public string RetrieveAttribute(String XpathVar)
        {
            Console.WriteLine("Start to verify presence of element with xpath: " + XpathVar);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathVar)));
            Console.WriteLine("Attribute = " + driver.FindElement(By.XPath(XpathVar)).GetAttribute("value"));
            String ValueVar = driver.FindElement(By.XPath(XpathVar)).GetAttribute("value");
            return ValueVar;
        }

        public void ExpandShadowElement(String TagName, int orderElement, String CssSelector)
        {
            Console.WriteLine("Start to verify presence of element shadow with tagName " + TagName);
            var ShadowItem = driver.FindElements(By.TagName(TagName));
            Console.WriteLine("Element shadow with tagName " + TagName + " and with " + ShadowItem.Count + " elements");

            var shadowRoot = ShadowItem[orderElement].GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            Console.WriteLine("Verify the element by CssSelector:" + CssSelector);

        }

        public void ExpandShadowElementAndClick(String TagName, int orderElement, String CssSelector)
        {
            Console.WriteLine("Start to verify presence of element shadow with tagName " + TagName);
            var ShadowItem = driver.FindElements(By.TagName(TagName));
            Console.WriteLine("Element shadow with tagName " + TagName + " and with " + ShadowItem.Count + " elements");

            var shadowRoot = ShadowItem[orderElement].GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            js.ExecuteScript("arguments[0].click();", shadowRootElement);
            Console.WriteLine("Click on the element");

        }

        public void ExpandShadowElementClickClearAndSendKeys(String TagName, int orderElement, String CssSelector, String Value)
        {
            Console.WriteLine("Start to verify presence of element shadow with tagName " + TagName);
            var ShadowItem = driver.FindElements(By.TagName(TagName));
            Console.WriteLine("Element shadow with tagName " + TagName + " and with " + ShadowItem.Count + " elements");

            var shadowRoot = ShadowItem[orderElement].GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            js.ExecuteScript("arguments[0].click();", shadowRootElement);
            Console.WriteLine("Click on the element");

            // Insert Test VIN
            shadowRootElement.Clear();
            shadowRootElement.SendKeys(Value);
            Console.WriteLine("Clear fields and Inserted test: " + Value);

        }

        public void ExpandShadowElementClickClearAndSendKeysNew(String Xpath, String CssSelector, String Value)
        {
            Console.WriteLine("Start to verify presence of element: " + Xpath);
            var ShadowItem = driver.FindElement(By.XPath(Xpath));
            Console.WriteLine("Element with xpath " + Xpath + "verified");

            var shadowRoot = ShadowItem.GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            js.ExecuteScript("arguments[0].click();", shadowRootElement);
            Console.WriteLine("Click on the element");

            // Insert Test VIN
            shadowRootElement.Clear();
            shadowRootElement.SendKeys(Value);
            Console.WriteLine("Clear fields and Inserted test: " + Value);

        }

        public void ExpandShadowElementClickNew(String Xpath, String CssSelector, String Value)
        {
            Console.WriteLine("Start to verify presence of element: " + Xpath);
            var ShadowItem = driver.FindElement(By.XPath(Xpath));
            Console.WriteLine("Element with xpath " + Xpath + " verified");

            var shadowRoot = ShadowItem.GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            js.ExecuteScript("arguments[0].click();", shadowRootElement);
            Console.WriteLine("Click on the element: + "+ Value);

        }

        public void ExpandShadowElementAndClear(String TagName, int orderElement, String CssSelector)
        {
            Console.WriteLine("Start to verify presence of element shadow with tagName " + TagName);
            var ShadowItem = driver.FindElements(By.TagName(TagName));
            Console.WriteLine("Element shadow with tagName " + TagName + " and with " + ShadowItem.Count + " elements");

            var shadowRoot = ShadowItem[orderElement].GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            js.ExecuteScript("arguments[0].click();", shadowRootElement);
            Console.WriteLine("Click on the element");

            // Insert Test VIN
            shadowRootElement.Clear();


        }
        public void ExpandShadowElementClickAndSendKeys(String TagName, int orderElement, String CssSelector, String Value)
        {
            Console.WriteLine("Start to verify presence of element shadow with tagName " + TagName);
            var ShadowItem = driver.FindElements(By.TagName(TagName));
            Console.WriteLine("Element shadow with tagName " + TagName + " and with " + ShadowItem.Count + " elements");

            var shadowRoot = ShadowItem[orderElement].GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            js.ExecuteScript("arguments[0].click();", shadowRootElement);
            Console.WriteLine("Click on the element");

            shadowRootElement.SendKeys(Value);
            Console.WriteLine("Inserted test: " + Value);
        }

        public void ExpandShadowElementClickXpath(String Xpath, String CssSelector)
        {
            Console.WriteLine("Start to verify presence of element: " + Xpath);
            var ShadowItem = driver.FindElement(By.XPath(Xpath));
            Console.WriteLine("Element with xpath " + Xpath + " verified");

            var shadowRoot = ShadowItem.GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            js.ExecuteScript("arguments[0].click();", shadowRootElement);
            Console.WriteLine("Click on the element");

        }

        public void ExpandShadowElementClickAndSendKeysSTEP4(String Xpath, String CssSelector, String Value)
        {
            Console.WriteLine("Start to verify presence of element: " + Xpath);
            var ShadowItem = driver.FindElement(By.XPath(Xpath));
            Console.WriteLine("Element with xpath " + Xpath + "verified");

            var shadowRoot = ShadowItem.GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            js.ExecuteScript("arguments[0].click();", shadowRootElement);
            Console.WriteLine("Click on the element");

            shadowRootElement.SendKeys(Value);
            Console.WriteLine("Inserted test: " + Value[0]);
        }
        public void ShadowAssertValueIsEqualTo(String TagName, int orderElement, String CssSelector, String ValueVar)
        {
            Console.WriteLine("Start to verify presence of element shadow with tagName " + TagName);
            var ShadowItem = driver.FindElements(By.TagName(TagName));
            Console.WriteLine("Element shadow with tagName " + TagName + " and with " + ShadowItem.Count + " elements");
            var shadowRoot = ShadowItem[orderElement].GetShadowRoot();
            var shadowRootElement = shadowRoot.FindElement(By.CssSelector(CssSelector));

            Console.WriteLine("Attribute = " + shadowRootElement.GetAttribute("value"));
            Assert.That(shadowRootElement.GetAttribute("value").ToString(), Is.EqualTo(ValueVar));
            Console.WriteLine("Verified presence of " + ValueVar);
        }

        public void GetScreenshotAndPrintError(Exception e)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            String ScreenShotName = "ErrorScreenshot_" + DateTime.Now.ToString("HHmmss") + ".png";
            ss.SaveAsFile(ScreenShotName, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(ScreenShotName, "Screenshot for failure analysis");
            Console.WriteLine("Test failed");
            Console.WriteLine(e.StackTrace);
            Assert.Fail("Test failed. See test output and attachment for analysis");
        }
        public static bool CheckFileDownloaded(string filename)
        {
            bool exportFileExist = false;
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string downloadFile in filePaths)
            {
                if (downloadFile.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(downloadFile);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                    {
                        exportFileExist = true;
                        String name = thisFile.FullName;
                        Console.WriteLine("The complete name of the file is: " + name);
                        Console.WriteLine("File has been correctly downloaded");
                        File.Delete(downloadFile);
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("Downloaded file has been deleted");
                        break;
                    }


                }
            }
            return exportFileExist;
        }

        public string ContractRefenceDownloaded(string filename)
        {

            string contractrefence = string.Empty;
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string downloadFile in filePaths)
            {
                if (downloadFile.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(downloadFile);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                    {
                        contractrefence = thisFile.FullName.Replace(System.Environment.GetEnvironmentVariable("USERPROFILE"), "").Replace("\\Downloads\\", "").Replace(DateTime.Today.ToString("yyyy-MM-d"), "").Replace("_IVECO-ON_", "").Replace(".pdf", "");
                        Console.WriteLine("The complete name of the file is: " + thisFile.FullName);
                        Console.WriteLine("The contract reference name of the file is: " + contractrefence);
                    }
                }
            }
            return contractrefence;
        }

        public int WaitingSpinner(String XpathLoader, int timer)
        {
            WebDriverWait waitLoader = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            int loaderVisible = 1;
            while (loaderVisible <= 15)
            {
                try
                {
                    System.Threading.Thread.Sleep(timer);
                    waitLoader.Until(ExpectedConditions.ElementExists(By.XPath(XpathLoader)));
                }
                catch
                {
                    break;
                }
                loaderVisible++;
            }
            int timerwait = (loaderVisible * (timer / 1000));
            Console.WriteLine("Waiting for " + timerwait + " seconds ");

            return timerwait;
        }

        public List<string> vehicleType()

        {
            List<string> VehicleType = new List<string>(new string[] { "Trucks", "Daily", "Heavy Bus", "T-Way" });
            List<string> FuelType = new List<string>(new string[] { "Diesel", "NP" });

            return VehicleType;
        }

        /*
        public void DashboardChoice(String Dashboard)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                // Navigate to choose dashboard
                driver.Navigate().GoToUrl(weburl_runsettings + "dashboard?db=" + Dashboard);
                Console.WriteLine("Navigating to dashboard " + Dashboard);
                System.Threading.Thread.Sleep(2000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 2000);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

        }*/

        public void DashboardChoice(String Dashboard)
        {
            try
            {
                switch (Dashboard)
                {
                    case "11":
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='pfe-accordion-dashboard']//h5[contains (text (),'Trucks')]", "Trucks", 1000);
                        JSClickDropdownChoice("//*[@id='shoulder-left']//a[@href='/dashboard?db=11']", "Trucks Diesel", 1000);
                        Console.WriteLine("Heavy Diesel Selected");
                        //Adding two click on menu 
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                        break;

                    case "12":
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='pfe-accordion-dashboard']//h5[contains (text (),'Trucks')]", "Trucks", 1000);
                        JSClickDropdownChoice("//*[@id='shoulder-left']//a[@href='/dashboard?db=12']", "Trucks NP", 1000);
                        Console.WriteLine("Heavy NP Selected");
                        //Adding two click on menu 
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                        break;

                    case "21":
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='pfe-accordion-dashboard']//h5[contains (text (),'Daily')]", "Daily", 1000);
                        JSClickDropdownChoice("//*[@id='shoulder-left']//a[@href='/dashboard?db=21']", "Daily Diesel", 1000);
                        Console.WriteLine("Light Diesel Selected");
                        //Adding two click on menu 
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                        break;

                    case "22":
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='pfe-accordion-dashboard']//h5[contains (text (),'Daily')]", "Daily", 1000);
                        JSClickDropdownChoice("//*[@id='shoulder-left']//a[@href='/dashboard?db=22']", "Daily NP", 1000);
                        Console.WriteLine("Light NP Selected");
                        //Adding two click on menu 
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                        break;

                    case "23":
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='pfe-accordion-dashboard']//h5[contains (text (),'Daily')]", "Daily", 1000);
                        JSClickDropdownChoice("//*[@id='shoulder-left']//a[@href='/dashboard?db=23']", "Daily Electric", 1000);
                        Console.WriteLine("Light Electric Selected");
                        //Adding two click on menu 
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                        break;

                    case "31":
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='pfe-accordion-dashboard']//h5[contains (text (),'Heavy Bus')]", "Heavy Bus", 1000);
                        JSClickDropdownChoice("//*[@id='shoulder-left']//a[@href='/dashboard?db=31']", "Heavy Bus Diesel", 1000);
                        Console.WriteLine("Heavy Bus Diesel Selected");

                        //Adding two click on menu 
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        break;

                    case "32":
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='pfe-accordion-dashboard']//h5[contains (text (),'Heavy Bus')]", "Heavy Bus", 1000);
                        JSClickDropdownChoice("//*[@id='shoulder-left']//a[@href='/dashboard?db=32']", "Heavy Bus NP", 1000);
                        Console.WriteLine("Heavy Bus NP Selected");

                        //Adding two click on menu 
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        break;

                    case "33":
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='pfe-accordion-dashboard']//h5[contains (text (),'Heavy Bus')]", "Heavy Bus", 1000);
                        JSClickDropdownChoice("//*[@id='shoulder-left']//a[@href='/dashboard?db=33']", "Heavy Bus Electric", 1000);
                        Console.WriteLine("Heavy Bus Electric Selected");

                        //Adding two click on menu 
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        break;

                    case "51":
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='pfe-accordion-dashboard']//h5[contains (text (),'T-Way')]", "T-Way", 1000);
                        JSClickDropdownChoice("//*[@id='shoulder-left']//a[@href='/dashboard?db=51']", "T-Way Diesel", 1000);
                        Console.WriteLine("Tway Diesel Selected");

                        //Adding two click on menu 
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        break;
                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

        }
        public void SendingNotification(String VIN, String NotificationID)
        {
            // Create a request using a URL that can receive a post.
            WebRequest request = WebRequest.Create("https://apiinternalmip-" + enviroment_runsettings + ".azure.cnhind.com/wti/v1/wti/controlroomalerts");

            // Set the Method property of the request to POST.
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            string postData = "[{ 	\"chassis\": \"" + VIN + "\",\"alerts\": [" + NotificationID + "]}]";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            //request.ContentType = "application/json";
            // Set the others headers
            request.Headers.Set("Content-Type", "application/json");
            request.Headers.Set("Ocp-Apim-Subscription-Key", OcpApimSubscriptionKey_runsettings);
            request.Headers.Set("Caller", "WTI");
            request.Headers.Set("TraceId", "cv");
            request.Headers.Set("actor", "cv");
            request.Headers.Set("username", "user_tech@myiveco.com");

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
            }

            // Close the response.
            response.Close();

        }
    }
}