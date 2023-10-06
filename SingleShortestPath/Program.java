package SingleShortestPath;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedList;
import java.util.Scanner;

/**
 * https://open.kattis.com/problems/shortestpath1
 */
class Program {

   public static class WeightedEdge {

      public int from;
      public int to;
      public int weight;

      public WeightedEdge(int from, int to, int weight) {
         this.from = from;
         this.to = to;
         this.weight = weight;
      }

      public WeightedEdge(int from, int to, String weight) {
         this.from = from;
         this.to = to;
         this.weight = Integer.parseInt(weight);
      }

   }

   public static class Graph {

      protected int edges;
      protected int vertices;
      ArrayList<LinkedList<WeightedEdge>> adjList;

      public Graph(int edges, int vertices) {
         this.edges = edges;
         this.vertices = vertices;

         adjList = new ArrayList<>();

         for (int i = 0; i < vertices; i++) {
            adjList.add(i, new LinkedList<WeightedEdge>());
         }
      }

      public void addEdge(WeightedEdge edge) {
         LinkedList<WeightedEdge> currentList = adjList.get(edge.from);
         currentList.add(edge);
      }
   }

   public static void main(String[] args) {
      Scanner reader = new Scanner(System.in);
      String[] tests;
      int[] shortestPath;
      Graph graph;
      int vertices;
      int edges;
      int queries;
      int start;

      while (true) {
         // reading input
         tests = reader.nextLine().split(" ", 4);
         vertices = Integer.parseInt(tests[0]);
         edges = Integer.parseInt(tests[1]);
         queries = Integer.parseInt(tests[2]);
         start = Integer.parseInt(tests[3]);

         if (vertices == 0 && edges == 0 && queries == 0 && start == 0) {
            break; // All elements are zero, exit the loop
         }

         graph = new Graph(edges, vertices);

         // Parse and add edges to graph.
         for (int i = 0; i < edges; i++) {
            String[] inputLine = reader.nextLine().split(" ", 3);
            WeightedEdge inEdge = new WeightedEdge(
                  Integer.parseInt(inputLine[0]),
                  Integer.parseInt(inputLine[1]),
                  Integer.parseInt(inputLine[2]));

            graph.addEdge(inEdge);
         }

         shortestPath = Dijkstra(graph, start);

         for (int i = 0; i < queries; i++) {
            if (reader.hasNextLine()) {
               int index = Integer.parseInt(reader.nextLine());
               if (shortestPath[index] == Integer.MAX_VALUE) {
                  System.out.println("Impossible"); // No path from start to node index
               } else {
                  System.out.println(shortestPath[index]);
               }
            }
         }
         // Print a blank line between test cases
         System.out.println();
      }

      reader.close();
   }

   public static int[] Dijkstra(Graph graph, int source) {
      int[] dist = new int[graph.vertices];
      boolean[] visited = new boolean[graph.vertices];

      // Initialize all distances to infinity except for the source node
      Arrays.fill(dist, Integer.MAX_VALUE);
      dist[source] = 0;

      for (int i = 0; i < graph.vertices; i++) {
         int u = minDistance(dist, visited);
         visited[u] = true;

         LinkedList<WeightedEdge> neighbours = graph.adjList.get(u);
         for (WeightedEdge edge : neighbours) {
            int v = edge.to;
            int weight = edge.weight;
            int alt = dist[u] + weight;

            if (!visited[v] && alt < dist[v]) {
               dist[v] = alt;
            }
         }
      }
      return dist;
   }

   public static int minDistance(int[] dist, boolean[] visited) {
      int minDist = Integer.MAX_VALUE;
      int minIndex = -1;

      for (int v = 0; v < dist.length; v++) {
         if (!visited[v] && dist[v] < minDist) {
            minDist = dist[v];
            minIndex = v;
         }
      }

      if (minIndex == -1) {
         for (int v = 0; v < visited.length; v++) {
            if (!visited[v]) {
               return v;
            }
         }
      }

      return minIndex;
   }
}
