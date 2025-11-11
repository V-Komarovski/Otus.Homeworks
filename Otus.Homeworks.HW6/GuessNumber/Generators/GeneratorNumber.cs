namespace Otus.Homeworks.HW6.GuessNumber.Generators;

/// <summary>
/// Генератор, основанный на классе Random
/// </summary>
/// <see cref="IGeneratorNumber" />
internal class GeneratorNumber : IGeneratorNumber
{
    public int Min { get; set; }

    public int Max { get; set; }
    public int Generate()
    {
        var random = new Random();
        return random.Next(Min, Max + 1);
    }
}