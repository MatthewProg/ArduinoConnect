using ArduinoConnect.DataAccess.Converters;
using ArduinoConnect.DataAccess.DataAccess;
using ArduinoConnect.DataAccess.Models;
using Dapper;
using System.Collections.Generic;

namespace ArduinoConnect.DataAccess.BusinessLogic
{
    public class ExchangeTablesProcessor
    {
        private readonly ISqlDataAccess _dataAccess;

        public ExchangeTablesProcessor(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public int ClearExchange(string token, string receiverDevice = null, int? receiverID = null)
        {
            string name = "ClearExchange";

            token = StringConverter.MakeWhitespaceNull(token);
            receiverDevice = StringConverter.MakeWhitespaceNull(receiverDevice);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("receiverDevice", receiverDevice, System.Data.DbType.String);
            parameters.Add("receiverID", receiverID, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedure(name, parameters);
            return output;
        }
        public ExchangeTableModel CreateExchange(string token, string command, int receiverID, string receiverDevice = null)
        {
            string name = "CreateExchange";

            token = StringConverter.MakeWhitespaceNull(token);
            command = StringConverter.MakeWhitespaceNull(command);
            receiverDevice = StringConverter.MakeWhitespaceNull(receiverDevice);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("receiverID", receiverID, System.Data.DbType.Int32);
            parameters.Add("command", command, System.Data.DbType.String);
            parameters.Add("receiverDevice", receiverDevice, System.Data.DbType.String);

            var output = _dataAccess.ExecuteStoredProcedureReturnSingle<ExchangeTableModel>(name, parameters);
            return output;
        }
        public List<ExchangeTableModel> GetAllExchange(string token, string receiverDevice = null, int? receiverID = null)
        {
            string name = "GetAllExchange";

            token = StringConverter.MakeWhitespaceNull(token);
            receiverDevice = StringConverter.MakeWhitespaceNull(receiverDevice);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("receiverDevice", receiverDevice, System.Data.DbType.String);
            parameters.Add("receiverID", receiverID, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedureReturnList<ExchangeTableModel>(name, parameters);
            return output;
        }
        public ExchangeTableModel GetNewestExchange(string token, string receiverDevice = null, int? receiverID = null)
        {
            string name = "GetNewestExchange";

            token = StringConverter.MakeWhitespaceNull(token);
            receiverDevice = StringConverter.MakeWhitespaceNull(receiverDevice);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("receiverDevice", receiverDevice, System.Data.DbType.String);
            parameters.Add("receiverID", receiverID, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedureReturnSingle<ExchangeTableModel>(name, parameters);
            return output;
        }
        public ExchangeTableModel GetOldestExchange(string token, string receiverDevice = null, int? receiverID = null)
        {
            string name = "GetOldestExchange";

            token = StringConverter.MakeWhitespaceNull(token);
            receiverDevice = StringConverter.MakeWhitespaceNull(receiverDevice);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("receiverDevice", receiverDevice, System.Data.DbType.String);
            parameters.Add("receiverID", receiverID, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedureReturnSingle<ExchangeTableModel>(name, parameters);
            return output;
        }
        public int GetNoOfExchange(string token, string receiverDevice = null, int? receiverID = null)
        {
            string name = "GetNoOfExchange";

            token = StringConverter.MakeWhitespaceNull(token);
            receiverDevice = StringConverter.MakeWhitespaceNull(receiverDevice);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("receiverDevice", receiverDevice, System.Data.DbType.String);
            parameters.Add("receiverID", receiverID, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedureReturnSingle<int>(name, parameters);
            return output;
        }

        #region Overloaded methods

        //ClearExchange
        public int ClearExchange(TokenModel token, ExchangeTableModel model)
            => ClearExchange(token.Token, model.ReceiverDevice, model.ReceiverID);
        public int ClearExchange(string token, ExchangeTableModel model)
            => ClearExchange(token, model.ReceiverDevice, model.ReceiverID);
        public int ClearExchange(TokenModel token, string receiverDevice = null, int? receiverID = null)
            => ClearExchange(token.Token, receiverDevice, receiverID);


        //CreateExchange
        public ExchangeTableModel CreateExchange(string token, ExchangeTableModel model)
            => CreateExchange(token, model.Command, model.ReceiverID, model.ReceiverDevice);
        public ExchangeTableModel CreateExchange(TokenModel token, ExchangeTableModel model)
            => CreateExchange(token.Token, model.Command, model.ReceiverID, model.ReceiverDevice);
        public ExchangeTableModel CreateExchange(TokenModel token, string command, int receiverID, string receiverDevice = null)
            => CreateExchange(token.Token, command, receiverID, receiverDevice);


        //GetAllExchange
        public List<ExchangeTableModel> GetAllExchange(TokenModel token, ExchangeTableModel model)
            => GetAllExchange(token.Token, model.ReceiverDevice, model.ReceiverID);
        public List<ExchangeTableModel> GetAllExchange(string token, ExchangeTableModel model)
            => GetAllExchange(token, model.ReceiverDevice, model.ReceiverID);
        public List<ExchangeTableModel> GetAllExchange(TokenModel token, string receiverDevice = null, int? receiverID = null)
            => GetAllExchange(token.Token, receiverDevice, receiverID);


        //GetNewestExchange
        public ExchangeTableModel GetNewestExchange(TokenModel token, ExchangeTableModel model)
            => GetNewestExchange(token.Token, model.ReceiverDevice, model.ReceiverID);
        public ExchangeTableModel GetNewestExchange(string token, ExchangeTableModel model)
            => GetNewestExchange(token, model.ReceiverDevice, model.ReceiverID);
        public ExchangeTableModel GetNewestExchange(TokenModel token, string receiverDevice = null, int? receiverID = null)
            => GetNewestExchange(token.Token, receiverDevice, receiverID);


        //GetOldestExchange
        public ExchangeTableModel GetOldestExchange(TokenModel token, ExchangeTableModel model)
            => GetOldestExchange(token.Token, model.ReceiverDevice, model.ReceiverID);
        public ExchangeTableModel GetOldestExchange(string token, ExchangeTableModel model)
            => GetOldestExchange(token, model.ReceiverDevice, model.ReceiverID);
        public ExchangeTableModel GetOldestExchange(TokenModel token, string receiverDevice = null, int? receiverID = null)
            => GetOldestExchange(token.Token, receiverDevice, receiverID);


        //GetNoOfExchange
        public int GetNoOfExchange(TokenModel token, ExchangeTableModel model)
            => GetNoOfExchange(token.Token, model.ReceiverDevice, model.ReceiverID);
        public int GetNoOfExchange(string token, ExchangeTableModel model)
            => GetNoOfExchange(token, model.ReceiverDevice, model.ReceiverID);
        public int GetNoOfExchange(TokenModel token, string receiverDevice = null, int? receiverID = null)
            => GetNoOfExchange(token.Token, receiverDevice, receiverID);
        #endregion
    }
}
