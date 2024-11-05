using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Score_Summary_Tway

    {
        private String fuelConsuption;
        private String averageGrossCombinationWeight;
        private String averageDistancePerUnit;
        private String avgSpeed;
        private String cO2Emissions;


        public Values__Score_Summary_Tway(String fuelConsuption, String averageGrossCombinationWeight, String averageDistancePerUnit, String avgSpeed, String cO2Emissions)
        {
            this.fuelConsuption = fuelConsuption;
            this.averageGrossCombinationWeight = averageGrossCombinationWeight;
            this.averageDistancePerUnit = averageDistancePerUnit;
            this.avgSpeed = avgSpeed;
            this.cO2Emissions = cO2Emissions;
        }

        public string FuelConsuption { get => fuelConsuption; set => fuelConsuption = value; }
        public string AverageGrossCombinationWeight { get => averageGrossCombinationWeight; set => averageGrossCombinationWeight = value; }
        public string AverageDistancePerUnit { get => averageDistancePerUnit; set => averageDistancePerUnit = value; }
        public string AvgSpeed { get => avgSpeed; set => avgSpeed = value; }
        public string CO2Emissions { get => cO2Emissions; set => cO2Emissions = value; }
    }
}
