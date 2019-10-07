using NUnit.Framework;
using BinaryTreeLib;
using System.Collections.Generic;
using System;

namespace BinaryTreeTest
{
    public class Tests
    {
        [Test]
        public void TestQueueAddIntNode()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            List<int> intList = new List<int>() { 5, 7, 2, 11, 15, 6, 8 };

            foreach (int i in intList)
            {
                bt.Add(i);
            }

            Assert.IsTrue(bt.Peek() == 2);
        }

        [Test]
        public void TestPeekEmpty()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            try
            {
                bt.Peek();
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestPop()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            List<int> intList = new List<int>() { 5, 7, 2, 11, 15, 6, 8 };

            foreach (int i in intList)
            {
                bt.Add(i);
            }

            Assert.IsTrue(bt.Pop() == 2);
            Assert.IsTrue(bt.Pop() == 5);
            Assert.IsTrue(bt.Pop() == 6);
            Assert.IsTrue(bt.Pop() == 7);
            Assert.IsTrue(bt.Pop() == 8);
            Assert.IsTrue(bt.Pop() == 11);
            Assert.IsTrue(bt.Pop() == 15);
        }
    }
}