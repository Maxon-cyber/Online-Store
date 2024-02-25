using System.Runtime.InteropServices;

namespace OnlineStore.Tools;

public static class InternetAvailability
{
    [DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(out int description, int reservedValue);

    public static bool IsInternetAvailable()
        => InternetGetConnectedState(out int _, 0);
}