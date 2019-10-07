using PriorityQueue;
using System;
using System.Collections.Generic;

namespace PriorityQueueLib
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable, IComparable<T>
    {
        private List<T> backingList = new List<T>();

        /// <summary>
        /// Creates a new instance of the PriorityQueue object with the specified element as the first
        /// </summary>
        /// <param name="startElement">The initial element in the queue</param>
        public PriorityQueue(T startElement)
        {
            backingList.Add(startElement);
        }

        /// <summary>
        /// Creates a new instance of the PriorityQueue object
        /// </summary>
        public PriorityQueue()
        {
        }

        /// <summary>
        /// Adds and element to the Priority Queue and places the highest priority item at the front of the queue
        /// </summary>
        /// <param name="element">Object to be added to the queue</param>
        public void Add(T element)
        { 
            backingList.Add(element);

            int childIndex = backingList.Count - 1;
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (backingList[childIndex].CompareTo(backingList[parentIndex]) >= 0)
                {
                    break;
                }
                T tmp = backingList[childIndex];
                backingList[childIndex] = backingList[parentIndex];
                backingList[parentIndex] = tmp;
                childIndex = parentIndex;
            }
        }

        /// <summary>
        /// Returns the count of elements currently in the Priority Queue
        /// </summary>
        /// <returns>The number of elements in the Priority Queue</returns>
        public int Count() => backingList.Count;

        /// <summary>
        /// Returns the highest prioritized element in the Priority Queue.
        /// Prioritization is determined by the passed in types implementation of IComparable
        /// </summary>
        /// <returns>The highest prioritized element in the Priority Queue</returns>
        /// <exception cref="InvalidOperationException">Thrown when trying to access an empty PriorityQueue</exception>
        public T Peek()
        {
            if (backingList.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return backingList[0];
        }

        /// <summary>
        /// Returns the highest prioritized element and then removes it from the Priority Queue.
        /// Prioritization is determined by the passed in types implementation of IComparable
        /// </summary>
        /// <returns>The highest prioritized element in the queue</returns>
        /// /// <exception cref="InvalidOperationException">Thrown when trying to access an empty PriorityQueue</exception>
        public T Pop()
        {
            if (backingList.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T returnItem = backingList[0];
            int lastIndex = backingList.Count - 1;

            backingList[0] = backingList[lastIndex];
            backingList.RemoveAt(lastIndex);

            lastIndex--;
            int parentIndex = 0;
            int actualChildIndexToCheck;

            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1; 
                if (leftChildIndex > lastIndex)
                {
                    break;
                }
                int rightChildIndex = leftChildIndex + 1;
                if (rightChildIndex <= lastIndex && backingList[rightChildIndex].CompareTo(backingList[leftChildIndex]) < 0)
                {
                    actualChildIndexToCheck = rightChildIndex;
                }
                else
                {
                    actualChildIndexToCheck = leftChildIndex;
                }

                if (backingList[parentIndex].CompareTo(backingList[actualChildIndexToCheck]) <= 0)
                {
                    break;
                }
                T tmp = backingList[parentIndex];
                backingList[parentIndex] = backingList[actualChildIndexToCheck];
                backingList[actualChildIndexToCheck] = tmp;
                parentIndex = actualChildIndexToCheck;
            }
            return returnItem;
        }
    }
}
