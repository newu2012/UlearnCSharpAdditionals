namespace Arrays;

public class Program
{
    static int staticGlobal = 1;
    int globalValueVariable = 123;
    string globalReferenceVariable = "123";

    public static void Main()
    {
        //  Что будет в переменной result?
        var result = new int[] { 1, 2, 3 } == new int[] { 1, 2, 3 };
        
        //  Какое значение получить быстрее в массиве из 1000 элементов: values[0] или values[999]?
        var values = new int[1000];
        Console.WriteLine(values[0]);
        Console.WriteLine(values[999]);
        
        //  Где хранится строка? В куче или на стеке?
        var someString = "";
        
        //  Есть массив bigArray, в нём лежит 100 элементов.
        //  Напишите код который выводит в консоль каждый второй элемент массива.
        var bigArray = Enumerable.Range(1, 100).ToArray();
        for (var i = 0; i < bigArray.Length; i++)
            if (i % 2 == 0)
                Console.WriteLine(bigArray[i]);
        
        
        
        //  Что такое ссылочные типы и типы значения. Какие типы к чему относятся.
        //  Типы значений (Value types)
        var simpleNumber = 1;
        var numberWithFloatPoint = 1.0;
        var boolean = false;
        var character = 'A';

        //  Ссылочные типы (Reference types)
        var strEmpty1 = "";
        var strEmpty2 = string.Empty;
        var array = new int[5];
        var list = new List<int>();

        
        //  Что такое стек и куча. Что происходит при вызове метода. Что происходит, если из метода вызвать самого себя. Почему стек ограничен.
        IncrementTo(simpleNumber, 100);

        
        //  Как хранятся в памяти типы значения. Их значения по умолчанию.
        int someInt;
        double someDouble;
        bool someBool;
        char someChar;

        
        //  Как хранятся в куче ссылочные типы. Как хранятся массивы ссылочных типов и массивы типов значений.
        //  (Удобно рисовать таблицу сравнения типов, подобно той, что была в видеолекциях.)
        int[] intArray;
        var intArray1 = new int[5];
        var intArray2 = new[] { 1, 2, 3, 4, 5 };

        int[] strArray;
        var strArray1 = new string[5];
        var strArray2 = new[] { "1", "2", "3", "4", "5" };

        
        //  Как хранится в памяти ссылка, что такое null.
        //  Как хранятся пустая строка и пустой массив.
        //  (Ссылка по сути тип значения число — адрес в памяти области в куче.)
        string str;
        string str1 = "123";
        string str2 = "123";
        str = str1;
        var condStr1 = str == str1;
        var condStr2 = str1 == str2;

        int[] arr;
        int[] arr1 = new int[5];
        int[] arr2 = new int[5];
        arr = arr1;
        var condArr1 = arr == arr1;
        var condArr2 = arr == arr2;

        
        //  Где хранятся локальные переменные и где «глобальные» статические.
        var localValueVariable = 123;
        var localReferenceVariable = "123";


        // Про сборщик мусора. Он работает, когда захочет.
        // Я хз честно что и как рассказать чтобы было интересно и понятно...
        
        
        //  Дополнительное
        NotCoveredInLectures.RunAllUncoveredFeatures();
    }

    private static void IncrementTo(int numberToIncrement, int expectedNumber)
    {
        numberToIncrement++; // Comment this to fall in Stack Overflow
        Console.WriteLine($"Number is {numberToIncrement}");
        if (numberToIncrement < expectedNumber)
            IncrementTo(numberToIncrement, expectedNumber);
    }
}