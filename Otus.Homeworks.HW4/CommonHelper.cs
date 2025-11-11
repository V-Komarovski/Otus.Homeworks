using System.Runtime.InteropServices;

namespace Otus.Homeworks.HW4;

internal static class CommonHelper
{
    public static void ShowSystemInfo()
    {
        Console.WriteLine();
        Console.WriteLine("=== Информация об окружении ===");

        // Проц Intel i9-12900KF
        Console.WriteLine($"Количество ядер в процессоре: {Environment.ProcessorCount}");
        Console.WriteLine($"Архитектура процессора: {RuntimeInformation.ProcessArchitecture}");

        var totalMemory = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
        Console.WriteLine($"Объем физической памяти: {totalMemory / (1024 * 1024 * 1024):F2} GB");

        Console.WriteLine($"Операционная система: {Environment.OSVersion}");
        Console.WriteLine($"64-х разрядная система: {(Environment.Is64BitOperatingSystem ? "да" : "нет")}");
    }
}