using Otus.Homeworks.HW6.GuessNumber.Generators;
using Otus.Homeworks.HW6.GuessNumber.Validators;

namespace Otus.Homeworks.HW6.GuessNumber;

/// <summary>
/// Игра
/// </summary>
internal class Game(
    IGeneratorNumber generatorNumber,
    IValidator validator,
    int limit = 0)
{
    public IValidator Validator { get; init; } = validator;

    /// <summary>
    /// Игра запущена
    /// </summary>
    private bool _playGame;
    
    /// <summary>
    /// Ограничение  на количество шагов отгадывания
    /// </summary>
    private readonly int _limit = limit;
    
    /// <summary>
    /// загаданное число
    /// </summary>
    private int _secretNumber;
    
    /// <summary>
    /// предполагаемое число
    /// </summary>
    private int _guessedNumber;
    
    /// <summary>
    /// количество попыток отгадывания
    /// </summary>
    private int _steps;
    
    /// <summary>
    /// Результат законченной игры
    /// </summary>
    private bool _gameResult;
    
    /// <summary>
    /// детали отгадывания числа
    /// </summary>
    private int _resultDetail;

    /// <summary>
    /// Запуск игры
    /// </summary>
    /// <returns>Результирующее описание игры</returns>
    public ResultDto Play()
    {
        _secretNumber = generatorNumber.Generate();
        _steps = 0;
        _playGame = true;

        return GetResult();
    }

    /// <summary>
    /// Проверка предполагаемого числа на равенство загаданному числу
    /// </summary>
    /// <param name="guessedNumber">Предполагаемое число</param>
    /// <returns>Результирующее описание игры</returns>
    public ResultDto Check(int guessedNumber)
    {
        if (_playGame == false)
        {
            throw new InvalidOperationException("Игра не запущена");
        }

        _guessedNumber = guessedNumber;
        _resultDetail = Validator.Validate(guessedNumber, _secretNumber);
        _steps++;

        _gameResult = _resultDetail == 0;

        if (_resultDetail == 0 || (_limit > 0 && _limit == _steps))
        {
            _playGame = false;
        }

        return GetResult();
    }

    private ResultDto GetResult() =>
        new()
        {
            Min = generatorNumber.Min,
            Max = generatorNumber.Max,
            IsActivePlay = _playGame,
            GameResult = _gameResult,
            ResultDetail = _resultDetail,
            Secret = _playGame == false ? _secretNumber : null,
            Steps = _steps,
            Limit = _limit,
            GuessNumber=_guessedNumber
                
        };
}