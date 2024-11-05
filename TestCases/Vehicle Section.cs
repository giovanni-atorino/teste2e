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
using myiveco_selenium.Xpath;
using System.Reflection;
using myiveco_selenium.Values;
using myiveco_selenium.Filters;
using myiveco_selenium.Functions;


namespace myiveco_selenium
{
    public class Vehicles_Section: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void VehiclesSection(Xpath__Vehicles Xpath, Values__Vehicles Value)

        {
            try
            { 
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Open Menu
                JSClickDropdownChoice(Xpath.Menu, "Menu", 1000);

                //Open Vehicle Management 
                JSClickDropdownChoice(Xpath.VehiclesManagement, "Vehicles Management", 2000);

                //Click on Recaller
                JSClickDropdownChoice(Xpath.Vehicles, "Vehicles", 2000);

                RefreshCheck(Xpath.YourVehicleHeavy);
                js.ExecuteScript("document.body.style.zoom = '0.40'");

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab , Xpath.YourVehicleHeavy , Xpath.PlateNumberHeavy, Xpath.VINHeavy, Xpath.ModelHeavy, Xpath.FuelHeavy, Xpath.PlateNumberHeavy, Xpath.ConnectivityBoxHeavy, Xpath.AssociatedFleetsHeavy, Xpath.EngineWorkFleetsHeavy, Xpath.ServiceBatteryFleetsHeavy });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab, Xpath.YourVehicleLight, Xpath.PlateNumberLight, Xpath.VINLight, Xpath.ModelLight, Xpath.FuelLight, Xpath.PlateNumberLight, Xpath.ConnectivityBoxLight, Xpath.AssociatedFleetsLight, Xpath.OdemeterLight, Xpath.EngineWorkFleetsLight, Xpath.FuelLevelFleetsLight, Xpath.ServiceBatteryFleetsLight, Xpath.TractionBatteryFleetsLight, Xpath.DrivingModeFleetsLight, Xpath.RegenerativeFleetsLight, Xpath.ElectricityFleetsLight, Xpath.TemperatureFleetsLight, Xpath.ClimaFleetsLight, Xpath.ElectricPowerFleetsLight });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab, Xpath.YourVehicleHeavyBus, Xpath.PlateNumberHeavyBus, Xpath.VINHeavyBus, Xpath.ModelHeavyBus, Xpath.FuelHeavyBus, Xpath.PlateNumberHeavyBus, Xpath.ConnectivityBoxHeavyBus, Xpath.AssociatedFleetsHeavyBus });
                List<string> Tway = new List<string>(new string[] { VehicleType[3], Xpath.TwayTab, Value.TwayTab,    Xpath.YourVehicleTway,  Xpath.PlateNumberTway, Xpath.VINTway, Xpath.ModelTway, Xpath.FuelTway, Xpath.PlateNumberTway, Xpath.ConnectivityBoxTway, Xpath.AssociatedFleetsTway });
                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] {Trucks , Daily, HeavyBus, Tway });

                foreach (List<string> Data in Vehicles)
                {
                    // Verify the presence of  tab
                    AssertElementIsEqualTo(Data[1], Data[2]);

                    //Click on Light tab
                    JSClickDropdownChoice(Data[1], "",1000);

                    // Verify the presence of Your Vehicle Column
                    AssertElementIsEqualTo(Data[3], Value.YourVehicle);

                    // Verify the presence of Plate Number Column
                    AssertElementIsEqualTo(Data[4], Value.PlateNumber);

                    // Verify the presence of VIN Column
                    AssertElementIsEqualTo(Data[5], Value.VIN);

                    // Verify the presence of Model Column
                    AssertElementIsEqualTo(Data[6], Value.Model);

                    // Verify the presence of Fuel Column
                    AssertElementIsEqualTo(Data[7], Value.Fuel);

                    // Verify the presence of Plate Number Column
                    AssertElementIsEqualTo(Data[8], Value.PlateNumber);

                    // Verify the presence of Connectivity Box Column
                    AssertElementIsEqualTo(Data[9], Value.ConnectivityBox);

                    // Verify the presence of Associated Fleets Column
                    AssertElementIsEqualTo(Data[10], Value.AssociatedFleets);

                    if (Data == Trucks)
                    {
                        // Verify the presence of Engine Work hours
                        AssertElementIsEqualTo(Data[11], Value.EngineWorkFleetsHeavy);

                        // Verify the presence of Service Battery Charge %
                        AssertElementIsEqualTo(Data[12], Value.ServiceBatteryFleetsHeavy);
                    }

                    if (Data == Daily)
                    {
                        // Verify the presence of Odometer
                        AssertElementIsEqualTo(Data[11], Value.OdometerFleetsLight);

                        // Verify the presence of Engine Work hours Column
                        AssertElementIsEqualTo(Data[12], Value.EngineWorkFleetsLight);

                        // Verify the presence of % fuel level Column
                        AssertElementIsEqualTo(Data[13], Value.FuelLevelFleetsLight);

                        // Verify the presence of ServiceBatteryFleetsLight Column
                        AssertElementIsEqualTo(Data[14], Value.ServiceBatteryFleetsHeavy);

                        // Verify the presence of TractionBatteryFleetsLight Column
                        AssertElementIsEqualTo(Data[15], Value.TractionBatteryFleetsLight);

                        // Verify the presence of DrivingModeFleetsLight Column
                        AssertElementIsEqualTo(Data[16], Value.DrivingModeFleetsLight);

                        // Verify the presence of RegenerativeFleetsLight Column
                        AssertElementIsEqualTo(Data[17], Value.RegenerativeFleetsLight);

                        // Verify the presence of ElectricityFleetsLight Column
                        AssertElementIsEqualTo(Data[18], Value.ElectricityFleetsLight);

                        // Verify the presence of TemperatureFleetsLight Column
                        AssertElementIsEqualTo(Data[19], Value.TemperatureFleetsLight);

                        // Verify the presence of ClimaFleetsLight Column
                        AssertElementIsEqualTo(Data[20], Value.ClimaFleetsLight);

                        // Verify the presence of ElectricPowerFleetsLight Column
                        AssertElementIsEqualTo(Data[21], Value.ElectricPowerFleetsLight);
                    }
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