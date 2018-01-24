using System.Linq;
using GlobalCapture.ListBinder.Client;
using GlobalCapture.ListBinder.Repository;
using NUnit.Framework;

namespace GlobalCapture.ListBinder.Test
{
    [TestFixture]
    public class CountryRepositoryTests
    {
        private ICountryRepository _sut;

        [Test]
        public void ShouldGetFrance()
        {
            _sut = new CountryRepository(new RestApiContext("", new ApiClientOnlyWithFrance()));
            var countries = _sut.GetAllCountries();
            Assert.That(countries.Count, Is.EqualTo(1));
            Assert.That(countries.First(), Is.EqualTo("France"));
        }
    }

    class ApiClientOnlyWithFrance : IRestApiClient
    {
        public string Get(string url)
        {
            return "[{\"name\":\"France\",\"alpha2Code\":\"FR\",\"alpha2Code\":\"FRA\"}]";
        }
    }
}
