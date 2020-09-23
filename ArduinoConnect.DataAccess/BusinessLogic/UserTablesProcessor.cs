using ArduinoConnect.DataAccess.Converters;
using ArduinoConnect.DataAccess.DataAccess;
using ArduinoConnect.DataAccess.Models;
using Dapper;
using System.Collections.Generic;

namespace ArduinoConnect.DataAccess.BusinessLogic
{
    public class UserTablesProcessor
    {
        private readonly ISqlDataAccess _dataAccess;

        public UserTablesProcessor(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<UserTableModel> GetTables(string token)
        {
            string name = "TokenUserTables";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);

            var output = _dataAccess.ExecuteStoredProcedureReturnList<UserTableModel>(name, parameters);
            return output;
        }
        public UserTableModel GetTable(int tableId, string token)
        {
            string name = "TokenUserTables";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("tableId", tableId, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedureReturnSingle<UserTableModel>(name, parameters);
            return output;
        }
        public UserTableModel CreateTable(string tableName, string tableDescription, string tableSchema, string token)
        {
            tableName = StringConverter.MakeWhitespaceNull(tableName);
            tableDescription = StringConverter.MakeWhitespaceNull(tableDescription);
            tableSchema = StringConverter.MakeWhitespaceNull(tableSchema);
            token = StringConverter.MakeWhitespaceNull(token);

            string name = "CreateUserTables";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("tableName", tableName, System.Data.DbType.String);
            parameters.Add("tableDescription", tableDescription, System.Data.DbType.String);
            parameters.Add("tableSchema", tableSchema, System.Data.DbType.String);
            parameters.Add("token", token, System.Data.DbType.String);

            var output = _dataAccess.ExecuteStoredProcedureReturnSingle<UserTableModel>(name, parameters);
            return output;
        }
        public UserTableModel UpdateTable(string tableName, string tableDescription, string tableSchema, int tableId, string token)
        {
            tableName = StringConverter.MakeWhitespaceNull(tableName);
            tableDescription = StringConverter.MakeWhitespaceNull(tableDescription);
            tableSchema = StringConverter.MakeWhitespaceNull(tableSchema);
            token = StringConverter.MakeWhitespaceNull(token);

            string name = "ChangeUserTables";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("tableName", tableName, System.Data.DbType.String);
            parameters.Add("tableDescription", tableDescription, System.Data.DbType.String);
            parameters.Add("tableSchema", tableSchema, System.Data.DbType.String);
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("tableId", tableId, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedureReturnSingle<UserTableModel>(name, parameters);
            return output;
        }
        public bool DeleteTable(int tableId, string token)
        {
            string name = "DeleteUserTables";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("tableId", tableId, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedure(name, parameters);
            return (output > 0) ? true : false;
        }

        #region Overloaded methods

        //GetTables
        public List<UserTableModel> GetTables(TokenModel token) => GetTables(token.Token);


        //GetTable
        public UserTableModel GetTable(int tableId, TokenModel token) => GetTable(tableId, token.Token);


        //CreateTable
        public UserTableModel CreateTable(UserTableModel data, TokenModel token)
            => CreateTable(data.TableName, data.TableDescription, data.TableSchema, token.Token);
        public UserTableModel CreateTable(string tableName, string tableDescription, string tableSchema, TokenModel token)
            => CreateTable(tableName, tableDescription, tableSchema, token.Token);
        public UserTableModel CreateTable(UserTableModel data, string token)
            => CreateTable(data.TableName, data.TableDescription, data.TableSchema, token);


        //UpdateTable
        public UserTableModel UpdateTable(string tableName, string tableDescription, string tableSchema, int tableId, TokenModel token)
            => UpdateTable(tableName, tableDescription, tableSchema, tableId, token.Token);
        public UserTableModel UpdateTable(UserTableModel data, int tableId, TokenModel token)
            => UpdateTable(data.TableName, data.TableDescription, data.TableSchema, tableId, token.Token);
        public UserTableModel UpdateTable(UserTableModel data, int tableId, string token)
            => UpdateTable(data.TableName, data.TableDescription, data.TableSchema, tableId, token);


        //DeleteTable
        public bool DeleteTable(UserTableModel table, string token)
            => DeleteTable(table.TableID, token);
        public bool DeleteTable(UserTableModel table, TokenModel token)
            => DeleteTable(table.TableID, token.Token);
        public bool DeleteTable(int tableId, TokenModel token)
            => DeleteTable(tableId, token.Token);


        #endregion
    }
}
