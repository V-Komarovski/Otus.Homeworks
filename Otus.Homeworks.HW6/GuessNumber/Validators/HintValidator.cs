using Otus.Homeworks.HW6.GuessNumber.Generators;

namespace Otus.Homeworks.HW6.GuessNumber.Validators;

/// <summary>
/// Валидатор с небольшой подсказкой
/// </summary>
internal class HintValidator(IGeneratorNumber numberGenerator) : IValidator
{
    /// <summary>
    /// Ссылка на генератор чисел
    /// </summary>
    private readonly IGeneratorNumber _numberGenerator = numberGenerator;

    /// <summary>
    /// Результат проверки
    /// </summary>
    private int _result;

    /// <summary>
    /// Предполагаемое число
    /// </summary>
    private int _guessedNumber;

    public string CreateValidatorMessage()
    {
        var stringResult = string.Empty;
        if (_result == 0)
        {
            return $"Вы угадали загаданное число {_guessedNumber}";
        }

        stringResult = _result switch
        {
            3 => "много больше",
            2 => "больше",
            1 => "немного больше",
            -1 => "немного меньше",
            -2 => "меньше",
            -3 => "много меньше",
            _ => stringResult
        };

        return $"Ваше число {_guessedNumber} {stringResult} загаданного числа";
    }

    public int Validate(int guessedNumber, int secretNumber)
    {
        _guessedNumber = guessedNumber;

        if (secretNumber > _numberGenerator.Max || secretNumber < _numberGenerator.Min)
            throw new Exception("Некорректно задан диапазон возможных значений числа");

        float fraction;
        if (guessedNumber == secretNumber)
        {
            _result = 0;
            return _result;
        }

        if (guessedNumber > secretNumber)
        {
            fraction = Math.Abs((guessedNumber - secretNumber) / (_numberGenerator.Max - secretNumber));

            _result = fraction switch
            {
                < 0.33f => 1,
                < 0.66f => 2,
                _ => 3
            };
        }
        else
        {
            fraction = Math.Abs((float)(guessedNumber - secretNumber)/(_numberGenerator.Min - secretNumber));

            _result = fraction switch
            {
                < 0.33f => -1,
                < 0.66f => -2,
                _ => -3
            };
        }

        return _result;
    }
}