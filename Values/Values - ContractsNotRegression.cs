using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Values
{
     public class Values__ContractNotRegression
    {
        private List<string> VINInfo = new List<string>();
        private List<List<string>> AddedService = new List<List<string>>();
        private List<List<string>> RemovedService = new List<List<string>>();
        private List<string> Price = new List<string>();
        private List<string> CompanySite = new List<string>();
        private List<string> MFMInfo = new List<string>();
        private List<string> ValuePDF = new List<string>();
        private List<string> MarketInfo = new List<string>();


        public Values__ContractNotRegression(List<string> VINInfo , List<List<string>> AddedService,List <List<String>> RemovedService, List <string> Price,List <string> CompanySite, List<string> MFMInfo , List<string> ValuePDF, List<string> MarketInfo) 
        {
            this.VINInfo = VINInfo;
            this.AddedService = AddedService;
            this.RemovedService = RemovedService;
            this.Price = Price;
            this.CompanySite = CompanySite;
            this.MFMInfo = MFMInfo;
            this.ValuePDF = ValuePDF;
            this.MarketInfo = MarketInfo;
        }
        
        //VinIfo
        public List<string> GetVinInfo()
        {
            return VINInfo;
        }

        public void SetVinInfo(List<string> value)
        {
            VINInfo = value;
        }
        //AddedService
        public List<List<string>> GetAddedServiceInfo()
        {
            return AddedService;
        }

        public void SetAddedService1(List<List<string>> value)
        {
            AddedService = value;
        }
      
        //RemovedService 
        public List<List<string>> GetRemovedServiceInfo()
        {
            return RemovedService;
        }

        public void SetRemovedService2(List<List<string>> value)
        {
            RemovedService = value;
        }
        //Total Price and Discount
        public List<string> GetPriceInfo()
        {
            return Price;
        }

        public void SetPriceInfo(List<string> value)
        {
            Price = value;
        }

        //CompanySite
        public List<string> GetCompanySiteInfo()
        {
            return CompanySite;
        }

        public void SetCompanySiteInfo(List<string> value)
        {
            CompanySite = value;
        }
        //MFM
        public List<string> GetMFMInfo()
        {
            return MFMInfo;
        }

        public void SetMFMInfoInfo(List<string> value)
        {
            MFMInfo = value;
        }

        //ValuePDF
        public List<string> GetValuePDF()
        {
            return ValuePDF;
        }

        public void SetValuePDF(List<string> value)
        {
            ValuePDF = value;
        }

        //market Info
        public List<string> GetMarketInfo()
        {
            return MarketInfo;
        }

        public void SetMarketInfo(List<string> value)
        {
            MarketInfo = value;
        }
    }
}
