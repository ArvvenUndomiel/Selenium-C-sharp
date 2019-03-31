using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace AutomationCourseMockingHomework.Helpers
{
    public class ApiClient : IDisposable
    {
        private HttpClient httpClient;

        public ApiClient(string baseAddressUri)
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(baseAddressUri);
            this.httpClient.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }

        public TResult GetRequest<TResult>(string url)
            where TResult : class // TResult, трябва да бъде клас, за да можем да върнем null в случай, че рекуеста не върне 200 ОК
        {
            var result = this.httpClient.GetAsync(url).Result;
            var httpResponseBody = result.Content.ReadAsStringAsync().Result;

            if (result.IsSuccessStatusCode)
            {
                var model = JsonConvert.DeserializeObject<TResult>(httpResponseBody);
                return model;
            }
            return null;
        }

        public TResult PostRequest<TResult>(string url, HttpContent requestContent)
            where TResult : class
        {
            var result = this.httpClient.PostAsync(url, requestContent).Result;
            var httpResponseBody = result.Content.ReadAsStringAsync().Result;

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResult>(httpResponseBody);
            }
            return null;
        }

        public void Dispose()
        {
            this.httpClient?.Dispose();
        }
    }
}
