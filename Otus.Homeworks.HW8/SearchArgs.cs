namespace Otus.Homeworks.HW8;

internal class SearchArgs(string filePath) : EventArgs
{
    public string FilePath { get; private set; } = filePath;
    public bool IsCancelled { get; set; }
}