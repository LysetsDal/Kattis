package sort;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

class Sort {
    // Helper class to sort 
    public static class Pair implements Comparable<Pair> {
        int state;
        int number;
        int count;

        public Pair(int _number, int _count) {
            number = _number;
            count = _count;
        }

        public Pair(int _number, int _count, int _state) {
            number = _number;
            count = _count;
            state = _state;
        }

        // Sort on frequency, if equal on 'state' 
        // (which was read first) from StdIn.
        @Override
        public int compareTo(Pair a) {
            if (this.count > a.count) { return -1; }
            if (this.count < a.count) { return 1; }
            return Integer.compare(this.state, a.state);
        }
    }

    public static void main(String[] args) {
        ArrayList<Pair> ret = new ArrayList<Pair>();
        Scanner sc = new Scanner(System.in);
        
        sc.nextInt();
        int c = sc.nextInt();
        sc.nextLine();
        String in = sc.nextLine();

        int[] dict = new int[c];
        String[] parsed_in = in.split(" ");

        boolean[] processed = new boolean[c];
        int[] states = new int[c];

        int state = 1;
        for (int i = 0; i < parsed_in.length; i++) {
            int num = Integer.parseInt(parsed_in[i]);
            dict[num - 1] = dict[num - 1] + 1;

            if (!processed[num - 1]) {
                states[num - 1] = state;
                processed[num - 1] = true;
                state++;
            }
        }

        for (int i = 0; i < c; i++) {
            if (dict[i] != 0) {
                ret.add(new Pair(i + 1, dict[i], states[i]));
            }
        }

        Collections.sort(ret);

        StringBuilder strb = new StringBuilder();
        for (Pair p : ret) {
            String test = String.valueOf(p.number) + " ";
            strb.append(test.repeat(p.count));
        }

        // Printing res from strb and trimming trailing spaces.
        System.out.println(strb.toString().trim());
        sc.close();
    }
}