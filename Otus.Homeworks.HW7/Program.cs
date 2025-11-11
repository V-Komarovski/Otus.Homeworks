using System.Diagnostics;
using System.Text.Json;
using Otus.Homeworks.HW7;

var iterationsCount = 100000;
var instance = F.Get();

// Рефлексия
long reflectionSerializeTime = 0L;
long reflectionDeserializeTime = 0L;

for (var i = 0; i < iterationsCount; i++)
{
    var watch = Stopwatch.StartNew();
    string serialized = CustomSerializer.Serialize(instance);
    watch.Stop();
    reflectionSerializeTime += watch.ElapsedMilliseconds;

    watch.Restart();
    CustomSerializer.Deserialize<F>(serialized);
    watch.Stop();
    reflectionDeserializeTime += watch.ElapsedMilliseconds;
}

// System.Text.Json
var jsonSerializeTime = 0L;
var jsonDeserializeTime = 0L;

for (var i = 0; i < iterationsCount; i++)
{
    var watch = Stopwatch.StartNew();
    var serializeResult = JsonSerializer.Serialize(instance);
    watch.Stop();
    jsonSerializeTime += watch.ElapsedMilliseconds;

    watch.Restart();
    var deserializeResult = JsonSerializer.Deserialize<F>(serializeResult);
    watch.Stop();
    jsonDeserializeTime += watch.ElapsedMilliseconds;
}

// Время вывода в консоль
var consoleWatch = Stopwatch.StartNew();
Console.WriteLine("\nСериализуемый класс: class F {{ int i1, i2, i3, i4, i5; }}");
Console.WriteLine($"Количество замеров: {iterationsCount} итераций");
Console.WriteLine("Мой рефлекшен:");
Console.WriteLine($"Время на сериализацию = {reflectionSerializeTime} мс");
Console.WriteLine($"Время на десериализацию = {reflectionDeserializeTime} мс");
Console.WriteLine("Стандартный механизм - System.Text.Json");
Console.WriteLine($"Время на сериализацию = {jsonSerializeTime} мс");
Console.WriteLine($"Время на десериализацию = {jsonDeserializeTime} мс");

Console.Write("Введите путь к файлу (.csv): ");

consoleWatch.Stop();

var filePath = Console.ReadLine() ?? string.Empty;

consoleWatch.Start();

if (!File.Exists(filePath))
{
    Console.WriteLine("Файл не найден.");
    return;
}

var fileContent = File.ReadAllText(filePath);

long csvTime = HomeworkHelper.MeasureDeserializationTime(CustomSerializer.DeserializeFromCsv<F>, fileContent, iterationsCount);
var fFromCsv = CustomSerializer.DeserializeFromCsv<F>(fileContent);
Console.WriteLine($"\n[CSV] Десериализация выполнена за {csvTime} мс (кол-во итераций: {iterationsCount})");
HomeworkHelper.Print(fFromCsv);

consoleWatch.Stop();