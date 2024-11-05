using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Trip_details

    {
        public string[,] datasetTripDetailsMatrix = new string[15, 15];
        public String ecoScore;
        public String fuelConsumption;
        public String totalTripTime;
        public String averageSpeed;
        public String co2Emissions;

        public Values__Trip_details(string[,] datasetTripDetails, string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
        {
            this.datasetTripDetailsMatrix = datasetTripDetails;
            this.ecoScore = ecoScore;
            this.fuelConsumption = fuelConsumption;
            this.totalTripTime = totalTripTime;
            this.averageSpeed = averageSpeed;
            this.co2Emissions = co2Emissions;
        }

        public string EcoScore { get => ecoScore; set => ecoScore = value; }
        public string FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public string TotalTripTime { get => totalTripTime; set => totalTripTime = value; }
        public string AverageSpeed { get => averageSpeed; set => averageSpeed = value; }
        public string Co2Emissions { get => co2Emissions; set => co2Emissions = value; }


        public string[,] GetdatasetTripDetails()
        {
            return datasetTripDetailsMatrix;
        }

        public void SetdatasetTripDetails(string[,] value)
        {
            datasetTripDetailsMatrix = value;
        }
    }
}