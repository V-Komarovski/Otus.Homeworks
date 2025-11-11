namespace Otus.Homeworks.HW6.GuessNumber.Validators;

/// <summary>
/// Стандартный валидатор
/// </summary>
/// <seealso cref="IValidator" />
public class SimpleValidator : IValidator
{
    /// <summary>
    /// Результат проверки
    /// </summary>
    private int _result;

    /// <summary>
    /// Предполагаемое число
    /// </summary>
    private int _guessedNumber;
    
    public int Validate(int guessedNumber, int secretNumber)
    {
        _guessedNumber = guessedNumber;

        if (guessedNumber == secretNumber)
        {
            _result = 0;
            return _result;
        }
        if (guessedNumber > secretNumber) _result = 1;
        else _result = -1;

        return _result;
    }

    public string CreateValidatorMessage()
    {
        string stringResult = string.Empty;
        if (_result == 0)
        {
            return $"Вы угадали загаданное число {_guessedNumber}";
        }

        stringResult = _result switch
        {
            1 => "больше",
            -1 => "меньше",
            _ => stringResult
        };
        return $"Ваше число {_guessedNumber} {stringResult} загаданного числа";
    }
}