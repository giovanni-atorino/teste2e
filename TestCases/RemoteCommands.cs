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
    public class Remote_Commands_Page : BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        static string vin_remote_commands = TestContext.Parameters["vin_remote_commands"].ToString();

        public void RemoteCommandsPage(Xpath__RemoteCommands XpathRC, Values__RemoteCommands ValueRC)

        {
            try
            {
                GoToUrl(weburl_runsettings + "edaily-remote-commands/remote?vehicleName=-&vehicleVIN=" + vin_remote_commands);

                // Wait definition for element
                System.Threading.Thread.Sleep(10000);

                //Verify the presence of Remote Commands
                AssertElementIsEqualTo(XpathRC.RemoteCommands, ValueRC.RemoteCommands);

                //Click on Charging tab
                JSClickDropdownChoice(XpathRC.ChargingTab, ValueRC.ChargingTab, 1000);

                //Verify the presence of Charging Status
                AssertElementIsEqualTo(XpathRC.ChargingStatus, ValueRC.ChargingStatus);

                //Verify the presence of Statete of charge
                AssertElementIsEqualTo(XpathRC.StateOfCharge, ValueRC.StateOfCharge);

                //Verify the presence of Range
                AssertElementIsEqualTo(XpathRC.Range, ValueRC.Range);

                //Verify the presence of To complete the charge
                AssertElementIsEqualTo(XpathRC.ToCompleteTheCharge, ValueRC.ToCompleteTheCharge);

                //Verify the presence of Electricity Priority
                AssertElementIsEqualTo(XpathRC.ElectricityPriority, ValueRC.ElectricityPriority);

                //Click on Climatization tab
                JSClickDropdownChoice("//*[@class='ag-pinned-right-cols-container']/div/div/div/span/div/span[2]/span[1]", "", 1000);

                //Click on Climatization tab
                JSClickDropdownChoice("//app-remote-commands-charging/pfe-modal[6]//pfe-cta[@pfe-priority='primary']/a", "", 1000);

                //Click on Climatization tab
                JSClickDropdownChoice(XpathRC.ClimatizationTab, ValueRC.ClimatizationTab, 1000);

                //Verify the presence of Climatization label box
                AssertElementIsEqualTo(XpathRC.Climatization, ValueRC.Climatization);

                //Verify the presence of Climatization mode
                AssertElementIsEqualTo(XpathRC.ClimatizationMode, ValueRC.ClimatizationMode);

                //Verify the presence of Target vehicle temperature
                AssertElementIsEqualTo(XpathRC.TargetVehicleTemperature, ValueRC.TargetVehicleTemperature);

                //Verify the presence of Climatization EcoMode
                AssertElementIsEqualTo(XpathRC.ClimatizationEcoMode, ValueRC.ClimatizationEcoMode);

                //Verify the presence of Climatization EcoMode Normal
                AssertElementIsEqualTo(XpathRC.ClimatizationEcoModeNormal, ValueRC.ClimatizationEcoModeNormal);

                //Verify the presence of Climatization EcoMode Eco
                AssertElementIsEqualTo(XpathRC.ClimatizationEcoModeEco, ValueRC.ClimatizationEcoModeEco);

                //Click on Driving Mode tab
                JSClickDropdownChoice(XpathRC.DrivingModeTab, ValueRC.DrivingModeTab, 1000);

                //Verify the presence of Current status
                AssertElementIsEqualTo(XpathRC.CurrentStatus2, ValueRC.CurrentStatus);

                //Verify the presence of Next status
                AssertElementIsEqualTo(XpathRC.NextStatus2, ValueRC.NextStatus);

                //Verify the presence of Change driving mode Button
                AssertElementIsEqualTo(XpathRC.ChangeDrivingMode, ValueRC.ChangeDrivingMode);

                //Verify the presence of Details Button
                AssertElementIsEqualTo(XpathRC.DetailsButton, ValueRC.DetailsButton);

                //Click on Regeneration Mode tab
                JSClickDropdownChoice(XpathRC.RegenerationModeTab, ValueRC.RegenerationModeTab, 1000);

                //Verify the presence of Current status
                AssertElementIsEqualTo(XpathRC.CurrentStatus2, ValueRC.CurrentStatus);

                //Verify the presence of Next status
                AssertElementIsEqualTo(XpathRC.NextStatus2, ValueRC.NextStatus);

                //Verify the presence of Change regeneration mode Button
                AssertElementIsEqualTo(XpathRC.ChangeRegenerationMode, ValueRC.ChangeRegenerationMode);

                //Verify the presence of Details Button
                AssertElementIsEqualTo(XpathRC.DetailsButton, ValueRC.DetailsButton);

                //Click on ePTO tab
                JSClickDropdownChoice(XpathRC.ePTOtab, ValueRC.ePTOtab, 1000);

                //Verify the presence of Vehicle ePTO Deactivation
                AssertElementIsEqualTo(XpathRC.VehicleePTODeactivation, ValueRC.VehicleePTODeactivation);

            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}