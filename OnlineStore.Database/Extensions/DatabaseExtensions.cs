using Microsoft.Data.SqlClient;
using OnlineStore.Database.Sql;
using OnlineStore.Entities;
using OnlineStore.Entities.Attributes;
using System.Reflection;

namespace OnlineStore.Database.Extensions;

internal static class DatabaseExtensions
{
    internal static async Task AddWithValueAsync<TEntity>(this SqlCommand command, TEntity model)
      where TEntity : IEntity
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model), "Параметр не проинициализирован");

        await Task.Run(() =>
        {
            foreach (PropertyInfo property in model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                MappingAttribute attribute = property.GetCustomAttribute<MappingAttribute>()!;

                (object value, Type sqlType) = SqlHelper.ParseToSqlType(property.GetValue(model)!, attribute.DbType);

                if (value != null && value is not "Undefined" && !value.Equals(sqlType.IsValueType ? Activator.CreateInstance(sqlType) : null))
                    command.Parameters.AddWithValue($"@{attribute.ColumnName}", value);
            }
        });
    }

    internal static async Task<TEntity> MappingAsync<TEntity>(this SqlDataReader sqlDataReader)
        where TEntity : class, IEntity, new()
    {
        TEntity entity = new TEntity();

        await Task.Run(() =>
        {
            Dictionary<string, object> columnNamesAndValues = new Dictionary<string, object>();

            for (int index = 0; index < sqlDataReader.VisibleFieldCount; index++)
                columnNamesAndValues.Add(sqlDataReader.GetName(index), sqlDataReader.GetValue(index));

            foreach (PropertyInfo property in entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                MappingAttribute attribute = property.GetCustomAttribute<MappingAttribute>()!;
                string columnName = attribute.ColumnName;

                if (!columnNamesAndValues.ContainsKey(columnName))
                    continue;

                object? value = SqlHelper.ParseToSLRType(columnNamesAndValues[columnName], property.PropertyType);

                property.SetValue(entity, value);
            }
        });

        return entity;
    }
}