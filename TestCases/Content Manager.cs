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

    public class Content_Manager: BaseClass
	{
		public Content_Manager(Account Account) : base(Account) { }

		public Content_Manager() { }

		static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();

		public void ContentManagerSection(Xpath__ContentManager Xpath, Values__ContentManager Value )
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                //Open Menu + Click on Content Manager
                OpenSectionMenu(Xpath.Menu, Xpath.ContentManager, "Custom notification management", 1000);

                //Verify Presence Management Creation
                AssertElementIsEqualTo(Xpath.ContentManagerTitle, Value.ContentManagerTitle);

                js.ExecuteScript("document.body.style.zoom = '0.70'");

                //Verify Presence of all the columns
                AssertElementIsEqualTo(Xpath.ID, Value.ID);
				AssertElementIsEqualTo(Xpath.ContentName, Value.ContentName);
				AssertElementIsEqualTo(Xpath.Channel, Value.Channel);
				AssertElementIsEqualTo(Xpath.CreationDate, Value.CreationDate);
				AssertElementIsEqualTo(Xpath.CreatedBy, Value.CreatedBy);
				AssertElementIsEqualTo(Xpath.ScheduledDate, Value.ScheduledDate);
				AssertElementIsEqualTo(Xpath.SentDate, Value.SentDate);
				AssertElementIsEqualTo(Xpath.ApprovedDate, Value.ApprovedDate);
				AssertElementIsEqualTo(Xpath.ApprovedBy, Value.ApprovedBy);
				AssertElementIsEqualTo(Xpath.ContentStatus, Value.ContentStatus);
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}

		}
	}
}