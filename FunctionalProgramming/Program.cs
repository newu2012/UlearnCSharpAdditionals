using System.Text;

public record Student(string Name, string Group, double Grade);

public record CoolStudent(string Name, string Group, double Grade, double Coolness) : Student(Name, Group, Grade);

public class StudentClass
{
    public StudentClass(string name, string group, int grade)
    {
        Name = name;
        Group = group;
        Grade = grade;
    }

    public string Name { get; set; }
    public string Group { get; set; }
    public int Grade { get; set; }
}

internal class Program
{
    public static void Main()
    {
        //  Для русского языка в консоли
        Console.OutputEncoding = Encoding.Unicode;

        var students = new List<Student> { new("Вова", "AT-2012", 0) };

        ShowRecords(students);
        ShowLinq(students);
    }

    /// <summary>
    /// https://metanit.com/sharp/tutorial/3.51.php
    /// </summary>
    /// <param name="students"></param>
    private static void ShowRecords(List<Student> students)
    {
        var gosha = new Student("Гоша", "AT-0", 50);
        students.Add(gosha);
        students.WriteAllEntries("Класс с Гошей");

        students.Add(gosha with { Name = "Шиза Гоши" });
        students.WriteAllEntries("Класс с Гошей (x2)");

        Console.WriteLine($"Гоша == Шиза Гоши? {students[1] == students[2]}");
        //  students[2].Name = "Гоша"; - Так сделать нельзя, в этом и прикол Records
        students.Add(gosha);
        students.WriteAllEntries("Два Гошана?????");

        Console.WriteLine($"Гоша == Гоша? {students[1] == students[3]} КАВООО");
        var twoGoshasWithClass = new StudentClass("Гоша", "АТ-0", 50) == new StudentClass("Гоша", "АТ-0", 50);
        Console.WriteLine($"А Гоши на классах равны? {twoGoshasWithClass}");

        var coolGosha = new CoolStudent(gosha.Name, gosha.Group, gosha.Grade, 1000);
        students.Add(coolGosha);
        students.WriteAllEntries("Ага, реально крутой");

        (string coolName, string coolGroup, double coolGrade, double coolCoolness) = coolGosha;
        Console.WriteLine($"Вот это крут: {coolName}, {coolGroup}, {coolGrade}, {coolCoolness}");
    }

    /// <summary>
    /// https://metanit.com/sharp/tutorial/15.2.php
    /// </summary>
    /// <param name="students"></param>
    private static void ShowLinq(List<Student> students)
    {
        //  Nothing :(
    }
}

public static class IEnumerableExtensions
{
    public static void WriteAllEntries<T>(this IEnumerable<T> entries, string description)
    {
        Console.WriteLine();
        Console.WriteLine(description);
        entries.ToList().ForEach(entry => Console.WriteLine(entry));
    }
}