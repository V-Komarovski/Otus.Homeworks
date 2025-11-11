using System.Diagnostics;
using Otus.Homeworks;

var filesPath = "Files";

var stopwatch = new Stopwatch();
stopwatch.Start();

var whitespaceCount = await FileReader.GetWhitespaceCountInDirectory(filesPath);

stopwatch.Stop();

Console.WriteLine($"Число пробелов: {whitespaceCount}");
Console.WriteLine($"Время выполнения: {stopwatch.Elapsed}");

Console.ReadKey();