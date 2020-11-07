using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArduinoConnect.Web.Managers
{
    public interface IApiManager
    {
        Task<bool> DataTableDelete(string token, int tableId, int? id = null);
        Task<List<ResponseModels.DataTableModel>> DataTableGet(string token, int? tableId = null);
        Task<List<ResponseModels.DataTableModel>> DataTableOffsetGet(string token, int? tableId = null, int offset = 0, int fetch = 25);
        Task<List<ResponseModels.ExchangeTableModel>> ExchangeTableAll(string token, int? receiverId = null, string receiverDevice = null);
        Task<bool> ExchangeTableDelete(string token, int? receiverId = null, string receiverDevice = null);
        Task<bool> ExchangeTableNew(string token, RequestModels.ExchangeTableModel model);
        Task<ResponseModels.ExchangeTableModel> ExchangeTableNewest(string token, int? receiverId = null, string receiverDevice = null);
        Task<int> ExchangeTableNoOf(string token, int? receiverId = null, string receiverDevice = null);
        Task<ResponseModels.ExchangeTableModel> ExchangeTableOldest(string token, int? receiverId = null, string receiverDevice = null);
        Task<bool> TokenExists(string token);
        Task<ResponseModels.TokenModel> TokenGenerateNew();
        Task<bool> UserTableDelete(string token, int tableId);
        Task<List<ResponseModels.UserTableModel>> UserTableGet(string token, int? tableId = null);
    }
}