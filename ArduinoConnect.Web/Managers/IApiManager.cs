using ArduinoConnect.Web.ResponseModels;
using System.Threading.Tasks;

namespace ArduinoConnect.Web.Managers
{
    public interface IApiManager
    {
        Task<bool> TokenExists(string token);
        Task<TokenModel> TokenGenerateNew();
    }
}