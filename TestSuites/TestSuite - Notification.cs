using Microsoft.VisualStudio.TestTools.UnitTesting;
using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{

    public class TestSuite_Notification 
    {
        public NUnit.Framework.TestContext TestContext { get; set; }
        static string tco_account_runsettings = NUnit.Framework.TestContext.Parameters["tco_account"].ToString();
        static string tco_pwd_runsettings = NUnit.Framework.TestContext.Parameters["tco_pwd"].ToString();
        static string hq_account_runsettings = NUnit.Framework.TestContext.Parameters["hq_account"].ToString();
        static string hq_pwd_runsettings = NUnit.Framework.TestContext.Parameters["hq_pwd"].ToString();
        static string dealer_account_runsettings = NUnit.Framework.TestContext.Parameters["dealer_account"].ToString();
        static string dealer_pwd_runsettings = NUnit.Framework.TestContext.Parameters["dealer_pwd"].ToString();
        static string fm2_account_runsettings = NUnit.Framework.TestContext.Parameters["fm_account2"].ToString();
        static string fm2_pwd_runsettings = NUnit.Framework.TestContext.Parameters["fm_pwd2"].ToString();

        public class NotificationSending : Notification_Center
        {
            Values__NotificationCenter Value = new Values__NotificationCenter();
            Xpath__NotificationCenter Xpath = new Xpath__NotificationCenter();

            [Test]
            [Category("NotificationCenter")]
            public void NotificationSendingTest() => NotificationSending(Xpath, Value);
        }
    }
}