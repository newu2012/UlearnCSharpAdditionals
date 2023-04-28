using System.Diagnostics;
using System.Text;

namespace MultithreadedProgramming;

public class Program
{
    private static object lockObjectForRaceConditionWithLock = new();

    static async Task Main(string[] args)
    {
        //  Для русского языка в консоли
        Console.OutputEncoding = Encoding.Unicode;

        SimpleIncrement();
        LockedIncrement();
        InterlockedIncrement();
        InterlockedRaceCondition();
        LockWithoutRaceCondition();
        // DeadLock();
        ExplainAsync();

        Console.ReadKey();
    }

    private static void SimpleIncrement()
    {
        var count = 0;
        var task1 = Task.Run(() =>
        {
            for (var i = 0; i < 500; i++)
            {
                Thread.Sleep(1);
                count++;
            }
        });
        var task2 = Task.Run(() =>
        {
            for (var i = 0; i < 500; i++)
            {
                Thread.Sleep(1);
                count++;
            }
        });
        Task.WaitAll(task1, task2);
        Console.WriteLine(count);
    }

    private static void LockedIncrement()
    {
        //  Мы не можем заворачивать в lock структуры, так как при их помещении в lock создаётся новый объект,
        //  так же как и при передаче int'ов в методы
        //  Чтобы использовать их между потоками чаще всего:
        //  1. Повышают класс до object
        //  2. Хранят в отдельном объекте ссылочного типа
        //  3. Используют специальные методы, типа Interlocked.Increment()
        object count = 0;
        var task1 = Task.Run(() =>
        {
            for (var i = 0; i < 500; i++)
            {
                Thread.Sleep(1);
                lock (count)
                    count = (int)count + 1;
            }
        });
        var task2 = Task.Run(() =>
        {
            for (var i = 0; i < 500; i++)
            {
                Thread.Sleep(1);
                lock (count)
                    count = (int)count + 1;
            }
        });
        Task.WaitAll(task1, task2);
        Console.WriteLine(count);
    }

    //  Быстрее чем lock и простой инкремент внутри
    private static void InterlockedIncrement()
    {
        var count = 0;
        var task1 = Task.Run(() =>
        {
            for (var i = 0; i < 500; i++)
            {
                Thread.Sleep(1);
                Interlocked.Increment(ref count);
            }
        });
        var task2 = Task.Run(() =>
        {
            for (var i = 0; i < 500; i++)
            {
                Thread.Sleep(1);
                Interlocked.Increment(ref count);
            }
        });
        Task.WaitAll(task1, task2);
        Console.WriteLine(count);
    }

    private static void InterlockedRaceCondition()
    {
        var times = 1_000_000;
        long incrementValue = 0;
        long sumValue = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        Parallel.For(0, times, _ =>
        {
            Interlocked.Increment(ref incrementValue);
            Interlocked.Add(ref sumValue, incrementValue);
        });

        stopwatch.Stop();
        Console.WriteLine($"Increment Value With Interlocked: {incrementValue}");
        Console.WriteLine($"Sum Value With Interlocked: {sumValue}");
        Console.WriteLine($"Time for Interlocked: {stopwatch.ElapsedMilliseconds}ms");
    }

    private static void LockWithoutRaceCondition()
    {
        var times = 1_000_000;
        long incrementValue = 0;
        long sumValue = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        Parallel.For(0, times, _ =>
        {
            lock (lockObjectForRaceConditionWithLock)
            {
                incrementValue++;
                sumValue += incrementValue;
            }
        });

        stopwatch.Stop();
        Console.WriteLine($"Increment Value With Lock: {incrementValue}");
        Console.WriteLine($"Sum Value With Lock: {sumValue}");
        Console.WriteLine($"Time for Lock: {stopwatch.ElapsedMilliseconds}ms");
    }

    private static void DeadLock()
    {
        object count1 = 777;
        object count2 = 2012;

        void ObliviousFunction()
        {
            lock (count1)
            {
                Thread.Sleep(1000); //  Пропускаем второй метод вперёд для создания дедлока
                lock (count2)
                {
                    //  Делаем что-то
                    count2 = (int)count2 + 1;
                }
            }
        }

        void BlindFunction()
        {
            lock (count2)
            {
                Thread.Sleep(1000); //  Фиксируем прибыль
                lock (count1)
                {
                    //  Делаем что-то
                    count1 = (int)count1 + 1;
                }
            }
        }

        var taskObliviousFunction = Task.Run(() =>
        {
            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(1);
                ObliviousFunction();
            }
        });
        var taskBlindFunction = Task.Run(() =>
        {
            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(1);
                BlindFunction();
            }
        });

        Task.WaitAll(taskObliviousFunction, taskBlindFunction);
        Console.WriteLine($"c1: {count1}; c2: {count2}");
    }

    //  https://metanit.com/sharp/tutorial/13.3.php
    private static async void ExplainAsync()
    {
        await ShowSimpleExampleAsync();

        var names = new List<string> { "Rita", "Vasya", "Zhenya" };

        TrySayHiInForEach(names);
        Console.WriteLine();

        await TrySayHiForEachOtherWay(names);
        Console.WriteLine();

        await TrySayHiThirdWay(names);
    }

    private static async Task ShowSimpleExampleAsync()
    { // вызов асинхронного метода
        await PrintAsync();
        Console.WriteLine("Некоторые действия в методе Main");

        void Print()
        {
            // имитация продолжительной работы
            Thread.Sleep(3000);
            Console.WriteLine("Hello METANIT.COM");
        }

        // определение асинхронного метода
        async Task PrintAsync()
        {
            Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
            await Task.Run(Print); // выполняется асинхронно
            Console.WriteLine("Конец метода PrintAsync");
        }
    }

    private static async Task<string> SayHiAsync(string name)
    {
        //  Обычно задержку теперь делают так
        await Task.Delay(3000);
        // await Task.Delay(new Random().Next(1000, 5000)); // Помогает понять работу
        return $"Hi {name}!!!";
    }

    private static void TrySayHiInForEach(List<string> names) =>
        names.ForEach(async name => Console.WriteLine(await SayHiAsync(name)));

    private static async Task TrySayHiForEachOtherWay(List<string> names)
    {
        foreach (var name in names)
            Console.WriteLine(await SayHiAsync(name));
    }

    private static async Task TrySayHiThirdWay(List<string> names)
    {
        var nameHiTasks = new List<Task<string>>();
        foreach (var name in names)
            nameHiTasks.Add(SayHiAsync(name));
        foreach (var hiTask in nameHiTasks)
            Console.WriteLine(await hiTask);
    }
}