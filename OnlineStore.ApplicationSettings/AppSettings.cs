using Microsoft.Extensions.Configuration;

namespace OnlineStore.ApplicationSettings;

public static class AppSettings
{
    private static IConfigurationRoot _configurationRoot = default!;
    private static readonly IConfigurationBuilder _configurationBuilder = new ConfigurationBuilder()!;

    public static void Initialize(params string[] fileNames)
    {
        if (fileNames.Length == 0)
            throw new ArgumentException($"{nameof(fileNames)} - не проинициализирован");

        for (int index = 0; index < fileNames.Length; index++)
        {
            string currentPath = fileNames[index];

            if (string.IsNullOrWhiteSpace(currentPath))
                throw new ArgumentNullException(nameof(currentPath), $"Элемент массива {nameof(fileNames)} не проинициализирован");

            _configurationBuilder.AddYamlFile(currentPath, true, true);
        }

        _configurationRoot = _configurationBuilder.Build();
    }

    public static string? GetValue(string needSection, string key, string value)
    {
        if (_configurationRoot == null)
            throw new NullReferenceException($"{nameof(_configurationRoot)} не проинициализирован");
        
        string? connectionString = _configurationRoot.GetSection(needSection)
                                                     .GetSection(key)
                                                     .GetSection(value)
                                                     .Value;
        return connectionString;
    }

    public static string? GetValue(string needSection, string[] keys, string value)
    {
        if (_configurationRoot == null)
            throw new NullReferenceException($"{nameof(_configurationRoot)} не проинициализирован");

        IConfigurationSection section = _configurationRoot.GetSection(needSection);

        for (int index = 0; index < keys.Length; index++)
            section.GetSection(keys[index]);

        string? connectionString = section.GetSection(value).Value;

        return connectionString;
    }
}