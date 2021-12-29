using System;
using System.Threading;

//Задание 7
/*Создать на языке C# статический метод класса Parallel.WaitAll,
который:
-принимает в параметрах массив делегатов; -выполняет все указанные делегаты параллельно с помощью пула
потоков;
-дожидается окончания выполнения всех делегатов.
Реализовать простейший пример использования метода
Parallel.WaitAll.*/

namespace SeventhTask
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback[] tasks = CreateTasks(10);
            Parallel.WaitAll(tasks);
        }

        private static WaitCallback[] CreateTasks(int taskNumber)
        {
            WaitCallback[] tasks = new WaitCallback[taskNumber];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = obj =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Task in {Thread.CurrentThread.ManagedThreadId} completed.");
                };
            }
            return tasks;
        }
    }
}