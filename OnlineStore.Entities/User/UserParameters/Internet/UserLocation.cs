using Newtonsoft.Json;
using System.Globalization;
using System.Net;

namespace OnlineStore.Entities.User.UserParameters.Internet;

public static class UserGeolocation
{
    private static readonly WebClient _webClient = new WebClient();
    private static readonly string _publicIP = default;

    static UserGeolocation()
       => _publicIP = _webClient.DownloadString("https://api.ipify.org");

    public static IPInfo GetLocation()
    {
        string info = _webClient.DownloadString($"http://ipinfo.io/{_publicIP}");

        IPInfo ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);

        RegionInfo region = new RegionInfo(ipInfo.Country);
        ipInfo.Country = region.EnglishName;

        return ipInfo;
    }
}