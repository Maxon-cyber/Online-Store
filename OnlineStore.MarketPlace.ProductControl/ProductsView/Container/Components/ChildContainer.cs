using OnlineStore.Entities.Product;
using OnlineStore.MarketPlace.ProductControl.Extensions;
using OnlineStore.MarketPlace.ProductControl.ProductsView.Container.Components.ButtonEvents;

namespace OnlineStore.MarketPlace.ProductControl.ProductsView.Container.Components;

internal static class ChildContainer
{
    private class ShoppingCartManagement()
    {
        internal static Panel Create(ProductEntity product)
        {
            Panel basketControl = new Panel()
            {
                Name = $"panelBasket{product.Name}",
                Size = new Size(85, 29),
                Location = new Point(161, 97),
                Dock = DockStyle.Right
            };

            Button addButton = new Button()
            {
                Name = $"buttonAddProduct{product.Name}",
                Text = "+",
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(45, 17),
                Size = new Size(23, 23),
            }.SetToolTip("Добавить товар в корзину");

            Button deleteButton = new Button()
            {
                Name = $"buttonDeleteProduct{product.Name}",
                Text = "-",
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(15, 17),
                Size = new Size(23, 23),
            }.SetToolTip("Удалить товар из корзины");

            ShoppingCartButtonEvent buttonEvents = new ShoppingCartButtonEvent(product);
            addButton.Click += buttonEvents.AddItem!;
            deleteButton.Click += buttonEvents.RemoveItem!;

            basketControl.Controls.AddRange(new Button[] { addButton, deleteButton });

            return basketControl;
        }
    }

    private class BasicProductInfo()
    {
        internal static Label Create(ProductEntity product)
        {
            Label productInfo = new Label()
            {
                Name = $"label{product.Name}",
                Text = product.Name,
                Location = new Point(3, 18),
                AutoSize = false,
                Size = new Size(96, 24)
            };

            return productInfo;
        }
    }

    internal static Panel Create(ProductEntity product)
    {
        Panel childContainer = new Panel()
        {
            Name = $"panelChildContainer{product.Name}",
            Size = new Size(292, 49),
            Location = new Point(0, 106),
            Dock = DockStyle.Bottom
        };

        childContainer.Controls.AddRange(new Control[]
        {
            ShoppingCartManagement.Create(product),
            BasicProductInfo.Create(product)
        });

        return childContainer;
    }
}