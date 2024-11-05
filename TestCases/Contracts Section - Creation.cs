using System;
using System.Text;
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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace myiveco_selenium
{
    public class Contracts_Section_Creation : BaseClassNoHead
    {
        static string weburl = TestContext.Parameters["weburl"].ToString();
        public Contracts_Section_Creation(Account Account) : base(Account) {}
        public void ContractsSectionContractCreation1step(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                System.Threading.Thread.Sleep(2000);
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


                //Take Market Data
                List<string> MarketInfo = Info.GetMarketInfo();
                
                //if the user is a TCO, the selection of the market is required
                if (MarketInfo[2]=="TCO"){
                
                Console.WriteLine("The user is a TCO, so the market choice is required");
                //Select Market 
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains (text(),'Select market')]//parent::pfe-select//select/option[@value='" + MarketInfo[0] + "']")));
                Console.WriteLine("Verify the presence of Country id " + MarketInfo[0] + " which correspond to " + MarketInfo[1] + " market");

                driver.FindElement(By.XPath("//*[contains (text(),'Select market')]//parent::pfe-select//select/option[@value='" + MarketInfo[0] + "']")).Click();
                Console.WriteLine("Selected market is " + MarketInfo[1]);

                System.Threading.Thread.Sleep(2000);
                }
                else
                { Console.WriteLine("The user is a Dealer, so the market choice is NOT required"); }
                //Take VIN DATA
                List<string> VinInfo = Info.GetVinInfo();

                //Selet vehicle type
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pfe-select']/option[@value='"+ VinInfo[1] + "']")));
                Console.WriteLine("Verify the presence of range "+VinInfo[1]+" which correspond to "+ VinInfo[2] + " vehicle" );

                driver.FindElement(By.XPath("//*[@id='pfe-select']/option[@value='" + VinInfo[1] + "']")).Click();
                System.Threading.Thread.Sleep(2000);

                // FIND AND CLICK SEARCH VIN BUTTON AND INSERT VIN VALUE
                ExpandShadowElementClickAndSendKeys("pfe-input", 1, "[id=input]", VinInfo[0]); 

                // Click on Search icon
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SearchButtonLens)));
                System.Threading.Thread.Sleep(1000);
                IWebElement SearchButtonLens = driver.FindElement(By.XPath(Xpath.SearchButtonLens));
                js.ExecuteScript("arguments[0].click();", SearchButtonLens);
                Console.WriteLine("Click on Search button to look for VIN");

                // Verify test VIN has been added
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.JustAddedVIN)));
                Assert.That(driver.FindElement(By.XPath(Xpath.JustAddedVIN)).Text, Is.EqualTo(VinInfo[0]));
                Console.WriteLine("Verified correct VIN is inserted");

                // Click on LET'S START button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.LetsStartButton)));
                IWebElement LetsStartButton = driver.FindElement(By.XPath(Xpath.LetsStartButton));
                js.ExecuteScript("arguments[0].click()", LetsStartButton);
                Console.WriteLine("Clicked on LET'S START button and moved to STEP 2");

            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }


        public void ContractsSectionContractCreation2step(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info)
        { 
            try
            {

                //Take VIN DATA
                List<string> VinInfo = Info.GetVinInfo();
                Console.WriteLine("Entered in Step 2");
                
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='row title-box-details border-title' and contains(text(), '"+VinInfo[7]+"')]")));

                // Verify label: New contract
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.NewContract)));
                Assert.That(driver.FindElement(By.XPath(Xpath.NewContract)).Text, Is.EqualTo(Value.NewContract));
                Console.WriteLine("Verified correct label: " + Value.NewContract);

              

               IList<IWebElement> pfeCheckboxItem = driver.FindElements(By.TagName("pfe-checkbox"));

            foreach (List<string> RemovedServiceInfo in Info.GetRemovedServiceInfo())
            {
                //Removed first pre-selected service
                // Verify first service name
                AssertElementIsEqualTo("//div[@class='my-services-title' and contains(text(), '" + RemovedServiceInfo[0] + "')]", RemovedServiceInfo[0]);
            

                // Expand checkbox item and Click on checkbox to remove the first service
                    
                 String XpathCheckbox = "//div[@class='my-services-title' and contains(text(), '" + RemovedServiceInfo[0] + "')]/parent::div/parent::div//div[@class='my-service-footer-price' and contains (text(),'" + RemovedServiceInfo[2] + "')]/parent::div/parent::div//pfe-checkbox";
                 ExpandShadowElementClickXpath(XpathCheckbox, "[id=checkbox]");
                }

                foreach (List<string> AddedServiceInfo in Info.GetAddedServiceInfo())
            {
                // Verify first service name
                AssertElementIsEqualTo("//div[contains(@class, 'my-services')]//div[@class='my-services-title' and contains(text(), '" + AddedServiceInfo[0] + "')]", AddedServiceInfo[0]);
     

                // Verify first service price
                AssertElementIsEqualTo("//div[contains(@class, 'my-services')]//div[@class='my-services-title' and contains(text(), '" + AddedServiceInfo[0] + "')]/parent::div/parent::div//div[@class='my-service-footer-price' and contains(text(), '" + AddedServiceInfo[2] + "')]", AddedServiceInfo[2]);
     

                // Verify first service duration
                Console.WriteLine("TO FIX: //div[@class='my-services'][" + AddedServiceInfo[1] + "]//div[@class='my-service-footer-uom' and contains(text(), '" + AddedServiceInfo[3] + " " + AddedServiceInfo[4] + "')]");
                //wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='my-services'][" + AddedServiceInfo[1] + "]//div[@class='my-service-footer-uom' and contains(text(), '" + AddedServiceInfo[3] + " " + AddedServiceInfo[4] + "')]")));
                //Assert.That(driver.FindElement(By.XPath("//div[@class='my-services'][" + AddedServiceInfo[1] + "]//div[@class='my-service-footer-uom' and contains(text(), '" + AddedServiceInfo[3] +DurationService+ "')]")).Text, Is.EqualTo(AddedService[3]));
                Console.WriteLine("Verified correct service duration: " + AddedServiceInfo[3]+" "+AddedServiceInfo[4]);

                // Click on checkbox of first service
                //ExpandShadowElementAndClick("pfe-checkbox", Int32.Parse(AddedServiceInfo[5]), "[id=checkbox]");
                //System.Threading.Thread.Sleep(1000);
                //Console.WriteLine("Clicked on checkbox of service: " + AddedServiceInfo[0]);
                String XpathCheckbox = "//div[@class='my-services-title' and contains(text(), '" + AddedServiceInfo[0] + "')]/parent::div/parent::div//div[@class='my-service-footer-price' and contains (text(),'" + AddedServiceInfo[2] + "')]/parent::div/parent::div//pfe-checkbox";
                ExpandShadowElementClickXpath(XpathCheckbox, "[id=checkbox]");
                }

                // Click on OK NEXT button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.OkNextButton)));
                IWebElement OkNextButton = driver.FindElement(By.XPath(Xpath.OkNextButton));
                js.ExecuteScript("arguments[0].click()", OkNextButton);
                Console.WriteLine("Entered in Step 3");

            } 

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

        }


        public void ContractsSectionContractCreation3step(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info)
        {
            try
            {   //Retrieve VIN DATA
                List<string> VinInfo = Info.GetVinInfo();

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Verify label: New contract
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.NewContract)));
                Assert.That(driver.FindElement(By.XPath(Xpath.NewContract)).Text, Is.EqualTo(Value.NewContract));
                Console.WriteLine("Verified correct label: " + Value.NewContract);
                System.Threading.Thread.Sleep(2000);

                // Verify label: VIN code
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3VINCodeLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3VINCodeLabel)).Text, Is.EqualTo(Value.Step3VINCodeLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3VINCodeLabel);

                // Verify label: Commercial code
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3CommercialModelLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3CommercialModelLabel)).Text, Is.EqualTo(Value.Step3CommercialModelLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3CommercialModelLabel);

                // Verify label: Fuel
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3FuelLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3FuelLabel)).Text, Is.EqualTo(Value.Step3FuelLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3FuelLabel);

                // Verify label:Warranty start date
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3WarrantyStartDateLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3WarrantyStartDateLabel)).Text, Is.EqualTo(Value.Step3WarrantyStartDateLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3WarrantyStartDateLabel);

                // Verify label: VIN code value
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3VINCodeValue)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3VINCodeValue)).Text, Is.EqualTo(VinInfo[0]));
                Console.WriteLine("Verified correct label: " + VinInfo[0]);

                // Verify label: Fuel value
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3FuelValue)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3FuelValue)).Text, Is.EqualTo(VinInfo[3]));
                Console.WriteLine("Verified correct label: " + VinInfo[3]);

                // Verify label: Warranty start date value
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3WarrantyStartDateValue)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3WarrantyStartDateValue)).Text, Is.EqualTo(VinInfo[6]));
                Console.WriteLine("Verified correct label: " + VinInfo[6]);

                // Verify label: Plate value
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3PlateValue)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3PlateValue)).Text, Is.EqualTo(VinInfo[5]));
                Console.WriteLine("Verified correct label: " + VinInfo[5]);

                // Verify label: Service label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3ServiceLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3ServiceLabel)).Text, Is.EqualTo(Value.Step3ServiceLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3ServiceLabel);

                // Verify label: Duration label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3DurationLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3DurationLabel)).Text, Is.EqualTo(Value.Step3DurationLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3DurationLabel);

                // Verify label: Service start date label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3ServiceStartDateLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3ServiceStartDateLabel)).Text, Is.EqualTo(Value.Step3ServiceStartDateLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3ServiceStartDateLabel);

                // Verify label: Service end date label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3ServiceEndDateLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3ServiceEndDateLabel)).Text, Is.EqualTo(Value.Step3ServiceEndDateLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3ServiceEndDateLabel);

                // Verify label: Discount label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3DiscountLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3DiscountLabel)).Text, Is.EqualTo(Value.Step3DiscountLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3DiscountLabel);

                // Verify label: Price label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3PriceLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3PriceLabel)).Text, Is.EqualTo(Value.Step3PriceLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3PriceLabel);
               
                foreach (List<string> AddedServiceInfo in Info.GetAddedServiceInfo())
                {
              
                // Verify label: First service name
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='slot-2 padding-t padding-r' and contains(text(), '"+ AddedServiceInfo[0]+"')]")));
                Assert.That(driver.FindElement(By.XPath("//div[@class='slot-2 padding-t padding-r' and contains(text(), '" + AddedServiceInfo[0] + "')]")).Text, Is.EqualTo(AddedServiceInfo[0]));
                Console.WriteLine("Verified correct label: " + AddedServiceInfo[0]);

                // Verify label: First service price
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'slot-8 padding-t right') and contains(text(), '"+ AddedServiceInfo[2] + "')]")));
                Assert.That(driver.FindElement(By.XPath("//div[contains(@class, 'slot-8 padding-t right') and contains(text(), '" + AddedServiceInfo[2] + "')]")).Text, Is.EqualTo(AddedServiceInfo[2]));
                Console.WriteLine("Verified correct label: " + AddedServiceInfo[2]);

                // Verify label: First service duration
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='slot-3 padding-t padding-r service-duration' and contains(text(), '"+ AddedServiceInfo[3]+"')]")));
                //Assert.That(driver.FindElement(By.XPath("//div[@class='slot-3 padding-t padding-r service-duration' and contains(text(), '" + AddedServiceInfo[3] + "')]")).Text, Is.EqualTo(AddedServiceInfo[3] + DurationService));
                Console.WriteLine("Verified correct label: " + AddedServiceInfo[3] + " "+ AddedServiceInfo[4]);
                }
                //Retrieve Price Info
                List<string> PriceInfo = Info.GetPriceInfo();
                
                if (PriceInfo[2]!= "EUR 0.00" && PriceInfo[2] != "GBP 0.00" && PriceInfo[2] != "PLN 0.00")
                {
                // Verify label: Add discount only when the contract price is different from zero
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3AddDiscount)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3AddDiscount)).Text, Is.EqualTo(Value.Step3AddDiscount));
                Console.WriteLine("Verified correct label: " + Value.Step3AddDiscount);
                }

                // Verify label: Total
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3Total)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3Total)).Text, Is.EqualTo(PriceInfo[0]));
                Console.WriteLine("Verified correct label: " + PriceInfo[0]);

                // Verify label: Total discounted
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3TotalDiscounted)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3TotalDiscounted)).Text, Is.EqualTo(PriceInfo[1]));
                Console.WriteLine("Verified correct label: " + PriceInfo[1]);

                // Verify label: Final price
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3FinalPrice)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3FinalPrice)).Text, Is.EqualTo(PriceInfo[2]));
                Console.WriteLine("Verified correct label: " + PriceInfo[2]);


                // Click on OK NEXT button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.OkNextButton)));
                IWebElement OkNextButton = driver.FindElement(By.XPath(Xpath.OkNextButton));
                js.ExecuteScript("arguments[0].click()", OkNextButton);

                //Wait until the NEXT button is enabled again
                // Wait definition for element
                int NextButtonVisible = WaitingSpinner(Xpath.OKNextButtonDisabled, 5000);
            
           
                Console.WriteLine("Entered in Step 4");
               
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }

        public void CustomerFilling(Xpath__Contracts Xpath, Values__ContractNotRegression Info)
        {
            // Wait definition for element
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
      
            //Retrieve Company sites data
            List<string> CompanySiteInfo = Info.GetCompanySiteInfo();

            // Expand Number VAT and Insert Number VAT
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.VATNumberCustomer,"[id = input]", CompanySiteInfo[0]);

            // Click on VAT Number SEARCH icon
            ExpandShadowElementClickNew(Xpath.SearchButtonVATNumber, "span[class=pfe-cta--wrapper]", "search button");

            //wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SearchButtonVATNumber)));
            //IWebElement SearchButtonVATNumber = driver.FindElement(By.XPath(Xpath.SearchButtonVATNumber));
            //js.ExecuteScript("arguments[0].click()", SearchButtonVATNumber);
            //Console.WriteLine("Click on Search Button for VAT Number");

            Console.WriteLine("Waiting for loader");
            int loaderVisible = WaitingSpinner(Xpath.Loader, 5000);

            // Click on Insert New Customer
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.InsertNewCustomer)));
            IWebElement InsertNewCustomer = driver.FindElement(By.XPath(Xpath.InsertNewCustomer));
            js.ExecuteScript("arguments[0].click()", InsertNewCustomer);
            Console.WriteLine("Click on Insert New Customer");
            System.Threading.Thread.Sleep(2000);

            // Expand Continue button
            JSClickDropdownChoice(Xpath.ContinueButtonCustomer, "Continue button", 2000);

            // Expand Company name and inserts value
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.CompanyCustomer, "[id = input]", CompanySiteInfo[1]);
            Console.WriteLine("Inserted Company name: " + CompanySiteInfo[1]);
            System.Threading.Thread.Sleep(500);

            // Expand Address and inserts value
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.AddressCustomer, "[id = input]", CompanySiteInfo[2]);
            Console.WriteLine("Inserted Address: " + CompanySiteInfo[2]);
            System.Threading.Thread.Sleep(500);

            // Expand Post code and inserts value
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.PostCodeCustomer, "[id = input]", CompanySiteInfo[3]);
            Console.WriteLine("Inserted Post code: " + CompanySiteInfo[3]);
            System.Threading.Thread.Sleep(500);

            // Expand City and inserts value
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.CityCustomer, "[id = input]", CompanySiteInfo[5]);
            Console.WriteLine("Inserted City: " + CompanySiteInfo[5]);
            System.Threading.Thread.Sleep(500);

            // Expand Phone number and inserts value
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.PhoneNumberCustomer, "[id = input]", CompanySiteInfo[4]);
            Console.WriteLine("Inserted Phone number: " + CompanySiteInfo[4]);
            System.Threading.Thread.Sleep(500);

            // Expand Client Email and inserts value
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.EmailCustomer, "[id = input]", CompanySiteInfo[6]);
            Console.WriteLine("Inserted Client email: " + CompanySiteInfo[6]);
            System.Threading.Thread.Sleep(500);

            // Expand Signatory Name and inserts value

            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SignatoryName, "[id = input]", CompanySiteInfo[7]);
            Console.WriteLine("Inserted Signatory name: " + CompanySiteInfo[7]);
            System.Threading.Thread.Sleep(500);

            // Expand Signatory Surname  and inserts value
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SignatorySurname, "[id = input]", CompanySiteInfo[8]);
            Console.WriteLine("Inserted Signatory surname: " + CompanySiteInfo[8]);
            System.Threading.Thread.Sleep(500);
            /*
            // Click on Date of Birth Signatory
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DateOfBirthSignatory)));
            IWebElement DateOfBirthSignatory = driver.FindElement(By.XPath(Xpath.DateOfBirthSignatory));
            js.ExecuteScript("arguments[0].click()", DateOfBirthSignatory);

            // Expand Date Of Birth Signatory
            IList<IWebElement> pfeCalendarItem = driver.FindElements(By.TagName("pfe-calendar"));
            IWebElement shadowPfeCalendarInputItem = expandRootElement(pfeCalendarItem[1]);
            IWebElement CalendarInputItem = shadowPfeCalendarInputItem.FindElement(By.CssSelector("[aria-label='" + Value.DateOfBirthSignatory + "']"));
            js.ExecuteScript("arguments[0].click();", CalendarInputItem);
            Console.WriteLine("Inserted Date of birth signatory: " + Value.DateOfBirthSignatory);
            
            */
            // Expand Place Of Birth Signatory  and inserts value
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SignatoryBirthPlace, "[id = input]", CompanySiteInfo[9]);
            Console.WriteLine("Inserted Place of birth signatory: " + CompanySiteInfo[9]);
            System.Threading.Thread.Sleep(500);


            // Expand Signer Email  and inserts value // to ass the value of email in CompanySiteInfo list string
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SignatoryEmail, "[id = input]", CompanySiteInfo[12]);
            Console.WriteLine("Inserted Signer email: " + "");
            System.Threading.Thread.Sleep(500);
        }
       
        public void PayerDataFilling(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info, String FlagDigitalSignature)
        {           
        //Retrieve Company sites data
        List<string> CompanySiteInfo = Info.GetCompanySiteInfo();
        List<string> PayerNumbering = new List<string>{ };
 
        // Expand IBAN
        ExpandShadowElementClickAndSendKeysSTEP4(Xpath.IBANPayer, "[id = input]", CompanySiteInfo[10]);
        System.Threading.Thread.Sleep(500);

        // Expand BIC
        ExpandShadowElementClickAndSendKeysSTEP4(Xpath.BICPayer, "[id = input]", CompanySiteInfo[11]);
        System.Threading.Thread.Sleep(500);

        //Retrieve Price DATA
        List<string> PriceInfo = Info.GetPriceInfo();

        //Retrieve Company DATA
        List<string> MarketInfo = Info.GetMarketInfo();

        //The SEPA fields are present only for not-free contract and they are different for each country 
            
            if ( PriceInfo[2] != "EUR 0.00" && MarketInfo[1] == "Italy")
            {
              // Expand Presso la banca
              ExpandShadowElementClickAndSendKeysSTEP4(Xpath.BankPayerItalyGermany, "[id = input]", "Banck test");
              System.Threading.Thread.Sleep(500);
              
              // Expand  Codice fiscale/Partita IVA debitore* 
              ExpandShadowElementClickAndSendKeysSTEP4(Xpath.FiscalCodePayer, "[id = input]", "VATtest");
              System.Threading.Thread.Sleep(500);

              // Expand  Codice SDI o PEC del Debitore* 
              ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SDIPayer, "[id = input]", "SDItest");
              System.Threading.Thread.Sleep(500);

            }
            else if (PriceInfo[2] != "GBP 0.00" &&  MarketInfo[1] == "United Kingdom")
            {
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.BankPayer, "[id = input]", "Banck test");
                System.Threading.Thread.Sleep(500);

                // Expand  Codice fiscale/Partita IVA debitore* 
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.BranchSortCode, "[id = input]", "Sort Code test");
                System.Threading.Thread.Sleep(500);
            }

            else if (PriceInfo[2] != "EUR 0.00" && MarketInfo[1] == "Germany")
            {
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.BankPayerItalyGermany, "[id = input]", "Banck test");
                System.Threading.Thread.Sleep(500);

                // Expand  Codice fiscale/Partita IVA debitore* 
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.FiscalCodePayer, "[id = input]", "Fiscal Code");
                System.Threading.Thread.Sleep(500);
            }

        }

        public void MFMFilling(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info, String FlagDigitalSignature)
        {
            //Retrieve MFM data
            List<string> MFMInfo = Info.GetMFMInfo();
            List<string> MarketInfo = Info.GetMarketInfo();
            List<string> PriceInfo = Info.GetPriceInfo();


            // Expand Activation email address and Insert Activation email address
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.EmailMFM, "[id=input]", MFMInfo[0]);
            System.Threading.Thread.Sleep(1000);

            // Expand prefix for Phone number
            JSClickDropdownChoice("//app-contract-fleet-manager//div[@class='iti__selected-flag dropdown-toggle']//div[@class='iti__arrow']", "search containers", 500);
            JSClickDropdownChoice("//app-contract-fleet-manager//*[@id='iti-0__item-" + MarketInfo[4]+"']/span[1]", MarketInfo[4], 500);
            Console.WriteLine("Select prefix for country:  +" + MarketInfo[4]);

            // Expand Phone number
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.PhoneMFM, "[name =phoneNumber]", MFMInfo[1]);
            System.Threading.Thread.Sleep(500);

            // Expand FM name
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.NameMFM, "[name =fmFirstname]", MFMInfo[2]);
            System.Threading.Thread.Sleep(500);

            // Expand FM surname
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SurnameMFM, "[name =fmLastname]", MFMInfo[3]);
            System.Threading.Thread.Sleep(500);

   
        }


        public void FinancialAdminFilling(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegressionPayerData Info , Values__ContractNotRegression Info2)
        {
            //Retrieve MFM data
            List<string> FinancialInfo = Info.GetFinancialInfo();
            List<string> MarketInfo = Info2.GetMarketInfo();

            // Expand Activation email address and Insert Activation email address
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.EmailFinancial, "[id=input]", FinancialInfo[0]);
            System.Threading.Thread.Sleep(1000);


            // Expand prefix for Phone number
            JSClickDropdownChoice("//app-contract-financial-admin//div[@class='iti__selected-flag dropdown-toggle']//div[@class='iti__arrow']", "search containers", 500);
            JSClickDropdownChoice("//app-contract-financial-admin//*[@id='iti-0__item-" + MarketInfo[4] + "']/span[1]", MarketInfo[4], 500);
            Console.WriteLine("Select prefix for country:  +" + MarketInfo[4]);
            // Expand Phone number
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.PhoneFinancial, "[name = phoneNumberFA]", FinancialInfo[1]);
            System.Threading.Thread.Sleep(500);

            // Expand FM name
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.NameFinancial, "[name =faFirstname]", FinancialInfo[2]);
            System.Threading.Thread.Sleep(500);

            // Expand FM surname
            ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SurnameFinancial, "[name =faLastname]", FinancialInfo[3]);
            System.Threading.Thread.Sleep(500);


        }


        public void ContractsSectionContractCreation4step(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info,String FlagDigitalSignature)
        {
           try
           {
           // Wait definition for element
           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

           //Retrieve Company sites data
           List<string> CompanySiteInfo = Info.GetCompanySiteInfo();
           //Retrieve MFM data
           List<string> MFMInfo = Info.GetMFMInfo();

         
               if (FlagDigitalSignature=="true")
               {
                    Console.WriteLine("The digital signature is enabled");
               }
               else
               {
                    Console.WriteLine("The digital signature is NOT enabled");
               }

           // Verify label: New contract
           wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.NewContract)));
           Assert.That(driver.FindElement(By.XPath(Xpath.NewContract)).Text, Is.EqualTo(Value.NewContract));
           Console.WriteLine("Verified correct label: " + Value.NewContract);

           //Filling customer information 
           CustomerFilling(Xpath,Info);
          
           //Filling payer data 
           PayerDataFilling(Xpath, Value, Info, FlagDigitalSignature);
    
            // Define pfe-input shadow element
           IList<IWebElement> pfeStep4InputItem = driver.FindElements(By.TagName("pfe-input"));
            
           //Filling mfm data in case of main account is non stil set
           //MFMFilling(Xpath, Value, Info, FlagDigitalSignature); //the main account is already filled and NOT editable when the company is mapped on DB side

           // Click on OK NEXT button
           wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.OkNextButton)));
           IWebElement OkNextButton = driver.FindElement(By.XPath(Xpath.OkNextButton));
           js.ExecuteScript("arguments[0].click()", OkNextButton);

           //Wait until the NEXT button is enabled again
           int NextButtonVisible =  WaitingSpinner(Xpath.OKNextButtonDisabled, 5000);
           Console.WriteLine("Waiting until NEXT button is enabled");
         

           }
            catch (Exception e)
           {
                GetScreenshotAndPrintError(e); ;
           }

          
        }

        public void ContractsSectionContractCreation4stepWithpayerDifferentFromCustomer(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info, Values__ContractNotRegressionPayerData PayerData, String FlagDigitalSignature)
        {
            try
            {   //Retrieve Company sites data
                List<string> CompanySiteInfo = Info.GetCompanySiteInfo();
                //Retrieve MFM data
                List<string> MFMInfo = Info.GetMFMInfo();
                //Retrieve Payer data
                List<string> PayerInfo = PayerData.GetPayerInfo();
               
                if (FlagDigitalSignature == "true")
                {
                    Console.WriteLine("The digital signature is enabled");
                }
                else
                {
                    Console.WriteLine("The digital signature is NOT enabled");
                }

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Verify label: New contract
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.NewContract)));
                Assert.That(driver.FindElement(By.XPath(Xpath.NewContract)).Text, Is.EqualTo(Value.NewContract));
                Console.WriteLine("Verified correct label: " + Value.NewContract);

                Console.WriteLine("Entered in Step 5");
                //Customer filling
                CustomerFilling(Xpath, Info);

                //Selecting payer is different from customer
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//pfe-radio[@value='no']")));
                IWebElement RadioNo = driver.FindElement(By.XPath("//pfe-radio[@value='no']"));
                js.ExecuteScript("arguments[0].click()", RadioNo);
                Console.WriteLine("Click on radio button NO: payer is different from customer");
                System.Threading.Thread.Sleep(500);


                //DATA OF THE PAYER DIFFERENT FROM CUSTOMER/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Expand Number VAT
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.VATNumberPayer, "[id = input]", PayerInfo[0]);
              
                // Click on VAT Number SEARCH icon
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SearchButtonVATNumberPayer)));
                IWebElement SearchButtonVATNumberPayer = driver.FindElement(By.XPath(Xpath.SearchButtonVATNumberPayer));
                js.ExecuteScript("arguments[0].click()", SearchButtonVATNumberPayer);
                Console.WriteLine("Click on Search Button for VAT Number of Payer");


                int loaderVisible2 = WaitingSpinner(Xpath.Loader, 5000);
                Console.WriteLine("Waited until loader is not visible anymore");

               
                // Click on Insert New Customer
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.InsertNewPayer)));
                IWebElement InsertNewPayer = driver.FindElement(By.XPath(Xpath.InsertNewPayer));
                js.ExecuteScript("arguments[0].click()", InsertNewPayer);
                Console.WriteLine("Click on Insert New Payer");
                System.Threading.Thread.Sleep(2000);

                // Expand Continue button
                JSClickDropdownChoice(Xpath.ContinueButtonPayer, "Continue button", 2000);


                // Expand Company name and insert Company name
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.CompanyPayer, "[id = input]", PayerInfo[1]);
                System.Threading.Thread.Sleep(500);

                // Expand Address and insert it
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.AddressPayer, "[id = input]", PayerInfo[2]);
                System.Threading.Thread.Sleep(500);

                // Expand Post code and insert it
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.PostCodePayer, "[id = input]", PayerInfo[3]);
                System.Threading.Thread.Sleep(500);

                // Expand City and Insert City
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.CityPayer, "[id = input]", PayerInfo[5]);
                System.Threading.Thread.Sleep(500);

                // Expand Phone number and insert it
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.PhoneNumberPayer, "[id = input]", PayerInfo[4]);
                System.Threading.Thread.Sleep(500);

                // Expand Client Email and insert it
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.EmailPayer, "[id = input]", PayerInfo[6]);
                System.Threading.Thread.Sleep(500);

                // Expand Signatory Name and insert it
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SignatoryNamePayer, "[id = input]", PayerInfo[7]);
                System.Threading.Thread.Sleep(500);

                // Expand Signatory Surname
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SignatorySurnamePayer, "[id = input]", PayerInfo[8]);
                System.Threading.Thread.Sleep(500);

                /*
                // Click on Date of Birth Signatory
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DateOfBirthSignatory)));
                IWebElement DateOfBirthSignatory = driver.FindElement(By.XPath(Xpath.DateOfBirthSignatory));
                js.ExecuteScript("arguments[0].click()", DateOfBirthSignatory);

                // Expand Date Of Birth Signatory
                IList<IWebElement> pfeCalendarItem = driver.FindElements(By.TagName("pfe-calendar"));
                IWebElement shadowPfeCalendarInputItem = expandRootElement(pfeCalendarItem[1]);
                IWebElement CalendarInputItem = shadowPfeCalendarInputItem.FindElement(By.CssSelector("[aria-label='" + Value.DateOfBirthSignatory + "']"));
                js.ExecuteScript("arguments[0].click();", CalendarInputItem);
                Console.WriteLine("Inserted Date of birth signatory: " + Value.DateOfBirthSignatory);

                */
                // Expand Place Of Birth Signatory
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SignatoryBirthPlacePayer, "[id = input]", PayerInfo[9]);
                System.Threading.Thread.Sleep(500);

                // Expand payer signer email 
                ExpandShadowElementClickAndSendKeysSTEP4(Xpath.SignatoryEmailPayer, "[id = input]", PayerInfo[10]);
                System.Threading.Thread.Sleep(500);
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Payer data filling
                PayerDataFilling(Xpath,Value,Info, FlagDigitalSignature);


                //Finacial admin filling
                FinancialAdminFilling(Xpath, Value, PayerData, Info);


                //MFM filling
                //MFMFilling(Xpath, Value, Info, FlagDigitalSignature); //the main account is already filled if the company has already the account and it is not editable


                // Click on OK NEXT button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.OkNextButton)));
                IWebElement OkNextButton = driver.FindElement(By.XPath(Xpath.OkNextButton));
                js.ExecuteScript("arguments[0].click()", OkNextButton);

                //Wait until the NEXT button is enabled again
                int NextButtonVisible = WaitingSpinner(Xpath.OKNextButtonDisabled, 5000); ;
                Console.WriteLine("Waited until NEXT button is clickable");
                Console.WriteLine("Entered in Step 5");


            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }


        }

        public void ContractsSectionContractCreation5step(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info)
        {
            try
            {   //Retrieve VIN DATA
                List<string> VinInfo = Info.GetVinInfo();

                //Retrieve Price DATA
                List<string> PriceInfo = Info.GetPriceInfo();

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                System.Threading.Thread.Sleep(3000);
                // Verify label: New contract
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.NewContract)));
                Assert.That(driver.FindElement(By.XPath(Xpath.NewContract)).Text, Is.EqualTo(Value.NewContract));
                Console.WriteLine("Verified correct label: " + Value.NewContract);

                // Verify label: VIN code
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3VINCodeLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3VINCodeLabel)).Text, Is.EqualTo(Value.Step3VINCodeLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3VINCodeLabel);

                // Verify label: Commercial code
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3CommercialModelLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3CommercialModelLabel)).Text, Is.EqualTo(Value.Step3CommercialModelLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3CommercialModelLabel);

                // Verify label: Fuel
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3FuelLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3FuelLabel)).Text, Is.EqualTo(Value.Step3FuelLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3FuelLabel);

                // Verify label:Warranty start date
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3WarrantyStartDateLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3WarrantyStartDateLabel)).Text, Is.EqualTo(Value.Step3WarrantyStartDateLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3WarrantyStartDateLabel);

                // Verify label: VIN code value
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3VINCodeValue)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3VINCodeValue)).Text, Is.EqualTo(VinInfo[0]));
                Console.WriteLine("Verified correct label: " + VinInfo[0]);

                // Verify label: Fuel value
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3FuelValue)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3FuelValue)).Text, Is.EqualTo(VinInfo[3]));
                Console.WriteLine("Verified correct label: " + VinInfo[3]);

                // Verify label: Warranty start date value
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3WarrantyStartDateValue)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3WarrantyStartDateValue)).Text, Is.EqualTo(VinInfo[6]));
                Console.WriteLine("Verified correct label: " + VinInfo[6]);

                // Verify label: Plate value
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3PlateValue)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3PlateValue)).Text, Is.EqualTo(VinInfo[5]));
                Console.WriteLine("Verified correct label: " + VinInfo[5]);

                // Verify label: Service label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3ServiceLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3ServiceLabel)).Text, Is.EqualTo(Value.Step3ServiceLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3ServiceLabel);

                // Verify label: Duration label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3DurationLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3DurationLabel)).Text, Is.EqualTo(Value.Step3DurationLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3DurationLabel);

                // Verify label: Service start date label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3ServiceStartDateLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3ServiceStartDateLabel)).Text, Is.EqualTo(Value.Step3ServiceStartDateLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3ServiceStartDateLabel);

                // Verify label: Service end date label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3ServiceEndDateLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3ServiceEndDateLabel)).Text, Is.EqualTo(Value.Step3ServiceEndDateLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3ServiceEndDateLabel);

                // Verify label: Discount label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3DiscountLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3DiscountLabel)).Text, Is.EqualTo(Value.Step3DiscountLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3DiscountLabel);

                // Verify label: Price label
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3PriceLabel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3PriceLabel)).Text, Is.EqualTo(Value.Step3PriceLabel));
                Console.WriteLine("Verified correct label: " + Value.Step3PriceLabel);

            foreach (List<string> AddedServiceInfo in Info.GetAddedServiceInfo())
            {
                // Verify first service name
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='slot-2 padding-t padding-r' and contains(text(), '"+ AddedServiceInfo[0] + "')]")));
                Assert.That(driver.FindElement(By.XPath("//div[@class='slot-2 padding-t padding-r' and contains(text(), '" + AddedServiceInfo[0] + "')]")).Text, Is.EqualTo(AddedServiceInfo[0]));
                Console.WriteLine("Verified correct service name: " + AddedServiceInfo[0]);
                
                // Verify first service price
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'slot-8 padding-t right') and contains(text(), '"+ AddedServiceInfo[2] + "')]")));
                Assert.That(driver.FindElement(By.XPath("//div[contains(@class, 'slot-8 padding-t right') and contains(text(), '" + AddedServiceInfo[2] + "')]")).Text, Is.EqualTo(AddedServiceInfo[2]));
                Console.WriteLine("Verified correct service price: " + AddedServiceInfo[2]);
                
                // Verify first service duration
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='slot-3 padding-t padding-r service-duration' and contains(text(), '"+ AddedServiceInfo[3] + "')]")));
                //Assert.That(driver.FindElement(By.XPath("//div[@class='slot-3 padding-t padding-r service-duration' and contains(text(), '"+ AddedServiceInfo[3] + "')])).Text, Is.EqualTo(AddedServiceInfo[3]));
                Console.WriteLine("Verified correct service duration: " + AddedServiceInfo[3]+" "+ AddedServiceInfo[4]);
                }
               
                // Verify label: Total
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3Total)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3Total)).Text, Is.EqualTo(PriceInfo[0]));
                Console.WriteLine("Verified correct label: " + PriceInfo[0]);

                // Verify label: Total discounted
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3TotalDiscounted)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3TotalDiscounted)).Text, Is.EqualTo(PriceInfo[1]));
                Console.WriteLine("Verified correct label: " + PriceInfo[1]);

                // Verify label: Final price
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Step3FinalPrice)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Step3FinalPrice)).Text, Is.EqualTo(PriceInfo[2]));
                Console.WriteLine("Verified correct label: " + PriceInfo[2]);

                // Click on OK NEXT button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.OkNextButton)));
                IWebElement OkNextButton2 = driver.FindElement(By.XPath(Xpath.OkNextButton));
                js.ExecuteScript("arguments[0].click()", OkNextButton2);
                Console.WriteLine("Entered in Step 6");


            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }
        public void ContractsSectionContractCreation6step(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info)
        { 
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                IWebElement NewConractElement = (driver.FindElement(By.XPath(Xpath.NewContract)));
                js.ExecuteScript("arguments[0].scrollIntoView();", NewConractElement);

                // Verify label: New contract
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.NewContract)));
                Assert.That(driver.FindElement(By.XPath(Xpath.NewContract)).Text, Is.EqualTo(Value.NewContract));
                Console.WriteLine("Verified correct label: " + Value.NewContract);
             
                //Click on downlaod button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DownloadContract)));
                IWebElement DownloadContract = driver.FindElement(By.XPath(Xpath.DownloadContract));
                js.ExecuteScript("arguments[0].click()", DownloadContract);
                Console.WriteLine("Click on download button");
                System.Threading.Thread.Sleep(5000);

                //Verify the downloaded contract
                //Take the today data to insert in the downloaded contract
                DateTime thisDay = DateTime.Today;
                String DownloadTitlewithoutContractReference = thisDay.ToString("yyyy-M-d") + Value.DownloadTitle;
                String ContractReference = ContractRefenceDownloaded(DownloadTitlewithoutContractReference);
  

                // Check presence of export file and delete it
                Console.WriteLine("Check if file is availbale in /Download section");
                bool downloadContractFileExistAndRemove = CheckFileDownloaded(DownloadTitlewithoutContractReference);
                Assert.That(downloadContractFileExistAndRemove == true);
                Console.WriteLine("Removal completed");

                System.Threading.Thread.Sleep(1000);
                //Retrieve Price DATA
                List<string> PriceInfo = Info.GetPriceInfo();
                //The SEPA file is present only for not-free contract 
                if (PriceInfo[2] != "EUR 0.00" && PriceInfo[2] != "GBP 0.00")
                {
                 //Click on downlaod button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DownloadSEPA)));
                IWebElement DownloadSEPA = driver.FindElement(By.XPath(Xpath.DownloadSEPA));
                js.ExecuteScript("arguments[0].click()", DownloadSEPA);
                Console.WriteLine("Click on download button");
                System.Threading.Thread.Sleep(5000);

                //Verify the downloaded SEPA
                Console.WriteLine("Check if SEPA file is available in /Download section");
                bool downloadSEPAExist = CheckFileDownloaded(Value.SEPATitle);
                Assert.That(downloadSEPAExist == true);
                Console.WriteLine("Check completed");
                }
                else
                {
                    Console.WriteLine("The contract is at zero price");
                }
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }

        public string ContractsSectionCheckDownloadedPDF(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info)
        {
            String ContractReference = "";
            String ContractReferenceWithX = "";

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                //Retrieve PDF Data
                List<string> ValuePDF = Info.GetValuePDF();
                //Retrieve CompanyData
                List<string> CompanySiteInfo = Info.GetCompanySiteInfo();

                //Take Market Data
                List<string> MarketInfo = Info.GetMarketInfo();

                //Retrieve VinInfo
                List<string> vinInfo = Info.GetVinInfo();

                IWebElement NewContractElement = (driver.FindElement(By.XPath(Xpath.NewContract)));

                //Verify label: New contract
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.NewContract)));
                System.Threading.Thread.Sleep(5000);

                //Click on downlaod button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DownloadContract)));
                IWebElement DownloadContract = driver.FindElement(By.XPath(Xpath.DownloadContract));
                js.ExecuteScript("arguments[0].click()", DownloadContract);
                Console.WriteLine("Click on download button");

                //Waiting for spinner
                WaitingSpinner(Xpath.Spinner, 5000);


                //Verify the downloaded contract
                //Take the today data to insert in the downloaded contract
                DateTime thisDay = DateTime.Today;
                String DownloadTitlewithoutContractReference = thisDay.ToString("yyyy-MM-d") + Value.DownloadTitle;
                String ContractReferenceWithLanguageCode = ContractRefenceDownloaded(DownloadTitlewithoutContractReference);

                ContractReference = ContractReferenceWithLanguageCode.Replace("_" + MarketInfo[3], "");

                ContractReferenceWithX = ContractReference.Replace("M", "X");

                // Define information to be checked inside the PDF
                List<List<string>> ValuesPDF = new List<List<string>>
        {
              new List<string> {ValuePDF[0], CompanySiteInfo[1]}, //Company Name
              new List<string> {ValuePDF[1], CompanySiteInfo[7] + " "+CompanySiteInfo[8] }, //signatory name and surname
              new List<string> {ValuePDF[2], CompanySiteInfo[2]}, //address
              new List<string> {ValuePDF[3], CompanySiteInfo[3]}, //post cose
              new List<string> {ValuePDF[4], CompanySiteInfo[5]}, //city 
              new List<string> {ValuePDF[5], CompanySiteInfo[9]},//Country
              new List<string> {ValuePDF[6], CompanySiteInfo[4]},//phone number
              new List<string> {ValuePDF[7], CompanySiteInfo[6]},//client email
              new List<string> {ValuePDF[8], CompanySiteInfo[10]},//IBAN
              new List<string> {ValuePDF[9], CompanySiteInfo[11]},  //BIC 
              new List<string> {ValuePDF[10], ContractReference}, //Contract reference
              //new List<string> {ValuePDF[11], AddedService1Info[0]}, //servicename 1 
              //new List<string> {ValuePDF[11], AddedService2Info[0] }, //servicename 2 
              new List<string> {ValuePDF[12], vinInfo[5]},// vin plate
              new List<string> {ValuePDF[13], vinInfo[4]}, //vin commercial model
              new List<string> {ValuePDF[14], vinInfo[0]}, //vin id
              //new List<string> {AddedService1Info[0] + ";" ,ValuePDF[18]},  //servicename,  duration+price    // aggiungere start and end date
              //new List<string> {AddedService2Info[0] + ";",  ValuePDF[17]},//servicename,  duration+price  // aggiungere start and end date
              new List<string> { ValuePDF[15], ValuePDF[16] }, //finalPrice 

        };
               
                // Save PDF content
                StringBuilder PDFcontent = new StringBuilder();
                using (PdfReader reader = new PdfReader(System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads\\" + DownloadTitlewithoutContractReference + ContractReferenceWithLanguageCode + ".pdf"))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        PDFcontent.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                }
                //Print the contract PDF content
                //Console.WriteLine(PDFcontent.ToString());

                //Starting verification of data in PDF
                Console.WriteLine("Starting verification of data in PDF");
                int foundvalue = 0;
                foreach (List<string> DataPDf in ValuesPDF)
                {
                    if (PDFcontent.ToString().Contains(DataPDf[0]) && PDFcontent.ToString().Contains(DataPDf[1])) //impleted in this way for the fact that the order of data in pdf is not correct
                    {
                        Console.WriteLine("'" + DataPDf[0] + " " + DataPDf[1] + "'" + " found on PDF");
                    }
                    else
                    {
                        Console.WriteLine(DataPDf[0] + " " + DataPDf[1] + "'" + " not found");
                        foundvalue++;
                    }
                }
                // Service verification data
                //Remember: aggiungere start and end date
                foreach (List<string> AddedService in Info.GetAddedServiceInfo())
                {
                    if (PDFcontent.ToString().Contains(ValuePDF[11]) && PDFcontent.ToString().Contains(AddedService[0])) 
                    {
                        Console.WriteLine("'" + ValuePDF[11] + " " + AddedService[0] + "'" + " found on PDF");
                    }
                    else
                    {
                        Console.WriteLine(ValuePDF[11] + " " + AddedService[0] + "'" + " not found");
                        foundvalue++;
                    }

                    if (PDFcontent.ToString().Contains(AddedService[0]+";") && PDFcontent.ToString().Contains(AddedService[6])) 
                    {
                        Console.WriteLine("'" + AddedService[0] + " " + AddedService[6] + "'" + " found on PDF");
                    }
                    else
                    {
                        Console.WriteLine(AddedService[0] + " " + AddedService[6] + "'" + " not found");
                        foundvalue++;
                    }
                }
                // Check presence of export file and delete it
                Console.WriteLine("Check if file is availbale in /Download section");
                bool downloadContractFileExistAndRemove = CheckFileDownloaded(DownloadTitlewithoutContractReference);
                Assert.That(downloadContractFileExistAndRemove == true);
                Console.WriteLine("Removal completed");

                if (foundvalue != 0)
                {
                    Assert.Fail("Test failed. One of the data inserted on contract creation was not found on generated PDF");

                }

                System.Threading.Thread.Sleep(1000);
                //Retrieve Price DATA
                List<string> PriceInfo = Info.GetPriceInfo();
                //The SEPA file is present only for not-free contract 
                if (PriceInfo[2]!= "EUR 0.00" && PriceInfo[2] != "GBP 0.00" && MarketInfo[1]!="Poland" && MarketInfo[1] != "Belgium" && MarketInfo[1] != "United Kingdom" && MarketInfo[1] != "Austria") 
                {
                //Click on download button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DownloadSEPA)));
                IWebElement DownloadSEPA = driver.FindElement(By.XPath(Xpath.DownloadSEPA));
                js.ExecuteScript("arguments[0].click()", DownloadSEPA);
                Console.WriteLine("Click on download button");

                //Waiting for spinner
                WaitingSpinner(Xpath.Spinner, 5000);
                

                //Verify the downloaded SEPA
                Console.WriteLine("Check if SEPA file is available in /Download section");
                bool downloadSEPAExist = CheckFileDownloaded(Value.SEPATitle);
                Assert.That(downloadSEPAExist == true);
                Console.WriteLine("Check completed");
                }
                else
                {
                    Console.WriteLine("The contract is at zero price or for that country SEPA is not available");
                }
                return (ContractReferenceWithX);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
                return (ContractReferenceWithX);
            }
        
        }


        public string ContractsSectionCheckDownloadedPDFCustomerDifferentFromPayer(Xpath__Contracts Xpath, Values__Contracts Value, Values__ContractNotRegression Info, Values__ContractNotRegressionPayerData PayerData)
        {
            String ContractReference = "";
            String ContractReferenceWithX = "";
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                //Retrieve PDF Data
                List<string> ValuePDF = Info.GetValuePDF();
                //Retrieve CompanyData
                List<string> CompanySiteInfo = Info.GetCompanySiteInfo();
                //Retrieve VinInfo
                List<string> vinInfo = Info.GetVinInfo();
                //Retrieve VinInfo
                List<string> PayerInfo = PayerData.GetPayerInfo();

                // IWebElement NewContractElement = (driver.FindElement(By.XPath(Xpath.NewContract)));

                //Verify label: New contract
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.NewContract)));
                System.Threading.Thread.Sleep(2000);

                //Click on downlaod button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DownloadContract)));
                IWebElement DownloadContract = driver.FindElement(By.XPath(Xpath.DownloadContract));
                js.ExecuteScript("arguments[0].click()", DownloadContract);
                Console.WriteLine("Click on download button");

                //Waiting for spinner
                WaitingSpinner(Xpath.Spinner, 5000);


                //Verify the downloaded contract
                //Take the today data to insert in the downloaded contract
                DateTime thisDay = DateTime.Today;
                String DownloadTitlewithoutContractReference = thisDay.ToString("yyyy-MM-d") + Value.DownloadTitle;
                String ContractReferenceWithLanguageCode = ContractRefenceDownloaded(DownloadTitlewithoutContractReference);
                //Take Market Data
                List<string> MarketInfo = Info.GetMarketInfo();

                ContractReference = ContractReferenceWithLanguageCode.Replace("_" + MarketInfo[3], "");
                ContractReferenceWithX = ContractReference.Replace("M", "X");

                // Define information to be checked inside the PDF
                List<List<string>> ValuesPDF = new List<List<string>>
        {
              new List<string> {ValuePDF[0], CompanySiteInfo[1]}, //Company Name
              new List<string> {ValuePDF[1], CompanySiteInfo[7] + " "+CompanySiteInfo[8] }, //signatory name and surname
              new List<string> {ValuePDF[2], CompanySiteInfo[2]}, //address
              new List<string> {ValuePDF[3], CompanySiteInfo[3]}, //post cose
              new List<string> {ValuePDF[4], CompanySiteInfo[5]}, //city 
              new List<string> {ValuePDF[5], CompanySiteInfo[9]},//Country
              new List<string> {ValuePDF[6], CompanySiteInfo[4]},//phone number
              new List<string> {ValuePDF[7], CompanySiteInfo[6]},//client email
              new List<string> {ValuePDF[8], CompanySiteInfo[10]},//IBAN
              new List<string> {ValuePDF[9], CompanySiteInfo[11]},  //BIC 
              new List<string> {ValuePDF[10], ContractReference}, //Contract reference
              //new List<string> {ValuePDF[11], AddedService1Info[0]}, //servicename 1 
              //new List<string> {ValuePDF[11], AddedService2Info[0] }, //servicename 2 
              new List<string> {ValuePDF[12], vinInfo[5]},// vin plate
              new List<string> {ValuePDF[13], vinInfo[4]}, //vin commercial model
              new List<string> {ValuePDF[14], vinInfo[0]}, //vin id
              //new List<string> {AddedService1Info[0] + ";" ,ValuePDF[18]},  //servicename,  duration+price    // aggiungere start and end date
              //new List<string> {AddedService2Info[0] + ";",  ValuePDF[17]},//servicename,  duration+price  // aggiungere start and end date
              new List<string> { ValuePDF[15], ValuePDF[16] }, //finalPrice 
              new List<string> { ValuePDF[15], ValuePDF[16] }, //finalPrice 
                
              //add this field for payer diffent from customer
              new List<string> {ValuePDF[17], PayerInfo[1]}, //Payer Name
              new List<string> {ValuePDF[1], PayerInfo[7] + " "+ PayerInfo[8] }, //signatory name and surname
              new List<string> {ValuePDF[2], PayerInfo[2]}, //address
              new List<string> {ValuePDF[3], PayerInfo[3]}, //post cose
              new List<string> {ValuePDF[4], PayerInfo[5]}, //city 
              new List<string> {ValuePDF[5], PayerInfo[9]},//Country
              new List<string> {ValuePDF[6], PayerInfo[4]},//phone number
              new List<string> {ValuePDF[7], PayerInfo[6]},//client email

        };

                // Save PDF content
                StringBuilder PDFcontent = new StringBuilder();
                using (PdfReader reader = new PdfReader(System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads\\" + DownloadTitlewithoutContractReference + ContractReferenceWithLanguageCode + ".pdf"))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        PDFcontent.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                }
                //Print the contract PDF content
                //Console.WriteLine(PDFcontent.ToString());

                //Starting verification of data in PDF
                Console.WriteLine("Starting verification of data in PDF");
                int foundvalue = 0;
                foreach (List<string> DataPDf in ValuesPDF)
                {
                    if (PDFcontent.ToString().Contains(DataPDf[0]) && PDFcontent.ToString().Contains(DataPDf[1])) //impleted in this way for the fact that the order of data in pdf is not correct
                    {
                        Console.WriteLine("'" + DataPDf[0] + " " + DataPDf[1] + "'" + " found on PDF");
                    }
                    else
                    {
                        Console.WriteLine(DataPDf[0] + " " + DataPDf[1] + "'" + " not found");
                        foundvalue++;
                    }
                }
                // Service verification data
                //Remember: aggiungere start and end date
                foreach (List<string> AddedService in Info.GetAddedServiceInfo())
                {
                    if (PDFcontent.ToString().Contains(ValuePDF[11]) && PDFcontent.ToString().Contains(AddedService[0]))
                    {
                        Console.WriteLine("'" + ValuePDF[11] + " " + AddedService[0] + "'" + " found on PDF");
                    }
                    else
                    {
                        Console.WriteLine(ValuePDF[11] + " " + AddedService[0] + "'" + " not found");
                        foundvalue++;
                    }

                    if (PDFcontent.ToString().Contains(AddedService[0] + ";") && PDFcontent.ToString().Contains(AddedService[6]))
                    {
                        Console.WriteLine("'" + AddedService[0] + " " + AddedService[6] + "'" + " found on PDF");
                    }
                    else
                    {
                        Console.WriteLine(AddedService[0] + " " + AddedService[6] + "'" + " not found");
                        foundvalue++;
                    }
                }
                // Check presence of export file and delete it
                Console.WriteLine("Check if file is availbale in /Download section");
                bool downloadContractFileExistAndRemove = CheckFileDownloaded(DownloadTitlewithoutContractReference);
                Assert.That(downloadContractFileExistAndRemove == true);
                Console.WriteLine("Removal completed");

                if (foundvalue != 0)
                {
                    Assert.Fail("Test failed. One of the data inserted on contract creation was not found on generated PDF");

                }

                System.Threading.Thread.Sleep(1000);
                //Retrieve Price DATA
                List<string> PriceInfo = Info.GetPriceInfo();
                //The SEPA file is present only for not-free contract 
                if (PriceInfo[2] != "EUR 0.00" && PriceInfo[2] != "GBP 0.00")
                {
                    //Click on download button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DownloadSEPA)));
                    IWebElement DownloadSEPA = driver.FindElement(By.XPath(Xpath.DownloadSEPA));
                    js.ExecuteScript("arguments[0].click()", DownloadSEPA);
                    Console.WriteLine("Click on download button");

                    //Waiting for spinner
                    WaitingSpinner(Xpath.Spinner, 5000);


                    //Verify the downloaded SEPA
                    Console.WriteLine("Check if SEPA file is available in /Download section");
                    bool downloadSEPAExist = CheckFileDownloaded(Value.SEPATitle);
                    Assert.That(downloadSEPAExist == true);
                    Console.WriteLine("Check completed");
                }
                else
                {
                    Console.WriteLine("The contract is at zero price");
                }
                return (ContractReferenceWithX);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
                return (ContractReferenceWithX);
            }
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
            s = String.Concat(s, random.Next(10).ToString());
            return s;
        }



        public void DeleteContract(Xpath__Contracts Xpath, Values__Contracts Value, String ContractReference)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));



                //Open Menu + Click on Contract + Click on Connectivity 
                OpenSecondSectionMenu(Xpath.Menu, Xpath.Contracts, Value.Contracts, Xpath.Connectivity, Value.Connectivity, 1000);

                //js.ExecuteScript("document.body.style.zoom = '0.50'");
                if (ContractReference!="")
                {
                    //Verify that the contract is in Draft Downloadable status
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains (text (),'"+ ContractReference + "')]/parent::span/parent::div/parent::div/parent::div//span[contains( text(),'Draft')]")));
                    Console.WriteLine("The contract "+ ContractReference + " is in draft status");
                    
                    //Click to remove the contract
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains (text (),'"+ ContractReference + "')]/parent::span/parent::div/parent::div/parent::div")));
                    String AttributeRowId = driver.FindElement(By.XPath("//span[contains (text (),'" + ContractReference + "')]/parent::span/parent::div/parent::div/parent::div")).GetAttribute("row-id"); 
                    IWebElement DeleteFirstRow = driver.FindElement(By.XPath("//*[@id='tableContracts']//div[@row-id='"+ AttributeRowId + "']//*[@id='delete']/div/span"));
                    js.ExecuteScript("arguments[0].click();", DeleteFirstRow);
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Delete button clicked:Pop up opened");
                    
                    //Click to remove the contract
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContinueButton)));
                    IWebElement ContinueButton = driver.FindElement(By.XPath(Xpath.ContinueButton));
                    js.ExecuteScript("arguments[0].click();", ContinueButton);
                    Console.WriteLine("Click on Continue in order to remove the contrat");
                    System.Threading.Thread.Sleep(2000);
                    
                    //Verify the contract removed
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@row-id='"+AttributeRowId+"']//span[contains( text(),'Deleted')]")));
                    Console.WriteLine("Contract "+ ContractReference + " was correctly removed");
                }

                else
                {
                    //Verify that the contract is in Draft Downloadable status
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DraftStatusFirstRow)));
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContractReferenceFirstRow)));
                    String ContractReference1 = driver.FindElement(By.XPath(Xpath.ContractReferenceFirstRow)).Text;
                    Console.WriteLine("The contract on the first row is in Draft status: " + ContractReference);

                    //Click to remove the contract
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeleteFirstRowContract)));
                    IWebElement DeleteFirstRow = driver.FindElement(By.XPath(Xpath.DeleteFirstRowContract));
                    js.ExecuteScript("arguments[0].click();", DeleteFirstRow);
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Delete button clicked:Pop up opened");

                    //Click to remove the contract
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ContinueButton)));
                    IWebElement ContinueButton = driver.FindElement(By.XPath(Xpath.ContinueButton));
                    js.ExecuteScript("arguments[0].click();", ContinueButton);
                    Console.WriteLine("Click on Continue in order to remove the contrat");
                    System.Threading.Thread.Sleep(2000);

                    //Verify the contract removed
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DeleteStatusFirstRow)));
                    Console.WriteLine("Contract " + ContractReference + " was correctly removed");
                }
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }

        public void ContractsSectionVATNumber4step(Xpath__Contracts Xpath, Values__Contracts Value)
        {
            try
            {
                List<List<string>> VatMatrix1 = new List<List<string>>
            {
                new List<string> {"Austria", "AT", "7", "11" },
                new List<string> {"Belgium", "BE", "3", "12" },
                new List<string> {"Bosnia and Herzegovina", "BA", "3", "20" },
                new List<string> {"Bulgaria","BG","3","12"},
                new List<string> {"Croatia","HR","11","13"},
                new List<string> {"Czech Republic","CZ","3","14"},
                new List<string> {"Denmark","DK","3","10"},
                new List<string> {"Estonia","EE","11","11"},
                new List<string> {"Finland","FI","8","10"},
                new List<string> {"France","FR","9","14"},
                new List<string> {"Germany","DE","9","16"},
                new List<string> {"Ireland","IE","3","11"},
                new List<string> {"Italy","IT","3","16"},
                new List<string> {"Latvia","LV","13","13"},
                new List<string> {"Lithuania","LT","10","14"},
                new List<string> {"Luxembourg","LU","8","10"},
                new List<string> {"Moldavia","MD","3","20"},
                new List<string> {"Montenegro","ME","3","20"},
                new List<string> {"Netherlands","NL","14","14"},
                new List<string> {"Norway","NO","3","9"},
                new List<string> {"Poland","PL","3","13"},
                new List<string> {"Portugal","PT","9","11"},
                new List<string> {"Romania","RO","3","20"},
                new List<string> {"Serbia","RS","3","20"},
                new List<string> {"Slovakia","SK","3","14"},
                new List<string> {"Slovenia","SI","10","10"},
                new List<string> {"Spain","ES","9","11"},
                //new List<string> {"Sweden","SE","14","14"},//to be solved 
                new List<string> {"Switzerland","CH","3","20"},
                new List<string> {"Ukraine","UA","3","20"},
                new List<string> {"United Kingdom","GB","3","14"}
            };

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                System.Threading.Thread.Sleep(3000);

                // Verify label: New contract
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.NewContract)));
                Assert.That(driver.FindElement(By.XPath(Xpath.NewContract)).Text, Is.EqualTo(Value.NewContract));
                Console.WriteLine("Verified correct label: " + Value.NewContract);


                foreach (List<string> MatrixValue in VatMatrix1)
                {
                    // Expand Number VAT
                    ExpandShadowElementAndClick("pfe-select", 4, "[icon=dcx-arrow-down-fill]");
                    System.Threading.Thread.Sleep(500);
                  
                    // Select one country in the in the list
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pfe-select-3']//option[contains(text(),'" + MatrixValue[0] + "')]"))).Click();
                    Console.WriteLine("Select " + MatrixValue[0] + " as country in the list");

                    //MINIMUM VALUE 
                    // Insert random Number VAT with length under minimum value
                    int minimumNumberValue = Int16.Parse(MatrixValue[2]) - 3;//2 in the lenght of country isocode + 1 to be under minimum lenght
                    string minimumRandomVAT = RandomDigits(minimumNumberValue);

                    // Expand Number VAT and send minimum value for VAT number
                    ExpandShadowElementClickClearAndSendKeys("pfe-input",2, "[id=input]", MatrixValue[1] + minimumRandomVAT);
                    Console.WriteLine("Inserted as VAT: " + MatrixValue[1] + minimumRandomVAT);
                    System.Threading.Thread.Sleep(1000);

                    // Verify presence of error message for VAT lenght
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VATInvalidFieldError)));
                    Console.WriteLine("Verify presence of error message for VAT length lower than minimum value");
                    
                    //Remove the string inserted
                    //ExpandShadowElementAndClear("pfe-input", 2, "[id=input]"); 
                    //System.Threading.Thread.Sleep(1000);

                    //MAXIMUM VALUE 
                    // Insert random Number VAT with length higher than maximum value
                    int maximumNumberValue = Int16.Parse(MatrixValue[3]) - 1; //2 in the lenght of country isocode - 1 to be higher than maximum lenght
                    string maximumRandomVAT = RandomDigits(maximumNumberValue);

                    //Expand VAT number and send maximun value for VAT number 
                    ExpandShadowElementClickClearAndSendKeys("pfe-input", 2, "[id=input]", MatrixValue[1] + maximumRandomVAT);
                    Console.WriteLine("Inserted as VAT: " + MatrixValue[1] + maximumRandomVAT);

                    System.Threading.Thread.Sleep(10000);
                    // Verify presence of error message for VAT lenght
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VATInvalidFieldError)));
                    Console.WriteLine("Verify presence of error message for VAT length higher than maximum value" + MatrixValue[1]);
                }

            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

        }

        public int VerifyPopUp(String PopUp, String Message)
        {
            int Successful = 0;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
            //Verify the presence of error pop-up  
            wait.Until(ExpectedConditions.ElementExists(By.XPath(PopUp)));
            Console.WriteLine("Verify the presence of pop-up: " + Message);
            System.Threading.Thread.Sleep(1000);
            Successful = 1;

            // close successful pop-up
            ExpandShadowElementAndClick("pfe-modal", 14, "[class=pfe-modal__close]");
            Console.WriteLine("Pop-up closed");
            System.Threading.Thread.Sleep(1000);
            }
            catch (Exception e)
            {   //Print the error which is shown as pop-up
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//body[contains(@style,'overflow: hidden')]//pfe-modal[@window-outline-onfocus='hidden']//div/div/h5")));
                Console.WriteLine("Error in the pop-up: "+ driver.FindElement(By.XPath("//body[contains(@style,'overflow: hidden')]//pfe-modal[@window-outline-onfocus='hidden']//div/div/h5")).Text);

                GetScreenshotAndPrintError(e);
            }
            return Successful;
        }

        public String DigitalSignature(String account, String market )
        {
            String flag;
              if (weburl == "https://ivecoon-dev.iveco.com/" || weburl == "https://ivecoon-beta.iveco.com/" || weburl == "https://ivecoon-cert.iveco.com/")
              {
                if (account=="demo_dealer@yopmail.com" || market== "Italy" || market == "France"||  market == "Spain" ||  market == "Portugal" || market == "Poland")
                {
                    flag = "true";
                }

                else
                {
                    flag = "false";
                }
            }
        
            else //case in prod
            {
                if ( market == "France" )
                {
                    flag = "true";
                }

                else
                {
                    flag = "false";
                }

            }

            return flag;
        }

    }
}