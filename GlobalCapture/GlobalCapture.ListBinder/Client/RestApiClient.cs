using System.Net.Http;

namespace GlobalCapture.ListBinder.Client
{
    public class RestApiClient : IRestApiClient
    {
        public string Get(string url)
        {
            var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
            return client.GetStringAsync(url).Result;
        }
    }
}