using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemsoft_DB
{
    public sealed class Context
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Connect()
        {
            await Disconnect();
            _connection = new SqlConnection(_connectionString);

            try
            {
                await _connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task Disconnect()
        {
            if (_connection == null) return;

            try
            {
                await _connection.CloseAsync();
                _connection.Dispose();
                _connection = null;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<SqlDataReader> GetReaderAsync(string expression)
        {
            SqlCommand command = new(expression, _connection);
            return await command.ExecuteReaderAsync();
        }

        public async Task<SqlCommand> GetCommandAsync(string expression)
        {
            SqlCommand command = new(expression, _connection);
            await command.ExecuteNonQueryAsync();
            return command;
        }

        public SqlDataAdapter GetAdapter(string expression)
        {
            return new SqlDataAdapter(expression, _connection);
        }
    }
}
