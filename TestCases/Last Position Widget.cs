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
    public class LastPositionWidget: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void LastPositionTestHeavy(Xpath__LastPosition Xpath, Values__LastPosition Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

                //Scroll website until title of widget is found
                ScrollFunction();
                Scroll(Xpath.TitleLastPosition); 

                //Verify the label TitleLastPosition
                AssertElementIsEqualTo(Xpath.TitleLastPosition, Value.TitleLastPosition);
                //Verify the label LastPosition
                AssertElementIsEqualTo(Xpath.LastPosition, Value.LastPosition);
                //Verify the label Route
                AssertElementIsEqualTo(Xpath.Route, Value.Route); 
                //Verify the label From
                AssertElementIsEqualTo(Xpath.From, Value.From);
                //Verify the label To
                AssertElementIsEqualTo(Xpath.To, Value.To);
                //Verify the label TotalDistance
                AssertElementIsEqualTo(Xpath.TotalDistance, Value.TotalDistance);
                //Verify the label TotalTripTime
                AssertElementIsEqualTo(Xpath.TotalTripTime, Value.TotalTripTime);
                //Verify the label FuelConsumption
                AssertElementIsEqualTo(Xpath.FuelConsumption, Value.FuelConsumption);
                //Verify the label ButtonResetView
                AssertElementIsEqualTo(Xpath.ButtonResetView, Value.ButtonResetView);
                //Verify the label ButtonRefresh
                AssertElementIsEqualTo(Xpath.ButtonRefresh, Value.ButtonRefresh);
                /*
                //Click on Choose Vehicle
                JSClickDropdownChoice(Xpath.ChooseVehicle, "", 2000);
                //Click on Deselect All
                JSClickDropdownChoice(Xpath.DeselectAll, "", 2000);
                //Click on Choose Vehicle
                JSClickDropdownChoice(Xpath.ChooseVehicle, "", 2000);
                //Click on First Vehicle
                JSClickDropdownChoice(Xpath.FirstVehicle, "", 2000);
                //Click on Pin
                ExpandShadowElementAndClick("div", , "[]");
                System.Threading.Thread.Sleep(500);

                //Verify the label VIN
                AssertElementIsEqualTo(Xpath.VIN, Value.VIN);
                //Verify the label Name
                AssertElementIsEqualTo(Xpath.Name, Value.Name);
                //Verify the label Plate
                AssertElementIsEqualTo(Xpath.Plate, Value.Plate);
                //Verify the label Model
                AssertElementIsEqualTo(Xpath.Model, Value.Model);
                //Verify the label Fuel
                AssertElementIsEqualTo(Xpath.Fuel, Value.Fuel);
                //Verify the label LastUpdate
                AssertElementIsEqualTo(Xpath.LastUpdate, Value.LastUpdate);
                //Verify the label Type
                AssertElementIsEqualTo(Xpath.Type, Value.Type);
                */
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }
        public void LastPositionTestLight(Xpath__LastPosition Xpath, Values__LastPosition Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Add additional zoom out
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                //Scroll website until title of widget is found
                Scroll(Xpath.TitleLastPosition);

                //Verify the label TitleLastPosition
                AssertElementIsEqualTo(Xpath.TitleLastPosition, Value.TitleLastPosition);
                //Verify the label LastPosition
                AssertElementIsEqualTo(Xpath.LastPosition, Value.LastPosition);
                //Verify the label Route
                AssertElementIsEqualTo(Xpath.Route, Value.Route);
                //Verify the label From
                AssertElementIsEqualTo(Xpath.From, Value.From);
                //Verify the label To
                AssertElementIsEqualTo(Xpath.To, Value.To);
                //Verify the label Start
                AssertElementIsEqualTo(Xpath.Start, Value.Start);
                //Verify the label End
                AssertElementIsEqualTo(Xpath.End, Value.End);
                //Verify the label Duration
                AssertElementIsEqualTo(Xpath.Duration, Value.Duration);
                //Verify the label ButtonResetView
                AssertElementIsEqualTo(Xpath.ButtonResetView, Value.ButtonResetView);
                //Verify the label ButtonRefresh
                AssertElementIsEqualTo(Xpath.ButtonRefresh, Value.ButtonRefresh);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }
    }
}
