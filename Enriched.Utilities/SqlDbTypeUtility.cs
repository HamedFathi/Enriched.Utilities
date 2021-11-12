using System;
using System.Collections.Generic;

namespace Enriched.Utilities
{
    public static class SqlDbTypeUtility
    {
        private static Dictionary<string, Type> _mappings;

        public static string FromString(string sqlDataType)
        {
            sqlDataType = sqlDataType.ToLower().Trim();
            _mappings = new Dictionary<string, Type>
            {
                {"bigint", typeof(long)},
                {"binary", typeof(byte[])},
                {"bit", typeof(bool)},
                {"char", typeof(string)},
                {"date", typeof(DateTime)},
                {"datetime", typeof(DateTime)},
                {"datetime2", typeof(DateTime)},
                {"datetimeoffset", typeof(DateTimeOffset)},
                {"decimal", typeof(decimal)},
                {"float", typeof(double)},
                {"image", typeof(byte[])},
                {"int", typeof(int)},
                {"money", typeof(decimal)},
                {"nchar", typeof(string)},
                {"ntext", typeof(string)},
                {"numeric", typeof(decimal)},
                {"nvarchar", typeof(string)},
                {"real", typeof(float)},
                {"rowversion", typeof(byte[])},
                {"smalldatetime", typeof(DateTime)},
                {"smallint", typeof(short)},
                {"smallmoney", typeof(decimal)},
                {"text", typeof(string)},
                {"time", typeof(TimeSpan)},
                {"timestamp", typeof(byte[])},
                {"tinyint", typeof(byte)},
                {"uniqueidentifier", typeof(Guid)},
                {"varbinary", typeof(byte[])},
                {"varchar", typeof(string)}
            };
            return _mappings[sqlDataType].Name;
        }

        public static Type ToType(string sqlDataType)
        {
            sqlDataType = sqlDataType.ToLower().Trim();
            _mappings = new Dictionary<string, Type>
            {
                {"bigint", typeof(long)},
                {"binary", typeof(byte[])},
                {"bit", typeof(bool)},
                {"char", typeof(string)},
                {"date", typeof(DateTime)},
                {"datetime", typeof(DateTime)},
                {"datetime2", typeof(DateTime)},
                {"datetimeoffset", typeof(DateTimeOffset)},
                {"decimal", typeof(decimal)},
                {"float", typeof(double)},
                {"image", typeof(byte[])},
                {"int", typeof(int)},
                {"money", typeof(decimal)},
                {"nchar", typeof(string)},
                {"ntext", typeof(string)},
                {"numeric", typeof(decimal)},
                {"nvarchar", typeof(string)},
                {"real", typeof(float)},
                {"rowversion", typeof(byte[])},
                {"smalldatetime", typeof(DateTime)},
                {"smallint", typeof(short)},
                {"smallmoney", typeof(decimal)},
                {"text", typeof(string)},
                {"time", typeof(TimeSpan)},
                {"timestamp", typeof(byte[])},
                {"tinyint", typeof(byte)},
                {"uniqueidentifier", typeof(Guid)},
                {"varbinary", typeof(byte[])},
                {"varchar", typeof(string)}
            };
            return _mappings[sqlDataType];
        }
    }
}