namespace Otus.Homeworks.HW6.GuessNumber.Validators;

/// <summary>
/// Валидатор
/// </summary>
internal interface IValidator
{
    /// <summary>
    /// Проверка равенства предполагаемого числа с загаданным
    /// </summary>
    /// <param name="guessedNumber">Предполагаемое число</param>
    /// <param name="secretNumber">Загаданное число</param>
    /// <returns></returns>
    int Validate(int guessedNumber, int secretNumber);

    /// <summary>
    /// Вывод результата проверки в текстовом виде
    /// </summary>
    /// <returns></returns>
    string CreateValidatorMessage();
}