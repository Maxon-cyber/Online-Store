using OnlineStore.Database;
using OnlineStore.Database.Sql.Queries;
using OnlineStore.Entities.Product;
using OnlineStore.MarketPlace.ChildForms.Caching;
using OnlineStore.MarketPlace.Extensions;
using OnlineStore.MarketPlace.ProductControl.ProductsView.Container;
using OnlineStore.Tools;

namespace OnlineStore.MarketPlace.ProductControl.ProductsView;

internal sealed class ViewProductsTLP(TableLayoutPanel viewTableLayoutPanel, ProgressBar progressBar) : IDisposable
{
    private readonly ProductViewContainer _container = new ProductViewContainer();

    internal async Task AddItemsAsync()
    {
        if (!InternetAvailability.IsInternetAvailable())
        {
           
            
        }
        Cache cache1 = new Cache();
        await using DatabaseMapper database = new DatabaseMapper(StoredProcedure.GetProducts);

        ProductEntity[]? products = null;
        
        products = await database.GetEntitiesAsync<ProductEntity>();

        int countOfProducts = products.Length;

        if (countOfProducts == 0)
            return;

        int columnTPL = viewTableLayoutPanel.ColumnCount;
        int rowTPL = countOfProducts / columnTPL;
        viewTableLayoutPanel.RowCount = rowTPL;

        viewTableLayoutPanel.SuspendLayout();
        for (int index = 0; index < countOfProducts; index++)
        {
            int column = index % columnTPL;
            int row = index / columnTPL;

            progressBar.Value *= 100 / progressBar.Maximum;
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