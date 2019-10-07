using System;
using PriorityQueue;
using BinaryTreeLib;

namespace BinaryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IPriorityQueue.PriorityQueueTester.TestPriorityQueue(() => new BinaryTree<int>(), () => new BinaryTree<string>());
        }
    }
}
