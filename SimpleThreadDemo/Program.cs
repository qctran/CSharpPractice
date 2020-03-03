using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var result = await LongWaitingTaskWrapper();
            var result2 = await LongWaitingTask();
            Console.WriteLine(result);
            Console.WriteLine(result2);
        }

        private static async Task<int> LongWaitingTaskWrapper()
        {
            var result = await LongWaitingTask();
            return result;
        }
        private static async Task<int> LongWaitingTask()
        {
            for (var i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    Console.WriteLine(i+1 + " second");
                }
                else
                {
                    Console.WriteLine(i + 1 + " seconds");
                }
            }
            
            return 1;
        }
    }
}
