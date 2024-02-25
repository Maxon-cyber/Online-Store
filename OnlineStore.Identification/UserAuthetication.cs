using OnlineStore.Database;
using OnlineStore.Database.Sql.Queries;
using OnlineStore.Entities.User;

namespace OnlineStore.Identification;

internal static class UserAuthetication
{
    internal static async Task<UserEntity?> CheckAsync(string login, string password)
    {
        await using DatabaseMapper database = new DatabaseMapper(StoredProcedure.GetUser);

        UserEntity? user = await database.GetEntityByAsync(new UserEntity()
        {
            Login = login,
            Password = password
        });

        return user;
    }
}