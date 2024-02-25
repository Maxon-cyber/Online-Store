using OnlineStore.Entities.Product;
using OnlineStore.MarketPlace.Extensions;
using OnlineStore.MarketPlace.OrderControl.OrderView.Container.Components;

namespace OnlineStore.MarketPlace.OrderControl.OrderView.Container;

internal sealed class OrderViewContainer() : IDisposable
{
    internal async Task<Panel> Create(ProductEntity product)
    {
        Panel viewOrderPanel = new Panel()
        {
            Dock = DockStyle.Fill,
        };

        await Task.Run(() =>
        {
            viewOrderPanel.ThreadSafeAddition(async () =>
            {
                viewOrderPanel.Controls.AddRange(new Control[]
                {
                    await OrderImage.Create(product),
                    OrderInfo.Create(product)
                });
            });
        });

        return viewOrderPanel;
    }

    public void Dispose()
    {        
        GC.Collect();
        GC.SuppressFinalize(this);
    }
}