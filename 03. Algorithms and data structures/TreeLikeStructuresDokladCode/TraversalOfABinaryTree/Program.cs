using System;

namespace TraversalOfABinaryTree
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

        // Инордер обхождане: ляво-корен-дясно
        public void InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.WriteLine(node.Data);
                InOrderTraversal(node.Right);
            }
        }

        // Предордер обхождане: корен-ляво-дясно
        public void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Data);
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        // Постордер обхождане: ляво-дясно-корен
        public void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.WriteLine(node.Data);
            }
        }
    }

    class Program
	{
		static void Main(string[] args)
		{
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root = new BinaryTreeNode<int>(1);
            binaryTree.Root.Left = new BinaryTreeNode<int>(2);
            binaryTree.Root.Right = new BinaryTreeNode<int>(3);
            binaryTree.Root.Left.Left = new BinaryTreeNode<int>(4);
            binaryTree.Root.Left.Right = new BinaryTreeNode<int>(5);

            Console.WriteLine("InOrder traversal:");
            binaryTree.InOrderTraversal(binaryTree.Root);

            Console.WriteLine("PreOrder traversal:");
            binaryTree.PreOrderTraversal(binaryTree.Root);

            Console.WriteLine("PostOrder traversal:");
            binaryTree.PostOrderTraversal(binaryTree.Root);

        }
    }
}
