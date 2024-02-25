using Microsoft.IdentityModel.Tokens;
using OnlineStore.MarketPlace.Extensions;
using OnlineStore.MarketPlace.ProductControl.DTO;
using OnlineStore.MarketPlace.ProductControl.ProductsView;

namespace OnlineStore.MarketPlace.ProductControl;

public sealed partial class ProductForm : UserControl
{
    public ProductForm(ControlCollection parentControlCollection)
    {
        InitializeComponent();

        textBoxSearch.SetWatermark("Поиск");

        ControlDTO.ParentControls = parentControlCollection;

        bool threadIsQueied = ThreadPool.QueueUserWorkItem((_) =>
        {
            using ViewProductsTLP viewProductsTLP = new ViewProductsTLP(tableLayoutPanelViewProducts, progressBar);

            tableLayoutPanelViewProducts.ThreadSafeAddition(async () => await viewProductsTLP.AddItemsAsync());
        });

        if (threadIsQueied)
            Controls.Remove(progressBar);
    }

    private void BtnSearch_Click(object sender, EventArgs e)
    {
        if (textBoxSearch.Text.IsNullOrEmpty())
        {
            MessageBox.Show("Введите название товара");
            return;
        }

        Control? needControl = tableLayoutPanelViewProducts.Controls.Find($"{textBoxSearch.Text}Panel", true).FirstOrDefault();

        if (needControl == null)
        {
            MessageBox.Show("Элемент не найден");
            return;
        }

        int desiredRow = tableLayoutPanelViewProducts.GetRow(needControl);
        int desiredColumn = tableLayoutPanelViewProducts.GetColumn(needControl);
        tableLayoutPanelViewProducts.ScrollControlIntoView(tableLayoutPanelViewProducts.GetControlFromPosition(desiredColumn, desiredRow));
        needControl.Select();
    }
}