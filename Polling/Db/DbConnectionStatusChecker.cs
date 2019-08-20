using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Polling.Db
{
    public class DbConnectionStatusChecker : IDbConnectionStatusChecker
    {
        private readonly IConfiguration _configuration;
        
        public DbConnectionStatusChecker(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public bool IsConnected()
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch (NpgsqlException)
                {
                    return false;
                }
            }
        }
    }
}