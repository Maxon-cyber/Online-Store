using OnlineStore.Entities.Product;

namespace OnlineStore.MarketPlace.OrderControl.OrderView.Container.Components;

internal static class OrderImage
{
    internal static async Task<PictureBox> Create(ProductEntity product)
    {
        PictureBox picture = new PictureBox()
        {
            Name = $"{product.Name}PictureBox",
            Size = new Size(196, 104),
            Location = new Point(0, 0),
            Image = await GetImageFromBytesArray(product.Image),
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        return picture;
    }

    private static async Task<Image> GetImageFromBytesArray(byte[] image)
    {
        await using MemoryStream memoryStream = new MemoryStream(image);

        return Image.FromStream(memoryStream);
    }
}