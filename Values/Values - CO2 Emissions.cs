using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__CO2_Emissions
    {
        private List<List<string>> cO2Datalist = new List<List<string>>();
        public String emissionKPI;

        public Values__CO2_Emissions(List<List<string>> cO2Datalist, string emissionKPI)
        {
            this.cO2Datalist = cO2Datalist;
            this.emissionKPI = emissionKPI;
        }

        public string EmissionKPI { get => emissionKPI; set => emissionKPI = value; }

        public List<List<string>> GetCO2Datalist()
        {
            return cO2Datalist;
        }

        public void SetCO2Datalist(List<List<string>> value)
        {
            cO2Datalist = value;
        }
     
        
    }
}
