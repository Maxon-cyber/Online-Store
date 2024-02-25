namespace OnlineStore.MarketPlace.ChildForms.Caching.CacheEnviroment;

public sealed class CacheFile
{
    public string Name { get; private init; } = string.Empty;
    public string Extension { get; private init; } = string.Empty;
    public string FullName { get; private init; } = string.Empty;
    public DateTime LastAccesTime { get; private init; } = default!;

    private CacheFile() { }

    internal static CacheFile Create()
    {
        return new();
    }

    internal static Dictionary<string, List<CacheFile>> GetFiles()
    {
        Dictionary<string, List<CacheFile>> cacheFiles = new Dictionary<string, List<CacheFile>>();

        DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\рс\AppData\Local\Temp\OnlineStore.Cache\User");
        FileInfo[] fileInfos = directoryInfo.GetFiles();

        for (int fileIndex = 0; fileIndex < fileInfos.Length; fileIndex++)
        {
            List<CacheFile> files = new List<CacheFile>();

            FileInfo currentFile = fileInfos[fileIndex];
            string fileName = currentFile.Name;
            files.Add(new CacheFile
            {
                Name = fileName,
                Extension = currentFile.Extension,
                FullName = currentFile.FullName,
                LastAccesTime = currentFile.LastAccessTime
            });

            cacheFiles.Add(directoryInfo.Name, files);
        }

        return cacheFiles;
    }
}