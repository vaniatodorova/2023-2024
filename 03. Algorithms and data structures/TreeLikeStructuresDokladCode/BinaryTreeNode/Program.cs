using System;
using System.Collections.Generic;

namespace BinaryTreeNode
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

	public class BinaryTree<T>
	{
		public BinaryTreeNode<T> Root { get; set; }

		public BinaryTree()
		{
			Root = null;
		}

		// Метод за добавяне на възел в дървото
		public void Add(T data)
		{
			Root = AddRecursive(Root, data);
		}

		private BinaryTreeNode<T> AddRecursive(BinaryTreeNode<T> current, T data)
		{
			if (current == null)
			{
				return new BinaryTreeNode<T>(data);
			}

			// Рекурсивно добавяне на възела в подходящата поддървовидна част
			if (Comparer<T>.Default.Compare(data, current.Data) < 0)
			{
				current.Left = AddRecursive(current.Left, data);
			}
			else if (Comparer<T>.Default.Compare(data, current.Data) > 0)
			{
				current.Right = AddRecursive(current.Right, data);
			}

			return current;
		}

		// Метод за обхождане на дървото в инордер (ляво-корен-дясно)
		public void InOrderTraversal(BinaryTreeNode<T> node)
		{
			if (node != null)
			{
				InOrderTraversal(node.Left);
				Console.WriteLine(node.Data);
				InOrderTraversal(node.Right);
			}
		}
	}

	class Program
		{
			static void Main(string[] args)
			{
				BinaryTree<int> binaryTree = new BinaryTree<int>();
				binaryTree.Add(5);
				binaryTree.Add(3);
				binaryTree.Add(7);
				binaryTree.Add(1);
				binaryTree.Add(4);
				binaryTree.Add(6);
				binaryTree.Add(9);

				binaryTree.InOrderTraversal(binaryTree.Root);
			}
		}
}
