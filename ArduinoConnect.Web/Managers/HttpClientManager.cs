using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoConnect.Web.Managers
{
    public class HttpClientManager : IHttpClientManager
    {
        private readonly string _apiUrl;
        public HttpClientManager(IConfiguration configuration)
        {
            _apiUrl = configuration.GetValue<string>("ApiUrl");
        }

        public async Task<HttpResponseMessage> Get(string route, string query)
        {
            var builder = new UriBuilder(_apiUrl);
            builder.Path += route;
            builder.Query = query;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl + route);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(builder.ToString());

                return response;
            }
        }

        public async Task<HttpResponseMessage> Post(string route, string query, string data)
        {
            var builder = new UriBuilder(_apiUrl);
            builder.Path += route;
            builder.Query = query;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl + route);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsync(builder.ToString(), new StringContent(data, Encoding.UTF8, "application/json"));

                return response;
            }
        }

        public async Task<HttpResponseMessage> Put(string route, string query, string data)
        {
            var builder = new UriBuilder(_apiUrl);
            builder.Path += route;
            builder.Query = query;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl + route);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsync(builder.ToString(), new StringContent(data, Encoding.UTF8, "application/json"));

                return response;
            }
        }

        public async Task<HttpResponseMessage> Delete(string route, string query)
        {
            var builder = new UriBuilder(_apiUrl);
            builder.Path += route;
            builder.Query = query;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl + route);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(builder.ToString());

                return response;
            }
        }
    }
}
