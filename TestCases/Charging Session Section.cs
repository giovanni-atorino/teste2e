using myiveco_selenium.Functions;
using myiveco_selenium.Xpath;
using myiveco_selenium.Values;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Chrome;
using System.Windows;
using myiveco_selenium.Filters;
using System.Collections.Generic;
using System.Linq;


namespace myiveco_selenium
{

    public class Charging_Session_Section : BaseClass
    {
        public void ChargingSessionSection(Xpath__ChargingSession Xpath, Values__ChargingSession Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

                // Verify the presence of menu
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
                Console.WriteLine("Verified presence of Menu");

                System.Threading.Thread.Sleep(1000);

                //Click on Menu + Click on Charging session
                OpenSectionMenu(Xpath.Menu, Xpath.ChargingSession, Value.ChargingSession, 1000);

                js.ExecuteScript("document.body.style.zoom = '0.40'");

                //Verify Presence of title Charging sessions
                AssertElementIsEqualTo(Xpath.Charging, Value.ChargingSession);

                //Verify Presence of title SessionID
                AssertElementIsEqualTo(Xpath.SessionID, Value.SessionID);

                //Verify Presence of title VIN
                AssertElementIsEqualTo(Xpath.VIN, Value.VIN);

                //Verify Presence of title Vehicle name
                AssertElementIsEqualTo(Xpath.VehicleName, Value.VehicleName);

                //Verify Presence of title Plate number
                AssertElementIsEqualTo(Xpath.PlateNumber, Value.PlateNumber);

                //Verify Presence of title Status
                AssertElementIsEqualTo(Xpath.Status, Value.Status);

                //Verify Presence of title Date
                AssertElementIsEqualTo(Xpath.Date, Value.Date);

                //Verify Presence of title Charger serial number
                AssertElementIsEqualTo(Xpath.Charger, Value.Charger);

                //Verify Presence of title RFID serial number
                AssertElementIsEqualTo(Xpath.RFID, Value.RFID);

                //Verify Presence of title Amount
                AssertElementIsEqualTo(Xpath.Amount, Value.Amount);

                //Verify Presence of title Currency
                AssertElementIsEqualTo(Xpath.Currency, Value.Currency);

                //Verify Presence of title Actions
                AssertElementIsEqualTo(Xpath.Actions, Value.Actions);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }
    }
}