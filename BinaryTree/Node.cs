using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeLib
{
    public class Node<T> : IComparable, IComparable<T>
    {
        public T Value;

        public Node<T> ParentNode;
        public Node<T> LeftNode;
        public Node<T> RightNode;

        public Node()
        {
            Value = default;
        }
        public Node(T value)
        {
            Value = value;
        }


        public int CompareTo(object obj)
        {
            if (obj is Node<T> n)
            {
                return n.CompareTo(Value);
            }
            return Int32.MinValue;
        }

        public int CompareTo(T other)
        {
            if (other is Int32 otherAsInt)
            {
                return otherAsInt.CompareTo(Value);
            }
            else if (other is String otherAsString)
            {
                return otherAsString.CompareTo(Value);
            }

            return Int32.MinValue;
        }
    }
}
