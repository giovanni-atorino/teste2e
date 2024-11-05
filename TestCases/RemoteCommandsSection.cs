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
    public class RemoteCommands_Session_Section : BaseClass
    {
        public void RemoteCommandsSection(Xpath__RemoteCommands XpathRC, Values__RemoteCommands ValueRC)

        {
            try
            {
                // Verify the presence of menu
                AssertElementIsEqualTo(XpathRC.Menu, ValueRC.Menu);
                System.Threading.Thread.Sleep(1000);

                //Click on Menu + Click on VehicleManagement + RemoteCommands
                OpenSecondSectionMenu(XpathRC.Menu, XpathRC.VehiclesManagement, ValueRC.VehiclesManagement, XpathRC.RemoteCommandsSection, ValueRC.RemoteCommandsSection, 1000);

                js.ExecuteScript("document.body.style.zoom = '0.40'");

                //Verify the presence of label RemoteCommands
                AssertElementIsEqualTo(XpathRC.RemoteCommandsLabel, ValueRC.RemoteCommandsLabel);

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], XpathRC.TrucksTab, ValueRC.TrucksTab, XpathRC.VehicleNameTruck, XpathRC.VINTruck, XpathRC.PlateNumberTruck, XpathRC.EngineWorkHoursTruck, XpathRC.ServiceBatteryChargeTruck});
                List<string> Daily = new List<string>(new string[] { VehicleType[1], XpathRC.DailyTab, ValueRC.DailyTab, XpathRC.VehicleNameDaily, XpathRC.VINDaily, XpathRC.PlateNumberDaily, XpathRC.ChargingStatusColumnDaily, XpathRC.DrivingModeDaily, XpathRC.RegenerativeModeDaily,XpathRC.ElectricityLoadDaily, XpathRC.TemperatureDaily, XpathRC.ElectricityPowerDaily });
                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily});

                foreach (List<string> Data in Vehicles)
                {
                    // Verify the presence of  tab
                    AssertElementIsEqualTo(Data[1], Data[2]);

                    JSClickDropdownChoice(Data[1], "", 1000);

                    //Verify label VehicleNameTruck
                    AssertElementIsEqualTo(Data[3], ValueRC.VehicleName);

                    //Verify label VIN Truck
                    AssertElementIsEqualTo(Data[4], ValueRC.VIN);

                    //Verify label PlateNumber Truck
                    AssertElementIsEqualTo(Data[5], ValueRC.PlateNumber);

                    if (Data == Trucks)
                    {

                        //Verify label EngineWorkHoursTruck
                        AssertElementIsEqualTo(Data[6], ValueRC.EngineWorkHoursTruck);

                        //Verify label ServiceBatteryChargeTruck
                        AssertElementIsEqualTo(Data[7], ValueRC.ServiceBatteryChargeTruck);
                    }


                    if (Data == Daily)
                    {
                        //Verify label ChargingStatus
                        AssertElementIsEqualTo(Data[6], ValueRC.ChargingStatusColumn);

                        //Verify label DrivingMode
                        AssertElementIsEqualTo(Data[7], ValueRC.DrivingMode);

                        //Verify label RegenerativeMode
                        AssertElementIsEqualTo(Data[8], ValueRC.RegenerativeMode);

                        //Verify label ElectricityLoad
                        AssertElementIsEqualTo(Data[9], ValueRC.ElectricityLoad);

                        //Verify label Temperature
                        AssertElementIsEqualTo(Data[10], ValueRC.Temperature);

                        //Verify label ElectricityPower
                        AssertElementIsEqualTo(Data[11], ValueRC.ElectricityPower);
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