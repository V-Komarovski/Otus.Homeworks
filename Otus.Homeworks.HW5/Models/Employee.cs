namespace Otus.Homeworks.HW5.Models;

internal class Employee(string name, int age, Vehicle transport, TimeSpan shiftDuration)
    : Person(name, age, transport), ICloneable, IMyCloneable<Employee>
{
    public TimeSpan ShiftDuration { get; set; } = shiftDuration;

    public new object Clone()
    {
        return DeepClone();
    }

    public new Employee DeepClone()
    {
        var transport = Transport.DeepClone();
        return new Employee(Name, Age, transport, ShiftDuration);
    }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}; {nameof(Name)}: {Name}; {nameof(Age)}: {Age}; {nameof(ShiftDuration)}: {ShiftDuration}; {nameof(Transport)}: {Transport}";
    }
}