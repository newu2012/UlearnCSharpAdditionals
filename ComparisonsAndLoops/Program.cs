using ComparisonsAndLoops;

public class Program
{
    public static void Main()
    {
        // Как можно сократить этот код?
        // if (a == b) return true;
        // else return false;
        ShortenTheCode.LongCode();
        ShortenTheCode.ShortCode();
        
        // Перечислите методы, которые будут вызваны независимо ни от чего.
        // var a = (true && f()) && g() || h();
        var alwaysCalled1 = new AlwaysCalled(true, true, false);
        alwaysCalled1.CallMethods();
        var alwaysCalled2 = new AlwaysCalled(false, false, true);
        alwaysCalled2.CallMethods();
        
        // Найдите такое значение int x, при котором результат двух следующих выражений отличается. Или напишите, что такого нет.
        // 1) (x < 5) || (10 / x == 0)
        // 2) (x < 5) |  (10 / x == 0)
        var differentResults1 = new DifferentResults(x: 10);
        var differentResults2 = new DifferentResults(x: 0);
        try
        {
            // x == 10
            differentResults1.CalculateFirstExpression();
            differentResults1.CalculateSecondExpression();
            // x = 0
            differentResults2.CalculateFirstExpression();
            differentResults2.CalculateSecondExpression();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        // Напишите кусок кода, проверяющий равенство чисел a и b с точностью до константы eps.
        var areEqualsWithEpsilon1 = new AreEqualWithEpsilon(10.001, 10.002, 1e-1);
        var areEquals1 = areEqualsWithEpsilon1.AreEqual();
        var areEqualsWithEpsilon2 = new AreEqualWithEpsilon(10.001, 10.002, 1e-5);
        var areEquals2 = areEqualsWithEpsilon2.AreEqual();
        
        // Когда стоит использовать цикл for, а когда while?
        ForAndWhile.UseFor();
        ForAndWhile.UseWhile();
        
        //Что будет в "a" после этого кода?
        var a = 10;
        while (a > 0)
        {
            a -= 1;
            if (a % 2 == 0)
                break;
        }
        
        Console.WriteLine(a);
        
        // Что будет в "a" после этого кода?
        a = 10;
        while (a > 0)
        {
            a -= 1;
            if (a % 2 == 0)
                continue;
            Console.WriteLine(a);
        }
        
        Console.WriteLine(a);
        
        //  Дополнительные материалы, о которых в лекцих было мало или вообще ничего сказано
        NotCoveredInLectures.RunAllUncoveredFeatures();
    }
}
