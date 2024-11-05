using Microsoft.VisualStudio.TestTools.UnitTesting;
using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace myiveco_selenium
{

    [SetUpFixture]
    [Parallelizable]
    public class TestSuite_ContractsNoRegressionTest
    {
        public NUnit.Framework.TestContext TestContext { get; set; }
        static string tco_account_runsettings = NUnit.Framework.TestContext.Parameters["tco_account"].ToString();
        static string tco_pwd_runsettings = NUnit.Framework.TestContext.Parameters["tco_pwd"].ToString();
        static string dealer_account_runsettings = NUnit.Framework.TestContext.Parameters["dealer_account"].ToString();
        static string dealer_pwd_runsettings = NUnit.Framework.TestContext.Parameters["dealer_pwd"].ToString();
     
        static List<string> VinHeavy1 { get; set; } = new List<string> { 
                //VinID, ,Range number,Range String, Commercial Code Plate ,Warranty start date
                "WJMM62AWZ0C423994" , "commons.range.heavy","Trucks","Diesel","AS440S57T/FP" ,"GA782CL", "27/05/2020","WAY RANGE"};
        static List<string> VinHeavy2 { get; set; } = new List<string> { 
                //VinID, Range number,Range String, Commercial Code, Plate ,Warranty start date,"Range"
                "WJMJ63JU20C421199" , "commons.range.heavy","Trucks","Gas","AD340X48Z ON" ,"FM809SZ", "06/01/2020","WAY RANGE"};
        static List<string> VinLight1 { get; set; } = new List<string> { 
                //VinID, ,Range number,Range String, Commercial Code Plate ,Warranty start date
                "WJMM62AWZ0C425402" , "commons.range.light","Daily","Diesel","AS440S57T/FP" ,"NR-A 572", "29/01/2020","DAILY"};

        static List<string> VinHeavyWithoutWarranty { get; set; } = new List<string> { 
                //VinID, ,Range number,Range String, Commercial Code Plate ,Warranty start date
                "WJMM62AU40C400958" , "commons.range.heavy","Trucks","Diesel","AT440X48T/P ON" ,"-", "-","WAY RANGE"}; //vin without warranty

        static List<string> VinHeavyWithoutWarranty2 { get; set; } = new List<string> { 
                //VinID, Range number,Range String, Commercial Code Plate ,Warranty start date
                "WJMM62AU60C367347" , "commons.range.heavy","Trucks","Diesel","AT440X48T/P ON" ,"-", "-","WAY RANGE"}; //vin without warranty


        public class ContractCreationCheckDownloadedcontract : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractCreationCheckDownloadedcontract() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market, account,  language isocode, Country isocode
                "104" , "Italy","TCO","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;


            static List<string> ProfessionalFuelAdvisingInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number , duration in months and prince
                "Professional Fuel Advising","3", "EUR 300.00","1","Year","8","12 €300.00"};


            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number , duration in months and prince
                "Verizon Free Trial","5","EUR 0.00","6","Months","20","6 €0.00"};
            */

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 300.00","EUR 0.00" , "EUR 300.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> { 
                
                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
               ProfessionalFuelAdvisingInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo,AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsCreationCheckDownloadedContractTest()
            {
                String ContractReference="";
                int successful;
               
                string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                //Create the first contract
                ContractsSectionContractCreation1step(Xpath, Value, Info);
                ContractsSectionContractCreation2step(Xpath, Value, Info);
                ContractsSectionContractCreation3step(Xpath, Value, Info);
                ContractsSectionContractCreation4step(Xpath, Value, Info,FlagDigitalSignature);
                successful=VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                ContractsSectionContractCreation5step(Xpath, Value, Info);
                ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                //Delete the contract just in case it is created 
                if (successful == 1)
                {
                            DeleteContract(Xpath,Value, ContractReference);
         
                }
            }
        }
        
        public class ContractCreationLightVIN : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractCreationLightVIN() : base(Account) { }
            static List<string> VinInfo { get; set; } = VinLight1;
            static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market, account,  language isocode, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€0.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo );

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsCreationVinLightTest()
            {
                string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                
                String ContractReference = "";
                int successful;
                
                //Create the first contract
                ContractsSectionContractCreation1step(Xpath, Value, Info);
                ContractsSectionContractCreation2step(Xpath, Value, Info);
                ContractsSectionContractCreation3step(Xpath, Value, Info);
                ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                ContractsSectionContractCreation5step(Xpath, Value, Info);
                ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                //Delete the contract just in case it is created 
                if (successful == 1)
                {
                            DeleteContract(Xpath,Value, ContractReference);
                }

            }
        }

        public class ContractCreationTCOITalyLight : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
           
            public ContractCreationTCOITalyLight() : base(Account) { }
            static List<string> VinInfo { get; set; } = VinLight1;
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode, Country isocode
                "104" , "Italy","TCO","it","it"};
            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€0.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsCreationTCOVinLightTest()
            {
             
                    string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                    String ContractReference = "";
                    int successful;

                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                    //Delete the contract just in case it is created 
                    if (successful == 1)
                    {
                                DeleteContract(Xpath,Value, ContractReference);
                    }

                }
        }
        
        public class ContractCreationTCOAustria : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);

            public ContractCreationTCOAustria() : base(Account) { }
            static List<string> VinInfo { get; set; } = VinHeavy1;

            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode, Country isocode
                "14" , "Austria","TCO","de","at"};
            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC12345","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Austria","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activationaustria@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Kundenname","Zu Händen" ,"Rechnungsanschrift","PLZ","Ort","Land","Telefon", "E-Mail Adresse", "IBAN","BIC","Vertrags-Nummer", "Service Name/s","Kennzeichen","Modell","Fahrgestellnummer","Preis", "€0.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsCreationTCOAustriaTest()
            {
              
                string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                String ContractReference = "";
                int successful;

                //Create the first contract
                ContractsSectionContractCreation1step(Xpath, Value, Info);
                ContractsSectionContractCreation2step(Xpath, Value, Info);
                ContractsSectionContractCreation3step(Xpath, Value, Info);
                ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                ContractsSectionContractCreation5step(Xpath, Value, Info);
                ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                //Delete the contract just in case it is created 
                if (successful == 1)
                {
                            DeleteContract(Xpath,Value, ContractReference);
                }

            }
        }

        public class ContractCreationTCOPoland : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);

            public ContractCreationTCOPoland() : base(Account) { }
            static List<string> VinInfo { get; set; } = VinHeavy1;
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode, Country isocode
                "169" , "Poland","TCO","pl","pl"};
            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "PLN 0.00","5","Years","0","60 PLN0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "PLN 0.00","PLN 0.00" , "PLN 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC12346","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Poland","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activationpoland@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nazwa klienta","Do rąk" ,"Adres","Kod pocztowy","Miasto","Kraj","Telefon", "Telefon", "IBAN","BIC","Nr kontraktu", "Lista usług","Nr rejestracyjny","Model","Nr nadwozia","Total", "PLN0.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationTCOPolandTest()
            {
               
                    string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                    String ContractReference = "";
                    int successful;

                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                    //Delete the contract just in case it is created 
                    if (successful == 1)
                    {
                                DeleteContract(Xpath,Value, ContractReference);
                    }

            }
        }

        public class ContractCreationTCOBelgioFr : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);

            public ContractCreationTCOBelgioFr() : base(Account) { }
            static List<string> VinInfo { get; set; } = VinHeavy1;
            static List<string> MarketInfo { get; set; } = new List<string> {
                 //CountryID, Market, account,  language isocode, Country isocode
                "21" , "Belgium","TCO","fr","be"};
            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "AB123458","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Belgium","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activationbelgio@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nom du client","Destinataire" ,"Adresse","Code Postal","Ville","Pays","Téléphone", "Adresse électronique", "IBAN","BIC","Nº du contrat", "Service Name/s","Immatriculation","Modèle","Vehicules","Total", "€0.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsCreationTCOBelgioFrTest()
            {
                    string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                    String ContractReference = "";
                    int successful;

                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                    //Delete the contract just in case it is created 
                    if (successful == 1)
                    {
                                DeleteContract(Xpath,Value, ContractReference);
                    }

            }
        }

        public class ContractCreationCustomerDifferentFromPayerTCOItalyLight : Contracts_Section_Creation
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractCreationCustomerDifferentFromPayerTCOItalyLight() : base(Account) { }

            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode, Country isocode
                "104" , "Italy","TCO","it","it"};
            static List<string> VinInfo { get; set; } = VinLight1;

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> PayerInfo { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482875","Test Payer S.P.A.","Via del Test 190/B" , "10100","+3917823456789","Payer City", "payeremail@test.com","Payername","Payersurname","Italia","payersigner@yopmail.com"};
            static List<string> FinancialInfo { get; set; } = new List<string> { 
                 //Email,phone, name, Surname
                 "test_financial@yopmail.com","987654321" , "FinancialName","FinancialSurname"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€0.00","Nome"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

        

      
            Values__ContractNotRegressionPayerData InfoPayer = new Values__ContractNotRegressionPayerData(PayerInfo,FinancialInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationCustomerDifferentFromPayerTCOItalylightTest()
            {
                   string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);

                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4stepWithpayerDifferentFromCustomer(Xpath, Value, Info , InfoPayer, FlagDigitalSignature);
                    int successful=VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractsSectionCheckDownloadedPDFCustomerDifferentFromPayer(Xpath, Value, Info, InfoPayer);
               
                    if (successful==1)
                {
                    DeleteContract(Xpath ,Value, "");
                }
            }
        }

        public class ContractCreationCustomerDifferentFromPayerTCOItalyHeavy : Contracts_Section_Creation
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractCreationCustomerDifferentFromPayerTCOItalyHeavy() : base(Account) { }

            static List<string> MarketInfo { get; set; } = new List<string> { 
             //CountryID, Market, account,  language isocode, Country isocode
                "104" , "Italy","TCO","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> PayerInfo { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482875","Test Payer S.P.A.","Via del Test 190/B" , "10100","+3917823456789","Payer City", "payeremail@test.com","Payername","Payersurname","Italia","payersigner@yopmail.com"};
            static List<string> FinancialInfo { get; set; } = new List<string> { 
                 //Email,phone, name, Surname
                 "test_financial@yopmail.com","987654321" , "FinancialName","FinancialSurname"};
            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€0.00","Nome"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            Values__ContractNotRegressionPayerData InfoPayer = new Values__ContractNotRegressionPayerData(PayerInfo, FinancialInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationCustomerDifferentFromPayerTCOItalyHeavyTest()
            {
                
                    string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4stepWithpayerDifferentFromCustomer(Xpath, Value, Info, InfoPayer, FlagDigitalSignature);
                    int successful= VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractsSectionCheckDownloadedPDFCustomerDifferentFromPayer(Xpath, Value, Info, InfoPayer);
                    if (successful == 1)
                    {
                        //Delete the first contract created in each case 
                        DeleteContract(Xpath,Value,"");
                    }

            }
        }

        public class ContractCreationCustomerDifferentFromPayerDealerItalyHeavy : Contracts_Section_Creation
        {
            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractCreationCustomerDifferentFromPayerDealerItalyHeavy() : base(Account) { }

            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;
            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> PayerInfo { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482875","Test Payer S.P.A.","Via del Test 190/B" , "10100","+3917823456789","Payer City", "payeremail@test.com","Payername","Payersurname","Italia","payersigner@yopmail.com"};
            static List<string> FinancialInfo { get; set; } = new List<string> { 
                 //Email,phone, name, Surname
                 "test_financial@yopmail.com","987654321" , "FinancialName","FinancialSurname"};
            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€0.00","Nome"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            Values__ContractNotRegressionPayerData InfoPayer = new Values__ContractNotRegressionPayerData(PayerInfo, FinancialInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationCustomerDifferentFromPayerDealerItalyHeavyTest()
            {
                
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4stepWithpayerDifferentFromCustomer(Xpath, Value, Info, InfoPayer, FlagDigitalSignature);
                    int successful=VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    String ContractReference=ContractsSectionCheckDownloadedPDFCustomerDifferentFromPayer(Xpath, Value, Info, InfoPayer);
                if (successful==1)
                {
                    //Delete the first contract created in each case 
                            DeleteContract(Xpath,Value, ContractReference);
                }

            }
        }

        public class ContractCreationCustomerDifferentFromPayerDealerItalyLight : Contracts_Section_Creation
        {
            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractCreationCustomerDifferentFromPayerDealerItalyLight() : base(Account) { }

            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinLight1;

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> PayerInfo { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482875","Test Payer S.P.A.","Via del Test 190/B" , "10100","+3917823456789","Payer City", "payeremail@test.com","Payername","Payersurname","Italia","payersigner@yopmail.com"};
            static List<string> FinancialInfo { get; set; } = new List<string> { 
                 //Email,phone, name, Surname
                 "test_financial@yopmail.com","987654321" , "FinancialName","FinancialSurname"};
            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","87654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€0.00","Nome"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            Values__ContractNotRegressionPayerData InfoPayer = new Values__ContractNotRegressionPayerData(PayerInfo, FinancialInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationCustomerDifferentFromPayerDealerItalyLighTest()
            {
               
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4stepWithpayerDifferentFromCustomer(Xpath, Value, Info, InfoPayer, FlagDigitalSignature);
                    int successful=VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractsSectionCheckDownloadedPDFCustomerDifferentFromPayer(Xpath, Value, Info, InfoPayer);
               if (successful==1)
               {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");


               }
            }
        }

        public class ContractCreationTCOGermany : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);

            public ContractCreationTCOGermany() : base(Account) { }
            static List<string> VinInfo { get; set; } = VinHeavy1;
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode, Country isocode
                "78" , "Germany","TCO","de","de"};
            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC123459","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Germany","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activationhermany@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Kundenname","Zu Händen" ,"Rechnungsanschrift","PLZ","Ort","Land","Telefon", "E-Mail Adresse", "IBAN","BIC","Vertrags-Nummer", "Service Name/s","Kennzeichen","Modell","Fahrgestellnummer","Preis", "€0.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationTCOGermanyTest()
            {
                    string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                    String ContractReference = "";
                    int successful;

                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                    //Delete the contract just in case it is created 
                    if (successful == 1)
                    {
                                DeleteContract(Xpath,Value, ContractReference);
                    }

                }
        }

        public class ContractCreationTCOITaly : Contracts_Section_Creation
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractCreationTCOITaly() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market
                "104" , "Italy","TCO","it","it"};
            static List<string> VinInfo { get; set; } = VinLight1;

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€0.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationTCOITalyMarketTest()
            {
               
                    string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                    String ContractReference = "";
                    int successful;

                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                    //Delete the contract just in case it is created 
                    if (successful == 1)
                    {
                                DeleteContract(Xpath,Value, ContractReference);
                    }

            }
        }
        public class ContractCreationTCOUK : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractCreationTCOUK() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode for pdf genarated, Country isocode
                "225" , "United Kingdom","TCO","en","gb"};
            static List<string> VinInfo { get; set; } = VinLight1;

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "GBP 0.00","5","Years","0","60 £0.00"};

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "GBP 0.00","GBP 0.00" , "GBP 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482879","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","UK","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activationuk@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Customer Name","Attention" ,"Address","Zip","City","Country","Phone", "Email", "IBAN","BIC","N° of contract", "Service Name/s","Plate","Model"," Vehicles","Total", "£0.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationTCOUKMarketTest()
            {
                    string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                    String ContractReference = "";
                    int successful;

                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                    //Delete the contract just in case it is created 
                    if (successful == 1)
                    {
                                DeleteContract(Xpath,Value, ContractReference);
                    }

            }
        }

        public class ContractCreationTCOFrance : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractCreationTCOFrance() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode, Country isocode
                "72" , "France","TCO","fr","fr"};
            static List<string> VinInfo { get; set; } = VinHeavy1;

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","6" , "EUR 0.00","6","Months","21","6 €0.00"};*/

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482870","Test Entreprise S.P.A.","Rue Test 190/B" , "10100","+39123456789","Test Ville", "clientemail@test.com","Test Prénom","Test Nom","FR","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activationfrance@email.com","987654321" , "FM Prénom","FMN Nom"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nom du client","Destinataire" ,"Ville","Code Postal","Ville","Pays","Téléphone", "Adresse électronique", "IBAN","BIC","Nº du contrat", "Service Name/s","Immatriculation","Modèle","Vehicules","Prix", "€0.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationTCOFRMarketTest()
            {
                    string FlagDigitalSignature = DigitalSignature(tco_account_runsettings, MarketInfo[1]);
                    String ContractReference = "";
                    int successful;

                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
                    ContractReference = ContractsSectionCheckDownloadedPDF(Xpath, Value, Info);

                    //Delete the contract just in case it is created 
                    if (successful == 1)
                    {
                                DeleteContract(Xpath,Value, ContractReference);
                    }

            }
        }
        public class ContractCreationStep1 : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractCreationStep1() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","TCO","it","it"};
           static List<string> VinInfo { get; set; } = VinHeavy1;

            static List<string> ProfessionalFuelAdvisingInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Professional Fuel Advising","3", "EUR 300.00","1","Year","8","12 €300.00"};


            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};*/

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 300.00","EUR 0.00" , "EUR 300.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
               ProfessionalFuelAdvisingInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo,AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationStep1Test()
            {
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
            }
        }
        
        public class ContractCreationStep2 : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractCreationStep2() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","TCO","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;

            static List<string> ProfessionalFuelAdvisingInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number , duration in months and prince
                "Professional Fuel Advising","3", "EUR 300.00","1","Year","8","12 €300.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration in years ,Checkbox Number, duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince, duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};*/

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 300.00","EUR 0.00" , "EUR 300.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
               ProfessionalFuelAdvisingInfo
            };


            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationStep2Test()
            {
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                
            }
        }
      
        public class ContractCreationStep3 : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractCreationStep3() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","TCO","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;


            static List<string> ProfessionalFuelAdvisingInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Professional Fuel Advising","3", "EUR 300.00","1","Year","8","12 €300.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};*/

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 300.00","EUR 0.00" , "EUR 300.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
               ProfessionalFuelAdvisingInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractCreationStep3Test()
            {
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
            }
        }
        
        public class ContractsSectionVATNumber4step : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractsSectionVATNumber4step() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","TCO","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;

            static List<string> ProfessionalFuelAdvisingInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Professional Fuel Advising","3", "EUR 300.00","1","Year","8","12 €300.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};*/

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 300.00","EUR 0.00" , "EUR 300.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
               ProfessionalFuelAdvisingInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService,RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsSectionVATNumber4stepTest()
            {
                ContractsSectionContractCreation1step(Xpath, Value, Info);
                ContractsSectionContractCreation2step(Xpath, Value, Info);
                ContractsSectionContractCreation3step(Xpath, Value, Info);
                ContractsSectionVATNumber4step(Xpath, Value);

            }
        }
        
        public class ContractCreation : Contracts_Section_Creation
        {
         
            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractCreation() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;


            static List<string> ProfessionalFuelAdvisingInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Professional Fuel Advising","3", "EUR 300.00","1","Year","8","12 €300.00"};


            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};
            
            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};
            */

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 300.00","EUR 0.00" , "EUR 300.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
               ProfessionalFuelAdvisingInfo
            };
            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService,RemovedService, Price, CompanySite, MFMInfo,ValuePDF,MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsCreationTest()
            {
                String ContractReference = "";
                int successful;
              
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    successful = VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    ContractsSectionContractCreation5step(Xpath, Value, Info);
               
                    if (successful==1)
                    {
                                DeleteContract(Xpath,Value, ContractReference);
                    }

            }
        }
        

        public class ContractsErr23 : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company, same period and same service of onther contract already existent
            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr23() : base(Account) {}
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;

            static List<string> ProfessionalFuelAdvisingInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Professional Fuel Advising","3", "EUR 300.00","1","Year","8","12 €300.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};*/

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 300.00","EUR 0.00" , "EUR 300.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
               ProfessionalFuelAdvisingInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo,AddedService, RemovedService, Price,CompanySite, MFMInfo,ValuePDF,MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr23Test()
            {
                try
                {
                string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                //Create the first contract
                ContractsSectionContractCreation1step(Xpath, Value, Info);
                ContractsSectionContractCreation2step(Xpath, Value, Info);
                ContractsSectionContractCreation3step(Xpath, Value, Info);
                ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                VerifyPopUp(Xpath.SuccessfulPopUp,Value.SuccessfulPopUp);

                //Try to create another contract with the same vin, same period, same services,same company
                ContractsSectionContractCreation1step(Xpath, Value, Info);
                ContractsSectionContractCreation2step(Xpath, Value, Info);
                ContractsSectionContractCreation3step(Xpath, Value, Info);
                ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                VerifyPopUp(Xpath.Err23PopUp,Value.Err23PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }

        public class ContractsErr33 : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company and same service of onther contract already existent
            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr33() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
               //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;

            static List<string> ProfessionalFuelAdvisingInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Professional Fuel Advising","3", "EUR 300.00","1","Year","8","12 €300.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};*/

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 300.00","EUR 0.00" , "EUR 300.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
               ProfessionalFuelAdvisingInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr33Test()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with the same vin, same period, same services,same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err33PopUp, Value.Err33PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }

        public class ContractsErr33WithoutWSD : Contracts_Section_Creation
        {
            //Try to create a contract with the same vin, same company and same service of onther contract already existent
            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr33WithoutWSD() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
               //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavyWithoutWarranty;

            static List<string> ProfessionalFuelAdvisingInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Professional Fuel Advising","3", "EUR 300.00","1","Year","8","12 €300.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};*/

            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 300.00","EUR 0.00" , "EUR 300.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00"};

            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
               ProfessionalFuelAdvisingInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr33WithoutWSDTest()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with the same vin, same period, same services,same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err33PopUp, Value.Err33PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }
        /*
        public class ContractsErr17 : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr17() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
              //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy1;


            static List<string> AstrataBronzeInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Bronze","10", "EUR 276.00","1","Year","41","12 €276.00"};

            static List<string> ASTRATARTDSInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA RTDS","13", "EUR 70.00","1","Year","56","12 €70.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};

            static List<string> VerizonFleetEssentialTachoInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Verizon Fleet Essential Tacho","6", "EUR 384.00","1","Year","21","12 €384.00"};


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 384.00","EUR 0.00" , "EUR 384.00"};
            static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 346.00","EUR 0.00" , "EUR 346.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00","12 €300.00","60 €0.00"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
               SmartPackInfo,
               VerizonFleetEssentialTachoInfo
            };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
               AstrataBronzeInfo,
               ASTRATARTDSInfo
            };


            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();             
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo,ValuePDF,MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo, AddedService2, RemovedService, Price2, CompanySite, MFMInfo,ValuePDF,MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr17Test()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, Verizon service and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);
                    
                    //Try to create another contract with the same vin, same period, Astrata services,same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err17PopUp, Value.Err17PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }
    */
        /*
        public class ContractsErr17WithoutWSD : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr17WithoutWSD() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
              //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavyWithoutWarranty;


            static List<string> AstrataBronzeInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Bronze","10", "EUR 276.00","1","Year","41","12 €276.00"};

            static List<string> ASTRATARTDSInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA RTDS","13", "EUR 70.00","1","Year","56","12 €70.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};

            static List<string> VerizonFleetEssentialTachoInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Verizon Fleet Essential Tacho","6", "EUR 384.00","1","Year","21","12 €384.00"};


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 384.00","EUR 0.00" , "EUR 384.00"};
            static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 346.00","EUR 0.00" , "EUR 346.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00","12 €300.00","60 €0.00"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
               SmartPackInfo,
               VerizonFleetEssentialTachoInfo
            };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
               AstrataBronzeInfo,
               ASTRATARTDSInfo
            };


            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo, AddedService2, RemovedService, Price2, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr17WithoutWSDTest()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, Verizon service and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with the same vin, same period, Astrata services,same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err17PopUp, Value.Err17PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }*/
        /*public class ContractsErr18Verizon : Contracts_Section_Creation
            {
                //Try to create the same contract with 

                static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
                public ContractsErr18Verizon() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy2;
            static List<string> VinInfo2 { get; set; } = VinHeavy1;

            static List<string> VerizonFleetEssentialTachoInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Verizon Fleet Essential Tacho","6", "EUR 384.00","1","Year","21","12 €384.00"};

                static List<string> VerizonWorkForceInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "VERIZON Workforce","9", "EUR 120.00","1","Year","36","12 €120.00"};

                static List<string> VerizonFleetEnhancedInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Verizon Fleet Enhanced","7", "EUR 456.00","1","Year","26","12 €456.00"};


                static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","12 €384.00"};

                static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5","EUR 0.00","6","Months","20","12 €0.00"};


                static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 504.00","EUR 0.00" , "EUR 504.00"};

                 static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 576.00","EUR 0.00" , "EUR 576.00"};

                static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

                static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00","12 €300.00","60 €0.00"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                VerizonFleetEssentialTachoInfo,
               VerizonWorkForceInfo
            };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
                VerizonFleetEnhancedInfo,
               VerizonWorkForceInfo
            };

            Values__Contracts Value = new Values__Contracts();
                Xpath__Contracts Xpath = new Xpath__Contracts();
                Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo,ValuePDF,MarketInfo);
                Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo2, AddedService2, RemovedService, Price2, CompanySite, MFMInfo,ValuePDF,MarketInfo);
                [Test]
                [Category("Contracts_NRT")]
                public void ContractsErr18VerizonTest()
                {
                    try
                    {
                        string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                        //Create the first contract  with a vin, a period, Verizon Fleet Essential Tacho and a company 
                        ContractsSectionContractCreation1step(Xpath, Value, Info);
                        ContractsSectionContractCreation2step(Xpath, Value, Info);
                        ContractsSectionContractCreation3step(Xpath, Value, Info);
                        ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                        VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                        //Try to create another contract with different vin, same period, Verizon Fleet Enhanced,same company
                        ContractsSectionContractCreation1step(Xpath, Value, Info2);
                        ContractsSectionContractCreation2step(Xpath, Value, Info2);
                        ContractsSectionContractCreation3step(Xpath, Value, Info2);
                        ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                        VerifyPopUp(Xpath.Err18PopUp, Value.Err18PopUp);
                    }
                    finally
                    {
                        //Delete the first contract created in each case 
                        DeleteContract(Xpath,Value,"");
                    }

                }
        }
        */

        /*
        public class ContractsErr18VerizonWithoutWSD : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr18VerizonWithoutWSD() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
             //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavyWithoutWarranty;

            static List<string> VinInfo2 { get; set; } = VinHeavyWithoutWarranty2;

            static List<string> VerizonFleetEssentialTachoInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Verizon Fleet Essential Tacho","6", "EUR 384.00","1","Year","21","12 €384.00"};

            static List<string> VerizonWorkForceInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "VERIZON Workforce","9", "EUR 120.00","1","Year","36","12 €120.00"};

            static List<string> VerizonFleetEnhancedInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "Verizon Fleet Enhanced","7", "EUR 456.00","1","Year","26","12 €456.00"};


            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","12 €384.00"};

            static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5","EUR 0.00","6","Months","20","12 €0.00"};


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 504.00","EUR 0.00" , "EUR 504.00"};

            static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 576.00","EUR 0.00" , "EUR 576.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00","12 €300.00","60 €0.00"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                VerizonFleetEssentialTachoInfo,
               VerizonWorkForceInfo
            };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
                VerizonFleetEnhancedInfo,
               VerizonWorkForceInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo2, AddedService2, RemovedService, Price2, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr18VerizonWithoutWSDTest()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, Verizon Fleet Essential Tacho and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with different vin, same period, Verizon Fleet Enhanced,same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err18PopUp, Value.Err18PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }*/

        public class ContractsErr18Astrata : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr18Astrata() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
              //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy2;

            static List<string> VinInfo2 { get; set; } = VinHeavy1;


            static List<string> AstrataBronzeInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Bronze","10", "EUR 276.00","1","Year","41","12 €276.00"};

            static List<string> AstrataSilverInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Silver","11", "EUR 384.00","1","Year","46","12 €384.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","12 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};*/


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 276.00","EUR 0.00" , "EUR 276.00"};

            static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 384.00","EUR 0.00" , "EUR 384.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00",};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                  AstrataBronzeInfo
        };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
               AstrataSilverInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo2, AddedService2, RemovedService, Price2, CompanySite, MFMInfo, ValuePDF,MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr18AstrataTest()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, Astrata Silver Tacho and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with different vin, same period, Astrata Bronze, same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err18PopUp, Value.Err18PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }

        public class ContractsErr18AstrataWithoutWSD : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr18AstrataWithoutWSD() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                 //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavyWithoutWarranty;

            static List<string> VinInfo2 { get; set; } = VinHeavyWithoutWarranty2;


            static List<string> AstrataBronzeInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Bronze","10", "EUR 276.00","1","Year","41","12 €276.00"};

            static List<string> AstrataSilverInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Silver","11", "EUR 384.00","1","Year","46","12 €384.00"};

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","12 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name, Order on step 2,Price, Duration in years ,Checkbox Number , duration in months and prince
                "Verizon Free Trial","5" , "EUR 0.00","6","Months","20","6 €0.00"};*/


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 276.00","EUR 0.00" , "EUR 276.00"};

            static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 384.00","EUR 0.00" , "EUR 384.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total", "€300.00",};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                  AstrataBronzeInfo
        };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
               AstrataSilverInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo2, AddedService2, RemovedService, Price2, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr18AstrataWithoutWSDTest()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, Astrata Silver Tacho and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with different vin, same period, Astrata Bronze, same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err18PopUp, Value.Err18PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }

        /*public class ContractsErr19Verizon : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr19Verizon() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
              //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy2;

            static List<string> VinInfo2 { get; set; } = VinHeavy1;

            static List<string> VerizonFleetEssentialTachoInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration, Duration unit of measure , Checkbox Number 
                "Verizon Fleet Essential Tacho","6", "EUR 384.00","1", "Year","21","12 €384.00"};

          
            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration , Duration unit of measure ,Checkbox Number 
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","12 €0.00"};

            static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration, Duration unit of measure ,Checkbox Number 
                "Verizon Free Trial","5" , "EUR 0.00","6", "Months","20","6 €0.00"};


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 384.00","EUR 0.00" , "EUR 384.00"};

            static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                VerizonFleetEssentialTachoInfo,
            };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
               VerizonFreeTrialInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo2, AddedService2, RemovedService, Price2, CompanySite, MFMInfo, ValuePDF,MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr19VerizonTest()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, Verizon Fleet Essential Tacho and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with different vin, same period, Verizon Fleet Enhanced,same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err19PopUp, Value.Err19PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }*/

        /*public class ContractsErr19VerizonWithoutWSD : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr19VerizonWithoutWSD() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavyWithoutWarranty;

            static List<string> VinInfo2 { get; set; } = VinHeavyWithoutWarranty2;

            static List<string> VerizonFleetEssentialTachoInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration, Duration unit of measure , Checkbox Number 
                "Verizon Fleet Essential Tacho","6", "EUR 384.00","1", "Year","21","12 €384.00"};


            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration , Duration unit of measure ,Checkbox Number 
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","12 €0.00"};

            static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration, Duration unit of measure ,Checkbox Number 
                "Verizon Free Trial","5" , "EUR 0.00","6", "Months","20","6 €0.00"};


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 384.00","EUR 0.00" , "EUR 384.00"};

            static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                VerizonFleetEssentialTachoInfo,
            };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
               VerizonFreeTrialInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo2, AddedService2, RemovedService, Price2, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr19VerizonWithoutWSDTest()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, Verizon Fleet Essential Tacho and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with different vin, same period, Verizon Fleet Enhanced,same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err19PopUp, Value.Err19PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }
        */
        public class ContractsErr19Astrata : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr19Astrata() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy2;
            static List<string> VinInfo2 { get; set; } = VinHeavy1;

            static List<string> AstrataBronzeInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Bronze","10", "EUR 276.00","1","Year","41","12 €276.00"};

            static List<string> AstrataBronzeFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Bronze Free Trial","14", "EUR 0.00","3","Months","61","3 €0.00"};


            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration , Duration unit of measure ,Checkbox Number 
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration, Duration unit of measure ,Checkbox Number 
                "Verizon Free Trial","5" , "EUR 0.00","6", "Months","20","6 €0.00"};*/


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 276.00","EUR 0.00" , "EUR 276.00"};

            static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                AstrataBronzeInfo
            };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
               AstrataBronzeFreeTrialInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo2, AddedService2, RemovedService, Price2, CompanySite, MFMInfo, ValuePDF,MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr19AstrataTest()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, Astrata Bronze and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with different vin, same period, Astrata Bronze Free Trial,same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err19PopUp, Value.Err19PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }

        public class ContractsErr19AstrataWithoutWSD : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr19AstrataWithoutWSD() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
               //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavyWithoutWarranty;

            static List<string> VinInfo2 { get; set; } = VinHeavyWithoutWarranty2;

            static List<string> AstrataBronzeInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Bronze","10", "EUR 276.00","1","Year","41","12 €276.00"};

            static List<string> AstrataBronzeFreeTrialInfo { get; set; } = new List<string> { 
                 //Service name,Order on step 2, Price, Duration in years, Checkbox Number 
                "ASTRATA Bronze Free Trial","14", "EUR 0.00","3","Months","61","3 €0.00"};


            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration , Duration unit of measure ,Checkbox Number 
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","60 €0.00"};

           /* static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration, Duration unit of measure ,Checkbox Number 
                "Verizon Free Trial","5" , "EUR 0.00","6", "Months","20","6 €0.00"};*/


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 276.00","EUR 0.00" , "EUR 276.00"};

            static List<string> Price2 { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};
            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                AstrataBronzeInfo
            };
            static List<List<string>> AddedService2 { get; set; } = new List<List<string>>  {
               AstrataBronzeFreeTrialInfo
            };

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo2, AddedService2, RemovedService, Price2, CompanySite, MFMInfo, ValuePDF, MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr19AstrataWithoutWSDTest()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, Verizon Fleet Essential Tacho and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with different vin, same period, Verizon Fleet Enhanced,same company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err19PopUp, Value.Err19PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }

        public class ContractsErr31 : Contracts_Section_Creation
        {
            //Try to create the same contract with 

            static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
            public ContractsErr31() : base(Account) { }
            static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavy2;

            static List<string> SmartPackInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration , Duration unit of measure ,Checkbox Number 
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","12 €0.00"};

            /*static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration, Duration unit of measure ,Checkbox Number 
                "Verizon Free Trial","5" , "EUR 0.00","6", "Months","20","6 €0.00"};*/


            static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

            static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

            static List<string> CompanySite2 { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482877","Test Company2 S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City2", "clientemail2@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation2@yopmail.com"};

            static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

            static List<string> MFMInfo2 { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation2@email.com","987654321" , "FMname","FMsurname"};

            static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total"};
            static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
            };
            static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
            };
           

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();
            Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF,MarketInfo);
            Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite2, MFMInfo2, ValuePDF,MarketInfo);
            [Test]
            [Category("Contracts_NRT")]
            public void ContractsErr31Test()
            {
                try
                {
                    string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                    //Create the first contract  with a vin, a period, a service and a company 
                    ContractsSectionContractCreation1step(Xpath, Value, Info);
                    ContractsSectionContractCreation2step(Xpath, Value, Info);
                    ContractsSectionContractCreation3step(Xpath, Value, Info);
                    ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                    VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                    //Try to create another contract with the same vin, same period, same service and different company
                    ContractsSectionContractCreation1step(Xpath, Value, Info2);
                    ContractsSectionContractCreation2step(Xpath, Value, Info2);
                    ContractsSectionContractCreation3step(Xpath, Value, Info2);
                    ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                    VerifyPopUp(Xpath.Err31PopUp, Value.Err31PopUp);
                }
                finally
                {
                    //Delete the first contract created in each case 
                    DeleteContract(Xpath,Value,"");
                }

            }
        }

        public class ContractsErr14WithoutWSD : Contracts_Section_Creation
            {
                //Try to create the same contract with 

                static Account Account = new Account(dealer_account_runsettings, dealer_pwd_runsettings);
                public ContractsErr14WithoutWSD() : base(Account) { }
             static List<string> MarketInfo { get; set; } = new List<string> { 
                //CountryID, Market, account,  language isocode for pdf generated, Country isocode
                "104" , "Italy","Dealer","it","it"};
            static List<string> VinInfo { get; set; } = VinHeavyWithoutWarranty;

            /* static List<string> VerizonFreeTrialInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration, Duration unit of measure ,Checkbox Number 
                "Verizon Free Trial","5" , "EUR 0.00","6", "Months","20","6 €0.00"};*/

                static List<string> SmartPackInfo { get; set; } = new List<string> { 
                //Service name, Order on step 2,Price, Duration , Duration unit of measure ,Checkbox Number 
                "Smart Pack & Proactive service","1" , "EUR 0.00","5","Years","0","12 €0.00"};

                static List<string> Price { get; set; } = new List<string> { 
                //Total Price, Discount , Final price 
                "EUR 0.00","EUR 0.00" , "EUR 0.00"};

                static List<string> CompanySite { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482876","Test Company S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City", "clientemail@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation@yopmail.com"};

                static List<string> CompanySite2 { get; set; } = new List<string> { 
                // VAT Compamy name ,Address, CAP, Phone,City,email, name,surname, Place Of birth,IBAN, BIC
                "ABC66482877","Test Company2 S.P.A.","Via del Test 190/B" , "10100","+39123456789","Test City2", "clientemail2@test.com","Testname","Testsurname","Italia","ABC66482876","XYZ12645498","signerautomation2@yopmail.com"};

                static List<string> MFMInfo { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation@email.com","987654321" , "FMname","FMsurname"};

                static List<string> MFMInfo2 { get; set; } = new List<string> { 
                //Email,phone, name, Surname
                "activation2@email.com","987654321" , "FMname","FMsurname"};

                static List<string> ValuePDF { get; set; } = new List<string> {

                "Nome cliente","Nome del referente" ,"Indirizzo","CAP","Città","Paese","Telefono", "Indirizzo e-mail", "IBAN","BIC","N. di contratto:", "Nome Servizio:","targa","Modello","Veicoli","Total"};
                static List<List<string>> RemovedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                //VerizonFreeTrialInfo
                };
                static List<List<string>> AddedService { get; set; } = new List<List<string>>  {
                SmartPackInfo,
                };


                Values__Contracts Value = new Values__Contracts();
                Xpath__Contracts Xpath = new Xpath__Contracts();
                Values__ContractNotRegression Info = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite, MFMInfo, ValuePDF, MarketInfo);
                Values__ContractNotRegression Info2 = new Values__ContractNotRegression(VinInfo, AddedService, RemovedService, Price, CompanySite2, MFMInfo2, ValuePDF, MarketInfo);
                [Test]
                [Category("Contracts_NRT")]
                public void ContractsErr14WithoutWSDTest()
                {
                    try
                    {
                        string FlagDigitalSignature = DigitalSignature(dealer_account_runsettings, MarketInfo[1]);
                        //Create the first contract  with a vin, a period, a service and a company 
                        ContractsSectionContractCreation1step(Xpath, Value, Info);
                        ContractsSectionContractCreation2step(Xpath, Value, Info);
                        ContractsSectionContractCreation3step(Xpath, Value, Info);
                        ContractsSectionContractCreation4step(Xpath, Value, Info, FlagDigitalSignature);
                        VerifyPopUp(Xpath.SuccessfulPopUp, Value.SuccessfulPopUp);

                        //Try to create another contract with the same vin, same period, same service and different company
                        ContractsSectionContractCreation1step(Xpath, Value, Info2);
                        ContractsSectionContractCreation2step(Xpath, Value, Info2);
                        ContractsSectionContractCreation3step(Xpath, Value, Info2);
                        ContractsSectionContractCreation4step(Xpath, Value, Info2, FlagDigitalSignature);
                        VerifyPopUp(Xpath.Err14PopUp, Value.Err14PopUp);
                    }
                    finally
                    {
                        //Delete the first contract created in each case 
                        DeleteContract(Xpath,Value,"");
                    }

                
            }
        }
    }
}