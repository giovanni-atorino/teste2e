using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Monitored_Drivers
    {
        private List<List<string>> driverVinList = new List<List<string>>();

        public Values__Monitored_Drivers(List<List<string>> driverVinList)
        {
            this.driverVinList = driverVinList;
        }

        public List<List<string>> GetdriverList()
        {
            return driverVinList;
        }

        public void SetvinList(List<List<string>> value)
        {
            driverVinList = value;
        }
    }
}
