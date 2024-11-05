using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Login
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String Account = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[2]/h3/a";
        public String LogoutButton = "//div[@class='pfe-navigation--column']//a[contains(text(), 'Logout')]";
    }
}
