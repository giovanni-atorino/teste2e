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
    public class Permissions_Section_AddRemoveAccount: BaseClass
    {

        public void PermissionsSectionAddRemoveAccount(Xpath__Permissions Xpath, Values__Permissions Value)
        {
            try
            {

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
                js.ExecuteScript("document.body.style.zoom = '0.70'");

                // Verify the presence of menu
                VerifyElement(Xpath.Menu);

                //Open Menu + click on Permission + click on Permission
                OpenSecondSectionMenu(Xpath.Menu, Xpath.Permissions, Value.Permissions, Xpath.Permissions2, Value.Permissions2, 1000);

                // Expand Add new user box
                ExpandShadowElementClickAndSendKeys("pfe-input", 1, "[id=input]", Value.TestAccount);
                System.Threading.Thread.Sleep(1000);
                ExpandShadowElementClickAndSendKeys("pfe-input", 1, "[id=input]", "");

                //Verify the presence of Add button
                AssertElementIsEqualTo(Xpath.AddButton, Value.Add);

                //Click on ADD button
                JSClickDropdownChoice(Xpath.AddButton, "ADD button", 1000);

                // Check on popoup window for contact details
                //Verify label Contact
                AssertElementIsEqualTo(Xpath.AddNewUserTitle, Value.AddNewUserTitle);
                //Verify label Account
                VerifyElement(Xpath.AddNewUserAccountEmail);
                //Verify label Registered
                VerifyElement(Xpath.AddNewUserRegistered);
                //Verify label Name
                VerifyElement(Xpath.AddNewUserName);
                //Insert test name
                ExpandShadowElementClickClearAndSendKeys("pfe-input", 3, "[id=input]", Value.TestAccountName);

                //Verify label Surname
                VerifyElement(Xpath.AddNewUserLastName);
                //Insert test last name
                ExpandShadowElementClickClearAndSendKeys("pfe-input", 4, "[id=input]", Value.TestAccountLastName);

                //Verify label Phone
                VerifyElement(Xpath.AddNewUserPhone);
                //Search and select prefix italy
                JSClickDropdownChoice(Xpath.AddNewUserPrefixArrow, "Prefix selection", 500);
                JSClickDropdownChoice(Xpath.AddNewUserPrefix + Value.TestAccountPrefix + "')]", "Prefix ITALY", 500);
                //Insert test phone
                ExpandShadowElementClickClearAndSendKeys("pfe-input", 5, "[id=input]", Value.TestAccountPhone);
                System.Threading.Thread.Sleep(1000);

                //Click on save button
                JSClickDropdownChoice(Xpath.AddNewUserSaveButton, "SAVE button", 6000);

                //Close successful popup
                ExpandShadowElementAndClick("pfe-modal", 5, "[class=pfe-modal__close]");

                //Verify that the account is added in the list
                VerifyElement(Xpath.TestAccount);

                //Verify the presence of Resend Button
                AssertElementIsEqualTo(Xpath.ResendButton, Value.Resend);

                //Verify the presence of Remove button
                AssertElementIsEqualTo(Xpath.RemoveButton, Value.Remove);

                //Click on Remove 
                JSClickDropdownChoice(Xpath.RemoveButton, "Remove button", 1000);

                //Verify the presence of pop-up and click on it
                JSClickDropdownChoice(Xpath.YesButton, "YES button", 1000);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

        driver.Close();
        }
    }
}