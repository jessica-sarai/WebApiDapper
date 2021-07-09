using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Da.Interfaces;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Da.Services
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly IConfiguration _config;
        public AsyncRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("bdConnection"));
            }
        }

        public async Task Delete(T entity)
        {
            using IDbConnection conn = Connection;
            await conn.DeleteAsync(entity);
            //throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            using IDbConnection conn = Connection;
            return await conn.GetAsync<T>(id);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetList()
        {
            using IDbConnection conn = Connection;
            return await conn.GetListAsync<T>();
            //throw new NotImplementedException();
        }

        public async Task<int?> Insert(T entity)
        {
            using IDbConnection conn = Connection;
            return await conn.InsertAsync(entity);
            // throw new NotImplementedException();
        }

        public async Task Update(T entity)
        {
            using IDbConnection conn = Connection;
            await conn.UpdateAsync(entity);
            // throw new NotImplementedException();
        }
    }
}
