using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.ResourceAccess
{
    public class BaseRepository
    {
        private static string _connectionString;

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<T> QueryOneAsync<T>(string spName, object parameterModel)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<T>(spName, parameterModel, null, 1, System.Data.CommandType.StoredProcedure);
                return result.FirstOrDefault<T>();
            }
        }

        protected async Task<List<T>> QueryListAsync<T>(string spName, object parameterModel, Func<List<T>, List<T>> additional)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var models = await conn.QueryAsync<T>(spName, parameterModel, null, 1, System.Data.CommandType.StoredProcedure);

                if (additional != null)
                {
                    return (List<T>)additional.DynamicInvoke(models.ToList());
                }
                else
                {
                    return (List<T>)models.ToList();
                }
            }
        }

        protected async Task ExecuteAsync(string spName, object parameterModel)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.ExecuteAsync(spName, parameterModel, null, 1, System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
