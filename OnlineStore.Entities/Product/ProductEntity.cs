using OnlineStore.Entities.Attributes;
using System.Data;

namespace OnlineStore.Entities.Product;

public sealed class ProductEntity() : IEntity
{
    [Mapping(columnName: "id", dbType: SqlDbType.BigInt)]
    public ulong Id { get; init; }

    [Mapping(columnName: "name", dbType: SqlDbType.NVarChar)]
    public string Name { get; init; }

    [Mapping(columnName: "image", dbType: SqlDbType.VarBinary)]
    public byte[] Image { get; init; }

    [Mapping(columnName: "count", dbType: SqlDbType.Int)]
    public uint Quantity { get; init; }

    [Mapping(columnName: "category", dbType: SqlDbType.NVarChar)]
    public string Category { get; init; }

    [Mapping(columnName: "price", dbType: SqlDbType.Money)]
    public decimal Price { get; init; }

    public string ToString(string message)
        => $"{Name}-{Price}({message})";

    public override string ToString()
        => $"{Name}-{Price}";

    public override bool Equals(object? obj)
        => base.Equals(obj);

    public override int GetHashCode()
        => base.GetHashCode();
}