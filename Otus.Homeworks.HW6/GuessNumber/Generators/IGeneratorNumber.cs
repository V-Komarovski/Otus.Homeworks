namespace Otus.Homeworks.HW6.GuessNumber.Generators;

/// <summary>
/// Интерфейс для генератора числа
/// </summary>
internal interface IGeneratorNumber
{
    /// <summary>
    /// Сгенерировать число
    /// </summary>
    /// <returns></returns>
    int Generate();

    /// <summary>
    /// Нижняя граница диапазона генерируемых чисел
    /// </summary>       
    int Min { get; set; }

    /// <summary>
    /// Верхняя граница диапазона генерируемых чисел
    /// </summary>        
    int Max { get; set; }
}