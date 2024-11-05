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
    public class Settings_Section_Privacy_Settings: BaseClass
    {
        public void SettingsSectionPrivacySettings(Xpath__Settings Xpath, Values__Settings Value)
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

                // Verify the presence of PrivacySettings
                VerifyElement(Xpath.PrivacySettings);

                //Open PrivacySettings
                JSClickDropdownChoice(Xpath.PrivacySettings, "Privacy settings button", 100);

                // Verify Privacy Notice
                AssertElementIsEqualTo(Xpath.PrivacyNotice, Value.PrivacyNotice);

                // Verify Marketing Activities
                AssertElementIsEqualTo(Xpath.MarketingActivities, Value.MarketingActivities);

                // Verify MarketingThirdParties
                AssertElementIsEqualTo(Xpath.MarketingThirdParties, Value.MarketingThirdParties);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}
