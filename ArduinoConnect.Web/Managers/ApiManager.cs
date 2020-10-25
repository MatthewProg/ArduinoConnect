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

        public async Task<List<ResponseModels.UserTableModel>> UserTableGet(string token, int? tableId = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["token"] = token;
            if (tableId != null) query["tableId"] = tableId.ToString();

            var response = await _httpClient.Get("tables/GetTable", query.ToString());

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (tableId == null)
                {
                    var output = JsonConvert.DeserializeObject<List<ResponseModels.UserTableModel>>(data);
                    return output;
                }
                else
                {
                    var single = JsonConvert.DeserializeObject<ResponseModels.UserTableModel>(data);
                    var output = new List<ResponseModels.UserTableModel>() { single };
                    return output;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> UserTableDelete(string token, int tableId)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["token"] = token;
            query["tableId"] = tableId.ToString();

            var response = await _httpClient.Delete("tables/Delete", query.ToString());

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<List<ResponseModels.DataTableModel>> DataTableGet(string token, int? tableId = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["token"] = token;
            if (tableId != null) query["tableId"] = tableId.ToString();

            var response = await _httpClient.Get("data/GetTables", query.ToString());

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var output = JsonConvert.DeserializeObject<List<ResponseModels.DataTableModel>>(data);
                return output;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> DataTableDelete(string token, int tableId, int? id = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["token"] = token;
            query["tableId"] = tableId.ToString();
            if (id != null) query["id"] = id.ToString();

            var response = await _httpClient.Delete("data/Delete", query.ToString());

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<int> ExchangeTableNoOf(string token, int? receiverId = null, string receiverDevice = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["token"] = token;
            if (receiverId != null) query["receiverId"] = receiverId.ToString();
            if (string.IsNullOrWhiteSpace(receiverDevice)) query["receiverDevice"] = receiverDevice;

            var response = await _httpClient.Get("exchange/GetNoOfExchange", query.ToString());

            var output = await response.Content.ReadAsStringAsync();
            return int.Parse(output);
        }
    }
}
