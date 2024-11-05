using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Energy_Usage
    {

        private String averageFleet;

        public Values__Energy_Usage(String averageFleet)
        {
            this.averageFleet = averageFleet; 
        }
        
        public string AverageFleet { get => averageFleet; set => averageFleet = value; }
    }
}
