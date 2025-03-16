using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace data_04_03_25.Source.LocalDB
{
    public class SqlDataProvider
    {
        public string? ConnectionString { get; set; }

        public SqlDataProvider()
        {
        }

        public SqlDataProvider(string? connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public bool IsConnectionOpen()
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();
            return connection.State == ConnectionState.Open;    
        }

        public void VoidExecute(string query)
        {
            try
            {
                using SqlConnection connection = new(ConnectionString);
                connection.Open();
                using SqlCommand command = new(query, connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public int ScalarExecute(string query)
        {
            try
            {
                using SqlConnection connection = new(ConnectionString);
                connection.Open();
                using SqlCommand command = new(query, connection);
                return (int)command.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public Dictionary<int, List<string?>> ReaderExecute(string? query)
        {
            if (query == null) throw new Exception("Query is null");
            Dictionary<int, List<string?>> result = [];
            try
            {
                using SqlConnection connection = new(ConnectionString);
                connection.Open();
                using SqlCommand command = new(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    List<string?> row = [];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader[i].ToString());
                    }
                    result.Add(result.Count, row);
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
    }
}
