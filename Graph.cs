using System;
using System.Collections.Generic;

namespace TSPJamaica
{
    // The Graph class is responsible for representing the graph structure and implementing search algorithms
    public class Graph
    {
        // Dictionary to store the coordinates (latitude, longitude) of each node (parish) indexed by an integer
        private Dictionary<int, (double latitude, double longitude)> nodeCoordinates;
        private const int V = 14; // Number of parishes in the graph

        // Constructor for the Graph class.
        public Graph(Dictionary<string, (double latitude, double longitude)> parishCoordinates)
        {
            InitializeNodeCoordinates(parishCoordinates);
        }

        // Method to initialize the nodeCoordinates dictionary from the parishCoordinates dictionary
        private void InitializeNodeCoordinates(Dictionary<string, (double latitude, double longitude)> parishCoordinates)
        {

            nodeCoordinates = new Dictionary<int, (double latitude, double longitude)>
            {
                { 0, parishCoordinates["Kingston"] },
                { 1, parishCoordinates["St. Andrew"] },
                { 2, parishCoordinates["St. Catherine"] },
                { 3, parishCoordinates["Clarendon"] },
                { 4, parishCoordinates["Manchester"] },
                { 5, parishCoordinates["St. Elizabeth"] },
                { 6, parishCoordinates["Westmoreland"] },
                { 7, parishCoordinates["Hanover"] },
                { 8, parishCoordinates["St. James"] },
                { 9, parishCoordinates["Trelawny"] },
                { 10, parishCoordinates["St. Ann"] },
                { 11, parishCoordinates["St. Mary"] },
                { 12, parishCoordinates["Portland"] },
                { 13, parishCoordinates["St. Thomas"] }
            };
        }

        // Method to calculate the heuristic distance between two nodes 
        private double CalculateHeuristic(int u, int v)
        {
            var coordU = nodeCoordinates[u];
            var coordV = nodeCoordinates[v];


            return Math.Sqrt(Math.Pow(coordU.latitude - coordV.latitude, 2) + Math.Pow(coordU.longitude - coordV.longitude, 2));
        }

        // Implementation of Dijkstra's algorithm 
        public int Dijkstra(int[,] graph, int startVertex, int endVertex, out string path)
        {
            int[] dist = new int[V];
            bool[] sptSet = new bool[V];
            int[] parents = new int[V];


            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
                parents[i] = -1;
            }

            dist[startVertex] = 0;


            for (int count = 0; count < V - 1; count++)
            {

                int u = MinDistance(dist, sptSet);


                if (u == endVertex)
                    break;

                sptSet[u] = true;


                for (int v = 0; v < V; v++)
                {

                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                        parents[v] = u;
                    }
                }
            }

            path = ConstructPath(parents, startVertex, endVertex);
            return dist[endVertex];
        }


        private int MinDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, minIndex = -1;


            for (int v = 0; v < V; v++)
            {
                if (!sptSet[v] && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        // Implementation of the A* algorithm to find the shortest path from startVertex to endVertex
        public int AStar(int[,] graph, int startVertex, int endVertex, out string path)
        {
            int[] dist = new int[V];
            bool[] closedList = new bool[V];
            int[] parents = new int[V];


            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                closedList[i] = false;
                parents[i] = -1;
            }

            dist[startVertex] = 0;


            SortedSet<(int, int)> openList = new SortedSet<(int, int)>();
            openList.Add((0, startVertex));

            while (openList.Count > 0)
            {
                var current = openList.Min;
                openList.Remove(current);

                int u = current.Item2;
                if (u == endVertex)
                    break;

                closedList[u] = true;


                for (int v = 0; v < V; v++)
                {
                    if (!closedList[v] && graph[u, v] != 0)
                    {
                        int newDist = dist[u] + graph[u, v];
                        double heuristic = CalculateHeuristic(v, endVertex);


                        if (newDist + heuristic < dist[v])
                        {
                            openList.Remove((dist[v], v));
                            dist[v] = newDist;
                            parents[v] = u;
                            openList.Add((dist[v] + (int)heuristic, v));
                        }
                    }
                }
            }

            path = ConstructPath(parents, startVertex, endVertex);
            return dist[endVertex];
        }

        // Implementation of the Best-First Search algorithm to find the path from startVertex to endVertex
        public int BestFirstSearch(int[,] graph, int startVertex, int endVertex, out string path)
        {
            bool[] visited = new bool[V];
            int[] dist = new int[V];
            int[] parents = new int[V];

            for (int i = 0; i < V; i++)
            {
                visited[i] = false;
                dist[i] = int.MaxValue;
                parents[i] = -1;
            }

            dist[startVertex] = 0;

            // Priority queue to hold vertices based on their heuristic values
            SortedSet<(double, int)> pq = new SortedSet<(double, int)>();
            pq.Add((0, startVertex)); // Add the start vertex to the priority queue

            // Loop to process all vertices in the priority queue
            while (pq.Count > 0)
            {
                var current = pq.Min; // Get the vertex with the lowest heuristic value
                pq.Remove(current); // Remove it from the priority queue

                int u = current.Item2;

                if (u == endVertex)
                    break;

                visited[u] = true;


                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && graph[u, v] != 0)
                    {
                        double heuristic = CalculateHeuristic(v, endVertex); // Calculate heuristic distance to the end vertex
                        pq.Add((heuristic, v)); // Add the vertex to the priority queue based on its heuristic

                        // If a shorter path is found
                        if (dist[v] > graph[u, v])
                        {
                            dist[v] = graph[u, v];
                            parents[v] = u; // Update the parent of vertex v
                        }
                    }
                }
            }

            path = ConstructPath(parents, startVertex, endVertex); // Construct the path from the parents array
            return dist[endVertex]; // Return the distance to the endVertex
        }


        private string ConstructPath(int[] parents, int startVertex, int endVertex)
        {
            Stack<int> stack = new Stack<int>();
            int vertex = endVertex;


            while (vertex != -1)
            {
                stack.Push(vertex);
                vertex = parents[vertex];
            }


            return string.Join(" -> ", stack);
        }
    }
}