using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Ranking_Vehicles_Light_Electric

    {
        public string[,] datasetVehiclesMatrix = new string[15, 31];

        public Values__Ranking_Vehicles_Light_Electric(string[,] datasetvehicles)
        {
            this.datasetVehiclesMatrix = datasetvehicles;

        }

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