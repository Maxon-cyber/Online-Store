using OnlineStore.Database;
using OnlineStore.Database.Sql.Queries;
using OnlineStore.Entities.Order;
using OnlineStore.Entities.Product;
using OnlineStore.MarketPlace.Extensions;
using OnlineStore.MarketPlace.OrderControl.OrderView.Container;

namespace OnlineStore.MarketPlace.OrderControl.OrderView;

internal sealed class ViewOrdersTLP(TableLayoutPanel viewTableLayoutPanel) : IDisposable
{
    private readonly OrderViewContainer _container = new OrderViewContainer();

    internal async Task AddItemsAsync()
    {
        await using DatabaseMapper database = new DatabaseMapper(StoredProcedure.AddOrder);
        OrderEnity order = await database.GetEntityAsync<OrderEnity>();

        if (order == null)
            return;

        List<ProductEntity> products = order.Products;

        int countOfProducts = products.Count;

        int columnTPL = viewTableLayoutPanel.ColumnCount;
        int rowTPL = products.Count / columnTPL;
        viewTableLayoutPanel.RowCount = rowTPL;

        viewTableLayoutPanel.SuspendLayout();
        for (int index = 0; index < products.Count; index++)
        {
            int column = index % columnTPL;
            int row = index / columnTPL;

            viewTableLayoutPanel.ThreadSafeAddition(async () => viewTableLayoutPanel.Controls.Add(await _container.Create(products[index]), column, row));
        }
        viewTableLayoutPanel.ResumeLayout();

        void UpdateRowAndColumnStyles()
        {
            TableLayoutRowStyleCollection rowStyles = viewTableLayoutPanel.RowStyles;
            TableLayoutColumnStyleCollection columnStyles = viewTableLayoutPanel.ColumnStyles;

            rowStyles.Clear();
            columnStyles.Clear();

            for (int rowIndex = 0; rowIndex < rowTPL; rowIndex++)
                rowStyles.Add(new RowStyle() { Height = 100F, SizeType = SizeType.Percent });
            for (int columnIndex = 0; columnIndex < columnTPL; columnIndex++)
                columnStyles.Add(new ColumnStyle() { Width = 50F, SizeType = SizeType.Percent });
        }

        UpdateRowAndColumnStyles();
        viewTableLayoutPanel.Invalidate();
    }

    public void Dispose()
    {
        _container.Dispose();
        GC.Collect();
        GC.SuppressFinalize(this);
    }
}