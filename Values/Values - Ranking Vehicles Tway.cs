using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Ranking_Vehicles_Tway

    {
        public string[,] datasetVehiclesMatrix = new string[15, 31];
        public String averageTotalFuel;
        public String pto;
        public String idiling;
        public String numberOfStop;
        public String co2Emissions;


        public Values__Ranking_Vehicles_Tway(string[,] datasetVehicles, string averageTotalFuel, string pto, string idiling, string numberOfStop, string co2Emissions)
        {
            this.datasetVehiclesMatrix = datasetVehicles;
            this.averageTotalFuel = averageTotalFuel;
            this.pto = pto;
            this.idiling = idiling;
            this.numberOfStop = numberOfStop;
            this.co2Emissions = co2Emissions;
        }

        public string AverageTotalFuel { get => averageTotalFuel; set => averageTotalFuel = value; }
        public string Pto { get => pto; set => pto = value; }
        public string Idiling { get => idiling; set => idiling = value; }
        public string NumberOfStop { get => numberOfStop; set => numberOfStop = value; }
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