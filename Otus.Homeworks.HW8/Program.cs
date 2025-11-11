using Otus.Homeworks.HW8;

// Поиск максимального значения
List<Person> persons = [];
var random = new Random(DateTime.Now.Microsecond);
for (var i = 0; i < 10; i++)
{
    persons.Add(new Person(random.Next(100)));
}

var oldest = persons.GetMax(x => x.Age);
var message = oldest is null
    ? "Не удалось найти максимальный возраст"
    : $"Максимальный возраст: {oldest.Age}";

Console.WriteLine(message);

// Проходка по каталогу файлов
var fileSearcher = new FileSearcher();
fileSearcher.FileFound += OnFileSearcherFileFound;

var currentDir = Directory.GetCurrentDirectory();
var pathDir = Path.Combine(currentDir, "Files");
fileSearcher.Search(pathDir);

fileSearcher.FileFound -= OnFileSearcherFileFound;

Console.ReadLine();
return;

static void OnFileSearcherFileFound(object? sender, SearchArgs args)
{
    var fileName = args.FilePath.Split('\\').Last();

    Console.WriteLine($"Файл c именем {fileName} найден");
    args.IsCancelled = true;
}