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
    class Parallel
    {
        public static void WaitAll(WaitCallback[] tasks)
        {
            foreach (var task in tasks)
                ThreadPool.QueueUserWorkItem(task);

            int availableThreads;
            int maxNumThread;
            ThreadPool.GetMaxThreads(out maxNumThread, out _);
            do
            {
                ThreadPool.GetAvailableThreads(out availableThreads, out _);
            } while (maxNumThread != availableThreads);
        }
    }
}