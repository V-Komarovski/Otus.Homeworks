using Otus.Homeworks.HW5.Models;

var directorCar = new Car("Red", "Audi");
var director = new Director("Tom", 35, directorCar, "Development");

var employeeBike = new Bike("Black", 120);
var employee = new Employee("Mike", 20, employeeBike, new TimeSpan(8, 0, 0));

List<Person> persons = [];
for (var i = 0; i < 10; i++)
{
    // Создаём экземпляры клонированием прототипа 
    var newDirector = director.DeepClone();
    // Явно указываем id каждому экземпляру - показывает, что это действительно разные объекты
    newDirector.Id = i;
    newDirector.Transport.Id = i + 5000;

    var newEmployee = employee.DeepClone();
    newEmployee.Id = i + 100;
    newEmployee.Transport.Id = i + 6000;

    persons.Add(newDirector);
    persons.Add(newEmployee);
}

foreach (var person in persons)
{
    Console.WriteLine(person);
}

Console.ReadKey();