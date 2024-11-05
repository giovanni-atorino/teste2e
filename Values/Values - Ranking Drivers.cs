using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Ranking_Drivers

    {
        public string[,] datasetDriversMatrix = new string[15, 33];
        public String fuelSavingScore;
        public String averageTotalFuel;
        public String degreeOfDifficulty;
        public String co2Emissions;
        public String vehicleCare;

        public Values__Ranking_Drivers(string[,] datasetDrivers, string fuelSavingScore, string averageTotalFuel, string degreeOfDifficulty, string co2Emissions, string vehicleCare)
        {
            this.datasetDriversMatrix = datasetDrivers;
            this.fuelSavingScore = fuelSavingScore;
            this.averageTotalFuel = averageTotalFuel;
            this.degreeOfDifficulty = degreeOfDifficulty;
            this.co2Emissions = co2Emissions;
            this.vehicleCare = vehicleCare;
        }

        public string FuelSavingScore { get => fuelSavingScore; set => fuelSavingScore = value; }
        public string AverageTotalFuel { get => averageTotalFuel; set => averageTotalFuel = value; }
        public string DegreeOfDifficulty { get => degreeOfDifficulty; set => degreeOfDifficulty = value; }
        public string Co2Emissions { get => co2Emissions; set => co2Emissions = value; }
        public string VehicleCare { get => vehicleCare; set => vehicleCare = value; }


        // Matrix on Ranking Drivers table
        public string[,] GetdatasetDrivers()
        {
            return datasetDriversMatrix;
        }

        public void SetdatasetDrivers(string[,] value)
        {
            datasetDriversMatrix = value;
        }
    }
}