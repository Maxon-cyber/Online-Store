using OnlineStore.Entities.Attributes;
using System.Data;

namespace OnlineStore.Entities.User;

public sealed class UserEntity() : IEntity
{
    [Mapping(columnName: "id", dbType: SqlDbType.BigInt)]
    public ulong Id { get; init; }

    [Mapping(columnName: "name", dbType: SqlDbType.NChar)]
    public string Name { get; init; }

    [Mapping(columnName: "second_name", dbType: SqlDbType.NChar)]
    public string SecondName { get; init; }

    [Mapping(columnName: "patronymic", dbType: SqlDbType.NChar)]
    public string Patronymic { get; init; }

    //[Mapping(columnName: "gender", dbType: SqlDbType.NChar)]
    //public string Gender { get; init; }

    //[Mapping(columnName: "age", dbType: SqlDbType.Int)]
    //public uint Age { get; init; }

    //[Mapping(columnName: "geografy", dbType: SqlDbType.NVarChar)]
    //public string Geografy { get; init; }

    [Mapping(columnName: "login", dbType: SqlDbType.NChar)]
    public string Login { get; init; }

    [Mapping(columnName: "password", dbType: SqlDbType.NChar)]
    public string Password { get; init; }

    [Mapping(columnName: "role", dbType: SqlDbType.NChar)]
    public Role Role { get; init; }

    [Mapping(columnName: "date_of_registration", dbType: SqlDbType.SmallDateTime)]
    public DateTime DateOfRegistartion { get; init; }

    public override string ToString()
        => $"{Name} {SecondName} {Patronymic}";

    public override bool Equals(object? obj)
        => base.Equals(obj);

    public override int GetHashCode()
        => base.GetHashCode();
}