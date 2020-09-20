using ArduinoConnect.DataAccess.DataAccess;
using ArduinoConnect.DataAccess.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoConnect.DataAccess.BusinessLogic
{
    public class TokenProcessor
    {
        private readonly ISqlDataAccess _dataAccess;

        public TokenProcessor(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public TokenModel GenerateNewToken()
        {
            string name = "CreateUniqueToken";

            var output = _dataAccess.ExecuteStoredProcedureReturnSingle<TokenModel>(name,null);
            return output;
        }

        public bool DeleteToken(TokenModel token) => DeleteToken(token.Token);
        public bool DeleteToken(string token)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);

            var output = _dataAccess.ExecuteStoredProcedure("DeleteToken", parameters);
            return (output > 0) ? true : false;
        }
    }
}
