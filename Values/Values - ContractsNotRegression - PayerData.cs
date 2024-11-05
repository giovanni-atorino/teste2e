using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
     public class Values__ContractNotRegressionPayerData
    {
     
        private List<string> PayerData = new List<string>();
        private List<string> FinancialData = new List<string>();

        public Values__ContractNotRegressionPayerData(List<string> PayerData, List<string> FinancialData)
        {
            this.PayerData = PayerData;
            this.FinancialData = FinancialData;
        }

        //PayerInfo
        public List<string> GetPayerInfo()
        {
            return PayerData;
        }

        public void SetPayerInfo(List<string> value)
        {
            PayerData = value;
        }

        public List<string> GetFinancialInfo()
        {
            return FinancialData;
        }

        public void SetFinancialInfo(List<string> value)
        {
            FinancialData = value;
        }
    }
}
