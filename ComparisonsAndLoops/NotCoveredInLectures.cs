namespace ComparisonsAndLoops;

public static class NotCoveredInLectures
{
    public static void RunAllUncoveredFeatures()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        SimpleSwitch(1);
        SimpleSwitch(3);
        SimpleSwitch(5);
        SimpleSwitch(10);

        var fromSwitch1 = GetValueFromSwitch(1, 10, 5);
        var fromSwitch2 = GetValueFromSwitch(2, 5, 10);
        var fromSwitch3 = GetValueFromSwitch(3, 5, 7);
        var fromSwitch4 = GetValueFromSwitch(5, 2, 15);

        var tinySwitch1 = GetValueFromTinySwitch(1, 10, 5);
        var tinySwitch2 = GetValueFromTinySwitch(2, 5, 10);
        var tinySwitch3 = GetValueFromTinySwitch(3, 5, 7);
        var tinySwitch4 = GetValueFromTinySwitch(5, 2, 15);

        var whatIsGreater1 = WhatIsGreater(100, -50);
        var whatIsGreater2 = WhatIsGreater(-100, -50);

        string? newEmptyString = null;
        Console.WriteLine(newEmptyString ?? "Nothing is there");
        Console.WriteLine(newEmptyString?.Length ?? 100);
        newEmptyString = "Something!";
        Console.WriteLine(newEmptyString ?? "Nothing is there");
        Console.WriteLine(newEmptyString?.Length ?? 100);

        var AreEqual1 = AreThisStringsEqual("Ulearn", "Ulearn");
        var AreEqual2 = AreThisStringsEqual("Ulearn", "uLeArN");
        var AreEqual3 = AreThisStringsEqualWithLowering("Ulearn", "uLeArN");

        var баллыЗаUlearnУспевающим = БаллЗаUlearn(100, 20);
        var баллыЗаUlearnСтарающимся = БаллЗаUlearn(80, 10);
        var баллыЗаUlearnОтсутствующим = БаллЗаUlearn(60);

        var students = new double[10];
        var rand = new Random();
        for (var studentScore = 0; studentScore < students.Length; studentScore++)
        {
            students[studentScore] = rand.NextDouble() * 40;
            Console.WriteLine(students[studentScore]);
        }

        students = AddNewScores(students);
        Console.WriteLine("Выставил новые баллы в БРС");
        foreach (var studentScore in students)
        {
            Console.WriteLine(studentScore);
        }

        Console.WriteLine();
        var numberString = 123456789.ToString();
        foreach (var character in numberString)
        {
            Console.WriteLine(character);
        }

        var notSoGoodStudentCurrentScore = 0;
        var notSoGoodStudentExpectedScore = 60;
        УчитьUlearn(notSoGoodStudentCurrentScore, notSoGoodStudentExpectedScore);

        var goodStudentCurrentScore = 80;
        var goodStudentExpectedScore = 80;

        УчитьUlearn(goodStudentCurrentScore, goodStudentExpectedScore);
    }

    private static void SimpleSwitch(int number)
    {
        switch (number)
        {
            case 1:
                Console.WriteLine("case 1");
                goto case 5; // переход к case 5
            case 3:
                Console.WriteLine("case 3");
                break;
            case 5:
                Console.WriteLine("case 5");
                break;
            // default - в любом другом случае
            default:
                Console.WriteLine("default");
                break;
        }
    }

    private static int GetValueFromSwitch(int operation, int firstNumber, int secondNumber)
    {
        switch (operation)
        {
            case 1: return firstNumber + secondNumber;
            case 2: return firstNumber - secondNumber;
            case 3: return firstNumber * secondNumber;
            default: return 0;
        }

        // Если нужно сохранить результат switch'а в переменную
        var result = operation switch
        {
            1 => firstNumber + secondNumber,
            2 => firstNumber - secondNumber,
            3 => firstNumber * secondNumber,
            _ => 0
        };
        return result;

        // Первый switch в методе можно написать ещё проще,
        // но так пока что нельзя сдавать на Ulearn - там старая версия C#
        return operation switch
        {
            1 => firstNumber + secondNumber,
            2 => firstNumber - secondNumber,
            3 => firstNumber * secondNumber,
            _ => 0
        };
    }

    private static int GetValueFromTinySwitch(int operation, int firstNumber, int secondNumber) => operation switch
    {
        1 => firstNumber + secondNumber,
        2 => firstNumber - secondNumber,
        3 => firstNumber * secondNumber,
        _ => 0
    };

    private static int WhatIsGreater(int first, int second) => first >= second ? first : second;

    private static bool AreThisStringsEqual(string first, string second) => first == second;

    private static bool AreThisStringsEqualWithLowering(string first, string second) =>
        string.Equals(first, second, StringComparison.CurrentCultureIgnoreCase);

    private static double БаллЗаUlearn(double coefficient, int offset = 0)
    {
        var rand = new Random();
        var forUlearn = Math.Round(rand.NextDouble() * coefficient) + offset;

        return forUlearn > 100 ? 100 : forUlearn;
    }

    private static double[] AddNewScores(double[] students)
    {
        for (var student = 0; student < students.Length; student++)
        {
            students[student] *= 1.5;
        }

        return students;
    }

    private static void УчитьUlearn(int currentScore, int expectedScore)
    {
        do
        {
            currentScore += 5;
            Console.WriteLine($"Поучил ulearn, теперь у меня {currentScore} баллов!");
        } while (currentScore < expectedScore);

        Console.WriteLine($"Набрал {currentScore} баллов, теперь можно и отдохнуть.");
    }
}