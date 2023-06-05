package mumblerap;

import java.lang.StringBuilder;
import java.util.*;

public class MumbleRap {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        sc.nextLine();

        ArrayList<Integer> numbers = new ArrayList<Integer>();
        StringBuilder strb = new StringBuilder();

        String line = sc.nextLine();
        for (char c : line.toCharArray()) {

            if (Character.isDigit(c)) {
                strb.append(c);
            } else {
                if (strb.length() > 0) {
                    numbers.add(Integer.parseInt(strb.toString()));
                    strb.setLength(0);
                }
            }
        }

        if (strb.length() > 0) {
            numbers.add(Integer.parseInt(strb.toString()));
        }

        int result = 0;
        for (int i : numbers) {
            if (result < i) {
                result = i;
            }
        }
        System.out.println(result);
    }
}