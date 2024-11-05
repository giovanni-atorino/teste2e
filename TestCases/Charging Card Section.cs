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

    public class Charging_Card_Section : BaseClass
    {
        public void ChargingCardSection(Xpath__ChargingCard Xpath, Values__ChargingCard Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

                // Verify the presence of menu
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
                Console.WriteLine("Verified presence of Menu");

                System.Threading.Thread.Sleep(1000);

                //Click on Menu + Click on Charging card
                OpenSectionMenu(Xpath.Menu, Xpath.ChargingCard, Value.ChargingCard, 1000);

                js.ExecuteScript("document.body.style.zoom = '0.40'");

                //Verify Presence of title Cards
                AssertElementIsEqualTo(Xpath.Card, Value.Card);

                //Verify Presence of title VIN
                AssertElementIsEqualTo(Xpath.VIN, Value.VIN);

                //Verify Presence of title Vehicle name
                AssertElementIsEqualTo(Xpath.VehicleName, Value.VehicleName);

                //Verify Presence of title Plate number
                AssertElementIsEqualTo(Xpath.PlateNumber, Value.PlateNumber);

                //Verify Presence of title Contract number
                AssertElementIsEqualTo(Xpath.ContractNumber, Value.ContractNumber);

                //Verify Presence of title Card number
                AssertElementIsEqualTo(Xpath.CardNumber, Value.CardNumber);

                //Verify Presence of title Type
                AssertElementIsEqualTo(Xpath.Type, Value.Type);

                //Verify Presence of title Date
                AssertElementIsEqualTo(Xpath.Date, Value.Date);

                //Verify Presence of title Status
                AssertElementIsEqualTo(Xpath.Status, Value.Status);

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