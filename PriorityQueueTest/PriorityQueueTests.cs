using NUnit.Framework;
using PriorityQueueLib;
using System.Collections.Generic;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PriorityQueueTest
{
    public class Tests
    {
        [Test]
        public void TestQueueAddStrings()
        {
            PriorityQueue<string> pQ = new PriorityQueue<string>();
            string[] stringArr = new string[] { "hej", "hejsan", "biltemakorv", "cykelställ", "cykelställ" };

            foreach (string str in stringArr)
            {
                pQ.Add(str);
            }

            Assert.AreEqual("biltemakorv", pQ.Peek());
        }

        [Test]
        public void TestQueueAddChars()
        {
            PriorityQueue<char> pQ = new PriorityQueue<char>();
            foreach (char c in "ökjabsdgkjbgb".ToCharArray())
            {
                pQ.Add(c);
            }

            Assert.AreEqual('a', pQ.Peek());
        }
        [Test]
        public void TestQueueAddInts()
        {
            PriorityQueue<int> pQ = new PriorityQueue<int>();
            List<int> intList = new List<int>() { 5, 7, 2, 11, 15, 6, 8 };

            foreach (int i in intList)
            {
                pQ.Add(i);
            }

            Assert.AreEqual(2, pQ.Peek());
        }

        [Test]
        public void TestPopEmpty()
        {
            PriorityQueue<int> pQ = new PriorityQueue<int>();
            try
            {
                pQ.Pop();
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestPeekEmpty()
        {
            PriorityQueue<int> pQ = new PriorityQueue<int>();
            try
            {
                pQ.Peek();
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestPop()
        {
            PriorityQueue<int> pQ = new PriorityQueue<int>();
            List<int> intList = new List<int>() { 5, 7, 2, 11, 15, 6, 8 };

            foreach (int i in intList)
            {
                pQ.Add(i);
            }

            Assert.AreEqual(2, pQ.Pop());
            Assert.AreEqual(5, pQ.Pop());
            Assert.AreEqual(6, pQ.Pop());
            Assert.AreEqual(7, pQ.Pop());
            Assert.AreEqual(8, pQ.Pop());
            Assert.AreEqual(11, pQ.Pop());
            Assert.AreEqual(15, pQ.Pop());
        }
        [Test]
        public void StressTest()
        {
            Random rand = new Random();
            PriorityQueue<int> pQ = new PriorityQueue<int>();
            for (int i = 0; i < 99997; i++)
            {
                pQ.Add(rand.Next());
            }

            pQ.Add(1);
            pQ.Add(2);
            pQ.Add(3);

            Assert.AreEqual(1, pQ.Pop());
            Assert.AreEqual(2, pQ.Pop());
            Assert.AreEqual(3, pQ.Pop());
        }

        [Test]
        public void TestCustomDataType()
        {
            DummyTestObjectEmployee emp1 = new DummyTestObjectEmployee
            {
                Salary = 15000.00,
                Name = "Bob Builder",
                Department = "Construction"
            };

            DummyTestObjectEmployee emp2 = new DummyTestObjectEmployee
            {
                Salary = 25000.00,
                Name = "Sally Supervisor",
                Department = "HR"
            };

            DummyTestObjectEmployee emp3 = new DummyTestObjectEmployee
            {
                Salary = 55000.00,
                Name = "Barry Boss",
                Department = "Directors"
            };

            PriorityQueue<DummyTestObjectEmployee> pQ = new PriorityQueue<DummyTestObjectEmployee>();

            pQ.Add(emp2);
            pQ.Add(emp1);
            pQ.Add(emp3);

            Assert.AreEqual(emp3, pQ.Pop());
            Assert.AreEqual(emp2, pQ.Pop());
            Assert.AreEqual(emp1, pQ.Pop());
        }
    }

    internal class DummyTestObjectEmployee : IComparable, IComparable<DummyTestObjectEmployee>
    {
        public double Salary { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is DummyTestObjectEmployee e)
            {
                if (e.Salary < Salary)
                {
                    return -1;
                }
                else if (Salary < e.Salary)
                {
                    return 1;
                }
                return 0;
            }
            return Int32.MinValue;
        }

        public int CompareTo(DummyTestObjectEmployee other)
        {
            if (other.Salary < Salary)
            {
                return -1;
            }
            else if (Salary < other.Salary)
            {
                return 1;
            }
            return 0;
        }
    }
}