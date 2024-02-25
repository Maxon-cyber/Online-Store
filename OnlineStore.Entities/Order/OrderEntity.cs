using OnlineStore.Entities.Attributes;
using OnlineStore.Entities.Product;
using System.Data;

namespace OnlineStore.Entities.Order;

public sealed class OrderEnity() : IEntity
{
    [Mapping(columnName: "id", dbType: SqlDbType.BigInt)]
    public ulong Id { get; init; }

    [Mapping(columnName: "user_id", dbType: SqlDbType.BigInt)]
    public ulong UserId { get; init; }

    [Mapping(columnName: "products", dbType: SqlDbType.Xml)]
    public List<ProductEntity> Products { get; init; }

    [Mapping(columnName: "total_amount", dbType: SqlDbType.Money)]
    public decimal TotalAmount { get; init; }

    [Mapping(columnName: "order_date", dbType: SqlDbType.SmallDateTime)]
    public DateTime OrderDate { get; init; }

    [Mapping(columnName: "status", dbType: SqlDbType.NChar)]
    public Status Status { get; init; }
}