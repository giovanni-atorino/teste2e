using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Ranking_Vehicles_HeavyBus

    {
        public string[,] datasetVehiclesMatrix = new string[15, 31];
        public String fuelSavingScore;
        public String averageTotalFuel;
        public String averageSpeed;
        public String co2Emissions;

        public Values__Ranking_Vehicles_HeavyBus(string[,] datasetVehicles, string fuelSavingScore, string averageTotalFuel, string averageSpeed, string co2Emissions)
        {
            this.datasetVehiclesMatrix = datasetVehicles;
            this.fuelSavingScore = fuelSavingScore;
            this.averageTotalFuel = averageTotalFuel;
            this.averageSpeed = averageSpeed;
            this.co2Emissions = co2Emissions;
        }

        public string FuelSavingScore { get => fuelSavingScore; set => fuelSavingScore = value; }
        public string AverageTotalFuel { get => averageTotalFuel; set => averageTotalFuel = value; }
        public string AverageSpeed { get => averageSpeed; set => averageSpeed = value; }

        public string Co2Emissions { get => co2Emissions; set => co2Emissions = value; }


        public string[,] GetdatasetVehicles()
        {
            return datasetVehiclesMatrix;
        }

        public void SetdatasetVehicles(string[,] value)
        {
            datasetVehiclesMatrix = value;
        }
    }
}