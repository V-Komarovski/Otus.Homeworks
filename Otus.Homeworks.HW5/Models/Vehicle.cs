namespace Otus.Homeworks.HW5.Models;

internal class Vehicle(string color) : ICloneable, IMyCloneable<Vehicle>
{
    /// <summary>
    /// Не задаётся при создании экземпляра
    /// </summary>
    public int Id { get; set; }
    public string Color { get; set; } = color;

    public object Clone()
    {
        return DeepClone();
    }

    public virtual Vehicle DeepClone()
    {
        return new Vehicle(Color);
    }
}