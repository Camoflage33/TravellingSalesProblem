using System;
using System.Collections.Generic;

namespace TSPJamaica
{
    public class Graph
    {
        private const int V = 14; // Number of vertices in the graph
        private Dictionary<int, (double latitude, double longitude)> coordinates;

        public Graph()
        {
            InitializeCoordinates();
        }

        void InitializeCoordinates()
        {
            coordinates = new Dictionary<int, (double, double)>
            {
                { 0, (18.0127, -76.7959) }, // Kingston
                { 1, (18.4665, -77.9211) }, // Montego Bay
                { 2, (17.9896, -76.9442) }, // Portmore
                { 3, (18.0153, -77.4996) }, // Mandeville
                { 4, (18.4172, -78.0748) }, // Negril
                { 5, (18.4047, -77.8558) }, // Lucea
                { 6, (18.2748, -78.3447) }, // Savanna-la-Mar
                { 7, (18.1004, -77.2855) }, // Black River
                { 8, (18.1772, -77.0151) }, // May Pen
                { 9, (18.2701, -77.6260) }, // Falmouth
                { 10, (18.4417, -77.6592) }, // Runaway Bay
                { 11, (18.4514, -77.1210) }, // Ocho Rios
                { 12, (18.4092, -76.9696) }, // St. Ann's Bay
                { 13, (18.1760, -76.7922) }  // Port Antonio
            };
        }

        double CalculateHeuristic(int u, int v)
        {
            var coordU = coordinates[u];
            var coordV = coordinates[v];

            double heuristic = Math.Sqrt(Math.Pow(coordU.latitude - coordV.latitude, 2) + Math.Pow(coordU.longitude - coordV.longitude, 2));
            return heuristic;
        }

        public int Dijkstra(int[,] graph, int startVertex, int endVertex, out string path)
        {
            int[] dist = new int[V];
            bool[] shortestPathTreeSet = new bool[V];
            int[] parents = new int[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
                parents[i] = -1;
            }

            dist[startVertex] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinDistance(dist, shortestPathTreeSet);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!shortestPathTreeSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                        parents[v] = u;
                    }
                }
            }

            path = GetPath(parents, endVertex);
            return dist[endVertex];
        }

        int MinDistance(int[] dist, bool[] sptSet)
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

        string GetPath(int[] parents, int j)
        {
            List<int> pathList = new List<int>();
            int current = j;

            while (current != -1)
            {
                pathList.Add(current);
                current = parents[current];
            }

            pathList.Reverse(); // To get the path from start to end
            return string.Join(" -> ", pathList);
        }


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

            SortedSet<(double, int)> openList = new SortedSet<(double, int)>();
            openList.Add((CalculateHeuristic(startVertex, endVertex), startVertex));

            while (openList.Count > 0)
            {
                var (f, u) = openList.Min;
                openList.Remove(openList.Min);
                closedList[u] = true;

                if (u == endVertex)
                {
                    path = GetPath(parents, endVertex);
                    return dist[u];
                }

                for (int v = 0; v < V; v++)
                {
                    if (!closedList[v] && graph[u, v] != 0)
                    {
                        double g = dist[u] + graph[u, v];
                        double h = CalculateHeuristic(v, endVertex);
                        double fNew = g + h;

                        if (g < dist[v])
                        {
                            dist[v] = (int)g;
                            parents[v] = u;
                            openList.Add((fNew, v));
                        }
                    }
                }
            }

            path = "";
            return -1; // If no path found
        }

        public int BestFirstSearch(int[,] graph, int startVertex, int endVertex, out string path)
        {
            bool[] visited = new bool[V];
            int[] parents = new int[V];
            for (int i = 0; i < V; i++)
            {
                parents[i] = -1;
            }

            SortedSet<(double, int)> openList = new SortedSet<(double, int)>();
            openList.Add((CalculateHeuristic(startVertex, endVertex), startVertex));

            while (openList.Count > 0)
            {
                var (h, u) = openList.Min;
                openList.Remove(openList.Min);

                if (u == endVertex)
                {
                    path = GetPath(parents, endVertex);
                    return (int)h;
                }

                visited[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && graph[u, v] != 0)
                    {
                        double heuristic = CalculateHeuristic(v, endVertex);
                        if (parents[v] == -1) // Not yet visited
                        {
                            openList.Add((heuristic, v));
                            parents[v] = u;
                        }
                    }
                }
            }

            path = "";
            return -1; // If no path found
        }

    }
}
