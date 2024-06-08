using System.Data.SqlClient;
using System.Configuration;

namespace DA
{
    public class Connection
    {
        private readonly string _dockerConnection;

        public Connection()
        {
            var appSettings = new Appsettings();
            _dockerConnection = appSettings.GetConnectionString("DockerConnection");
        }

        public static SqlConnection OriginConnection()
        {
            Connection connection = new Connection();
            return new SqlConnection(connection._dockerConnection);
        }
    }
}
