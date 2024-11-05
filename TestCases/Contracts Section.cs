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
    public class Contracts_Section_Navigation: BaseClass
    {
        public Contracts_Section_Navigation(Account Account) : base(Account){}
        public void ContractsSection(Xpath__Contracts Xpath, Values__Contracts Value)
        {
            try
            {
                System.Threading.Thread.Sleep(12000);

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                js.ExecuteScript("document.body.style.zoom = '0.10'");

                // Verify the presence of menu
                AssertElementIsEqualTo(Xpath.Menu, Value.Menu);


                //Open Menu + Click on Contract + Click on Connectivity 
                OpenSecondSectionMenu(Xpath.Menu, Xpath.Contracts, Value.Contracts, Xpath.Connectivity, Value.Connectivity, 1000);

                // Verify Contracts Management
                AssertElementIsEqualTo(Xpath.ContractsManagement, Value.ContractsManagement);

                //Verify the presence of label: Approved contracts
                AssertElementIsEqualTo(Xpath.ApprovedContracts, Value.ApprovedContracts);

                //Verify the presence of label: Contracts in progress
                AssertElementIsEqualTo(Xpath.ContractsInProgress, Value.ContractsInProgress);

                // REMOVED FOR DEMO_DEALER
                //Verify the presence of label: Error contracts
                // wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ErrorContracts)));
                // Assert.That(driver.FindElement(By.XPath(Xpath.ErrorContracts)).Text, Is.EqualTo(Value.ErrorContracts));
                // Console.WriteLine("Verified presence of label: Error contracts");

                //Verify the presence of label: Contracts List
                AssertElementIsEqualTo(Xpath.ContractsList, Value.ContractsList);

                //Verify the presence of label: Contracts number
                AssertElementIsEqualTo(Xpath.ContractsContractNumber, Value.ContractsContractNumber);

                //Verify the presence of label: Draft of origin
                AssertElementIsEqualTo(Xpath.ContractsDraftOfOrigin, Value.ContractsDraftOfOrigin);

                //Verify the presence of label: Range
                AssertElementIsEqualTo(Xpath.ContractsRange, Value.ContractsRange);

                //Verify the presence of label: Company
                AssertElementIsEqualTo(Xpath.ContractsCompany, Value.ContractsCompany);

                //Verify the presence of label: Country
                AssertElementIsEqualTo(Xpath.ContractsCountry, Value.ContractsCountry);

                //open Dealer column
                JSClickDropdownChoice(Xpath.DealerDataColumnOpen, "Dealer Data column", 2000);

                //Verify the presence of label: Dealer
                AssertElementIsEqualTo(Xpath.ContractsDealer, Value.ContractsDealer);


                //Verify the presence of label: Dealer Sap Code
                AssertElementIsEqualTo(Xpath.DealerSapCode, Value.DealerSapCode);

                //Verify the presence of label: City
                AssertElementIsEqualTo(Xpath.DealerCity, Value.DealerCity);

                //Verify the presence of label: Creation date
                AssertElementIsEqualTo(Xpath.ContractsCreationDate, Value.ContractsCreationDate);

                //Verify the presence of label: Start date of first service
                AssertElementIsEqualTo(Xpath.ContractsStartDate, Value.ContractsStartDate);

                //Verify the presence of label: Status
                AssertElementIsEqualTo(Xpath.ContractsStatus, Value.ContractsStatus);

                //open On board column
                JSClickDropdownChoice(Xpath.OnBoardColumnOpen, "On board column",2000);

                //Verify the presence of label: Main account
                AssertElementIsEqualTo(Xpath.ContractsAccountMFM, Value.ContractsAccountMFM);

                //Verify the presence of label: Onboard
                AssertElementIsEqualTo(Xpath.ContractsOnboard, Value.ContractsOnboard);

                //Verify the presence of label: Onboarding date
                AssertElementIsEqualTo(Xpath.ContractsOnboardingDate, Value.ContractsOnboardingDate);

                // REMOVED FOR DEMO_DEALER
                //Verify the presence of label: Error
                //wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContractsError)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.ContractsError)).Text, Is.EqualTo(Value.ContractsError));
                //Console.WriteLine("Verified presence of label: Error");

                //Verify the presence of label: Service termination request
                AssertElementIsEqualTo(Xpath.ContractsServiceTerminationRequest, Value.ContractsServiceTerminationRequest);

                //Verify the presence of label: Actions
                AssertElementIsEqualTo(Xpath.ContractsActions, Value.ContractsActions);

                //Verify the presence of button: CREATE NEW CONTRACT
                AssertElementIsEqualTo(Xpath.ContractsCreateNewContract, Value.ContractsCreateNewContract);

                //Verify the presence of label: Id
                AssertElementIsEqualTo(Xpath.ContractsId, Value.ContractsId);

            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

            driver.Close();
        }

        
    }
}