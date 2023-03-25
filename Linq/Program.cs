using System.Text;

internal class Program
{
    public static void Main()
    {
        //  Для русского языка в консоли
        Console.OutputEncoding = Encoding.Unicode;

        var method1Result = Example(new[] { "Ну привет", "Как дела?", "Ну пойдёт", "Ну привет", "Как дела?", "Как дела?" });
        var firstArray = new[] { 1, 2, 3 };
        var secondArray = new[] { 4, 5, 6 };
        var method2Result = ExampleWithGeneric(new[] { firstArray, secondArray, firstArray });
        var method3Result = RefactoredExample(new[] { "Ну привет", "Как дела?", "Ну пойдёт", "Ну привет", "Как дела?", "Как дела?" });
        var method4Result = RefactoredExampleWithGeneric(new[] { "Ну привет", "Как дела?", "Ну пойдёт", "Ну привет", "Как дела?", "Как дела?" });
        var method4Result2 = RefactoredExampleWithGeneric(new[] { firstArray, secondArray, firstArray });
    }

    private static string? Example(string[] a)
    {
        return a
            .SelectMany(x => a
                .Where(y => y == x)
                .Skip(1))
            .Min();
    }

    private static T? ExampleWithGeneric<T>(T[] a)
    {
        return a
            .SelectMany(x => a
                .Where(y => y?.Equals(x) ?? false)
                .Skip(1))
            .Min();
    }

    private static string? RefactoredExample(IEnumerable<string> a)
    {
        return a
            .GroupBy(x => x)
            .Where(g => g.Count() != 1)
            .Min(g => g.Key);
    }
    
    private static T? RefactoredExampleWithGeneric<T>(IEnumerable<T> a)
    {
        return a
            .GroupBy(x => x)
            .Where(g => g.Count() != 1)
            .Min(g => g.Key);
    }
}