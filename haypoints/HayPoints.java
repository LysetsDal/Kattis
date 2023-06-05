package haypoints;

import java.util.Scanner;
import java.util.HashMap;

// https://open.kattis.com/problems/haypoints

class HayPoints {
    public static void main(String[] args) {

        HashMap<String, Integer> dict = new HashMap<>();
        Scanner sc = new Scanner(System.in);
        int m = sc.nextInt();
        int n = sc.nextInt();
        sc.nextLine();
        int sum = 0;

        for (int i = 0; i < m; i++) {
            String line = sc.nextLine();
            int spaceIndex = line.indexOf(' ');
            String word = line.substring(0, spaceIndex);
            int value = Integer.parseInt(line.substring(spaceIndex + 1));
            dict.put(word, value);
        }

        int[] results = new int[n];
        for (int i = 0; i < n; i++) {
            String line;

            do {
                line = sc.nextLine();
                
                String[] arr = line.split(" ");
                
                for (String str : arr) {
                    if (dict.containsKey(str)) sum += dict.get(str);
                }
            } while (!line.contains("."));

            results[i] = sum;
            sum = 0;
        }
        
        for (int i : results) {
            System.out.println(i);
        }
        sc.close();
    }
}