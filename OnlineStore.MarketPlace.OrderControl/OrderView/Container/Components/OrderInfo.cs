using OnlineStore.Entities.Order;
using OnlineStore.Entities.Product;

namespace OnlineStore.MarketPlace.OrderControl.OrderView.Container.Components;

internal static class OrderInfo
{
    internal static Label Create(ProductEntity product)
    {
        Label productName = new Label()
        {
            Name = $"label{product.Name}",
            Location = new Point(202, 24),
            Text = product.Name,
        };

        return productName;
    }
}