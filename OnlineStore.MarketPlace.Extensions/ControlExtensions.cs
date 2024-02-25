namespace OnlineStore.MarketPlace.Extensions;

public static class ControlExtensions
{
    public static void ThreadSafeAddition<TControl>(this TControl control, Action action)
        where TControl : Control
    {
        if (control.InvokeRequired)
            control.Invoke(action);
        else
            action();
    }
}