using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Contracts
    {
        // Contract list section
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String Contracts = "//h5[contains(text(), 'Contracts')]";
        public String Connectivity = "//*[@id='pfe-link-connectivity']//*[contains(text(),' Connectivity ')]";
        public String ContractsManagement = "//div[@class='text-title padding margin color-title' and text() = 'Contracts management']";
        public String ApprovedContracts = "//p[contains(text(), 'Approved/Completed contracts')]";
        public String ContractsInProgress = "//p[contains(text(), 'Contracts in progress')]";
        //public String ErrorContracts = "//p[contains(text(), 'Error contracts')]";
        public String ContractsList = "//div[@class='text-title padding' and text() = ' Connectivity contracts list ']";
        public String ContractsId = "//div[@ref='eLabel']//span[contains(text(),'Id')]";
        public String ContractsContractNumber = "//div[@ref='eLabel']//span[contains(text(),'Contract number')]";
        public String ContractsDraftOfOrigin = "//div[@ref='eLabel']//span[contains(text(),'Draft of origin')]";
        public String ContractsRange = "//div[@ref='eLabel']//span[contains(text(),'Range')]";
        public String ContractsCompany = "//div[@ref='eLabel']//span[contains(text(),'Company')]";
        public String ContractsCountry = "//div[@ref='eLabel']//span[contains(text(),'Country')]";
        public String ContractsDealer = "//div[@ref='eLabel']//span[contains(text(),'Dealer')]";
        public String DealerCity = "//div[@ref='eLabel']//span[contains(text(),'City')]";
        public String DealerSapCode = "//div[@ref='eLabel']//span[contains(text(),'Dealer Sap Code')]";
        public String ContractsCreationDate = "//div[@ref='eLabel']//span[contains(text(),'Creation date')]";
        public String ContractsStartDate = "//div[@ref='eLabel']//span[contains(text(),'Start date of first service')]";
        public String ContractsStatus = "//*[@id='tableContracts']//div[@col-id='contract_status']//span[contains(text(),'Status')]";
        public String ContractsOnboard = "//*[@id='tableContracts']//div[@col-id='mfm_active']//span[contains(text(),'Onboard')]";
        public String ContractsAccountMFM = "//div[@ref='eLabel']//span[contains(text(),'Main account')]";
        public String ContractsOnboardingDate = "//div[@ref='eLabel']//span[contains(text(),'Onboarding date')]";
        public String ContractsError = "//div[@ref='eLabel']//span[contains(text(),'Error')]";
        public String ContractsServiceTerminationRequest = "//div[@ref='eLabel']//span[contains(text(),'Service termination request')]";
        public String ContractsActions = "//*[@id='tableContracts']//div[@col-id='action']//span[contains(text(),'Actions')]";
        public String DeleteFirstRowContract = "(//*[@id='delete'])[1]/div/span";//"(//*[@class='action__delete'])[1]";
        public String ContinueButton = "//pfe-modal[4]//pfe-cta[2]/a";
        public String DraftStatusFirstRow = "//div[@row-index='0']//span[contains( text(),'Draft')]";
        public String ContractReferenceFirstRow = "//div[@row-index='0']//div[@col-id='contract_number']";
        public String DeleteStatusFirstRow = "//div[@row-index='0']//span[contains( text(),'Deleted')]";

        public String DealerDataColumnOpen = "//*[@id='tableContracts']//div[@col-id='0_0']/div[@ref='agContainer']/span[@ref='agClosed']/span";
        public String OnBoardColumnOpen = "//*[@id='tableContracts']//div[@col-id='1_0']/div[@ref='agContainer']/span[@ref='agClosed']/span";

        // Contract creation section
        // 1 STEP
        public String ContractsCreateNewContract = "//a[contains(text(), 'CREATE NEW CONTRACT')]";
        public String ContractTypology = "//div[@class='row title-box-details border-title' and contains(text(), 'Contract typology')]";
        public String ContCreationSelectRange = "//label[contains(text(), 'Select range')]";
        public String ContCreationSearchVINCode = "//label[contains(text(), 'Search VIN code')]";
        public String ContCreationPlate = "//div[@ref='eLabel']//span[contains(text(), 'Plate')]";
        public String ContCreationCommercialModel = "//div[@ref='eLabel']//span[contains(text(), 'Commercial model')]";
        public String ContCreationFuel = "//div[@ref='eLabel']//span[contains(text(), 'Fuel')]";
        public String ContCreationWarrantyStartDate = "//div[@ref='eLabel']//span[contains(text(), 'Warranty start date')]";
        public String ContCreationVAN = "//div[@ref='eLabel']//span[contains(text(), 'VAN')]";
        public String SearchButtonLens = "//div[@class='col-md-1 col-sm-1 col-xs-1']//pfe-cta[@class='PFElement']//pfe-icon[@class='PFElement']";
        public String JustAddedVIN = "//label[@id='labelValue_vin-code_0']";
        public String LetsStartButton = "//a[contains(text(), 'S START')]";
        // 2 STEP
        public String OkNextButton = "//a[contains(text(), 'OK NEXT')]";

        // 3 STEP
        public String NewContract = "//div[@class='text-title padding' and contains(text(), 'New contract')]";
        public String Step3VINCodeLabel = "//div[@class='label' and contains(text(), 'VIN code')]";
        public String Step3CommercialModelLabel = "//div[@class='label' and contains(text(), 'Commercial model')]";
        public String Step3FuelLabel = "//div[@class='label' and contains(text(), 'Fuel')]";
        public String Step3WarrantyStartDateLabel = "//div[@class='label' and contains(text(), 'Warranty start date')]";
        public String Step3PlateLabel = "//div[@class='label' and contains(text(), 'Plate')]";
        public String Step3VINCodeValue = "//div[@class='contract-details-header padding']//div[@class='value blue bold']"; 
        public String Step3CommercialCodeValue = "//div[@class='contract-details-header padding']//div[@class='slot-3 padding-r']//div[@class='value']";
        public String Step3FuelValue = "//div[@class='contract-details-header padding']//div[@class='slot-4 padding-r']//div[@class='value']";
        public String Step3WarrantyStartDateValue = "//div[@class='contract-details-header padding']//div[@class='slot-5 padding-r']//div[@class='value']";
        public String Step3PlateValue = "//div[@class='contract-details-header padding']//div[@class='slot-6 padding-r']//div[@class='value']"; 
        public String Step3ServiceLabel = "//div[@class='slot-2 padding-b padding-r']";
        public String Step3DurationLabel = "//div[@class='slot-3 padding-b padding-r']";
        public String Step3ServiceStartDateLabel = "//div[@class='slot-4 padding-b padding-r']";
        public String Step3ServiceEndDateLabel = "//div[@class='slot-5 padding-b padding-r']";
        public String Step3DiscountLabel = "//div[@class='slot-6 padding-b padding-r']";
        public String Step3PriceLabel = "//div[@class='slot-8 padding-b right']";
        public String Step3AddDiscount = "//a[@class='action' and contains(text(), 'Add discount')]";
        public String Step3Total = "//div[@class='price-bar-slot'][1]/div[@class='value blue bold']";
        public String Step3TotalDiscounted = "//div[@class='price-bar-slot'][2]/div[@class='value blue bold']";
        public String Step3FinalPrice = "//div[@class='price-bar-slot'][3]/div[@class='value blue bold']";

        // STEP 4
        public String SearchButtonVATNumber = "//app-contract-customer-data//pfe-cta[@has-icon='alone']";
        public String SearchButtonVATNumberPayer = "//app-contract-payer-data//pfe-icon";
        public String InsertNewCustomer = "//app-contract-customer-data//pfe-radio[@class='mt-col PFElement']";
        public String InsertNewPayer = "//app-contract-payer-data//pfe-radio[@class='mt-col PFElement']";
        public String PopupContinueButton = "//app-contract-customer-data//pfe-cta[@class='PFElement'][2]";
        public String DateOfBirthSignatory = "//div[4]/app-contract-customer-data//div[@class='row mt-row'][4]//div[@class='time-filter']";
        public String VATInvalidFieldError = "//pfe-input[@pfe-status='error']";
        public String ContinueButtonPayer = "//app-contract-payer-data//a[contains (text (),'Continue')]";
        public String ContinueButtonCustomer =   "//app-contract-customer-data//a[contains (text (),'Continue')]";
        public String SuccessfulPopUp = "//body[contains(@style,'overflow: hidden')]//h5[contains(text(),'The contract has been successfully saved')]";
        public String Loader = "//pfe-modal//div[@id='sitesLoader']//app-loader//pfe-progress-indicator";
        public String Err23PopUp =      "//body[contains(@style,'overflow: hidden')]//h5[contains(text(),'On selected company and period, the service is already present on the same VIN')]";
        public String Err17PopUp =      "//body[contains(@style,'overflow: hidden')]//h5[contains(text(),'Company has already some active services that are not compatible with the ones selected')]";
        public String Err18PopUp =      "//body[contains(@style,'overflow: hidden')]//h5[contains(text(),'The Company has a different level of services already active')]";
        public String Err19PopUp =      "//body[contains(@style,'overflow: hidden')]//h5[contains(text(),'The Company has payment services already active in the same period')]";
        public String Err31PopUp =      "//body[contains(@style,'overflow: hidden')]//h5[contains(text(),'One of the selected services is already active on one of the chosen vehicles in the same period')]";
        public String Err14PopUp =      "//body[contains(@style,'overflow: hidden')]//h5[contains(text(),'Selected VIN has already an active service with another company in the selected period of time')]";
        public String Err33PopUp =      "//body[contains(@style,'overflow: hidden')]//h5[contains(text(),'Contract already exists for this vehicle and service')]";
        
        //Fields step 4 
        //customer
        public String VATNumberCustomer = "//app-contract-customer-data//pfe-input[@name='vatNumber']";
        public String CompanyCustomer = "//app-contract-customer-data//pfe-input[@name='companyName']"; 
        public String AddressCustomer = "//app-contract-customer-data//pfe-input[@name='companyAddress']";
        public String PostCodeCustomer = "//app-contract-customer-data//pfe-input[@name='companyPostCode']";
        public String CityCustomer = "//app-contract-customer-data//pfe-input[@name='companyCity']"; 
        public String PhoneNumberCustomer = "//app-contract-customer-data//pfe-input[@name='customerPhoneNumber']";
        public String EmailCustomer = "//app-contract-customer-data//pfe-input[@name='customerEmail']" ;
        public String SignatoryName = "//app-contract-customer-data//pfe-input[@name='signatoryName']";
        public String SignatorySurname = "//app-contract-customer-data//pfe-input[@name='signatorySurname']";
        public String SignatoryBirthPlace = "//app-contract-customer-data//pfe-input[@name='signatoryBirthPlace']";
        public String SignatoryEmail = "//app-contract-customer-data//pfe-input[@name='signatoryEmail']";
        //payer data 
        public String VATNumberPayer =   "//app-contract-payer-data//pfe-input[@name='vatNumber']";
        public String CompanyPayer = "//app-contract-payer-data//pfe-input[@name='companyName']";
        public String AddressPayer = "//app-contract-payer-data//pfe-input[@name='companyAddress']";
        public String PostCodePayer    = "//app-contract-payer-data//pfe-input[@name='companyPostCode']";
        public String CityPayer = "//app-contract-payer-data//pfe-input[@name='companyCity']";
        public String PhoneNumberPayer = "//app-contract-payer-data//pfe-input[@name='customerPhoneNumber']";
        public String EmailPayer = "//app-contract-payer-data//pfe-input[@name='customerEmail']";
        public String SignatoryNamePayer = "//app-contract-payer-data//pfe-input[@name='signatoryName']";
        public String SignatorySurnamePayer = "//app-contract-payer-data//pfe-input[@name='signatorySurname']";
        public String SignatoryBirthPlacePayer = "//app-contract-payer-data//pfe-input[@name='signatoryBirthPlace']";
        public String SignatoryEmailPayer = "//app-contract-payer-data//pfe-input[@name='signatoryEmail']";

        //payer 
        public String IBANPayer = "//app-contract-payer-data//pfe-input[@name='iban']";
        public String BICPayer = "//app-contract-payer-data//pfe-input[@name='bic']";
        public String BankPayerItalyGermany = "//app-contract-payer-data//pfe-input[@name='debtorBank']";
        public String FiscalCodePayer = "//app-contract-payer-data//pfe-input[@name='debtorFiscalCode']";
        public String SDIPayer = "//app-contract-payer-data//pfe-input[@name='debtorSdi']";

        public String BankPayer = "//app-contract-payer-data//pfe-input[@name='bankAccountNumber']";
        public String BankPayerUK = "//app-contract-dealer-data";
        public String BranchSortCode = "//app-contract-payer-data//pfe-input[@name='branchSortCode']";
      
       

        //MFM 
        public String EmailMFM = "//app-contract-fleet-manager//pfe-input[@name='emailAddress']";
        public String PhoneMFM = "//app-contract-fleet-manager//pfe-input[@name='phoneNumber']";
        public String NameMFM = "//app-contract-fleet-manager//pfe-input[@name='fmFirstname']";
        public String SurnameMFM = "//app-contract-fleet-manager//pfe-input[@name='fmLastname']";


        //Financial Info
        public String EmailFinancial = "//app-contract-financial-admin//pfe-input[@name='emailAddressFA']";
        public String PhoneFinancial = "//app-contract-financial-admin//pfe-input[@name='phoneNumberFA']";
        public String NameFinancial = "//app-contract-financial-admin//pfe-input[@name='faFirstname']";
        public String SurnameFinancial = "//app-contract-financial-admin//pfe-input[@name='faLastname']";


        //STEP 5
        public String OKNextButtonDisabled = "//div[@class='col-xl-3 col-lg-4 col-md-4 col-sm-3 col-xs-3']/pfe-cta[@pfe-priority='primary' and @aria-disabled='true']/a";

        //STEP 6
        public String DownloadSEPA = "//app-contracts-creation-page//div[6]/div/app-contract-print-sign//div[4]//pfe-icon[@icon='dcx-download']";
        public String DownloadContract = "//app-contracts-creation-page//div[6]/app-contract-print-sign//h5[contains(text(), 'Download contract template*')]/parent::div//pfe-icon[@icon='dcx-download']";
        public String Spinner = "//div[@id='maskBooking']";
    }
}
