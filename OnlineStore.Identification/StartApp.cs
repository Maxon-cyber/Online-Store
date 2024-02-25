using OnlineStore.ApplicationSettings;
using System.Reflection;

namespace OnlineStore.Identification;

internal static class StartApp
{
    [STAThread]
    private static void Main()
    {
        string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OnlineStore");
        DirectoryInfo currentAppDirectory = Directory.CreateDirectory(appDataPath);
        

        AppSettings.Initialize(
            new string[]
            {
                "",
            });

        ApplicationConfiguration.Initialize();
        Application.Run(new FormIdentification());
    }

    private static void CreateDomain()
    {
        string exeAssembly = Assembly.GetEntryAssembly().FullName;

        AppDomain appDomain = AppDomain.

        YourStartupClass proxy = (YourStartupClass)appDomain.CreateInstanceAndUnwrap(
               exeAssembly, typeof(YourStartupClass).FullName);

        // call the startup method - something like alternative main()
        proxy.StartupMethod();

        // in the end, unload the domain
        AppDomain.Unload(appDomain);
    }
}