using OnlineStore.Database;
using OnlineStore.Database.Sql.Queries;
using OnlineStore.Entities.Order;
using OnlineStore.Entities.Parameters;
using OnlineStore.MarketPlace.Extensions;
using OnlineStore.MarketPlace.OrderControl.OrderView.Container;

namespace OnlineStore.MarketPlace.OrderControl;

public sealed partial class OrderForm : UserControl
{
    private readonly ulong _userId = default!;

    public OrderForm(ulong userId)
    {
        InitializeComponent();
        _userId = userId;

        bool threadIsQueied = ThreadPool.QueueUserWorkItem((_) =>
        {
            using OrderViewContainer viewOrders = new OrderViewContainer();
            for (int index = 0; index < OrderDTO.Products.Count; index++)
            {
                tableLayoutPanelViewOrders.ThreadSafeAddition(async () =>
                    tableLayoutPanelViewOrders.Controls.Add(
                        await viewOrders.Create(OrderDTO.Products[index])));
            }

            //using ViewOrdersTLP viewOrderss = new ViewOrdersTLP(tableLayoutPanelViewOrders);
            //tableLayoutPanelViewOrders.ThreadSafeAddition(async () => await viewOrderss.AddItemsAsync());
        });
    }

    private async void BtnOrderProduct_Click(object sender, EventArgs e)
    {
        await using DatabaseMapper database = new DatabaseMapper(StoredProcedure.AddOrder);
        bool result = await database.UpdateEntityAsync(new OrderEnity()
        {
            Id = ID.Create(),
            UserId = _userId,
            Products = OrderDTO.Products,
            TotalAmount = OrderDTO.Products.Sum(product => product.Price),
            OrderDate = DateTime.Now,
            Status = Status.InProcessing
        });
    }
}