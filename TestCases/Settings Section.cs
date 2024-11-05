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
    public class Settings_Section : BaseClass
    {
        public void SettingsSection(Xpath__Settings Xpath, Values__Settings Value)
        {
            try
            {
                /*
                static String GetTimestamp(DateTime value)
                {
                    return value.ToString("yyyyMMddHHmmssffff");
                }
                */

                var timestamp = DateTime.Now.ToLocalTime();
                //String ts = GetTimestamp(DateTime.Now);
                Console.WriteLine("timestamp = " + timestamp);

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                js.ExecuteScript("document.body.style.zoom = '0.40'");

                // Verify the presence of Account Section
                VerifyElement(Xpath.Account);

                //Open Account
                JSClickDropdownChoice(Xpath.Account, "Account button", 1000);

                // Verify the presence of Manage profile section
                AssertElementIsEqualTo(Xpath.ManageProfile, Value.ManageProfile);

                //Open Manage profile section
                JSClickDropdownChoice(Xpath.ManageProfile, "Manage profile button", 3000);

                //Verify UserData: Name
                AssertElementIsEqualTo(Xpath.NameLabel, Value.Name);

                // Verify UserData: Surname
                AssertElementIsEqualTo(Xpath.SurnameLabel, Value.Surname);

                // Verify UserData: Notification email
                AssertElementIsEqualTo(Xpath.NotificationEmailLabel, Value.NotificationEmail);

                // Verify UserData: Prefix
                VerifyElement(Xpath.PrefixLabel);

                // Verify UserData: Mobile
                AssertElementIsEqualTo(Xpath.MobileUserLabel, Value.Mobile);

                // Verify UserData: Country
                VerifyElement(Xpath.CountryUserLabel);

                // Verify CompanyData: Country
                VerifyElement(Xpath.CountryCompanyLabel);

                // Verify CompanyData: VAT Number
                AssertElementIsEqualTo(Xpath.VATNumberLabel, Value.VATNumberLabel);

                // Verify CompanyData: Company
                AssertElementIsEqualTo(Xpath.CompanyLabel, Value.Company);

                // Verify CompanyData: Phone 
                AssertElementIsEqualTo(Xpath.PhoneCompanyLabel, Value.PhoneCompanyLabel);

                // Verify CompanyData: City
                AssertElementIsEqualTo(Xpath.CityLabel, Value.City);

                // Verify CompanyData: ZIP
                AssertElementIsEqualTo(Xpath.ZIPLabel, Value.ZIP);

                // Verify CompanyData: Address
                AssertElementIsEqualTo(Xpath.AddressLabel, Value.Address);

                // Verify Site preferences: Language
                AssertElementIsEqualTo(Xpath.LanguageLabel, Value.Language);

                // Verify Site preferences: Fuel Consumption Units Diesel
                AssertElementIsEqualTo(Xpath.FuelConsumptionUnitsDieselLabel, Value.FuelConsumptionUnitsDiesel);

                // Verify Site preferences: Fuel Consumption Units NP
                AssertElementIsEqualTo(Xpath.FuelConsumptionUnitsNPLabel, Value.FuelConsumptionNPDiesel);

                // Verify Site preferences: Consumption Units Electric
                AssertElementIsEqualTo(Xpath.EnergyConsumptionUnitsElectricLabel, Value.EnergyConsumptionUnitsElectric);

                // Verify Site preferences: Timezone
                AssertElementIsEqualTo(Xpath.TimezoneLabel, Value.Timezone);

                // Verify Emails settings
                AssertElementIsEqualTo(Xpath.EmailsSettings, Value.EmailsSettings);

                /**
                // Verify Report Settings - Smart Report: Heavy Vehicles Dropdown
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesDropdownSmartHeavy)));
                Console.WriteLine("Smart Report: verified presence of Heavy Vehicles Dropdown");

                // Verify Report Settings - Smart Report: Frequency Dropdown for Heavy Vehicles
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FrequenciesSmartHeavy)));
                Console.WriteLine("Smart Report: verified presence of Frequency for Heavy Vehicles ");

                // Verify Report Settings - Smart Report: Vehicles Maintenance Alert for heavy Diesel vehicles
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesMaintenanceAlertDiesel)));
                Console.WriteLine("Smart Report: verified presence of Vehicles Maintenance Alert for heavy Diesel vehicles ");

                // Verify Report Settings - Smart Report: Vehicles Maintenance Alert for heavy Gas vehicles
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesMaintenanceAlertGas)));
                Console.WriteLine("Smart Report: verified presence of Vehicles Maintenance Alert for heavy Gas vehicles ");

                // Verify Report Settings - Smart Report: CheckBox Email for heavy vehicles
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CheckBoxEmailSmartHeavy)));
                Console.WriteLine("Smart Report: verified presence of CheckBox Email for heavy vehicles");

                // Verify Report Settings - Smart Report: Light Vehicles Dropdown  
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesDropdownSmartLight)));
                Console.WriteLine("Smart Report: verified presence of Light Vehicles Dropdown  ");

                // Verify Report Settings - Smart Report: Frequency Dropdown for Light Vehicles
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FrequenciesSmartLight)));
                Console.WriteLine("Smart Report: verified presence of Frequency for Light Vehicles");

                // Verify Report Settings - Smart Report: CheckBox Email for light vehicles
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CheckBoxEmailSmartLight)));
                Console.WriteLine("Smart Report: verified presence of CheckBox Email for light vehicles");
                **/
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}