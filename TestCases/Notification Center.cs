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

    public class Notification_Center: BaseClass
	{
		public void NotificationCenter(Xpath__NotificationCenter Xpath, Values__NotificationCenter Value )
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

			    // Verify the presence of menu
				wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
				Console.WriteLine("Verified presence of Menu");

                //Click on Menu + click on Notification Center
                OpenSectionMenu(Xpath.Menu, Xpath.NotificationCenter, Value.NotificationCenter, 1000);

				js.ExecuteScript("document.body.style.zoom = '0.40'");
			
				//Verify Presence of title
				AssertElementIsEqualTo(Xpath.NotificationCenterTitle, Value.NotificationCenterTitle);

				//Verify Presence of Vehicles
				AssertElementIsEqualTo(Xpath.Vehicles, Value.Vehicles);
		    
				//Verify Presence of From
				AssertElementIsEqualTo(Xpath.From, Value.From);
		    
				//Verify Presence of To
				AssertElementIsEqualTo(Xpath.To, Value.To);
		    
				//Verify Presence of ControlRoom
				//AssertElementIsEqualTo(Xpath.ControlRoom, Value.ControlRoom);

				//Verify Presence of OverTheAirRecall
				//AssertElementIsEqualTo(Xpath.OverTheAirRecall, Value.OverTheAirRecall);
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}


		public void NotificationSending(Xpath__NotificationCenter Xpath, Values__NotificationCenter Value)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				// Verify the presence of menu
				wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
				Console.WriteLine("Verified presence of Menu");

                //Click on Menu + click on Notification Center
                OpenSectionMenu(Xpath.Menu, Xpath.NotificationCenter, Value.NotificationCenter, 1000);

                js.ExecuteScript("document.body.style.zoom = '0.40'");

				//Sending notification 8
				SendingNotification("WJME62RS0JC397534", "8");
				System.Threading.Thread.Sleep(300000);

				driver.Navigate().Refresh();
				RefreshCheck(Xpath.Vehicles);
				
				//Verify Date of Receipt of last notification
				DateTime thisDay = DateTime.Today;
				String DateofReceiptValue = thisDay.ToString("d-M-yyyy");
				                                                          
				//wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.LastNotificationDateOfReceipt)));
				//Assert.That(driver.FindElement(By.XPath(Xpath.LastNotificationDateOfReceipt)).Text.Replace("Date of receipt : ", ""), Is.EqualTo(DateofReceiptValue));
				Console.WriteLine("Verified presence of Date of Receipt " + DateofReceiptValue);

				//Verify Last notification corresponds to notification 8
				AssertElementIsEqualTo(Xpath.LastNotificationContent, Value.NotificationN8);

				//Verify notification 11 is NOT present
				String AbsenceNotificationN11 = driver.FindElement(By.XPath(Xpath.PreviousNotificationContent)).Text.Replace("]", "and contains(text(),'" + Value.NotificationN11 + "')]");
				wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(AbsenceNotificationN11)));
				Console.WriteLine("Verified absence of notification with content: " + Value.NotificationN11);

				//Sending notification 8 and 11
				SendingNotification("WJME62RS0JC397534", "8,11"); //8,11 notifica
				System.Threading.Thread.Sleep(300000);
				
				driver.Navigate().Refresh();
				RefreshCheck(Xpath.Vehicles);

				//Verify Date of Receipt of last notification
				//wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.LastNotificationDateOfReceipt)));
				//Assert.That(driver.FindElement(By.XPath(Xpath.LastNotificationDateOfReceipt)).Text.Replace("Date of receipt : ", ""), Is.EqualTo(DateofReceiptValue));
				Console.WriteLine("Verified presence of Date of Receipt " + DateofReceiptValue);

				//Verify Last notification corresponds to notification 11
				AssertElementIsEqualTo(Xpath.LastNotificationContent, Value.NotificationN11);

				//Verify Date of Receipt of previous notification
				//wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.PreviousNotificationDateOfReceipt)));
				//Assert.That(driver.FindElement(By.XPath(Xpath.PreviousNotificationDateOfReceipt)).Text.Replace("Date of receipt : ", ""), Is.EqualTo(DateofReceiptValue));
				Console.WriteLine("Verified presence of Date of Receipt " + DateofReceiptValue);

				//Verify Last notification corresponds to notification 8
				AssertElementIsEqualTo(Xpath.PreviousNotificationContent, Value.NotificationN8);

				//Sending notification 11
				SendingNotification("WJME62RS0JC397534", "11");
				System.Threading.Thread.Sleep(300000);

				driver.Navigate().Refresh();
				RefreshCheck(Xpath.Vehicles);

				//Verify Date of Receipt of last notification
				//wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.LastNotificationDateOfReceipt)));
				//Assert.That(driver.FindElement(By.XPath(Xpath.LastNotificationDateOfReceipt)).Text.Replace("Date of receipt : ", ""), Is.EqualTo(DateofReceiptValue));
				Console.WriteLine("Verified presence of Date of Receipt " + DateofReceiptValue);

				//Verify Last notification corresponds to notification 11
				AssertElementIsEqualTo(Xpath.LastNotificationContent, Value.NotificationN11);

				//Verify notification 8 is NOT present
				String AbsenceNotificationN8 = driver.FindElement(By.XPath(Xpath.PreviousNotificationContent)).Text.Replace("]", "and contains(text(),'" + Value.NotificationN8 + "')]");
				wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(AbsenceNotificationN8)));
				Console.WriteLine("Verified absence of notification with content: " + Value.NotificationN8);
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}
	}
}