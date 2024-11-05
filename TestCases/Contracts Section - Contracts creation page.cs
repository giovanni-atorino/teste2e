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
    public class Contracts_Section_Contract_Creation: BaseClass
    {
        public Contracts_Section_Contract_Creation(Account Account) : base(Account) {}
        public void ContractsSectionContractCreation(Xpath__Contracts Xpath, Values__Contracts Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                js.ExecuteScript("document.body.style.zoom = '0.20'");

                // Verify the presence of menu
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.Menu)).Text, Is.EqualTo(Value.Menu));
                Console.WriteLine("Verified presence of Menu");

                //Open Menu + Click on Contract + Click on Connectivity 
                OpenSecondSectionMenu(Xpath.Menu, Xpath.Contracts, Value.Contracts, Xpath.Connectivity, Value.Connectivity, 1000);

                js.ExecuteScript("document.body.style.zoom = '0.50'");

                //Verify the presence of button: CREATE NEW CONTRACT
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContractsCreateNewContract)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ContractsCreateNewContract)).Text.Replace("\r\n", " "), Is.EqualTo(Value.ContractsCreateNewContract));
                Console.WriteLine("Verified presence of label: CREATE NEW CONTRACT");

                //Create a new contract flow starts
                IWebElement CreateNewContractButton = driver.FindElement(By.XPath((Xpath.ContractsCreateNewContract)));
                js.ExecuteScript("arguments[0].click();", CreateNewContractButton);
                Console.WriteLine("Clicked on CREATE NEW CONTRACT BUTTON");

                //Verify the presence of field: Contract typology
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContractTypology)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ContractTypology)).Text, Is.EqualTo(Value.ContractTypology));
                Console.WriteLine("Verified presence of field: Contract typology");

                //Verify the presence of field: Select range
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContCreationSelectRange)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ContCreationSelectRange)).Text, Is.EqualTo(Value.ContCreationSelectRange));
                Console.WriteLine("Verified presence of field: Select range");

                //Verify the presence of field: Search VIN code
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContCreationSearchVINCode)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ContCreationSearchVINCode)).Text, Is.EqualTo(Value.ContCreationSearchVINCode));
                Console.WriteLine("Verified presence of field: Search VIN code");

                //Verify the presence of label: Plate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContCreationPlate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ContCreationPlate)).Text, Is.EqualTo(Value.ContCreationPlate));
                Console.WriteLine("Verified presence of label: Plate");

                //Verify the presence of label: Commercial model
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContCreationCommercialModel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ContCreationCommercialModel)).Text, Is.EqualTo(Value.ContCreationCommercialModel));
                Console.WriteLine("Verified presence of label: Commercial model");

                //Verify the presence of label: Fuel
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContCreationFuel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ContCreationFuel)).Text, Is.EqualTo(Value.ContCreationFuel));
                Console.WriteLine("Verified presence of label: Fuel");

                //Verify the presence of label: Warranty start date
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContCreationWarrantyStartDate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ContCreationWarrantyStartDate)).Text, Is.EqualTo(Value.ContCreationWarrantyStartDate));
                Console.WriteLine("Verified presence of label: Warranty start date");

                //Verify the presence of label: VAN
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContCreationVAN)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ContCreationVAN)).Text, Is.EqualTo(Value.ContCreationVAN));
                Console.WriteLine("Verified presence of label: VAN");

                //System.Threading.Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }

        
    }
}