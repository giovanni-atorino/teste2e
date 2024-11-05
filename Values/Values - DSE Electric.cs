using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__DSE_Electric

    {
        private String energyEfficiencyScoreValue;
        private String accelerationValue;
        private String decelerationValue;
        private String energyManagementValue;
        private String vehicleCareScoreValue;
        private String brakeUseValue;
        private String tyresValue;
        private String safeDrivingScoreValue;


        public Values__DSE_Electric(String energyEfficiencyScoreValue, String accelerationValue, String decelerationValue, String energyManagementValue, String vehicleCareScoreValue, String brakeUseValue, String tyresValue, String safeDrivingScoreValue)
        {
            this.energyEfficiencyScoreValue = energyEfficiencyScoreValue;
            this.accelerationValue = accelerationValue;
            this.decelerationValue = decelerationValue;
            this.energyManagementValue = energyManagementValue;
            this.vehicleCareScoreValue = vehicleCareScoreValue;
            this.brakeUseValue = brakeUseValue;
            this.tyresValue = tyresValue;
            this.safeDrivingScoreValue = safeDrivingScoreValue;
        }

        public string EnergyEfficiencyScoreValue { get => energyEfficiencyScoreValue; set => energyEfficiencyScoreValue = value; }
        public string AccelerationValue { get => accelerationValue; set => accelerationValue = value; }
        public string DecelerationValue { get => decelerationValue; set => decelerationValue = value; }
        public string EnergyManagementValue { get => energyManagementValue; set => energyManagementValue = value; }
        public string VehicleCareScoreValue { get => vehicleCareScoreValue; set => vehicleCareScoreValue = value; }
        public string BrakeUseValue { get => brakeUseValue; set => brakeUseValue = value; }
        public string TyresValue { get => tyresValue; set => tyresValue = value; }
        public string SafeDrivingScoreValue { get => safeDrivingScoreValue; set => safeDrivingScoreValue = value; }
    }
}
