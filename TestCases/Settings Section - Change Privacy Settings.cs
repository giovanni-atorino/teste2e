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
    public class Settings_Section_Change_Privacy_Settings: BaseClass
    {
        public void SettingsSectionChangePrivacySettings(Xpath__Settings Xpath, Values__Settings Value)
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

                // Verify Marketing Activities
                AssertElementIsEqualTo(Xpath.MarketingActivities, Value.MarketingActivities);

                //Change marketing activities 
                JSClickDropdownChoice(Xpath.RadioAgreeMarketingActivities, "Agree for Marketing Activities", 500);

                //Click on Save 
                JSClickDropdownChoice(Xpath.Save, "Save button", 100);

                //Verify presence of Successuful Privacy Save
                VerifyElement(Xpath.SuccessufulPrivacySave);

                // Verify the presence of Account Section
                VerifyElement(Xpath.Account);

                //Open Account
                JSClickDropdownChoice(Xpath.Account, "Account button", 100);

                // Verify the presence of PrivacySettings
                VerifyElement(Xpath.PrivacySettings);

                //Open PrivacySettings
                JSClickDropdownChoice(Xpath.PrivacySettings, "Privacy settings button", 100);

                // Verify the Changing of marketing activities to "Agree"
                VerifyElement(Xpath.RadioAgreeCheckedMarketingActivities);

                //Change marketing activities 
                JSClickDropdownChoice(Xpath.RadioNotAgreeMarketingActivities, "Not Agree for Marketing Activities", 500);

                //Click on Save 
                JSClickDropdownChoice(Xpath.Save, "Save button", 100);

                //Verify presence of Successuful Privacy Save
                VerifyElement(Xpath.SuccessufulPrivacySave);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}
