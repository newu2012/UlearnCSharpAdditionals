using System.Diagnostics;
using System.Text;

namespace Recursion;

public class Program
{
    //https://qna.habr.com/answer?answer_id=32038
    //  Порою достаточно простого цикла, с ним и работать проще и нет проблем со стеком.
    //  Еще, лучше все таки в цикле решать задачи, где результат следующего полностью зависит
    //  от результата предыдущего (например, факториал).

    //  При других задачках (например, обход вложенных каталогов),
    //  когда при этом у каждого имеется ряд своих отдельных переменных
    //  (например, количество файлов в данном каталоге), или асинхронных потоков,
    //  то поддерживать легче будет рекурсию.

    //  Да и рекурсия в данном случае будет удобнее,
    //  потому что обход одного каталога совсем не зависит от результатов обхода другого соседнего каталога,
    //  и они могут работать параллельно, независимо друг от друга. А затем в конце просто объединяют все свои результаты.
    //
    //  Еще рекурсия будет эффективна, если рекурсивная функция кешируемая,
    //  например, она запоминает результат и при следующем запросе просто возвращается кешированный вариант.
    public static void Main()
    {
        //  В чём идея подхода «Разделяй и властвуй» к проектированию алгоритмов?
        //  1. Разбить всю задачу на несколько подзадач меньшего размера.
        //  2. Научиться решать задачи для задач минимального размера.
        //  3. Решить каждую подзадачу тем же способом.
        //  4. Объединить решения подзадач в решение целой задачи.

        //  Как можно посчитать сумму элементов массива без циклов и библиотечных функций?
        TryRecursiveSum();

        //  Нарисуй дерево рекурсивных вызовов для SecretRecursion(2, 9).
        //  Напиши, что ищет этот алгоритм.
        Console.WriteLine(SecretRecursion(2, 3));
        Console.WriteLine(SecretRecursion(2, 9));
        Console.WriteLine(SecretRecursion(2, 32));
        Console.WriteLine(SecretRecursion(3, 3));
        Console.WriteLine(SecretRecursion(10, 6));
    }

    private static void TryRecursiveSum()
    {
        var arrayToSum = new[] { 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
        var simpleSum = arrayToSum.Sum();
        var recursiveSum = SumArray(arrayToSum, arrayToSum.Length - 1);
        Console.WriteLine($"{simpleSum} == {recursiveSum} // {simpleSum == recursiveSum}");
    }

    private static int SumArray(int[] array, int position)
    {
        if (position == 0)
            return array[position];

        return array[position] + SumArray(array, position - 1);
    }

    private static int SecretRecursion(int a, int n)
    {
        if (n == 0)
            return 1;
        if (n % 2 == 1)
            return SecretRecursion(a, n - 1) * a;

        var b = SecretRecursion(a, n / 2);
        return b * b;
    }
}