using System;
using System.Collections.Generic;
using GlobalCapture.ListBinder.Client;
using GlobalCapture.ListBinder.Repository;

namespace GlobalCapture.ListBinder
{
    public class CountriesListBinder
    {
        private readonly string _countriesLogFile;
        private readonly string _countriesUrl;

        public CountriesListBinder()
        {
            var configManager = new ConfigManager();
            _countriesLogFile = configManager.GetAppSetting("LogFile");
            _countriesUrl = configManager.GetAppSetting("CountriesEndpoint");
        }

        public List<string> ListFieldData(string input)
        {
            Log.AppendLine("GlobalCapture retrieving countries started.");
            var countries = new List<string>();
            try
            {
                var countryRepository = GetCountriesRepository();
                countries = countryRepository.GetAllCountries();
            }
            catch (Exception ex)
            {
                Log.AppendError(ex);
            }
            Log.AppendLine("GlobalCapture retrieving sellers list finished.");
            Log.SaveToFile(_countriesLogFile);
            return countries;
        }

        private ICountryRepository GetCountriesRepository()
        {
            var restApiContext = new RestApiContext(_countriesUrl, new RestApiClient());
            return new CountryRepository(restApiContext);
        }

    }
}
