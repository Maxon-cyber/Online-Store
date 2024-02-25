using Microsoft.Data.SqlClient;
using OnlineStore.ApplicationSettings;
using OnlineStore.Database.Internal;
using OnlineStore.Entities;

namespace OnlineStore.Database;

public sealed class DatabaseMapper : IDisposable, IAsyncDisposable
{
    private readonly SqlConnection _connection = default!;
    private readonly ResultOfSqlCommand _command = default!;

    public DatabaseMapper(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentNullException(nameof(query), "Запрос не был передан");

        string connectionString = AppSettings.GetValue("Database",
                                                       "MSSQLDatabase",
                                                       "ConnectionString") ??
                                                       throw new NullReferenceException($"{nameof(connectionString)} не был проинициализирован");

        _connection = new SqlConnection(connectionString);
        _command = new ResultOfSqlCommand(new SqlCommand(query, _connection));
    }

    public async Task<TEntity?> GetEntityAsync<TEntity>()
         where TEntity : class, IEntity, new()
    {
        TEntity? result;

        try
        {
            await _connection.OpenAsync();
            result = await _command.GetEntityAsync<TEntity>();
        }
        catch (TimeoutException ex)
        {
            throw ex;
        }
        catch (SqlException ex)
        {
            throw ex;
        }

        return result;
    }

    public async Task<TEntity?> GetEntityByAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity, new()
    {
        TEntity? result;

        try
        {
            await _connection.OpenAsync();
            result = await _command.GetEntityAsync(entity);
        }
        catch (TimeoutException ex)
        {
            throw ex;
        }
        catch (SqlException ex)
        {
            throw ex;
        }

        return result;
    }

    public async Task<TEntity[]> GetEntitiesAsync<TEntity>()
        where TEntity : class, IEntity, new()
    {
        Queue<TEntity> entities;

        try
        {
            await _connection.OpenAsync();
            entities = await _command.GetEntitiesAsync<TEntity>();
        }
        catch (TimeoutException ex)
        {
            throw ex;
        }
        catch (SqlException ex)
        {
            throw ex;
        }

        return entities.ToArray();
    }

    public async Task<bool> UpdateEntityAsync<TEntity>(TEntity entity)
        where TEntity : class, IEntity, new()
    {
        bool isAdded;

        try
        {
            await _connection.OpenAsync();
            isAdded = await _command.UpdateEntityAsync(entity);
        }
        catch (TimeoutException ex)
        {
            throw ex;
        }
        catch (SqlException ex)
        {
            throw ex;
        }

        return isAdded;
    }

    public async ValueTask DisposeAsync()
    {
        await _connection.DisposeAsync();
        await _command.DisposeAsync();
        GC.Collect();
        GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        _connection.Dispose();
        _command.Dispose();
        GC.Collect();
        GC.SuppressFinalize(this);
    }
}