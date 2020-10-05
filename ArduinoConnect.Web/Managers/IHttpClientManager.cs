using System.Net.Http;
using System.Threading.Tasks;

namespace ArduinoConnect.Web.Managers
{
    public interface IHttpClientManager
    {
        Task<HttpResponseMessage> Delete(string route, string query);
        Task<HttpResponseMessage> Get(string route, string query);
        Task<HttpResponseMessage> Post(string route, string query, string data);
        Task<HttpResponseMessage> Put(string route, string query, string data);
    }
}