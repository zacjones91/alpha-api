using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Alpha.IntegrationTest.Framework
{
    public class SqlExecutor
    {
        //private readonly IConfiguration config;

        //public SqlExecutor(IConfiguration config)
        //{
        //    this.config = config;
        //}

        public int Execute(string sql)
        {
            using (SqlConnection conn = new SqlConnection("ConnectionString"))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected;
            }
        }

        public object ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection("ConnectionString"))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                object id = command.ExecuteScalar();

                return id;
            }
        }
    }
}
