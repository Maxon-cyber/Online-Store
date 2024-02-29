using System.Runtime.InteropServices;

namespace OnlineStore.Entities.User.UserParameters.Internet;

public static class InternetAvailability
{
    [DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(out int description, int reservedValue);

    public static bool IsInternetAvailable()
        => InternetGetConnectedState(out int _, 0);
}