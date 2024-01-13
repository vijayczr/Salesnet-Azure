using Microsoft.Data.SqlClient;
using System.Data;


namespace SalesNet.DapperContext
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            //_connectionString = "Server=localhost;Database=TechlabSalesNetProd;uid=SA;pwd=vijay@130;TrustServerCertificate=True;MultipleActiveResultSets=True";
            _connectionString = _configuration.GetConnectionString("DefaultSQLConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
