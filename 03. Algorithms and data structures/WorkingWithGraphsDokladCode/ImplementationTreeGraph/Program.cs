using System;
using System.Collections.Generic;


namespace ImplementationTreeGraph
{
    class Tree
    {
        public int Value { get; set; }
        public List<Tree> Children { get; set; }

        // Constructor
        public Tree(int value)
        {
            Value = value;
            Children = new List<Tree>();
        }

        // Method to add children
        public void AddChild(Tree child)
        {
            Children.Add(child);
        }

        // Method to display the tree structure
        public void DisplayTree()
        {
            DisplayTreeUtil(this, 0);
        }

        private void DisplayTreeUtil(Tree node, int level)
        {
            Console.WriteLine($"{new string(' ', level * 4)}{node.Value}");

            foreach (var child in node.Children)
            {
                DisplayTreeUtil(child, level + 1);
            }
        }

        // Method to access the children of a node
        public List<Tree> GetChildren()
        {
            return Children;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create the tree structure
            Tree root = new Tree(1);
            Tree child1 = new Tree(2);
            Tree child2 = new Tree(3);
            Tree grandchild1 = new Tree(4);
            Tree grandchild2 = new Tree(5);

            // Build the tree
            root.AddChild(child1);
            root.AddChild(child2);
            child1.AddChild(grandchild1);
            child1.AddChild(grandchild2);

            // Display the tree structure
            Console.WriteLine("Tree Structure:");
            root.DisplayTree();
        }
    }
}
