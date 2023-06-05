package joinstrings2;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
// https://open.kattis.com/problems/99problems
// import java.util.Scanner;

class Problems {
    public static void main(String[] args) throws IOException, NumberFormatException {
        InputStream stream = System.in;
        BufferedInputStream bufferedStream = new BufferedInputStream(stream);
        BufferedReader reader = new BufferedReader(new InputStreamReader(bufferedStream));
        int size = Integer.parseInt(reader.readLine());

        Index[] words = new Index[size];

        for (int i = 0; i < size; i++) {
            String word = reader.readLine();
            words[i] = new Index(word);
        }

        Index current;
        Index next;
        int[] arr = new int[2];

        for (int i = 0; i < size - 1; i++) {
            String tmp = reader.readLine();
            String[] cmds = tmp.split(" ", 2);

            arr[0] = Integer.parseInt(cmds[0]);
            arr[1] = Integer.parseInt(cmds[1]);

            current = words[arr[0] - 1];
            next = words[arr[1] - 1];

            if (current.before != null) {
                current.before.after = next;
            }

            current.after = (current.before == null)
                    ? next
                    : current.after;

            current.before = (next.after != null)
                    ? next.before
                    : next;
        }

        StringBuilder strb = new StringBuilder();

        for (current = words[arr[0] - 1]; current != null; current = current.after) {
            strb.append((current.word));
        }

        System.out.println(strb.toString());
        reader.close();
    }

    public static class Index {

        public Index before;
        public Index after;
        public String word;

        public Index(Index before, Index after) {
            this.before = before;
            this.after = after;
            this.word = "";
        }

        public Index(String word) {
            this.word = word;
        }

        public String getWord() {
            return this.word;
        }

        public void setWord(String word) {
            this.word = word;
        }
    }
}
