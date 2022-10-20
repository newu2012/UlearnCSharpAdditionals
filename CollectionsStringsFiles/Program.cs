using System.Diagnostics;
using System.Text;

namespace CollectionsStringsFiles;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        //  Чем отличается строка (string) от массива символов (char[])?
        StringVsCharArray();

        //  Когда стоит использовать string и когда нужно использовать StringBuilder?
        StringVsStringBuilder();

        //  Что будет в переменной s после выполнения метода SetAndUpdate? Опиши почему именно так.
        SetAndUpdate();

        //  Хорош ли этот код, почему?
        WriteAllTextToFile();

        //  Что выведет этот код? Что делает эта программа?
        //  Не надо обдумывать что именно делает OpenNewFile, достаточно просто предположить из названия.
        TryOpenNewFile();

        //  Допишите код, чтобы при помощи форматирования строк вывести на консоль строчку как показано ниже.
        //  Последнее (итоговое) число должно вычисляться.
        //  (6 * 7) % 4 = 2
        FormatAndPrintString();
        
        //  Дополнительное
        NotCoveredInLectures.RunAllUncoveredFeatures();
    }

    private static void StringVsCharArray()
    {
        var simpleString = "Ulearn упал... Да здравствует Ulearn!";
        var simpleCharArray = new[] { 'U', 'l', 'e', 'a', 'r', 'n' };

        // simpleString[0] = 'u'; // Так делать не надо. Строка - неизменяема (иммутабельна)
        simpleCharArray[0] = 'u'; // А так можно
        
        var otherCharArray = simpleString.ToArray();
        var otherString = simpleCharArray.ToString(); // Так делать не надо
        otherString = new string(simpleCharArray);
    }

    private static void StringVsStringBuilder()
    {
        var stopwatch = new Stopwatch();
        const int numbersForStringBuilder = 1_000_000;
        const int numbersForString = 10_000;

        var simpleStringBuilder = new StringBuilder();

        stopwatch.Start();
        for (var i = 0; i < numbersForStringBuilder; i++)
            simpleStringBuilder.Append($"{i}, ");
        stopwatch.Stop();

        Console.WriteLine($"Elapsed {stopwatch.ElapsedMilliseconds} milliseconds");

        var simpleString = "";

        stopwatch.Restart();
        for (var i = 0; i < numbersForString; i++)
            simpleString += $"{i}, ";
        stopwatch.Stop();

        Console.WriteLine($"Elapsed {stopwatch.ElapsedMilliseconds} milliseconds");
    }

    //  Если хотим чтобы значение действительно менялось, то надо добавить "ref"
    //  1) Перед аргументом при вызове метода;
    //  2) Перед типом параметра в сигнатуре вызываемого метода
    private static void SetAndUpdate()
    {
        var s = "xyz";
        UpdateString(s);
    }

    private static void UpdateString(string s)
    {
        s = "abc";
    }

    private static void WriteAllTextToFile()
    {
        var badPath = "C:\test\new.txt";
        var goodPath = "C:\\test\\new.txt";
        var gigaChadPath = Path.Join(Directory.GetCurrentDirectory(), "new.txt");

        Console.WriteLine(badPath);
        Console.WriteLine(goodPath);
        Console.WriteLine(gigaChadPath);

        File.WriteAllText(gigaChadPath, "123456");
    }

    private static void TryOpenNewFile()
    {
        Dictionary<string, string> openWith = new Dictionary<string, string>();
        openWith.Add("txt", "notepad.exe");
        openWith.Add("png", "paint.exe");
        openWith.Add("jpg", "paint.exe");
        openWith.Add("docx", "winword.exe");

        var fileToOpen = "newFile.docx";
        var fileExtension = fileToOpen.Split('.')[1];
        var programToUse = openWith[fileExtension];

        Console.WriteLine(programToUse);
        OpenNewFile(fileToOpen, programToUse);
    }

    private static void OpenNewFile(string fileToOpen, string programToUse)
    {
        Console.WriteLine($"Opening {fileToOpen} with {programToUse}");
    }

    private static void FormatAndPrintString()
    {
        var number1 = 6;
        var number2 = 7;
        var number3 = 4;
        FormatAndPrint(number1, number2, number3);
    }

    private static void FormatAndPrint(int number1, int number2, int number3)
    {
        Console.WriteLine("({0} * {1}) % {2} = {3}", number1, number2, number3, number1 * number2 % number3);
        Console.WriteLine($"({number1} * {number2}) % {number3} = {number1 * number2 % number3}");
    }
}