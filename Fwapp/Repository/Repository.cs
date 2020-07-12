using System;
using System.Data.SqlClient;

namespace WebAPI.Repository
{
    public abstract class Repository
    {
        public T ExecuteCommand<T>(string connStr, Func<SqlConnection, T> task)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                return task(conn);
            }
        }
    }
}
