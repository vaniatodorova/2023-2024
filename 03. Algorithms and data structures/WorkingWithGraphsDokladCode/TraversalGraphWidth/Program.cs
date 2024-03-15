using System;
using System.Collections.Generic;

namespace TraversalGraphWidth
{
    class GraphTraversal
    {
        // Method for width-first search traversal
        public void BFS(Graph graph, int startVertex)
        {
            int vertices = graph.GetAdjacencyList().Count;
            bool[] visited = new bool[vertices];
            Queue<int> queue = new Queue<int>();

            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count != 0)
            {
                int currentVertex = queue.Dequeue();
                Console.WriteLine(currentVertex);

                foreach (var adjacentVertex in graph.GetAdjacencyList()[currentVertex])
                {
                    if (!visited[adjacentVertex])
                    {
                        visited[adjacentVertex] = true;
                        queue.Enqueue(adjacentVertex);
                    }
                }
            }
        }
    }

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
            if (!adjacencyList.ContainsKey(source))
            {
                adjacencyList[source] = new List<int>();
            }
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
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            // Create an instance of the GraphTraversal class
            GraphTraversal traversal = new GraphTraversal();

            // Perform BFS traversal on the graph starting from vertex 2
            Console.WriteLine("Width-First Search Traversal:");
            traversal.BFS(graph, 2);
        }
    }
}
