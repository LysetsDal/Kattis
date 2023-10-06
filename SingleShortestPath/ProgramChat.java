package SingleShortestPath;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.PriorityQueue;
import java.util.Scanner;

class ProgramChat {
   public static void main(String[] args) {
      Scanner sc = new Scanner(System.in);

      while (true) {
         int n = sc.nextInt(); // number of nodes
         int m = sc.nextInt(); // number of edges
         int q = sc.nextInt(); // number of queries
         int s = sc.nextInt(); // index of the starting node

         if (n == 0 && m == 0 && q == 0 && s == 0) {
            break; // terminate the input
         }

         List<List<Edge>> graph = new ArrayList<>();
         for (int i = 0; i < n; i++) {
            graph.add(new ArrayList<>());
         }

         // Reading the edges
         for (int i = 0; i < m; i++) {
            int u = sc.nextInt();
            int v = sc.nextInt();
            int w = sc.nextInt();
            graph.get(u).add(new Edge(v, w));
         }

         // Run Dijkstra's algorithm
         int[] distances = new int[n];
         Arrays.fill(distances, Integer.MAX_VALUE);
         distances[s] = 0;
         PriorityQueue<Edge> pq = new PriorityQueue<>(Comparator.comparingInt(e -> e.weight));
         pq.add(new Edge(s, 0));

         while (!pq.isEmpty()) {
            Edge cur = pq.poll();

            for (Edge edge : graph.get(cur.to)) {
               int newDist = cur.weight + edge.weight;
               if (newDist < distances[edge.to]) {
                  distances[edge.to] = newDist;
                  pq.add(new Edge(edge.to, newDist));
               }
            }
         }

         // Process queries
         for (int i = 0; i < q; i++) {
            int query = sc.nextInt();
            if (distances[query] == Integer.MAX_VALUE) {
               System.out.println("Impossible");
            } else {
               System.out.println(distances[query]);
            }
         }
         System.out.println();
         sc.close();
      }
   }

   static class Edge {
      int to, weight;

      Edge(int to, int weight) {
         this.to = to;
         this.weight = weight;
      }
   }
}
