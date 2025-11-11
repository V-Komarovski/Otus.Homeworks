namespace Otus.Homeworks.HW7;

/// <summary>
/// Тестовый класс для сериализации.
/// </summary>
internal class F
{
    public int I1 { get; private set; }
    public int I2 { get; private set; }
    public int I3 { get; private set; }
    public int I4 { get; private set; }
    public int I5 { get; private set; }

    public static F Get() => new() { I1 = 1, I2 = 2, I3 = 3, I4 = 4, I5 = 5, };
}