using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ArduinoConnect.Web.Managers
{
    public class ApiManager : IApiManager
    {
        private readonly IHttpClientManager _httpClient;

        public ApiManager(IHttpClientManager httpClientManager)
        {
            _httpClient = httpClientManager;
        }

        public async Task<bool> TokenExists(string token)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["token"] = token;

            var response = await _httpClient.Get("exchange/GetNoOfExchange", query.ToString());

            if (response.IsSuccessStatusCode) return true;
            else return false;
        }

        public async Task<ResponseModels.TokenModel> TokenGenerateNew()
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            var response = await _httpClient.Get("Tokens/GenerateNew", query.ToString());

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var output = JsonConvert.DeserializeObject<ResponseModels.TokenModel>(data);
                return output;
            }
            else
            {
                return null;
            }
        }
    }
}
