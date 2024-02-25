using OnlineStore.Entities.Product;

namespace OnlineStore.MarketPlace.OrderControl;

public static class OrderDTO
{
    public static List<ProductEntity> Products { get; } = new List<ProductEntity>();
}