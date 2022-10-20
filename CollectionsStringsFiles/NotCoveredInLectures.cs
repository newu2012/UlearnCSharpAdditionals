namespace CollectionsStringsFiles;

public class NotCoveredInLectures
{
    public static void RunAllUncoveredFeatures()
    {
        //  Немного о словарях
        ShowDictionaryAdditionals();

        //  Немного о строках
        ShowStringAdditionals();

        //  Немного о форматировании
        ShowFormattingAdditionals();
    }

    private static void ShowDictionaryAdditionals()
    {
        CountRecurring();
    }

    private static void CountRecurring()
    {
        var students = new Dictionary<string, int>
        {
            { "Макар", 65 },
            { "Маргарет", 69 },
            { "Володимир", 69 },
            { "Дениска", 50 },
        };

        var studentsWithMaxScore = students
            .Where(student => student.Value == students.Values.Max());
        var studentsSortedByOrdinal = studentsWithMaxScore
            .OrderBy(student => student.Key, StringComparer.Ordinal);
        var firstStudentWithMaxScore = studentsSortedByOrdinal
            .First();
        var firstStudentName = firstStudentWithMaxScore.Key;

        Console.WriteLine("\nСреди студентов:");
        foreach (var student in students)
            Console.WriteLine($"{student.Key} - {student.Value} баллов");

        Console.WriteLine($"Больше всего баллов у {firstStudentName} - целых {firstStudentWithMaxScore.Value} баллов!");
    }

    private static void ShowStringAdditionals()
    {
        SplitString();
    }

    private static void SplitString()
    {
        var sentenceDelimiter = '?';
        var wordDelimiter = ' ';

        var text =
            "Почему половина людей, которых я встречаю на пути, тут же решают напасть на вооруженного ведьмака? Может, у меня с лицом что не то?";

        var wordsInSentences = new List<List<string>>();
        var sentences = text.Split(sentenceDelimiter);

        Console.WriteLine();
        foreach (var sentence in sentences)
        {
            var wordsInSentence = sentence.Split(wordDelimiter).ToList();
            wordsInSentences.Add(wordsInSentence);
        }

        foreach (var sentence in wordsInSentences)
        {
            foreach (var word in sentence)
            {
                Console.Write($"{word}{wordDelimiter}");
            }

            Console.WriteLine($"{sentenceDelimiter}");
        }
    }

    private static void ShowFormattingAdditionals()
    {
        StringFormatting();
        StringInterpolation();
    }

    private static void StringFormatting()
    {
        SimpleFormatting();
        CurrencyFormatting();
        IntFormatting();
        DoubleFormatting();
    }

    private static void SimpleFormatting()
    {
        string name = "Tom";
        int age = 23;

        Console.WriteLine("Имя: {0}  Возраст: {1}", name, age);
        // консольный вывод
        // Имя: Tom  Возраст: 23
        
        string output = string.Format("Имя: {0}  Возраст: {1}", name, age);
        Console.WriteLine(output);
    }
    
    private static void CurrencyFormatting()
    {
        double number = 23.7;
        string result = string.Format("{0:C0}", number);
        Console.WriteLine(result); // 24 р.
        string result2 = string.Format("{0:C2}", number);
        Console.WriteLine(result2); // 23,70 р.
    }

    private static void IntFormatting()
    {
        int number = 23;
        string result = string.Format("{0:d}", number);
        Console.WriteLine(result); // 23
        string result2 = string.Format("{0:d4}", number);
        Console.WriteLine(result2); // 0023
    }

    private static void DoubleFormatting()
    {
        int number = 23;
        string result = string.Format("{0:f}", number);
        Console.WriteLine(result); // 23,00
 
        double number2 = 45.08;
        string result2 = string.Format("{0:f4}", number2);
        Console.WriteLine(result2); // 45,0800
 
        double number3 = 25.07;
        string result3 = string.Format("{0:f1}", number3);
        Console.WriteLine(result3); // 25,1
    }
    
    private static void StringInterpolation()
    {
        string name = "Tom";
        int age = 23;
 
        Console.WriteLine($"Имя: {name}  Возраст: {age}");
        // консольный вывод
        // Имя: Tom  Возраст: 23
        
        int x = 8;
        int y = 7;
        string result = $"{x} * {y} = {Multiply(x, y)}";
        Console.WriteLine(result); // 8 * 7 = 56
 
        int Multiply(int a, int b) => a * b; // Локальный метод
        
        long number = 19876543210;
        Console.WriteLine($"{number:+# ### ### ## ##}"); // +1 987 654 32 10
        
        string name2 = "Tom";
        int age2 = 23;
 
        Console.WriteLine($"Имя: {name2, -5} Возраст: {age2}"); // пробелы после
        Console.WriteLine($"Имя: {name2, 5} Возраст: {age2}"); // пробелы до
    }
}