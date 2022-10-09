namespace ComparisonsAndLoops;

public class ForAndWhile
{
    public static void UseFor()
    {
        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
    }
    
    public static void UseWhile()
    {
        var firstLiteral = 'a';
        while (firstLiteral != 'w')
        {
            Console.WriteLine(firstLiteral);
            firstLiteral++;
        }
        Console.WriteLine(firstLiteral);
    }
}