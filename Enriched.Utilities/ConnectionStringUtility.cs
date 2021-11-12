namespace Enriched.Utilities
{
    public static class ConnectionStringUtility
    {
        public static string GetFirebird(string database, string userId, string password,
                                            string dataSource = "localhost", int port = 3050, int dialect = 3, string charset = "UTF8",
                                            string role = "", int connectionLifeTime = 15, bool pooling = true, int minSizePool = 0,
                                            int maxSizePool = 50, int packetSize = 8192, byte serverType = 0)
        {
            var pool = pooling ? "true" : "false";
            return $"User={userId};Password={password};Database={database};DataSource={dataSource};Port = {port}; Dialect = {dialect}; Charset = {charset}; Role ={role}; Connection lifetime = {connectionLifeTime}; Pooling = {pool};MinPoolSize = {minSizePool}; MaxPoolSize = {maxSizePool}; Packet Size = {packetSize}; ServerType = {serverType};";
        }

        public static string GetMySql(string server, string database, string userId, string password)
        {
            return $"Server={server};Database={database};Uid={userId};Pwd={password};";
        }

        public static string GetMySql(string server, string port, string database, string userId, string password)
        {
            return $"Server={server};Port={port};Database={database};Uid={userId};Pwd={password};";
        }

        public static string GetOracle(string database)
        {
            return $"Data Source={database};Integrated Security=yes;";
        }

        public static string GetOracle(string database, string userId, string password)
        {
            return $"Data Source={database};User Id={userId};Password={password};Integrated Security = no;";
        }

        public static string GetOracle(string host, string port, string serviceName, string userId, string password)
        {
            return $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={serviceName})));User Id={userId};Password={password};";
        }

        public static string GetPostgreSql(string server, string database, string userId, string password, int port = 5432, int commandTimeout = 20, int timeout = 15)
        {
            return $"Server={server};Port={port};Database={database};User Id={userId};Password = {password};CommandTimeout={commandTimeout};Timeout={timeout}; ";
        }

        public static string GetPostgreSql(string server, string database, int port = 5432)
        {
            return $"Server={server};Port={port};Database={database};Integrated Security=true; ";
        }

        public static string GetSqLite3(string database, bool useUtf16 = true)
        {
            var utf = useUtf16 ? "True" : "False";
            return $"Data Source={database};Version=3;UseUTF16Encoding={utf};";
        }

        public static string GetSqLite3(string database, string password, bool useUtf16 = true)
        {
            var utf = useUtf16 ? "True" : "False";
            return $"Data Source={database};Version=3;Password={password};UseUTF16Encoding={utf};";
        }

        public static string GetSqlServer(string server, string database, string userId, string password)
        {
            return $"Server={server};Database={database};User Id={userId};Password={password};";
        }

        public static string GetSqlServer(string server, string database)
        {
            return $"Server={server};Database={database};Trusted_Connection=True;";
        }

        public static string GetSqlServer(string server, string instance, string database, string userId,
                                            string password)
        {
            return $"Server={server}\\{instance};Database={database};User Id={userId};Password={password};";
        }
    }
}