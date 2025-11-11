using System.Diagnostics;

namespace Otus.Homeworks.HW4;

public static class SumCalculator
{
    public static long MeasureSequential(int[] array)
    {
        Stopwatch sw = Stopwatch.StartNew();
        var count = 0L;
        for (int i = 0; i < array.Length; i++)
        {
            count += array[i];
        }
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    public static long MeasureParallelWithThreads(int[] array)
    {
        var threadCount = Environment.ProcessorCount;
        var chunkSize = array.Length / threadCount;
        var sumTotal = 0L;
        Lock lockObj = new();

        Stopwatch sw = Stopwatch.StartNew();

        Task[] tasks = new Task[threadCount];

        for (int t = 0; t < threadCount; t++)
        {
            int start = t * chunkSize;
            int end = (t == threadCount - 1) ? array.Length : start + chunkSize;

            tasks[t] = Task.Run(() =>
            {
                long localSum = 0;
                for (int i = start; i < end; i++)
                {
                    localSum += array[i];
                }
                lock (lockObj)
                {
                    sumTotal += localSum;
                }
            });
        }

        Task.WaitAll(tasks);
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    public static long MeasurePLINQ(int[] array)
    {
        var sw = Stopwatch.StartNew();
        long sum = array.AsParallel().Sum();
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}