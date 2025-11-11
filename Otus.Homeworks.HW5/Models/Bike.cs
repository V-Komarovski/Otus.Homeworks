namespace Otus.Homeworks.HW5.Models;

internal class Bike(string color, int maxSpeed) : Vehicle(color), ICloneable, IMyCloneable<Bike>
{
    public int MaxSpeed { get; } = maxSpeed;

    object ICloneable.Clone()
    {
        return DeepClone();
    }

    public override Bike DeepClone()
    {
        return new Bike(Color, MaxSpeed);
    }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}; {nameof(Color)}: {Color}; {nameof(MaxSpeed)}: {MaxSpeed}";
    }
}