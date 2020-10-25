using ArduinoConnect.Web.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArduinoConnect.Web.Managers
{
    public interface IApiManager
    {
        Task<bool> DataTableDelete(string token, int tableId, int? id = null);
        Task<List<DataTableModel>> DataTableGet(string token, int? tableId = null);
        Task<int> ExchangeTableNoOf(string token, int? receiverId = null, string receiverDevice = null);
        Task<bool> TokenExists(string token);
        Task<TokenModel> TokenGenerateNew();
        Task<bool> UserTableDelete(string token, int tableId);
        Task<List<UserTableModel>> UserTableGet(string token, int? tableId = null);
    }
}