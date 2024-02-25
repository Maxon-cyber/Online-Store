using OnlineStore.Entities.User;
using System.Data;

namespace OnlineStore.Database.Sql;

internal static class SqlHelper
{
    internal static (object ConvertedValue, Type SqlType) ParseToSqlType(object value, SqlDbType sqlDbType)
    {
        Type type = sqlDbType switch
        {
            SqlDbType.NChar => typeof(string),
            SqlDbType.Int => typeof(int),
            SqlDbType.Money => typeof(decimal),
            SqlDbType.BigInt => typeof(long),
            SqlDbType.VarBinary => typeof(byte[]),
            SqlDbType.Xml => typeof(Dictionary<uint, object>),
            SqlDbType.SmallDateTime => typeof(DateTime),
            _ => throw new ArgumentException("Неизвестный sql-тип", nameof(sqlDbType))
        };

        object convertedValue = Convert.ChangeType(value, type);

        return (convertedValue, type);
    }

    internal static object? ParseToSLRType(object value, Type type)
    {
        if (type == typeof(Role))
            return Enum.Parse(typeof(Role), value.ToString()!);

        return Convert.ChangeType(value, type);
    }
}