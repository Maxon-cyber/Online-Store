using OnlineStore.Entities.Product;
using OnlineStore.MarketPlace.Extensions;
using OnlineStore.MarketPlace.ProductControl.ProductsView.Container.Components;

namespace OnlineStore.MarketPlace.ProductControl.ProductsView.Container;

internal sealed class ProductViewContainer() : IDisposable
{
    internal async Task<Panel> Create(ProductEntity product)
    {
        Panel viewProductPanel = new Panel()
        {
            Name = $"panel{product.Name}",
            Dock = DockStyle.Fill
        };

        await Task.Run(() =>
        {
            viewProductPanel.ThreadSafeAddition(async () =>
            {
                viewProductPanel.Controls.AddRange(new Control[]
                {
                    await ProductImage.Create(product),
                    ChildContainer.Create(product)
                });
            });
        });

        return viewProductPanel;
    }

    public void Dispose()
    {
        GC.Collect();
        GC.SuppressFinalize(this);
    }
}