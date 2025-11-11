namespace Otus.Homeworks.HW5.Models;

internal class Director(string name, int age, Vehicle transport, string department)
    : Person(name, age, transport), ICloneable, IMyCloneable<Director>
{
    public string Department { get; set; } = department;

    public new object Clone()
    {
        return DeepClone();
    }

    public new Director DeepClone()
    {
        var transport = Transport.DeepClone();
        return new Director(Name, Age, transport, Department);
    }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}; {nameof(Name)}: {Name}; {nameof(Age)}: {Age}; {nameof(Department)}: {Department}; {nameof(Transport)}: {Transport}";
    }
}