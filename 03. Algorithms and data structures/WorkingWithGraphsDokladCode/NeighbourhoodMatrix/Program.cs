using System;

namespace NeighbourhoodMatrix
{
    class Graph
    {
        private int[,] adjacencyMatrix;

        // Constructor
        public Graph(int vertices)
        {
            adjacencyMatrix = new int[vertices, vertices];
        }

        // Method to add an edge between vertices
        public void AddEdge(int source, int destination)
        {
            adjacencyMatrix[source, destination] = 1;
        }

        // Method to access the adjacency matrix
        public int[,] GetAdjacencyMatrix()
        {
            return adjacencyMatrix;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Graph class
            Graph graph = new Graph(5); // Creating a graph with 5 vertices

            // Add some edges to the graph
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 2);
            graph.AddEdge(3, 4);

            // Display the adjacency matrix
            Console.WriteLine("Adjacency Matrix:");
            int[,] matrix = graph.GetAdjacencyMatrix();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
