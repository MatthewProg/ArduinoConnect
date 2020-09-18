using Dapper;
using System.Collections.Generic;

namespace ArduinoConnect.DataAccess.DataAccess
{
    public interface ISqlDataAccess
    {
        string ConnectionString { get; }

        int Execute(string sql, DynamicParameters parameters);
        int ExecuteStoredProcedure(string name, DynamicParameters parameters);
        List<T> ExecuteStoredProcedureReturnList<T>(string name, DynamicParameters parameters);
        T ExecuteStoredProcedureReturnSingle<T>(string name, DynamicParameters parameters);
        List<T> LoadDataList<T>(string sql, DynamicParameters parameters);
        T LoadDataSingle<T>(string sql, DynamicParameters parameters);
        int SaveData<T>(string sql, T data);
    }
}