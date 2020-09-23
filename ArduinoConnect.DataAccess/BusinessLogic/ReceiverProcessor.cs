using ArduinoConnect.DataAccess.Converters;
using ArduinoConnect.DataAccess.DataAccess;
using ArduinoConnect.DataAccess.Models;
using Dapper;
using System.Collections.Generic;

namespace ArduinoConnect.DataAccess.BusinessLogic
{
    public class ReceiverProcessor
    {
        private readonly ISqlDataAccess _dataAccess;

        public ReceiverProcessor(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<ReceiverModel> GetReceivers(int? receiverId = null, string description = null)
        {
            string name = "GetReceivers";

            description = StringConverter.MakeWhitespaceNull(description);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("receiverId", receiverId, System.Data.DbType.Int32);
            parameters.Add("description", description, System.Data.DbType.String);

            var output = _dataAccess.ExecuteStoredProcedureReturnList<ReceiverModel>(name, parameters);
            return output;
        }
    }
}
