using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Monitored_Vehicles
    {
        private List<List<string>> vehicleVinList = new List<List<string>>();

        public Values__Monitored_Vehicles(List<List<string>> vehicleVinList)
        {
            this.vehicleVinList = vehicleVinList;
        }

        public List<List<string>> GetvinList()
        {
            return vehicleVinList;
        }

        public void SetvinList(List<List<string>> value)
        {
            vehicleVinList = value;
        }
    }
}
