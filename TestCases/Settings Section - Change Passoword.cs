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
    public class Settings_Section_Change_Password: BaseClass
    {
        public void SettingsSectionChangePassword(Xpath__Settings Xpath, Values__Settings Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                js.ExecuteScript("document.body.style.zoom = '0.40'");

                // Verify the presence of Account Section
                VerifyElement(Xpath.Account);

                //Open Account
                JSClickDropdownChoice(Xpath.Account, "Account button", 100);

                // Verify the presence of Manage profile section
                AssertElementIsEqualTo(Xpath.ManageProfile, Value.ManageProfile);

                //Open Manage profile section
                JSClickDropdownChoice(Xpath.ManageProfile, "Manage profile button", 100);

                // Verify Click here button
                VerifyElement(Xpath.ClickHere);

                //Click on Click here button
                JSClickDropdownChoice(Xpath.ClickHere, "Click here button", 100);

                // Verify Old password:REMOVED for B2C
                //wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.OldPassword)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.OldPassword)).Text, Is.EqualTo(Value.OldPassword));
                //Console.WriteLine("Verified presence of Old PAssword field");

                // Verify New password
                AssertElementIsEqualTo(Xpath.NewPassword, Value.NewPassword);

                // Verify Confirm New password
                AssertElementIsEqualTo(Xpath.ConfirmNewPassword, Value.ConfirmNewPassword);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
 }
