using OnlineStore.Entities.Product;
using OnlineStore.MarketPlace.ProductControl.Extensions;

namespace OnlineStore.MarketPlace.ProductControl.ProductsView.Container.Components;

internal static class ProductImage
{
    internal static async Task<PictureBox> Create(ProductEntity product)
    {
        PictureBox photo = new PictureBox()
        {
            Name = $"pictureBox{product.Name}",
            Size = new Size(278, 76),
            Location = new Point(0, 0),
            Image = await GetImageFromBytesArray(product.Image),
            SizeMode = PictureBoxSizeMode.StretchImage
        }.SetToolTip($"{product.Price}\n{product.Category}");

        return photo;
    }

    private static async Task<Image> GetImageFromBytesArray(byte[] image)
    {
        await using MemoryStream memoryStream = new MemoryStream(image);

        return Image.FromStream(memoryStream);
    }
}