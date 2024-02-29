using OnlineStore.ApplicationSettings;
using Windows.Storage;

namespace OnlineStore.Identification;

internal static class StartApp
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormIdentification());
    }
}