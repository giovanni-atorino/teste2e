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

namespace myiveco_selenium.TestCases
{
    public class KroneWidget: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void KroneTest(Xpath__KRONE Xpath, Values__KRONE Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Scroll website
                Scroll(Xpath.TitleKrone); 

                //Add additional zoom out
                js.ExecuteScript("document.body.style.zoom = '0.50'");

                //Click to expand the table
                JSClickDropdownChoice(Xpath.ArrowContracted, "", 1000);

                //Verify the label TitleKrone
                AssertElementIsEqualTo(Xpath.TitleKrone, Value.TitleKrone);
                //Verify the label Date
                AssertElementIsEqualTo(Xpath.Date, Value.Date);
                //Verify the label VIN
                AssertElementIsEqualTo(Xpath.VIN, Value.VIN);
                //Verify the label Plate
                AssertElementIsEqualTo(Xpath.Plate, Value.Plate);
                //Verify the label Nickname
                AssertElementIsEqualTo(Xpath.Nickname, Value.Nickname);
                //Verify the label FIN
                AssertElementIsEqualTo(Xpath.FIN, Value.FIN);
                //Verify the label Type
                AssertElementIsEqualTo(Xpath.TypeKrone, Value.TypeKrone);
                //Verify the label Status
                AssertElementIsEqualTo(Xpath.Status, Value.Status);
                //Verify the label Temperatures
                AssertElementIsEqualTo(Xpath.Temperatures, Value.Temperatures);
                //Verify the label Position
                AssertElementIsEqualTo(Xpath.Position, Value.Position);
                //Verify the label Actions
                AssertElementIsEqualTo(Xpath.Actions, Value.Actions);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }

        public void KroneDataTest(Xpath__KRONE Xpath, Values__KRONE Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                
                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);
                

                KroneTest(Xpath, Value);

                try
                {
                //Click to open details page
                JSClickDropdownChoice(Xpath.OpenDetails, "", 2000);

                //Verify the label Details
                AssertElementIsEqualTo(Xpath.Details, Value.Details);
                //Verify the label CommonData
                AssertElementIsEqualTo(Xpath.CommonData, Value.CommonData);
                //Verify the label AssetName
                AssertElementIsEqualTo(Xpath.AssetName, Value.AssetName);
                //Verify the label DateCommonData
                AssertElementIsEqualTo(Xpath.DateCommonData, Value.DateCommonData);
                //Verify the label TimeReceived
                AssertElementIsEqualTo(Xpath.TimeReceived, Value.TimeReceived);
                //Verify the label Voltage
                AssertElementIsEqualTo(Xpath.Voltage, Value.Voltage);
                //Verify the label InternalVoltage
                AssertElementIsEqualTo(Xpath.InternalVoltage, Value.InternalVoltage);
                //Verify the label TempRecorder
                AssertElementIsEqualTo(Xpath.TempRecorder, Value.TempRecorder);
                //Verify the label DurationDriving
                AssertElementIsEqualTo(Xpath.DurationDriving, Value.DurationDriving);
                //Verify the label TemperatureData
                AssertElementIsEqualTo(Xpath.TemperatureData, Value.TemperatureData);
                //Verify the label ValueTemperature
                AssertElementIsEqualTo(Xpath.ValueTemperature, Value.ValueTemperature);
                //Verify the label GPS
                AssertElementIsEqualTo(Xpath.GPS, Value.GPS);
                //Verify the label Latitude
                AssertElementIsEqualTo(Xpath.Latitude, Value.Latitude);
                //Verify the label Longitude
                AssertElementIsEqualTo(Xpath.Longitude, Value.Longitude);
                //Verify the label Height
                AssertElementIsEqualTo(Xpath.Height, Value.Height);
                //Verify the label Location
                AssertElementIsEqualTo(Xpath.Location, Value.Location);
                //Verify the label Direction
                AssertElementIsEqualTo(Xpath.Direction, Value.Direction);
                //Verify the label GPSHeading
                AssertElementIsEqualTo(Xpath.GPSHeading, Value.GPSHeading);
                //Verify the label Satellites
                AssertElementIsEqualTo(Xpath.Satellites, Value.Satellites);
                //Verify the label RefrigeratorData
                AssertElementIsEqualTo(Xpath.RefrigeratorData, Value.RefrigeratorData);
                //Verify the label RefrigeratorDate
                AssertElementIsEqualTo(Xpath.RefrigeratorDate, Value.RefrigeratorDate);
                //Verify the label Fuel
                AssertElementIsEqualTo(Xpath.Fuel, Value.Fuel);
                //Verify the label FuelReserve
                AssertElementIsEqualTo(Xpath.FuelReserve, Value.FuelReserve);
                //Verify the label StandbyHours
                AssertElementIsEqualTo(Xpath.StandbyHours, Value.StandbyHours);
                //Verify the label OperatingHours
                AssertElementIsEqualTo(Xpath.OperatingHours, Value.OperatingHours);
                //Verify the label SwitchOnHours
                AssertElementIsEqualTo(Xpath.SwitchOnHours, Value.SwitchOnHours);
                //Verify the label Warning
                AssertElementIsEqualTo(Xpath.Warning, Value.Warning);
                }

                catch 
                {
                    Console.WriteLine("The widget does not have any data");
                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }

    }
}
