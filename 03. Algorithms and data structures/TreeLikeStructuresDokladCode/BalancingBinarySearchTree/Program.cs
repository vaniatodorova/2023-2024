using System;
using System.Collections.Generic;

namespace BalancingBinarySearchTree
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        // Вмъкване на елемент в дървото
        public void Insert(T data)
        {
            Root = InsertRecursive(Root, data);
        }

        private BinaryTreeNode<T> InsertRecursive(BinaryTreeNode<T> node, T data)
        {
            if (node == null)
            {
                return new BinaryTreeNode<T>(data);
            }

            if (Comparer<T>.Default.Compare(data, node.Data) < 0)
            {
                node.Left = InsertRecursive(node.Left, data);
            }
            else if (Comparer<T>.Default.Compare(data, node.Data) > 0)
            {
                node.Right = InsertRecursive(node.Right, data);
            }

            return node;
        }
        // Ротация на дървото надляво
        private BinaryTreeNode<T> RotateLeft(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            return newRoot;
        }

        // Ротация на дървото надясно
        private BinaryTreeNode<T> RotateRight(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            return newRoot;
        }

        // Балансиране на дървото
        public BinaryTreeNode<T> Balance(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            // Балансиране на лявото поддърво
            if (GetHeight(node.Left) - GetHeight(node.Right) > 1)
            {
                if (GetHeight(node.Left.Left) >= GetHeight(node.Left.Right))
                {
                    node = RotateRight(node);
                }
                else
                {
                    node.Left = RotateLeft(node.Left);
                    node = RotateRight(node);
                }
            }
            // Балансиране на дясното поддърво
            else if (GetHeight(node.Right) - GetHeight(node.Left) > 1)
            {
                if (GetHeight(node.Right.Right) >= GetHeight(node.Right.Left))
                {
                    node = RotateLeft(node);
                }
                else
                {
                    node.Right = RotateRight(node.Right);
                    node = RotateLeft(node);
                }
            }

            return node;
        }

        // Връща височината на дървото
        private int GetHeight(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        // Извеждане на дървото
        public void PrintInOrder(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PrintInOrder(node.Left);
                Console.Write(node.Data + " ");
                PrintInOrder(node.Right);
            }
        }
    }

    class Program
	{
		static void Main(string[] args)
		{
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(2);
            bst.Insert(4);
            bst.Insert(6);
            bst.Insert(8);

            Console.WriteLine("Before balancing:");
            bst.PrintInOrder(bst.Root);
            Console.WriteLine();

            bst.Root = bst.Balance(bst.Root);

            Console.WriteLine("After balancing:");
            bst.PrintInOrder(bst.Root);

        }
    }
}
