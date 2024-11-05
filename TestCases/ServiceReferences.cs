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

    public class Service_References: BaseClass
	{
		static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
		static string CompanyTopCareIdRodella = TestContext.Parameters["company_topcare_id_rodella"].ToString();

		public Service_References(Account Account) : base(Account) { }


		public void ServiceReferences(Xpath__ServiceReferences Xpath, Values__ServiceReferences Value )
		{
			try
			{
			// Wait definition for element
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
			System.Threading.Thread.Sleep(2000);

		    GoToUrl(weburl_runsettings + "topcare/" + CompanyTopCareIdRodella);
		    Console.WriteLine("Navigating to service references for company "+ Value.CompanyNameRodella);

            //Open Menu
            JSClickDropdownChoice(Xpath.Menu, "Menu", 1000);
            JSClickDropdownChoice(Xpath.Menu, "Menu", 1000);


                //Verify Presence of Company Title
                AssertElementIsEqualTo(Xpath.CompanyTitle, Value.CompanyTitle);
			
			//Verify Presence of VAT label
			AssertElementIsEqualTo(Xpath.VATnumber, Value.VATnumber);
			int NumberVATIndex ;
			int CompanyNameIndex ;
			int MFMNameIndex ;
			int MFMSurnameIndex ;
			int MFMEmailIndex ;
			int MFMEPhoneIndex ;

		    NumberVATIndex = 1;
		    CompanyNameIndex = 2;
		    MFMNameIndex = 3;
		    MFMSurnameIndex = 4;
		    MFMEmailIndex = 5;
		    MFMEPhoneIndex = 6;
				
			//Verify VAT number value
			ShadowAssertValueIsEqualTo("pfe-input", NumberVATIndex, "[name=vatNumber]", Value.CompanyVATRodella);

			//Verify Presence of Company
			AssertElementIsEqualTo(Xpath.Company, Value.Company);

			//Verify Company name
			ExpandShadowElement("pfe-input", CompanyNameIndex, "[name=companyName]");

			//Verify Presence of Fleet Manager Title
			AssertElementIsEqualTo(Xpath.FleetManagerTitle, Value.FleetManagerTitle);

			//Verify Presence of NameFleetManager label
			AssertElementIsEqualTo(Xpath.NameFleetManager, Value.NameFleetManager);

			//Verify Presence of NameFleetManager value
			ExpandShadowElement("pfe-input", MFMNameIndex, "[name=fmFirstName]");

			//Verify Presence of SurnameFleetManager
			AssertElementIsEqualTo(Xpath.SurnameFleetManager, Value.SurnameFleetManager);

			//Verify Presence of SurnameFleetManager value
			ExpandShadowElement("pfe-input", MFMSurnameIndex, "[name=fmSurname]");

			//Verify Presence of ClientEmail 
			AssertElementIsEqualTo(Xpath.ClientEmailFleetManager, Value.ClientEmailFleetManager);

			//Verify Presence of ClientEmail value
			ExpandShadowElement("pfe-input", MFMEmailIndex, "[name=fmEmail]");

			//Verify Presence of Phone Number
			AssertElementIsEqualTo(Xpath.PhoneFleetManager, Value.PhoneFleetManager);

			//Verify Presence of ClientEmail value
			ExpandShadowElement("pfe-input", MFMEPhoneIndex, "[name=fmPhone]");

			//Open Service Points Details columns
			ClickDropdownChoice(Xpath.ServicePointsDetailsIconContracted, "", 1000);
			//Open Contract Dealer Details columns
			ClickDropdownChoice(Xpath.ContractDealerDetailsIconContracted, "", 1000);
			//Open Contract Details columns
			ClickDropdownChoice(Xpath.ContractDetailsIconContracted, "", 1000);
			//Open Vehicles Details columns
			ClickDropdownChoice(Xpath.VehicleDetailsIconContracted, "", 1000);

			js.ExecuteScript("document.body.style.zoom = '0.40'");
			System.Threading.Thread.Sleep(2000);

			//Verify Presence of VIN
			AssertElementIsEqualTo(Xpath.VIN, Value.VIN);

			//Verify Presence of Range
			AssertElementIsEqualTo(Xpath.Range, Value.Range);

			//Verify Presence of Fuel
			AssertElementIsEqualTo(Xpath.Fuel, Value.Fuel);

			//Verify Presence of Contract Number
			AssertElementIsEqualTo(Xpath.ContractNumber, Value.ContractNumber);

			//Verify Presence of Start date
			AssertElementIsEqualTo(Xpath.StartDate, Value.StartDate);

			//Verify Presence of End date
			AssertElementIsEqualTo(Xpath.EndDate, Value.EndDate);

			//Verify Presence of ContractDealerSAPcode
			AssertElementIsEqualTo(Xpath.ContractDealerSAPcode, Value.ContractDealerSAPcode);

			//Verify Presence of ContractDealerName
			AssertElementIsEqualTo(Xpath.ContractDealerName, Value.ContractDealerName);

			//Verify Presence of Service Point Name
			AssertElementIsEqualTo(Xpath.ServicePointName, Value.ServicePointName);

			//Verify Presence of Service Point Active status
			AssertElementIsEqualTo(Xpath.ServicePointActiveStatus, Value.ServicePointActiveStatus);

			//Verify Presence of Push Notifications Enabled
			AssertElementIsEqualTo(Xpath.PushNotificationsEnabled, Value.PushNotificationsEnabled);
			}
			catch (Exception e)
			{
			 GetScreenshotAndPrintError(e);
			
			}

		}



	}
}