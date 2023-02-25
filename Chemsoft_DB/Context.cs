using System.Data.SqlClient;

namespace Chemsoft_DB
{
    public sealed class Context : IDisposable
    {
        private bool _disposing;
        private readonly string _connectionString;
        private SqlConnection? _connection;

        public Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ExecuteReaderAsync(string expression, Action<SqlDataReader>? action = null)
        {
            await Connect();
            SqlCommand command = new(expression, _connection);
            var reader = await command.ExecuteReaderAsync();
            action?.Invoke(reader);
            await Disconnect();
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

        public async Task<int> ExecuteNonQueryAsync(string expression, Action<SqlCommand>? action = null)
        {
            await Connect();
            SqlCommand command = new(expression, _connection);
            var result = await command.ExecuteNonQueryAsync();
            action?.Invoke(command);
            await Disconnect();
            return result;
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

        public async void Dispose()
        {
            if (_disposing) return;

            _disposing = true;

            await Disconnect();

            _disposing = false;
        }
    }
}
