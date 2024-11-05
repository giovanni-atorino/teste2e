using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Fuel_Consumption
    {

        private String averageFleet;

        public Values__Fuel_Consumption(String averageFleet)
        {
            this.averageFleet = averageFleet; 
        }
        
        public string AverageFleet { get => averageFleet; set => averageFleet = value; }
    }
}
