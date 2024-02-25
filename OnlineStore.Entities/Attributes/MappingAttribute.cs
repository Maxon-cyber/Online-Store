using System.Data;

namespace OnlineStore.Entities.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
public sealed class MappingAttribute : Attribute
{
    public string ColumnName { get; }
    public SqlDbType DbType { get; }

    public MappingAttribute(string columnName, SqlDbType dbType)
        => (ColumnName, DbType) = (columnName, dbType);
}