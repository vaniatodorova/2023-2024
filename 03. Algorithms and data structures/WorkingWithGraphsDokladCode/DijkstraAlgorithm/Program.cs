using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    class DijkstraAlgorithm
    {
        // Method for finding the shortest path
        public void Dijkstra(Graph graph, int source)
        {
            int vertices = graph.GetAdjacencyList().Count;
            int[] distance = new int[vertices];
            bool[] shortestPathTreeSet = new bool[vertices];

            for (int i = 0; i < vertices; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < vertices - 1; ++count)
            {
                int u = MinDistance(distance, shortestPathTreeSet);
                shortestPathTreeSet[u] = true;

                foreach (var v in graph.GetAdjacencyList()[u])
                {
                    if (!shortestPathTreeSet[v] && distance[u] != int.MaxValue &&
                        distance[u] + 1 < distance[v]) // Assuming each edge has weight 1
                    {
                        distance[v] = distance[u] + 1; // Assuming each edge has weight 1
                    }
                }
            }

            PrintSolution(distance);
        }

        // Method for finding the minimum distance
        int MinDistance(int[] distance, bool[] shortestPathTreeSet)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < distance.Length; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        // Method for printing the solution
        void PrintSolution(int[] distance)
        {
            Console.WriteLine("Vertex   Distance from Source");

            for (int i = 0; i < distance.Length; ++i)
                Console.WriteLine($"{i}\t{distance[i]}");
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
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            // Create an instance of the DijkstraAlgorithm class
            DijkstraAlgorithm dijkstra = new DijkstraAlgorithm();

            // Perform Dijkstra's algorithm on the graph starting from vertex 0
            Console.WriteLine("Dijkstra's Algorithm:");
            dijkstra.Dijkstra(graph, 0);
        }
    }
}
