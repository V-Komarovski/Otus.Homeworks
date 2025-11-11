namespace Otus.Homeworks.HW6.GuessNumber;

/// <summary>
/// Результирующее описание игры
/// </summary>
internal class ResultDto
{
    /// <summary>
    /// Игра запущена
    /// </summary>
    public bool IsActivePlay { get; internal set; }

    /// <summary>
    /// Результат игры
    /// </summary>
    public bool GameResult { get; internal set; }

    /// <summary>
    /// Количество попыток отгадывания числа
    /// </summary>        
    public int Steps { get; internal set; }

    /// <summary>
    /// Детали отгадывания числа
    /// </summary>        
    public int? ResultDetail { get; internal set; }
        
    /// <summary>
    /// Загаданное число. Приобретает значение только когда игра закончена
    /// </summary>
    public int? Secret { get; internal set; }

    /// <summary>
    /// Предполагаемое число
    /// </summary>
    public int GuessNumber {  get; internal set; }

    /// <summary>
    /// Нижняя граница диапазона загадывания числа
    /// </summary>        
    public int Min { get; internal set; }

    /// <summary>
    /// Верхняя граница диапазона загадывания числа
    /// </summary>
    /// <value>
    /// The maximum.
    /// </value>
    public int Max { get; internal set; }

    /// <summary>
    /// Ограничение  на количество шагов отгадывания
    /// </summary>       
    public int Limit { get; internal set; }
}