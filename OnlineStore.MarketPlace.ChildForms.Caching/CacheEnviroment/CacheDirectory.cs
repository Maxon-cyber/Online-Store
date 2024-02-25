namespace OnlineStore.MarketPlace.ChildForms.Caching.CacheEnviroment;

public sealed class CacheDirectory
{
    private static readonly Dictionary<string, List<CacheFile>> _cacheFiles = CacheFile.GetFiles();

    public string Name { get; private init; } = string.Empty;
    public string FullName { get; private init; } = string.Empty;
    public DateTime LastAccesTime { get; private set; } = default;

    private CacheDirectory() { }

    public CacheFile? this[string name]
    {
        get
        {
            string fileName = $"{name}Data";

            return null;
        }
    }

    internal static CacheDirectory Create(string name, string baseDirectory)
    {
        string fullPath = Path.Combine(baseDirectory, name);

        if (Directory.Exists(fullPath))
            fullPath = Path.Combine(baseDirectory, Path.GetRandomFileName() + name);

        DirectoryInfo createdDir = Directory.CreateDirectory(fullPath);

        return new CacheDirectory
        {
            Name = createdDir.Name,
            FullName = createdDir.FullName,
            LastAccesTime = createdDir.LastAccessTime
        };
    }

    internal static Dictionary<string, CacheDirectory> GetDirectoties()
    {
        Dictionary<string, CacheDirectory> cacheDirectories = new Dictionary<string, CacheDirectory>();
        
        DirectoryInfo directoryInfo = new DirectoryInfo(Cache.CacheBaseDirectory);
        DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();

        for (int directoryIndex = 0; directoryIndex < subDirectories.Length; directoryIndex++)
        {
            DirectoryInfo currentDirectory = subDirectories[directoryIndex];
            string directoryName = currentDirectory.Name;

            cacheDirectories.Add(directoryName, new CacheDirectory
            {
                Name = directoryName,
                FullName = currentDirectory.FullName,
                LastAccesTime = currentDirectory.LastAccessTime
            });
        }

        return cacheDirectories;
    }
}