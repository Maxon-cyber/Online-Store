using Microsoft.Data.SqlClient;
using OnlineStore.Database.Extensions;
using OnlineStore.Entities;
using System.Data;

namespace OnlineStore.Database.Internal;

internal sealed class ResultOfSqlCommand : IDisposable, IAsyncDisposable
{
    private readonly SqlCommand _command = default!;

    internal ResultOfSqlCommand(SqlCommand sqlCommand)
    {
        _command = (sqlCommand.Connection, sqlCommand.CommandText) is (null, null) ?
                        throw new ArgumentNullException(nameof(sqlCommand), "Параметр подключения или sql-запрос не проинициализирован полностью")
                        : sqlCommand;

        _command.CommandType = CommandType.StoredProcedure;
    }

    internal async Task<TEntity?> GetEntityAsync<TEntity>()
         where TEntity : class, IEntity, new()
    {
        await using SqlDataReader reader = await _command.ExecuteReaderAsync();

        if (!reader.HasRows)
            return null;

        TEntity? result = null;

        while (await reader.ReadAsync())
            result = await reader.MappingAsync<TEntity>();

        return result;
    }

    internal async Task<TEntity?> GetEntityAsync<TEntity>(TEntity entity)
        where TEntity : class, IEntity, new()
    {
        await _command.AddWithValueAsync(entity);

        await using SqlDataReader reader = await _command.ExecuteReaderAsync();

        if (!reader.HasRows)
            return null;

        TEntity? result = null;

        while (await reader.ReadAsync())
            result = await reader.MappingAsync<TEntity>();

        return result;
    }

    internal async Task<Queue<TEntity>> GetEntitiesAsync<TEntity>()
        where TEntity : class, IEntity, new()
    {
        await using SqlDataReader reader = await _command.ExecuteReaderAsync();

        Queue<TEntity> result = new Queue<TEntity>();

        if (!reader.HasRows)
            return result;

        while (await reader.ReadAsync())
            result.Enqueue(await reader.MappingAsync<TEntity>());

        return result;
    }

    internal async Task<bool> UpdateEntityAsync<TEntity>(TEntity entity)
        where TEntity : class, IEntity, new()
    {
        await _command.AddWithValueAsync(entity);

        int result = await _command.ExecuteNonQueryAsync();

        return result == 1;
    }

    public async ValueTask DisposeAsync()
    {
        await _command.DisposeAsync();
        GC.Collect();
        GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        _command.Dispose();
        GC.Collect();
        GC.SuppressFinalize(this);
    }
}