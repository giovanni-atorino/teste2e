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
    public class Settings_Section_Update_Fields : Basic_Test
    {
        public Settings_Section_Update_Fields(Account Account) : base(Account) { }
        static string save_button_number = TestContext.Parameters["save_button_number"].ToString();

        public void SettingsSectionUpdateFields(Xpath__Settings Xpath, Values__Settings Value, String UnitMeasurementFuelConsumptionChoiceDiesel, String UnitMeasurementFuelConsumptionChoiceValueDisel, String UnitMeasurementFuelConsumptionChoiceNP, String UnitMeasurementFuelConsumptionChoiceValueNP)

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

            // Verify Site preferences: Fuel Consumption Units
            AssertElementIsEqualTo(UnitMeasurementFuelConsumptionChoiceDiesel, UnitMeasurementFuelConsumptionChoiceValueDisel);
            System.Threading.Thread.Sleep(2000);

            // Verify Site preferences: Fuel Consumption Units
            AssertElementIsEqualTo(UnitMeasurementFuelConsumptionChoiceNP, UnitMeasurementFuelConsumptionChoiceValueNP);
            System.Threading.Thread.Sleep(2000);

            ClickDropdownChoice(UnitMeasurementFuelConsumptionChoiceDiesel, UnitMeasurementFuelConsumptionChoiceValueDisel, 100);
            ClickDropdownChoice(UnitMeasurementFuelConsumptionChoiceNP, UnitMeasurementFuelConsumptionChoiceValueNP, 100);

            JSClickDropdownChoice("//app-user-profile-page//pfe-cta/a[contains (text (),'SAVE')]", "SAVE button", 3000);


            //Verify the presence of successful pop-up    
            VerifyElement(Xpath.SuccessfulPopUp);
        }
        public void UpdateFields(Xpath__Settings Xpath, Values__Settings Value, String UnitMeasurementFuelConsumptionChoiceDiesel, String UnitMeasurementFuelConsumptionChoiceValueDiesel, String UnitMeasurementFuelConsumptionChoiceNP, String UnitMeasurementFuelConsumptionChoiceValueNP)

        {
            try
            {
                SettingsSectionUpdateFields(Xpath, Value, UnitMeasurementFuelConsumptionChoiceDiesel, UnitMeasurementFuelConsumptionChoiceValueDiesel, UnitMeasurementFuelConsumptionChoiceNP, UnitMeasurementFuelConsumptionChoiceValueNP);

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

              if (UnitMeasurementFuelConsumptionChoiceDiesel== Xpath.FuelConsumptionUnitslkm)
                {
                      List<string> DashboardList = new List<string> { "11", "12", "21", "22", "51" };

                foreach (string Dashboard in DashboardList)
                {
                    //Navigate to dashboard
                    DashboardChoice(Dashboard);

                    JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                    JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                    RefreshCheck("//*[@id='widgetContainer5']");

                    Console.WriteLine("Open Dashboard: " + Dashboard);

                    //Verify that the dashboard has data in the widget: 
                    int NoDataFlag = VerifyData();

                    if (NoDataFlag == 0)
                    {
                            if ((Dashboard == "11" || Dashboard == "21" || Dashboard == "51") & UnitMeasurementFuelConsumptionChoiceDiesel == Xpath.FuelConsumptionUnitskml)
                            {
                                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelTypeLabel)));
                                Assert.That(driver.FindElement(By.XPath(Xpath.FuelTypeLabel)).Text, Is.EqualTo(Value.Diesel));
                                Scroll(Xpath.FuelConsumptionTitle);
                                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.UnitOfMeasurekml)));
                                Console.WriteLine("In dashboard " + Dashboard + " the fuel consumption is in km/l");
                            }

                          if ((Dashboard == "12" || Dashboard == "22") & UnitMeasurementFuelConsumptionChoiceNP == Xpath.FuelConsumptionUnitskmkg)
                        {
                                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelTypeLabel)));
                                    Assert.That(driver.FindElement(By.XPath(Xpath.FuelTypeLabel)).Text, Is.EqualTo(Value.NP));
                                    Scroll(Xpath.FuelConsumptionTitle);
                                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.UnitOfMeasurekmkg)));
                                    Console.WriteLine("In dashboard " + Dashboard + " the fuel consumption is in km/kg");
                            
                        }

                            if ((Dashboard == "11" || Dashboard == "21" || Dashboard == "51") & UnitMeasurementFuelConsumptionChoiceDiesel == Xpath.FuelConsumptionUnitslkm)
                            {
                                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelTypeLabel)));
                                Assert.That(driver.FindElement(By.XPath(Xpath.FuelTypeLabel)).Text, Is.EqualTo(Value.Diesel));
                                Scroll(Xpath.FuelConsumptionTitle);
                                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.UnitOfMeasurelkm)));
                                Console.WriteLine("In dashboard " + Dashboard + " the fuel consumption is in l/100km");
                            }

                        if ((Dashboard == "12" || Dashboard == "22") & UnitMeasurementFuelConsumptionChoiceNP == Xpath.FuelConsumptionUnitskmkg)
                                {
                                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelTypeLabel)));
                                    Assert.That(driver.FindElement(By.XPath(Xpath.FuelTypeLabel)).Text, Is.EqualTo(Value.NP));
                                    Scroll(Xpath.FuelConsumptionTitle);
                                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.UnitOfMeasurekmkg)));
                                    Console.WriteLine("In dashboard " + Dashboard + " the fuel consumption is in km/kg");
                                
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
                SettingsSectionUpdateFields(Xpath, Value, Xpath.FuelConsumptionUnitslkm, Value.FuelConsumptionUnitslkm, Xpath.FuelConsumptionUnitskgkm, Value.FuelConsumptionUnitskgkm);

            }
        }
    }
}
