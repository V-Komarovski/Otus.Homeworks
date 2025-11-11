namespace Otus.Homeworks;

internal static class FileReader
{
    /// <summary>
    /// Возвращает количество пробелов в файлых указанной директории
    /// </summary>
    /// <param name="path">Путь к файлам</param>
    /// <returns></returns>
    public static async Task<int> GetWhitespaceCountInDirectory(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentNullException(nameof(path));

        var filePaths = Directory.GetFiles(path);

        var tasks = filePaths.Select(GetFileWhitespaceCount).ToArray();

        var results = await Task.WhenAll(tasks);
        var whitespaceCount = results.Sum();
        return whitespaceCount;
    }

    /// <summary>
    /// Возвращает количество пробелов в указанном файле
    /// </summary>
    /// <param name="localFilePath"></param>
    /// <returns></returns>
    private static async Task<int> GetFileWhitespaceCount(string localFilePath)
    {
        using var reader = new StreamReader(localFilePath);
        var content = await reader.ReadToEndAsync();
        var whitespaceCount = GetWhitespaceCount(content);
        return whitespaceCount;
    }

    /// <summary>
    /// Возвращает количество пробелов в тексте
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private static int GetWhitespaceCount(string text)
    {
        if (string.IsNullOrEmpty(text))
            return 0;

        var count = 0;
        foreach (var @char in text)
        {
            if (@char is ' ')
                count++;
        }

        return count;
    }
}