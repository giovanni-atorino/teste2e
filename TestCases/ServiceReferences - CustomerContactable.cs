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

    public class Service_References_CustomerContactable : BaseClass
	{
		static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
		static string CompanyTopCareIdRodella = TestContext.Parameters["company_topcare_id_rodella"].ToString();
		public Service_References_CustomerContactable(Account Account) : base(Account) { }


		public void CustomerContactable(Xpath__ServiceReferences Xpath, Values__ServiceReferences Value )
		{
			try
			{
			// Wait definition for element
			driver.Navigate().GoToUrl(weburl_runsettings + "topcare/" + CompanyTopCareIdRodella);
			Console.WriteLine("Navigating to service references for company " + Value.CompanyNameRodella);
			System.Threading.Thread.Sleep(3000);

			JSClickDropdownChoice(Xpath.Menu, Value.Menu, 1000);
			JSClickDropdownChoice(Xpath.Menu, Value.Menu, 1000);

			RefreshCheck(Xpath.CompanyTitle);

			//Verify Presence of Company Title
			AssertElementIsEqualTo(Xpath.CompanyTitle, Value.CompanyTitle);
			
			//Verify Presence of VAT label
			AssertElementIsEqualTo(Xpath.VATnumber, Value.VATnumber);

			//Select first check-box for the first vin-contract couple
			ClickDropdownChoice(Xpath.CheckBoxFirstRow, "", 1000);

			//Verify Presence and click on Manage Multiple Assign Button 
			FindElementAndClick(Xpath.ManageMultipleAssignButton, Value.ManageMultipleAssignButton, 1000);
			
			//Verify Pop-up opening
			AssertElementIsEqualTo(Xpath.ManageMultipleAssignPopupTitle, Value.ManageMultipleAssignPopupTitle);

			//Select flag for SKA
			ClickDropdownChoice(Xpath.SKACheckBox, "", 1000);

            //verify presence of ska checked
            VerifyElement(Xpath.SKACheckBoxChecked);

			//select one SKA
			ClickDropdownChoice(Xpath.testSKAyopmailemail, Value.testSKAyopmailemail, 1000);

            //Verify Customer Contactable label
            AssertElementIsEqualTo(Xpath.CustomerContactable, Value.CustomerContactable);

            //Verify BOX of Customer Contactable label
            AssertElementIsEqualTo(Xpath.BoxCustomerContactable, "");

			//click on save
			ClickDropdownChoice(Xpath.SaveButton, "", 2000);

            //open table
            //Open Service Points Details columns
            ClickDropdownChoice(Xpath.ServiceKeyAccountIconContracted, "", 1000);
            //Open Service Points Details columns
            ClickDropdownChoice(Xpath.ServicePointsDetailsIconContracted, "", 1000);
            //Open Contract Dealer Details columns
            ClickDropdownChoice(Xpath.ContractDealerDetailsIconContracted, "", 1000);
            js.ExecuteScript("document.body.style.zoom = '0.30'");

            //Verify Presence of SKA EMAIL
            AssertElementIsEqualTo(Xpath.SKAEmailValueTableFirstRow, Value.SKAEmailValueTableFirstRow);
			//Verify Presence of ska name
			AssertElementIsEqualTo(Xpath.SKANameValueTableFirstRow, Value.SKANameValueTableFirstRow);
			//Verify presence of ska surname
			AssertElementIsEqualTo(Xpath.SKASurnameValueTableFirstRow, Value.SKASurnameValueTableFirstRow);
			//Verify presence of ska phone
			AssertElementIsEqualTo(Xpath.SKAPhoneValueTableFirstRow, Value.SKAPhoneValueTableFirstRow);
            //Verify presence of Customer contactable
            AssertElementIsEqualTo(Xpath.CustomerContactableTableFirstRow, Value.CustomerContactableTableFirstRow);

            System.Threading.Thread.Sleep(7000);
			//Remove Customer Contactable (false) choice////////////////////////////////////////////////////////
			js.ExecuteScript("document.body.style.zoom = '1'");
			ClickDropdownChoice(Xpath.CheckBoxFirstRow, "", 1000);

			//Verify Presence and click on Manage Multiple Assign Button 
			FindElementAndClick(Xpath.ManageMultipleAssignButton, Value.ManageMultipleAssignButton, 1000);

			//Verify Pop-up opening
			AssertElementIsEqualTo(Xpath.ManageMultipleAssignPopupTitle, Value.ManageMultipleAssignPopupTitle);

            //Select flag for SKA
            ClickDropdownChoice(Xpath.SKACheckBox, "", 1000);

            //verify presence of ska checked
            VerifyElement(Xpath.SKACheckBoxChecked);

            //select one SKA
            ClickDropdownChoice(Xpath.testSKAyopmailemail, Value.testSKAyopmailemail, 1000);

            //verify presence of ska checked
            VerifyElement(Xpath.SKACheckBoxChecked);

            //select flag of Customer Contactable label
            ClickDropdownChoice(Xpath.BoxCustomerContactable, "", 8000);

			//click on save
			ClickDropdownChoice(Xpath.SaveButton, "", 1000);

            //open table
            //Open Service Points Details columns
            ClickDropdownChoice(Xpath.ServiceKeyAccountIconContracted, "", 1000);
            //Open Service Points Details columns
            ClickDropdownChoice(Xpath.ServicePointsDetailsIconContracted, "", 1000);
            //Open Contract Dealer Details columns
            ClickDropdownChoice(Xpath.ContractDealerDetailsIconContracted, "", 1000);
            js.ExecuteScript("document.body.style.zoom = '0.30'");

            //verify that the Customer Contactable choice is false//////////////////////////////////////////////////////
            //Verify Presence of SKA EMAIL
            AssertElementIsEqualTo(Xpath.SKAEmailValueTableFirstRow, Value.SKAEmailValueTableFirstRow);
            //Verify Presence of ska name
            AssertElementIsEqualTo(Xpath.SKANameValueTableFirstRow, Value.SKANameValueTableFirstRow);
            //Verify presence of ska surname
            AssertElementIsEqualTo(Xpath.SKASurnameValueTableFirstRow, Value.SKASurnameValueTableFirstRow);
            //Verify presence of ska phone
            AssertElementIsEqualTo(Xpath.SKAPhoneValueTableFirstRow, Value.SKAPhoneValueTableFirstRow);
            //Verify presence of Customer contactable
            AssertElementIsEqualTo(Xpath.CustomerContactableTableFirstRow, "false");


            //Remove inserted choice////////////////////////////////////////////
            //Select first check-box for the first vin-contract couple

            js.ExecuteScript("document.body.style.zoom = '1'");
            ClickDropdownChoice(Xpath.CheckBoxFirstRow, "", 1000);

            //Verify Presence and click on Manage Multiple Assign Button 
            FindElementAndClick(Xpath.ManageMultipleAssignButton, Value.ManageMultipleAssignButton, 1000);

            //Verify Pop-up opening
            AssertElementIsEqualTo(Xpath.ManageMultipleAssignPopupTitle, Value.ManageMultipleAssignPopupTitle);

            //Select flag for SKA
            ClickDropdownChoice(Xpath.SKACheckBox, "", 1000);

            //verify presence of ska checked
            VerifyElement(Xpath.SKACheckBoxChecked);

            //click on save
            ClickDropdownChoice(Xpath.SaveButton, "", 1000);

            //verify that all the choice have been removed///////////////////////////////////
            //open table
            //Open Service Points Details columns
            ClickDropdownChoice(Xpath.ServiceKeyAccountIconContracted, "", 1000);
            //Open Service Points Details columns
            ClickDropdownChoice(Xpath.ServicePointsDetailsIconContracted, "", 1000);
            //Open Contract Dealer Details columns
            ClickDropdownChoice(Xpath.ContractDealerDetailsIconContracted, "", 1000);
            js.ExecuteScript("document.body.style.zoom = '0.30'");

            //verify data update in table
            //Verify Presence of SKA EMAIL:empty
            AssertElementIsEqualTo(Xpath.SKAEmailValueTableFirstRow, "");
            //Verify Presence of ska name:empty
            AssertElementIsEqualTo(Xpath.SKANameValueTableFirstRow, "");
            //Verify presence of ska surname:empty
            AssertElementIsEqualTo(Xpath.SKASurnameValueTableFirstRow, "");
            //Verify presence of ska phone:empty
            AssertElementIsEqualTo(Xpath.SKAPhoneValueTableFirstRow, "");
            //Verify presence of Customer contactable
            AssertElementIsEqualTo(Xpath.CustomerContactableTableFirstRow, Value.CustomerContactableTableFirstRow);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

        }



    }
}