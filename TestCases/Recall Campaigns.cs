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

    public class Recall_Campaigns: BaseClass
	{
		public Recall_Campaigns(Account Account) : base(Account) { }

		public Recall_Campaigns() { }

		static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();

		static string account_italy = TestContext.Parameters["account_italy"].ToString();
		
		public void RecallCampaignsOpenMenu(Xpath__RecallCampaigns Xpath, Values__RecallCampaigns Value )
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				//Open Menu + click on Vehicle Management + Click on Recall Campigns
				OpenSecondSectionMenu(Xpath.Menu, Xpath.VehiclesManagement, "Vehicles Management", Xpath.RecallCampaigns, "Recall Campaigns", 1000);

				js.ExecuteScript("document.body.style.zoom = '0.40'");
			
				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.RecallCampaignsTitle, Value.RecallCampaignsTitle);

				//Verify Presence of OTARecallCampaignsTitle
				AssertElementIsEqualTo(Xpath.OTARecallCampaignsTitle, Value.OTARecallCampaignsTitle);
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}

		}

		public void RecallCampaignsVerifyTable(Xpath__RecallCampaigns Xpath, Values__RecallCampaigns Value)
		{
			try
			{
				try
				{
					//Verify Presence of ThereAreNoActiveCampaigns
					AssertElementIsEqualTo(Xpath.ThereAreNoActiveCampaigns, Value.ThereAreNoActiveCampaigns);
				}
				catch
				{
					//Verify Presence of RecallCampaign
					AssertElementIsEqualTo(Xpath.RecallCampaign, Value.RecallCampaign);

					//Verify Presence of ToBePerformedByAt
					AssertElementIsEqualTo(Xpath.ToBePerformedByAt, Value.ToBePerformedByAt);

					//Verify Presence of VehiclesToDoOnTotal
					AssertElementIsEqualTo(Xpath.VehiclesToDoOnTotal, Value.VehiclesToDoOnTotal);

					//Verify Presence of ReleaseDate
					AssertElementIsEqualTo(Xpath.ReleaseDate, Value.ReleaseDate);

					//Verify Presence of ExpirationDate
					AssertElementIsEqualTo(Xpath.ExpirationDate, Value.ExpirationDate);

					//Verify Presence of DaysToExpiration
					AssertElementIsEqualTo(Xpath.DaysToExpiration, Value.DaysToExpiration);
				}
			}
			catch(Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}
		public void RecallCampaignsAdvancedFilters(Xpath__RecallCampaigns Xpath, Values__RecallCampaigns Value)
        {
            try 
			{
				//Verify Presence of AdvanceFiltersTitle
				AssertElementIsEqualTo(Xpath.AdvancedFiltersTitle, Value.AdvancedFiltersTitle);
				
				//Verify Presence of Country
				AssertElementIsEqualTo(Xpath.Country, Value.Country);

				//Click on country selection ITALY
				JSClickDropdownChoice(Xpath.ITALY, Value.ITALY, 2000);

				//Search for an account
				ExpandShadowElementClickAndSendKeys("pfe-input", 2, "[id=input]", account_italy);
				System.Threading.Thread.Sleep(500);

				//Select the search icon
				JSClickDropdownChoice(Xpath.searchIcon, "", 2000);

				//Select first choice of accounts
				ClickDropdownChoice(Xpath.selectFirstChoice, "", 3000);

				//Select apply to apply filters
				JSClickDropdownChoice(Xpath.selectApply, "", 2000);
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}
		public void RecallCampaignsDifferentCountry(Xpath__RecallCampaigns Xpath, Values__RecallCampaigns Value)
		{
			try
			{
				//Verify Presence of AdvanceFiltersTitle
				AssertElementIsEqualTo(Xpath.AdvancedFiltersTitle, Value.AdvancedFiltersTitle);

				//Verify Presence of Country
				AssertElementIsEqualTo(Xpath.Country, Value.Country);

				//Click on country selection UNITED KINGDOM
				JSClickDropdownChoice(Xpath.UK, Value.UK, 2000);

				//Search for an account
				ExpandShadowElementClickAndSendKeys("pfe-input", 2, "[id=input]", account_italy);
				System.Threading.Thread.Sleep(500);

				//Select the search icon
				JSClickDropdownChoice(Xpath.searchIcon, "", 2000);

				//Verify that the select account bar is unselectable
				VerifyElement(Xpath.selectFirstChoiceDisabled);
				Console.WriteLine("Verified that the account is not related to the wrong market ");
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}
	}
}