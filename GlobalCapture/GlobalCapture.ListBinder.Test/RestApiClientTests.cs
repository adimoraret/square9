using System;
using GlobalCapture.ListBinder.Client;
using NUnit.Framework;

namespace GlobalCapture.ListBinder.Test
{
    [TestFixture]
    public class RestApiClientTests
    {
        private IRestApiClient _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new RestApiClient();
        }

        [Test]
        public void ShouldThrowExceptionForInvalidUrl()
        {
            Assert.Throws<AggregateException>(() => _sut.Get("https://invalid-url"));
        }

        [Test]
        public void ShouldGetValidResponse()
        {
            var response = _sut.Get("https://restcountries.eu/rest/v2/all");
            Assert.That(response, Is.Not.Null.And.Not.Empty);
        }
    }
}