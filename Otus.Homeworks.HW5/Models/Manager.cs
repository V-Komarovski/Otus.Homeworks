namespace Otus.Homeworks.HW5.Models;

internal class Manager(string name, int age, Vehicle transport, string aim)
    : Person(name, age, transport), ICloneable, IMyCloneable<Manager>
{
    /// <summary>
    /// Целевой план
    /// </summary>
    public string Aim { get; set; } = aim;

    public new object Clone()
    {
        return DeepClone();
    }

    public new Manager DeepClone()
    {
        var transport = Transport.DeepClone();
        return new Manager(Name, Age, transport, Aim);
    }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}; {nameof(Name)}: {Name}; {nameof(Age)}: {Age}; {nameof(Aim)}: {Aim}; {nameof(Transport)}: {Transport}";
    }
}