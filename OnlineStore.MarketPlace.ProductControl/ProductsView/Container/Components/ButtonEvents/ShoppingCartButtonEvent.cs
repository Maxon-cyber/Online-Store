using OnlineStore.Entities.Product;
using OnlineStore.MarketPlace.OrderControl;
using OnlineStore.MarketPlace.ProductControl.DTO;

namespace OnlineStore.MarketPlace.ProductControl.ProductsView.Container.Components.ButtonEvents;

internal sealed class ShoppingCartButtonEvent(ProductEntity product)
{
    private static readonly List<ProductEntity> _products = OrderDTO.Products;
    private static readonly Control _roundLabelProductCounter = ControlDTO.ParentControls.Find("buttonOrders", true).FirstOrDefault()!;

    internal void AddItem(object sender, EventArgs e)
    {
        _products.Add(product);

        _roundLabelProductCounter.Visible = true;

        _roundLabelProductCounter.Text = _products.Count.ToString();
    }

    internal void RemoveItem(object sender, EventArgs e)
    {
        if (_products.Count == 0)
        {
            _roundLabelProductCounter.Visible = false;
            return;
        }

        _products.Remove(product);

        _roundLabelProductCounter.Text = _products.Count.ToString();
    }
}