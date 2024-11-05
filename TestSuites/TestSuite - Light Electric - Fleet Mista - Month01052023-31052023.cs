using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Light_Electric_Month
    {
        // Define query parameters used in filters
        static string frequency = "m";
        static string from_date = "1682902800000";//"1682899200000";//"1682902800000";
        static string to_date = "1685581199000";//"1685577599000"; //"1685581199000";
        static string vehicle_list = "ZCFC642CX05485317-ZCFCX38E305523308-ZCFC652C405453839";
        static string fuel_type = "3";
        static string fleet_id = "17";
        static string vehicle_type = "2";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_Light_Electric_Month : Score_Summary_Widget
        {
            //Driving efficiency score (index); Driving efficiency score (kWh/h); Energy regenerated vs. used (%); Energy for climatization vs. used (%); Average recharge time (hh:mm); Average recharged energy  (kWh)
            Values__Score_Summary_Light_Electric Value = new Values__Score_Summary_Light_Electric("75", "0,42", "10,22", "0,03", "04:04", "369", "607,79", "01:04:53", "17,38", "5,41", "99", "4.115");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary_Light Xpath = new Xpath__Score_Summary_Light();

            [Test]
            public void ScoreSummary() => FleetManagerViewForLightElectricFleets(Xpath, Value, Filters);
        }


        public class CO2_Emissions_Light_Electric_Month : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","8.711,2","2","6.690,82","153"},
            new List<string>{ "2","4.030,7","3","6.298,29","56"},
            new List<string>{ "3","361,9","3","1.037,69","21"},
            new List<string>{ "4","596,5","3","1.823,36","29"}};

            static string weeklyEmissionKPI = "596,5";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsElectric(Xpath, Value, Filters);
        }


        public class Energy_Usage_Light_Electric_Month : Energy_usage_Widget
        {
            // KPI Fuel Consumption
            Values__Energy_Usage Value = new Values__Energy_Usage("0,42");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void EnergyUsage() => TotalEnergyUsageInformation(Xpath, Value, Filters);

        }


        public class DSE_Light_Electric_Month : DSE_Widget_Vehicles_Acceleration
        {
            //Eco Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            Values__DSE_Electric Value = new Values__DSE_Electric("75","86","68","100","100","79","100","96");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE_Light Xpath = new Xpath__DSE_Light();

            [Test]
            public void DSE() => DSEkpiAnalysisElectric(Xpath, Value, Filters);

        }

        public class Monitored_Vehicles_Light_Electric_Month : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Energy usage score (index), Energy used (kWh/km), Energy regenerated vs used(%), Energy for climatization vs used(%), Average time to recharge(hh:mm)
            new List<string>{ "ZCFC642CX05485317", "100","0,56","26","0","00:55"},
            new List<string>{ "ZCFCX38E305523308 - CH 299", "-","-","-","-","00:16"},
            new List<string>{ "ZCFC652C405453839 - ddddd", "100","0,41","29","0","11:01"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles_Light Xpath = new Xpath__Monitored_Vehicles_Light();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleElectric(Xpath, Value, Filters);
        }

        public class Ranking_Vehicles_Light_Electric_Month : Rankings_Widget
        {

            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
            {"0,57", "0,03", "-", "0,12", "98", "11.679", "60", "84", "62", "▼", "71", "Acceleration style", "100", "78", "100", "98", "0", "-", "-", "-", "6", "8", "86", "-", "-", "-", "-", "1.561,82", "5,71", "17,60", "294", "-", "ddddd", "-", "-", "21.111,75", "1", "ZCFC652C405453839", "57", "2", "0,41", "100", "509,1"},
            { "0,41", "0,01", "-", "0,15", "99", "567", "91", "95", "94", "▲", "95", "Acceleration style", "100", "83", "100", "66", "22", "-", "-", "-", "31", "4", "66", "-", "-", "-", "-", "261,41", "3,97", "16,45", "420", "0", "-", "-", "-", "5.455,18", "2", "ZCFC642CX05485317", "61", "12", "0,56", "100", "115,2"},
            {"111,59", "8,15", "-", "28,42", "99", "100", "-", "-", "-", "=", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "100", "-", "-", "-", "-", "0,13", "4,79", "1,64", "5.926", "-", "CH 299", "-", "38S14E V", "153,07", "3", "ZCFCX38E305523308", "-", "100", "-", "-", "-"}};

            Values__Ranking_Vehicles_Light_Electric Value = new Values__Ranking_Vehicles_Light_Electric(datasetVehiclesMatrix);
            //string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking_Light Xpath = new Xpath__Ranking_Light();

            [Test]
            public void RankingVehicles() => RankingVehiclesWidgetLightElectric(Xpath, Value, Filters);
        }

    }
}