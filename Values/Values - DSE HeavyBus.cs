using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__DSE_HeavyBus

    {
        private String fuelSavingScoreValuePath;
        private String accelerationValue;
        private String inertiaValue;
        private String stopValue;
        private String comfortScoreValue;
        private String lateralComfortScoreValue;
        private String longitudinalComfortScoreValue;
        private String verticalComfortScoreValue;


        public Values__DSE_HeavyBus(String fuelSavingScoreValuePath, String accelerationValue, String inertiaValue, String stopValue, String comfortScoreValue, String lateralComfortScoreValue, String longitudinalComfortScoreValue, String verticalComfortScoreValue)
        {
            this.fuelSavingScoreValuePath = fuelSavingScoreValuePath;
            this.accelerationValue = accelerationValue;
            this.inertiaValue = inertiaValue;
            this.stopValue = stopValue;
            this.comfortScoreValue = comfortScoreValue;
            this.lateralComfortScoreValue = lateralComfortScoreValue;
            this.longitudinalComfortScoreValue = longitudinalComfortScoreValue;
            this.verticalComfortScoreValue = verticalComfortScoreValue;
  

        }

        public string FuelSavingScoreValuePath { get => fuelSavingScoreValuePath; set => fuelSavingScoreValuePath = value; }
        public string AccelerationValue { get => accelerationValue; set => accelerationValue = value; }
        public string InertiaValue { get => inertiaValue; set => inertiaValue = value; }
        public string StopValue { get => stopValue; set => stopValue = value; }
        public string ComfortScoreValue { get => comfortScoreValue; set => comfortScoreValue = value; }
        public string LateralComfortScoreValue { get => lateralComfortScoreValue; set => lateralComfortScoreValue = value; }
        public string LongitudinalComfortScoreValue { get => longitudinalComfortScoreValue; set => longitudinalComfortScoreValue = value; }
        public string VerticalComfortScoreValue { get => verticalComfortScoreValue; set => verticalComfortScoreValue = value; }

    }
}
