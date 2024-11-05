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
    public class Tutorial_Test: BaseClass
    {
        public void Tutorial(Xpath__Tutorial Xpath)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

                js.ExecuteScript("document.body.style.zoom = '0.40'");

                RefreshCheck(Xpath.Tutorial);

                // Verify the presence of Tutorial Section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Tutorial)));
                Console.WriteLine("Verified presence of Tutorial");

                //Open Tutorial Section
                JSClickDropdownChoice(Xpath.Tutorial, "Tutorial", 1000);

                //Open Menu
                JSClickDropdownChoice(Xpath.Menu, "Menu", 2000);
                JSClickDropdownChoice(Xpath.Menu, "Menu", 2000);

                // Verify presence of Menu Overview
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.WatchVideoButton1)));
                Console.WriteLine("Verify presence of Menu Overview");

                //Click on Watch button
                IWebElement WatchButton1 = driver.FindElement(By.XPath(Xpath.WatchVideoButton1));
                js.ExecuteScript("arguments[0].click();", WatchButton1);
                Console.WriteLine("Click on Watch button");
                System.Threading.Thread.Sleep(2000);

                //Verify the correct opening of video
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TutorialVideoContainer)));
                Console.WriteLine("Verify the correct opening of video");

  
                ExpandShadowElementAndClick("pfe-modal", 0, "[class=pfe-modal__close]");
                System.Threading.Thread.Sleep(3000);


                // Verify presence of Manage Profile
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.WatchVideoButton2)));
                Console.WriteLine("Verify presence of Manage Profile");

                //Click on Watch button
                IWebElement WatchButton2 = driver.FindElement(By.XPath(Xpath.WatchVideoButton2));
                js.ExecuteScript("arguments[0].click();", WatchButton2);
                Console.WriteLine("Click on Watch button");
                System.Threading.Thread.Sleep(2000);

                //Verify the correct opening of video
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TutorialVideoContainer)));
                Console.WriteLine("Verify the correct opening of video");

                //Click on Close video button
                ExpandShadowElementAndClick("pfe-modal", 0, "[class=pfe-modal__close]");
                System.Threading.Thread.Sleep(3000);

                // Verify presence of Permissions
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.WatchVideoButton3)));
                Console.WriteLine("Verify presence of Permissions");

                //Click on Watch button
                IWebElement WatchButton3 = driver.FindElement(By.XPath(Xpath.WatchVideoButton3));
                js.ExecuteScript("arguments[0].click();", WatchButton3);
                Console.WriteLine("Click on Watch button");
                System.Threading.Thread.Sleep(2000);

                //Verify the correct opening of video
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TutorialVideoContainer)));
                Console.WriteLine("Verify the correct opening of video");

                //Click on Close video button
                ExpandShadowElementAndClick("pfe-modal", 0, "[class=pfe-modal__close]");
                System.Threading.Thread.Sleep(3000);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
 }
