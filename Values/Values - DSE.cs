using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__DSE

    {
        private String fuelSavingScoreValue;
        private String accelerationValue;
        private String decelerationValue;
        private String engineUseValue;
        private String vehicleCareScoreValue;
        private String brakeUseValue;
        private String tyresValue;
        private String safeDrivingScoreValue;


        public Values__DSE(String fuelSavingScoreValue, String accelerationValue, String decelerationValue,
            String engineUseValue, String vehicleCareScoreValue, String brakeUseValue, String tyresValue, String safeDrivingScoreValue)
        {
            this.fuelSavingScoreValue = fuelSavingScoreValue;
            this.accelerationValue = accelerationValue;
            this.decelerationValue = decelerationValue;
            this.engineUseValue = engineUseValue;
            this.vehicleCareScoreValue = vehicleCareScoreValue;
            this.brakeUseValue = brakeUseValue;
            this.tyresValue = tyresValue;
            this.safeDrivingScoreValue = safeDrivingScoreValue;
        }

        public string FuelSavingScoreValue { get => fuelSavingScoreValue; set => fuelSavingScoreValue = value; }
        public string AccelerationValue { get => accelerationValue; set => accelerationValue = value; }
        public string DecelerationValue { get => decelerationValue; set => decelerationValue = value; }
        public string EngineUseValue { get => engineUseValue; set => engineUseValue = value; }
        public string VehicleCareScoreValue { get => vehicleCareScoreValue; set => vehicleCareScoreValue = value; }
        public string BrakeUseValue { get => brakeUseValue; set => brakeUseValue = value; }
        public string TyresValue { get => tyresValue; set => tyresValue = value; }
        public string SafeDrivingScoreValue { get => safeDrivingScoreValue; set => safeDrivingScoreValue = value; }
    }
}
