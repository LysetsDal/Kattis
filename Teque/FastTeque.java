package Teque;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayDeque;
import java.util.ArrayList;

public class FastTeque {
   public static void main(String[] args) throws IOException {
      BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
      int n = Integer.parseInt(reader.readLine());

      ArrayDeque<Integer> front = new ArrayDeque<>();
      ArrayDeque<Integer> back = new ArrayDeque<>();

      for (int i = 0; i < n; i++) {
         String[] command = reader.readLine().split(" ");
         String op = command[0];
         int val = Integer.parseInt(command[1]);

         switch (op) {
            case "push_back":
               back.addLast(val);
               break;
            case "push_front":
               front.addFirst(val);
               break;
            case "push_middle":
               front.addLast(val);
               break;
            case "get":
               if (val < front.size()) {
                  System.out.println(new ArrayList<>(front).get(val));
               } else {
                  System.out.println(new ArrayList<>(back).get(val - front.size()));
               }
               break;
         }
         // Re-balance the two DequeArrays if needed
         if (front.size() > back.size() + 1) {
            back.addFirst(front.removeLast());
         } else if (back.size() > front.size()) {
            front.addLast(back.removeFirst());
         }
      }
   }
}
