using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Ranking_Vehicles_Electric

    {
        public string[,] datasetVehiclesMatrix = new string[15, 31];
        public String vehicles;
        public String mission;
        public String behaviour;
        public String energy;
        public String driver;
        public String co2Saved;

        public Values__Ranking_Vehicles_Electric(string[,] datasetvehicles, string mission, string behaviour, string energy,  string driver, string co2Saved)
        {
            this.datasetVehiclesMatrix = datasetvehicles;
            this.mission = mission;
            this.behaviour  = behaviour;
            this.energy = energy;
            this.driver = driver;
            this.co2Saved = co2Saved;
        }

        public string Mission { get => mission; set => mission = value; }
        public string Behaviour { get => behaviour; set => behaviour = value; }
        public string Energy { get => energy; set => energy = value; }
        public string Driver { get => driver; set => driver = value; }
        public string Co2Saved { get => co2Saved; set => co2Saved = value; }


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