using Otus.Homeworks.HW6;
using Otus.Homeworks.HW6.GuessNumber.Generators;
using Otus.Homeworks.HW6.GuessNumber.Validators;

var generator = new GeneratorNumber();
IValidator validator = new SimpleValidator(); // Но можно подложить и HintValidator
var consoleGame = new ConsoleGame();
consoleGame.Start(generator, validator);