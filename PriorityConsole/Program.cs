using System;
using PriorityQueue;
using PriorityQueueLib;

namespace BinaryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IPriorityQueue.PriorityQueueTester.TestPriorityQueue(() => new PriorityQueue<int>(), () => new PriorityQueue<string>());
            Console.ReadLine();
        }
    }
}
