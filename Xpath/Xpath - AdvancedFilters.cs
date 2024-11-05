using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__AdvancedFilters
    {

        public String CompanyField = "//*[@id='companyAutocomplete']/input";
        public String ApplyAdvancedFiltersButton="//a[contains(text(), 'Apply advanced filters')]";
        public String Country = "//pfe-radio[1]//pfe-select";
        public String SelectAllButton = "//*[@id='dropdownContracts']//pfe-cta/a[contains(text(), 'Select all')]";
        public String DeselectAllButton = "//*[@id='dropdownContracts']//pfe-cta/a[contains(text(), 'Deselect all')]";
        //public String CountryItaly = "//pfe-radio[1]//option[contains (text(),'Italy')]";
    }
}
