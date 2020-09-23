using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ArduinoConnect.DataAccess.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public string ConnectionString { get; private set; }

        public SqlDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<T> LoadDataList<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<T>(sql, parameters).ToList();
            }
        }
        public T LoadDataSingle<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.QueryFirstOrDefault<T>(sql, parameters);
            }
        }
        public int SaveData<T>(string sql, T data)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(sql, data);
            }
        }
        public int Execute(string sql, DynamicParameters parameters)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(sql, parameters);
            }
        }
        public int ExecuteStoredProcedure(string name, DynamicParameters parameters)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                return conn.Execute(name, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public T ExecuteStoredProcedureReturnSingle<T>(string name, DynamicParameters parameters)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                return conn.QueryFirstOrDefault<T>(name, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public List<T> ExecuteStoredProcedureReturnList<T>(string name, DynamicParameters parameters)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                return conn.Query<T>(name, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
