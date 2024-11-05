using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__Score_Summary_HeavyBusElectric

    {
        private String drivingEfficiencyScore;
        private String energyConsumption;
        private String averageDistancePerUnit;
        private String avgOCT;
        private String avgTripTime;
        private String averageSpeed;


        public Values__Score_Summary_HeavyBusElectric(String drivingEfficiencyScore, String energyConsumption, String averageDistancePerUnit, String avgOCT, String avgTripTime, String averageSpeed)
        {
            this.drivingEfficiencyScore = drivingEfficiencyScore;
            this.energyConsumption = energyConsumption;
            this.averageDistancePerUnit = averageDistancePerUnit;
            this.avgOCT = avgOCT;
            this.avgTripTime = avgTripTime;
            this.averageSpeed = averageSpeed;
        }

        public string DrivingEfficiencyScore { get => drivingEfficiencyScore; set => drivingEfficiencyScore = value; }
        public string EnergyConsumption { get => energyConsumption; set => energyConsumption = value; }
        public string AverageDistancePerUnit { get => averageDistancePerUnit; set => averageDistancePerUnit = value; }
        public string AvgOCT { get => avgOCT; set => avgOCT = value; }
        public string AvgTripTime { get => avgTripTime; set => avgTripTime = value; }
        public string AverageSpeed { get => averageSpeed; set => averageSpeed = value; }


    }
}
