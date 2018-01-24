using System.Collections.Generic;
using System.Web.Script.Serialization;
using GlobalCapture.ListBinder.Client;

namespace GlobalCapture.ListBinder.Repository
{
    public class RestApiContext : IContext
    {
        private readonly string _url;
        private readonly IRestApiClient _restClient;

        public RestApiContext(string url, IRestApiClient restClient)
        {
            _url = url;
            _restClient = restClient;
        }

        public IList<Country> GetCountries()
        {
            var apiResponse = _restClient.Get(_url);
            return MapJsonContentToCountries(apiResponse);
        }

        private static IList<Country> MapJsonContentToCountries(string content)
        {
            var ser = new JavaScriptSerializer();
            return ser.Deserialize<IList<Country>>(content);
        }

    }
}