using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Score_Summary_Light

    {
        private String ecoScore;
        private String fuelConsuption;
        private String totalDistance;
        private String totalTripTime;
        private String trips;
        private String averageSpeed;
        private String cO2Emissions;


        public Values__Score_Summary_Light(String ecoScore, String fuelConsuption, String totalDistance, 
            String totalTripTime, String trips, String averageSpeed, String cO2Emissions)
        {
            this.ecoScore = ecoScore;
            this.fuelConsuption = fuelConsuption;
            this.totalDistance = totalDistance;
            this.totalTripTime = totalTripTime;
            this.trips = trips;
            this.averageSpeed = averageSpeed;
            this.cO2Emissions = cO2Emissions;
        }

        public string EcoScore { get => ecoScore; set => ecoScore = value; }
        public string FuelConsuption { get => fuelConsuption; set => fuelConsuption = value; }
        public string TotalDistance { get => totalDistance; set => totalDistance = value; }
        public string TotalTripTime { get => totalTripTime; set => totalTripTime = value; }
        public string Trips { get => trips; set => trips = value; }
        public string AverageSpeed { get => averageSpeed; set => averageSpeed = value; }
        public string CO2Emissions { get => cO2Emissions; set => cO2Emissions = value; }
    }
}
