namespace Otus.Homeworks.HW8;

internal class FileSearcher
{
    internal event EventHandler<SearchArgs> FileFound;

    internal void Search(string directoryPath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new ArgumentException($"Каталог не найден по пути {directoryPath}");
        }

        var filePaths = Directory.GetFiles(directoryPath);
        foreach (var filePath in filePaths)
        {
            var searchArgs = FileFoundNotify(filePath);

            // После первой итерации заканчиваем
            if (searchArgs.IsCancelled)
            {
                break;
            }
        }
    }

    private SearchArgs FileFoundNotify(string filePath)
    {
        var searchArgs = new SearchArgs(filePath);
        FileFound?.Invoke(this, searchArgs);
        return searchArgs;
    }
}