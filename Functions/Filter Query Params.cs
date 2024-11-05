using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Filters
{
    public class Filter_Query_Params

    {
        private String frequency;
        private String from_date;
        private String to_date;
        private String vehicle_list;
        private String fuel_type;
        private String fleet_id;
        private String vehicle_type;
        private String dashboard;

        public Filter_Query_Params(String frequency, String from_date, String to_date, 
            String vehicle_list, String fuel_type, String fleet_id, String vehicle_type,String dashboard)
        {
            this.frequency = frequency;
            this.from_date = from_date;
            this.to_date = to_date;
            this.vehicle_list = vehicle_list;
            this.fuel_type = fuel_type;
            this.fleet_id = fleet_id;
            this.vehicle_type = vehicle_type;
            this.dashboard = dashboard;
        }

        public string Frequency { get => frequency; set => frequency = value; }
        public string From_date { get => from_date; set => from_date = value; }
        public string To_date { get => to_date; set => to_date = value; }
        public string Vehicle_list { get => vehicle_list; set => vehicle_list = value; }
        public string Fuel_type { get => fuel_type; set => fuel_type = value; }
        public string Fleet_id { get => fleet_id; set => fleet_id = value; }
        public string Vehicle_type { get => vehicle_type; set => vehicle_type = value; }

        public string Dashboard { get => dashboard; set => dashboard = value; }

    }
}
