namespace OnlineStore.MarketPlace.Extensions;

internal static class ControlExtensions
{
    internal static UserControl OpenNewUserControlWIndow(this Panel mainPanel, UserControl userControl)
    {
        userControl.BorderStyle = BorderStyle.None;
        userControl.Dock = DockStyle.Fill;
        mainPanel.Controls.Add(userControl);
        mainPanel.Tag = userControl;
        userControl.BringToFront();
        userControl.Show();

        return userControl;
    }
}