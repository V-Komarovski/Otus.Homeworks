using Otus.Homeworks.HW4;

CommonHelper.ShowSystemInfo();

var batchSizes = new[] { 100000, 1000000, 10000000 };

Console.WriteLine("\n=== Запуск ===");
foreach (var size in batchSizes)
{
    int[] array = ArrayGenerator.Generate(size);

    var sequentialTime = SumCalculator.MeasureSequential(array);
    var parallelThreadsTime = SumCalculator.MeasureParallelWithThreads(array);
    var plinqTime = SumCalculator.MeasurePLINQ(array);

    Console.WriteLine($"\nРазмер: {size:N0} | Последовательно: {sequentialTime} мс | Потоки: {parallelThreadsTime} мс | PLINQ: {plinqTime} мс");
}
Console.WriteLine("\n=== Конец ===");