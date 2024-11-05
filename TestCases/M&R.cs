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
    public class MeR_Section : BaseClass
    {
        public void MeRsection(Xpath__MeR Xpath, Values__MeR Value)

        {
            try
            {
                // Verify the presence of menu
                AssertElementIsEqualTo(Xpath.Menu, Value.Menu);
                System.Threading.Thread.Sleep(1000);

                //Open Menu + Click on Contract + Click on M&R 
                OpenSecondSectionMenu(Xpath.Menu, Xpath.Contracts, Value.Contracts, Xpath.MeR, Value.MeR, 1000);

                js.ExecuteScript("document.body.style.zoom = '0.40'");

                //Verify the presence of label Maintenance
                AssertElementIsEqualTo(Xpath.Maintenance, Value.Maintenance);

                //Verify the presence of ContractNumber
                AssertElementIsEqualTo(Xpath.ContractNumber, Value.ContractNumber);

                //Verify the presence of ContractType
                AssertElementIsEqualTo(Xpath.ContractType, Value.ContractType);

                //Verify the presence of ContractContent
                AssertElementIsEqualTo(Xpath.ContractContent, Value.ContractContent);

                //Verify the presence of ContractualMission
                AssertElementIsEqualTo(Xpath.ContractualMission, Value.ContractualMission);

                //Verify the presence of Total
                AssertElementIsEqualTo(Xpath.Total, Value.Total);

                //Verify the presence of ContractDuration
                AssertElementIsEqualTo(Xpath.ContractDuration, Value.ContractDuration);

                //Verify the presence of Payer
                AssertElementIsEqualTo(Xpath.Payer, Value.Payer);

                //Verify the presence of Customer
                AssertElementIsEqualTo(Xpath.Customer, Value.Customer);

                //Verify the presence of Instalment
                AssertElementIsEqualTo(Xpath.Instalment, Value.Instalment);

                //Click on View Button
                JSClickDropdownChoice(Xpath.ViewButton, "", 2000);
                js.ExecuteScript("document.body.style.zoom = '0.40'");

                //Verify the presence of ContractNumberDetail
                AssertElementIsEqualTo(Xpath.ContractNumberDetail, Value.ContractNumberDetail);

                //Verify the presence of VINDetail
                AssertElementIsEqualTo(Xpath.VINDetail, Value.VINDetail);

                //Verify the presence of StartDateDetail
                AssertElementIsEqualTo(Xpath.StartDateDetail, Value.StartDateDetail);

                //Verify the presence of EndDateDetail
                AssertElementIsEqualTo(Xpath.EndDateDetail, Value.EndDateDetail);

                //Verify the presence of SuspensionDateDetail
                AssertElementIsEqualTo(Xpath.SuspensionDateDetail, Value.SuspensionDateDetail);

                //Verify the presence of ReactivationDateDetail
                AssertElementIsEqualTo(Xpath.ReactivationDateDetail, Value.ReactivationDateDetail);

                //Verify the presence of SuspensionDetail
                AssertElementIsEqualTo(Xpath.SuspensionDetail, Value.SuspensionDetail);

                //Verify the presence of ReactivationDetail
                AssertElementIsEqualTo(Xpath.ReactivationDetail, Value.ReactivationDetail);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}