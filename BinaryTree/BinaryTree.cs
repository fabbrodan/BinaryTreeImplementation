using PriorityQueue;
using System;
using System.Collections.Generic;

namespace BinaryTreeLib
{
    public class BinaryTree<T> : IPriorityQueue<T> where T : IComparable, IComparable<T>
    {
        private Node<T> _root = null;
        private int _count = 0;

        public BinaryTree(Node<T> node)
        {
            _root = node;
        }

        public BinaryTree()
        {
        }

        public void Add(T element)
        {
            Node<T> newNode = new Node<T>(element);
            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                Insert(_root, newNode);
                ArrangeTree(newNode.ParentNode);
            }
            _count++;
        }

        private void Insert(Node<T> root, Node<T> newNode)
        {
            if (root == null)
            {
                root = newNode;
            }

            if (root.LeftNode == null)
            {
                root.LeftNode = newNode;
                newNode.ParentNode = root;
            }
            else if (root.RightNode == null)
            {
                root.RightNode = newNode;
                newNode.ParentNode = root;
            }
            else if ((_count & 1) == 1)
            {
                Insert(root.RightNode, newNode);
            }
            else
            {
                Insert(root.LeftNode, newNode);
            }
        }

        public int Count() => _count;

        public T Peek()
        {
            if (_root == null)
            {
                throw new InvalidOperationException();
            }

            return _root.Value;
        }

        public T Pop()
        {
            if (_root == null)
            {
                throw new InvalidOperationException();
            }

            T returnValue = _root.Value;
            if (_count > 1)
            {
                _count--;
                if (_root.RightNode == null && _root.LeftNode != null)
                {
                    _root = _root.LeftNode;
                    return returnValue;
                }
                int comparedValue = _root.LeftNode.Value.CompareTo(_root.RightNode.Value);

                Node<T> orgLeftNode = _root.LeftNode;
                Node<T> orgRightNode = _root.RightNode;

                if (comparedValue == -1)
                {
                    _root = _root.LeftNode;
                    ShiftNodes(_root, "left");
                    _root.RightNode = orgRightNode;
                }
                else if (comparedValue == 1)
                {
                    _root = _root.RightNode;
                    ShiftNodes(_root, "right");
                    _root.LeftNode = orgLeftNode;
                }
                else
                {
                    _root = _root.LeftNode;
                }
            }
            else
            {
                _root = null;
                _count--;
            }

            //ArrangeTree(_root);
            return returnValue;
        }

        private void ShiftNodes(Node<T> root, string leftOrRight)
        {
            int comparedValue = 0;
            //right
            if (leftOrRight == "right")
            {
                if (root.RightNode == null && root.LeftNode != null)
                {
                    root.RightNode = root.LeftNode;
                }
                else if (root.RightNode == null)
                {
                    return;
                }
                comparedValue = root.LeftNode.Value.CompareTo(root.RightNode.Value);

                if (comparedValue == -1)
                {
                    root.LeftNode.LeftNode = root.RightNode;
                }
                else
                {
                    root.RightNode.LeftNode = root.LeftNode;
                }
                ShiftNodes(root.RightNode, "right");
            }
            //left
            else
            {
                if (root.LeftNode == null && root.RightNode != null)
                {
                    root.LeftNode = root.RightNode;
                    return;
                }
                else if (root.RightNode == null)
                {
                    return;
                }
                comparedValue = root.LeftNode.Value.CompareTo(root.RightNode.Value);

                if (comparedValue == -1)
                {
                    root.LeftNode.LeftNode = root.RightNode;
                }
                else
                {
                    root.RightNode.LeftNode = root.LeftNode;
                    root.LeftNode = root.RightNode;
                }
                ShiftNodes(root.RightNode, "left");
            }
        }
        private void ArrangeTree(Node<T> root)
        {
            if (root.LeftNode != null)
            {
                if (root.LeftNode.Value.CompareTo(root.Value) == -1)
                {
                    var rootVal = root.Value;
                    var leftVal = root.LeftNode.Value;

                    root.Value = leftVal;
                    root.LeftNode.Value = rootVal;
                    ArrangeTree(root);
                }
            }
            
            if (root.RightNode != null)
            {
                if (root.RightNode.Value.CompareTo(root.Value) == -1)
                {
                    var rootVal = root.Value;
                    var rightVal = root.RightNode.Value;

                    root.Value = rightVal;
                    root.RightNode.Value = rootVal;
                    ArrangeTree(root);
                }
            }
        }
    }
}
