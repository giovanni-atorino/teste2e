using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
    public class Values__DSE_Light

    {
        private String ecoScoreValue;
        private String accelerationValue;
        private String decelerationValue;
        private String engineUseValue;
     


        public Values__DSE_Light(String ecoScoreValue, String accelerationValue, String decelerationValue,
            String engineUseValue)
        {
            this.ecoScoreValue = ecoScoreValue;
            this.accelerationValue = accelerationValue;
            this.decelerationValue = decelerationValue;
            this.engineUseValue = engineUseValue;
            
        }

        public string EcoScoreValue { get => ecoScoreValue; set => ecoScoreValue = value; }
        public string AccelerationValue { get => accelerationValue; set => accelerationValue = value; }
        public string DecelerationValue { get => decelerationValue; set => decelerationValue = value; }
        public string EngineUseValue { get => engineUseValue; set => engineUseValue = value; }
        
    }
}
