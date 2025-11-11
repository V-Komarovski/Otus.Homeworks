using System.Text.Json;

namespace Otus.Homeworks.HW6.GuessNumber;

/// <summary>
/// Расширение для результата игры
/// </summary>
internal static class ResultDtoExtensions
{
    /// <summary>
    /// Конвертирует результат игры в формат Json
    /// </summary>
    /// <param name="item">Результат игры</param>
    /// <returns></returns>
    public static string ConvertToJson(this ResultDto item)
    {
        return JsonSerializer.Serialize(item);
    }
}