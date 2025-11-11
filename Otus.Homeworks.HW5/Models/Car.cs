namespace Otus.Homeworks.HW5.Models;

internal class Car(string color, string model) : Vehicle(color), ICloneable, IMyCloneable<Car>
{
    public string Model { get; set; } = model;

    object ICloneable.Clone()
    {
        return DeepClone();
    }

    public override Car DeepClone()
    {
        return new Car(Color, Model);
    }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}; {nameof(Color)}: {Color}; {nameof(Model)}: {Model}";
    }
}