using System;
using System.Collections.Generic;

namespace NeighbourhoodList
{
    class Graph
    {
        private Dictionary<int, List<int>> adjacencyList;

        // Constructor
        public Graph()
        {
            adjacencyList = new Dictionary<int, List<int>>();
        }

        // Method to add an edge between vertices
        public void AddEdge(int source, int destination)
        {
            // If the source vertex is not in the adjacency list, create a new entry
            if (!adjacencyList.ContainsKey(source))
            {
                adjacencyList[source] = new List<int>();
            }

            // Add the destination vertex to the adjacency list of the source vertex
            adjacencyList[source].Add(destination);
        }

        // Method to access the adjacency list
        public Dictionary<int, List<int>> GetAdjacencyList()
        {
            return adjacencyList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Graph class
            Graph graph = new Graph();

            // Add some edges to the graph
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 2);

            // Display the adjacency list
            Console.WriteLine("Adjacency List:");
            foreach (var kvp in graph.GetAdjacencyList())
            {
                Console.Write(kvp.Key + ": ");
                foreach (var vertex in kvp.Value)
                {
                    Console.Write(vertex + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
