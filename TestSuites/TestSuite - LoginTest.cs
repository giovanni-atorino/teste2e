using Microsoft.VisualStudio.TestTools.UnitTesting;
using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    [Parallelizable]
    public class TestSuite_LoginTest
    {
        public class LoginSection : Login_Section
        {
            Values__Login Value = new Values__Login();
            Xpath__Login Xpath = new Xpath__Login();

            [Test]
            [Category("Login_NRT")]
            public void LoginSectionTest() => LoginSection(Xpath, Value);
        }


        public class LogoutSection : Logout_Section
        {
            Values__Login Value = new Values__Login();
            Xpath__Login Xpath = new Xpath__Login();

            [Test]
            [Category("Login_NRT")]
            public void LogoutSectionTest() => LogoutSection(Xpath, Value);
        }
    }
}