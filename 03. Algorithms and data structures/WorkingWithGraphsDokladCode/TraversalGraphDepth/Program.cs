using System;
using System.Collections.Generic;

namespace TraversalGraphDepth
{
    class GraphTraversal
    {
        // Recursive method for depth-first search traversal
        void DFSUtil(int vertex, bool[] visited, Graph graph)
        {
            visited[vertex] = true;
            Console.WriteLine(vertex);

            foreach (var adjacentVertex in graph.GetAdjacencyList()[vertex])
            {
                if (!visited[adjacentVertex])
                    DFSUtil(adjacentVertex, visited, graph);
            }
        }

        // Method for depth-first search traversal
        public void DFS(Graph graph)
        {
            int vertices = graph.GetAdjacencyList().Count;
            bool[] visited = new bool[vertices];

            for (int i = 0; i < vertices; ++i)
            {
                if (!visited[i])
                    DFSUtil(i, visited, graph);
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

            // Perform DFS traversal on the graph
            Console.WriteLine("Depth-First Search Traversal:");
            traversal.DFS(graph);
        }
    }
}
