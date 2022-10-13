namespace Arrays;

public static class NotCoveredInLectures
{
    public static void RunAllUncoveredFeatures()
    {
        int[] numbers = { 1, 2, 3, 5 };

        // получение элемента массива
        Console.WriteLine(numbers[3]); // 5

        // получение элемента массива в переменную
        var n = numbers[1]; // 2
        Console.WriteLine(n); // 2

        // изменим второй элемент массива
        numbers[1] = 505;

        Console.WriteLine(numbers[1]); // 505
        try
        {
            Console.WriteLine(numbers[6]); // ! Ошибка - в массиве только 4 элемента
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // throw; // Расскоментировать, чтобы обратно кинуть ошибку
        }

        // Длина массива
        Console.WriteLine(numbers.Length); // 4

        numbers = new[] { 1, 2, 3, 5 };
        Console.WriteLine(numbers[numbers.Length - 1]); // 5 - первый с конца или последний элемент
        Console.WriteLine(numbers[numbers.Length - 2]); // 3 - второй с конца или предпоследний элемент
        Console.WriteLine(numbers[numbers.Length - 3]); // 2 - третий элемент с конца

        // Начиная с C# 8 можно так, но на ulearn шарп старый, так что красиво делать не получится
        Console.WriteLine(numbers[^1]); // 5 - первый с конца или последний элемент
        Console.WriteLine(numbers[^2]); // 3 - второй с конца или предпоследний элемент
        Console.WriteLine(numbers[^3]); // 2 - третий элемент с конца

        
        // Разворот массива
        Console.WriteLine();
        int[] numbersToReverse = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
        numbersToReverse.ToList().ForEach(Console.WriteLine); // Вывод элементов в консоль, так вроде на ulearn нельзя 
        Console.WriteLine();
        
        ReverseArray(numbersToReverse);
        numbersToReverse.ToList().ForEach(Console.WriteLine);
        Console.WriteLine();
        
        numbersToReverse = ReverseArray(numbersToReverse);
        numbersToReverse.ToList().ForEach(Console.WriteLine);
        
        
        // Что ещё можно делать с массивами
        Console.WriteLine();
        
        // Удобно записывать в них Диапазон чисел
        numbers = Enumerable.Range(1, 10).ToArray(); 
        numbers.ToList().ForEach(Console.WriteLine);

        
        var numbers2 = new int[numbers.Length];
        numbers.CopyTo(numbers2, 0); // Копировать массив по значениям
        
        Console.WriteLine(numbers == numbers2);
        Console.WriteLine(numbers.SequenceEqual(numbers2)); // Сравнение по значению элементов
        
        numbers2[0] = 100;
        Console.WriteLine(numbers == numbers2);
        Console.WriteLine(numbers.SequenceEqual(numbers2));
        Console.WriteLine($"numbers: {numbers[0]} - numbers2: {numbers2[0]}");
    }

    private static int[] ReverseArray(int[] array) // Что есть лишнего в методе?
    {
        var n = array.Length; // длина массива
        var k = n / 2; // середина массива
        int temp; // вспомогательный элемент для обмена значениями
        
        for (var i = 0; i < k; i++)
        {
            temp = array[i];
            array[i] = array[n - i - 1];
            array[n - i - 1] = temp;
        }

        return array;
    }
}