using OnlineStore.Entities;
using OnlineStore.MarketPlace.ChildForms.Caching.CacheEnviroment;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace OnlineStore.MarketPlace.ChildForms.Caching;

public sealed class Cache
{
    private static readonly Dictionary<string, CacheDirectory> _cacheDirectories = CacheDirectory.GetDirectoties();
    private static readonly ISerializer _serializer = new SerializerBuilder()
                                                   .WithNamingConvention(PascalCaseNamingConvention.Instance)
                                                   .Build();

    public static string CacheBaseDirectory => Path.Combine(Path.GetTempPath(), "OnlineStore.Cache");

    public Cache()
    {
        if (!Directory.Exists(CacheBaseDirectory))
        {
            DirectoryInfo directory = Directory.CreateDirectory(CacheBaseDirectory);

            CacheDirectory userDir = CacheDirectory.Create("User", CacheBaseDirectory);
            CacheDirectory productsDir = CacheDirectory.Create("Products", CacheBaseDirectory);
            CacheDirectory ordresDir = CacheDirectory.Create("Orders", CacheBaseDirectory);

            _cacheDirectories.Add(userDir.Name, userDir);
            _cacheDirectories.Add(productsDir.Name, productsDir);
            _cacheDirectories.Add(ordresDir.Name, ordresDir);
        }
    }

    public async Task<string?> ReadByAsync(string key)
    {
        string data = await File.ReadAllTextAsync("");

        using StringReader reader = new StringReader(data);

        YamlStream documents = new YamlStream();
        documents.Load(reader);

        int documentsLength = documents.Documents.Count;

        for (int index = 0; index < documentsLength; index++)
        {
            YamlMappingNode root = (YamlMappingNode)documents.Documents[index].RootNode;

            foreach (KeyValuePair<YamlNode, YamlNode> child in root.Children)
                if (child.Key.ToString() == key)
                    return child.Value.ToString();
        }

        return null;
    }

    public async Task<TEntity[]?> ReadAllAsync<TEntity>()
        where TEntity : IEntity
    {
        string[] result = await File.ReadAllLinesAsync("");

        return null;
    }

    public async Task<string> WriteAsync<TEntity>(TEntity entity)
        where TEntity : IEntity
    {
        string result = _serializer.Serialize(entity);

        await File.AppendAllTextAsync("", result);

        return result;
    }

    public async Task<string> WriteAsync<TEntity>(TEntity[] entities)
        where TEntity : IEntity
    {
        string result = _serializer.Serialize(entities);

        await File.AppendAllTextAsync("", result);

        return result;
    }
}