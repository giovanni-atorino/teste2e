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
    public class Settings_Section_Update_Fields_Electric : Basic_Test
    {
        public Settings_Section_Update_Fields_Electric(Account Account) : base(Account) { }
        static string save_button_number = TestContext.Parameters["save_button_number"].ToString();

        public void SettingsSectionUpdateFieldsElectric(Xpath__Settings Xpath, Values__Settings Value, String UnitMeasureEnergyConsumptionChoice, String UnitMeasureEnergyConsumptionChoiceValue)

        {
            // Wait definition for element
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Verify the presence of Account Section
            VerifyElement(Xpath.Account);

            //Open Account
            JSClickDropdownChoice(Xpath.Account, "Account button", 100);

            // Verify the presence of Manage profile section
            AssertElementIsEqualTo(Xpath.ManageProfile, Value.ManageProfile);

            //Open Manage profile section
            JSClickDropdownChoice(Xpath.ManageProfile, "Manage profile button", 100);

            // Verify Site preferences: Energy Consumption Units
            AssertElementIsEqualTo(UnitMeasureEnergyConsumptionChoice, UnitMeasureEnergyConsumptionChoiceValue);
            System.Threading.Thread.Sleep(2000);

            ClickDropdownChoice(UnitMeasureEnergyConsumptionChoice, UnitMeasureEnergyConsumptionChoiceValue, 100);

            JSClickDropdownChoice("//app-user-profile-page//pfe-cta/a[contains (text (),'SAVE')]", "SAVE button", 3000);


            //Verify the presence of successful pop-up    
            VerifyElement(Xpath.SuccessfulPopUp);
        }
        public void UpdateFieldsElectric(Xpath__Settings Xpath, Values__Settings Value, String UnitMeasureEnergyConsumptionChoice, String UnitMeasurementFuelConsumptionChoiceValue)

        {
            try
            {
                SettingsSectionUpdateFieldsElectric(Xpath, Value, UnitMeasureEnergyConsumptionChoice, UnitMeasurementFuelConsumptionChoiceValue);

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                if (UnitMeasureEnergyConsumptionChoice == Xpath.EnergyConsumptionUnitskWhkm)
                {
                    List<string> DashboardList = new List<string> { "23", "33" };

                    foreach (string Dashboard in DashboardList)
                    {
                        //Navigate to dashboard
                        DashboardChoice(Dashboard);

                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                        JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                        Console.WriteLine("Open Dashboard: " + Dashboard);

                        //Verify that the dashboard has data in the widget: 
                        int NoDataFlag = VerifyData();

                        if (NoDataFlag == 0)
                        {
                            if ((Dashboard == "23" || Dashboard == "33") & UnitMeasureEnergyConsumptionChoice == Xpath.EnergyConsumptionUnitskWh100km)
                            {
                                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelTypeLabel)));
                                Assert.That(driver.FindElement(By.XPath(Xpath.FuelTypeLabel)).Text, Is.EqualTo(Value.Electric));
                                Scroll(Xpath.EnergyusageTitle);
                                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.UnitOfMeasurekWh100km)));
                                Console.WriteLine("In dashboard " + Dashboard + " the Energy consumption is in kWh/100km");
                            }

                            if ((Dashboard == "23" || Dashboard == "33") & UnitMeasureEnergyConsumptionChoice == Xpath.EnergyConsumptionUnitskWhkm)
                            {
                                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelTypeLabel)));
                                Assert.That(driver.FindElement(By.XPath(Xpath.FuelTypeLabel)).Text, Is.EqualTo(Value.Electric));
                                Scroll(Xpath.EnergyusageTitle);
                                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.UnitOfMeasurekWhkm)));
                                Console.WriteLine("In dashboard " + Dashboard + " the Energy consumption is in  kWh/km");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The unit of measure is set as option 1");
                }
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }


            finally
            {
                SettingsSectionUpdateFieldsElectric(Xpath, Value, Xpath.EnergyConsumptionUnitskWhkm, Value.EnergyConsumptionUnitskWhkm);
            }
        }
    }
}