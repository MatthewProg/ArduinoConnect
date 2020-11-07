using ArduinoConnect.DataAccess.Converters;
using ArduinoConnect.DataAccess.DataAccess;
using ArduinoConnect.DataAccess.Models;
using Dapper;
using System.Collections.Generic;

namespace ArduinoConnect.DataAccess.BusinessLogic
{
    public class DataTablesProcessor
    {
        private readonly ISqlDataAccess _dataAccess;

        public DataTablesProcessor(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public DataTableModel CreateDataTable(string token, int tableId, string data)
        {
            string name = "CreateDataTables";

            token = StringConverter.MakeWhitespaceNull(token);
            data = StringConverter.MakeWhitespaceNull(data);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("tableId", tableId, System.Data.DbType.Int32);
            parameters.Add("data", data, System.Data.DbType.String);

            var output = _dataAccess.ExecuteStoredProcedureReturnSingle<DataTableModel>(name, parameters);
            return output;
        }
        public List<DataTableModel> GetDataTables(string token, int? tableId = null)
        {
            string name = "GetDataTables";

            token = StringConverter.MakeWhitespaceNull(token);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("tableId", tableId, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedureReturnList<DataTableModel>(name, parameters);
            return output;
        }
        public List<DataTableModel> GetDataTablesOffset(string token, int? tableId = null, int offset = 0, int fetch = 25)
        {
            string name = "GetDataTablesOffset";

            token = StringConverter.MakeWhitespaceNull(token);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("tableId", tableId, System.Data.DbType.Int32);
            parameters.Add("offset", offset, System.Data.DbType.Int32);
            parameters.Add("fetch", fetch, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedureReturnList<DataTableModel>(name, parameters);
            return output;
        }
        public int DeleteDataTables(string token, int tableId, int? id = null)
        {
            string name = "DeleteDataTables";

            token = StringConverter.MakeWhitespaceNull(token);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("token", token, System.Data.DbType.String);
            parameters.Add("tableId", tableId, System.Data.DbType.Int32);
            parameters.Add("id", id, System.Data.DbType.Int32);

            var output = _dataAccess.ExecuteStoredProcedure(name, parameters);
            return output;
        }

        #region Overloaded methods

        //CreateDataTable
        public DataTableModel CreateDataTable(TokenModel token, int tableId, string data)
            => CreateDataTable(token.Token, tableId, data);
        public DataTableModel CreateDataTable(string token, DataTableModel model)
            => CreateDataTable(token, model.TableID, model.Data);
        public DataTableModel CreateDataTable(TokenModel token, DataTableModel model)
            => CreateDataTable(token.Token, model.TableID, model.Data);


        //GetDataTables
        public List<DataTableModel> GetDataTables(TokenModel token, int? tableId = null)
            => GetDataTables(token.Token, tableId);


        //GetDataTablesOffset
        public List<DataTableModel> GetDataTablesOffset(TokenModel token, int? tableId = null, int offset = 0, int fetch = 25)
            => GetDataTablesOffset(token.Token, tableId, offset, fetch);


        //DeleteDataTables
        public int DeleteDataTables(TokenModel token, int tableId, int? id = null)
            => DeleteDataTables(token.Token, tableId, id);
        public int DeleteDataTables(TokenModel token, DataTableModel model)
            => DeleteDataTables(token.Token, model.TableID, model.ID);

        #endregion
    }
}
