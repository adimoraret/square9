using GlobalCapture.ListBinder.Client;
using GlobalCapture.ListBinder.Repository;
using NUnit.Framework;

namespace GlobalCapture.ListBinder.Test
{
    public class CountryRepositoryIntegrationTests
    {
        private ICountryRepository _sut;

        [Test]
        public void ShouldGetAllCountries()
        {
            _sut = new CountryRepository(new RestApiContext("https://restcountries.eu/rest/v2/all", new RestApiClient()));
            var countries = _sut.GetAllCountries();
            CollectionAssert.IsNotEmpty(countries);
        }
    }
}