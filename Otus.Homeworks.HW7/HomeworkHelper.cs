using System.Diagnostics;

namespace Otus.Homeworks.HW7;

/// <summary>
/// Класс со вспомогательными методами для домашнего задания.
/// </summary>
internal static class HomeworkHelper
{
    internal static long MeasureDeserializationTime<T>(
        Func<string, T> deserializeFunc,
        string data,
        int iterations)
        where T : class
    {
        var stopwatch = Stopwatch.StartNew();
        for (var i = 0; i < iterations; i++)
            deserializeFunc(data);

        stopwatch.Stop();

        return stopwatch.ElapsedMilliseconds;
    }

    internal static void Print(F f) => Console.WriteLine($"I1={f.I1}, I2={f.I2}, I3={f.I3}, I4={f.I4}, I5={f.I5}");
}