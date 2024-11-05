using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Score_Summary_HeavyBus

    {
        private String fuelSavingScore;
        private String fuelConsuption;
        private String averageDistancePerUnit;
        private String cO2Emissions; 


        public Values__Score_Summary_HeavyBus(String fuelSavingScore, String fuelConsuption, String averageDistancePerUnit, String cO2Emissions)
        {
            this.fuelSavingScore = fuelSavingScore;
            this.fuelConsuption = fuelConsuption;
            this.averageDistancePerUnit = averageDistancePerUnit;
            this.cO2Emissions = cO2Emissions;
        }

        public string FuelSavingScore { get => fuelSavingScore; set => fuelSavingScore = value; }
        public string FuelConsuption { get => fuelConsuption; set => fuelConsuption = value; }
        public string AverageDistancePerUnit { get => averageDistancePerUnit; set => averageDistancePerUnit = value; }
        public string CO2Emissions { get => cO2Emissions; set => cO2Emissions = value; }
    }
}
