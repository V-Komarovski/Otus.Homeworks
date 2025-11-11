using Otus.Homeworks.HW6.GuessNumber;
using Otus.Homeworks.HW6.GuessNumber.Generators;
using Otus.Homeworks.HW6.GuessNumber.Validators;

namespace Otus.Homeworks.HW6;

internal class ConsoleGame
{
    private Game _gameInstance = null!;
    private ResultDto _result = null!;

    /// <summary>
    /// Старт игры в консоли
    /// </summary>
    /// <param name="generatorNumber">Генератор числа</param>
    /// <param name="validator">валидатор</param>
    internal void Start(IGeneratorNumber generatorNumber, IValidator validator)
    {
        var needExit = false;
        while (!needExit)
        {
            Console.Clear();
            Console.WriteLine("Игра: Угадай число");
            Console.WriteLine("Выберите вариант игры:");
            Console.WriteLine("С ограниченным числом попыток нажмите 1");
            Console.WriteLine("С неограниченным числом попыток нажмите 2");
            Console.WriteLine("Для выхода из игры нажмите ESC: ");
            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.Escape:
                    needExit = true;
                    break;
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    PlayGame(generatorNumber, validator, true);
                    break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    PlayGame(generatorNumber, validator);
                    break;
            }
        }
    }

    /// <summary>
    /// Обеспечивает корректный ввод числа с консоли
    /// </summary>
    /// <param name="message">Текст - приглашение</param>
    /// <returns></returns>
    private static int InputNumber(string message)
    {
        Console.Clear();
        var result = 0;
        var outPromt = true;
        var inputString = string.Empty;

        while (true)
        {
            SetNormalColor();
            if (outPromt)
            {
                Console.WriteLine($"{message}: ");
                outPromt = false;
            }

            try
            {
                var consoleKeyInfo = Console.ReadKey();

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        return result;
                    case ConsoleKey.Enter:
                        result = Convert.ToInt32(inputString);
                        return result;
                    default:
                        inputString += consoleKeyInfo.KeyChar;
                        break;
                }
            }
            catch (Exception ex) when (ex is FormatException or OverflowException)
            {
                SetErrorColor();
                Console.WriteLine("Вы ввели не число!");
                outPromt = true;
                inputString = string.Empty;
            }
        }
    }

    /// <summary>
    /// Установка нормального цвета текста консоли
    /// </summary>
    private static void SetNormalColor()
    {
        Console.ResetColor();
    }

    /// <summary>
    /// Установка цвета текста консоли при возникновении ошибки
    /// </summary>
    private static void SetErrorColor()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    /// <summary>
    /// Запуск игры в консоли
    /// </summary>
    /// <param name="generator">Генератор числа</param>
    /// <param name="validator">Валидатор</param>
    /// <param name="limitSteps">Если false, то нет ограничений на количество попыток</param>
    private void PlayGame(IGeneratorNumber generator, IValidator validator, bool limitSteps = false)
    {
        generator.Min = InputNumber("Задайте нижнюю границу диапазона чисел");
        generator.Max = InputNumber("Задайте верхнюю границу диапазона чисел");

        var limit = 0;
        if (limitSteps)
        {
            limit = InputNumber("Задайте количество попыток");
        }

        _gameInstance = new Game(generator, validator, limit);
        _result = _gameInstance.Play();

        GuessNumber();
        EndGame();
    }

    /// <summary>
    /// Запускает механизм отгадывания числа
    /// </summary>
    private void GuessNumber()
    {
        var outPromt = true;
        var inputString = string.Empty;
        Console.Clear();
        while (true)
        {
            SetNormalColor();
            try
            {
                if (outPromt)
                {
                    Console.WriteLine("Введите число: ");
                    outPromt = false;
                }

                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Enter:
                        _result = _gameInstance.Check(Convert.ToInt32(inputString));
                        inputString = string.Empty;
                        Console.WriteLine(_gameInstance.Validator.CreateValidatorMessage());
                        if (_result.IsActivePlay == false) return;
                        break;
                    default:
                        inputString += keyInfo.KeyChar;
                        break;
                }
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                SetErrorColor();
                Console.WriteLine("Вы ввели не число!!!");
                outPromt = true;
                inputString = string.Empty;
            }
        }
    }

    /// <summary>
    /// Завершение игры
    /// </summary>
    private void EndGame()
    {
        Console.WriteLine("Игра окончена");
        Console.WriteLine($"Результат игры: {(_result.GameResult ? "Победа" : "Поражение")}");
        Console.WriteLine("Параметры пройденной игры:");
        Console.WriteLine($"Диапазон чисел для загадывания числа: {_result.Min}...{_result.Max}");
        Console.WriteLine($"Количество попыток отгадать число: {(_result.Limit is 0 ? "Неограниченно" : _result.Limit)}");
        Console.WriteLine($"Загаданное число: {_result.Secret}\n\n");

        Console.WriteLine("Для продолжения нажмите любую клавишу");
        Console.ReadKey();
    }
}