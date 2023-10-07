package saving_daylight;

import java.util.Scanner;

/**
 * Program https://open.kattis.com/problems/savingdaylight
 * Passed.
 */
public class Program {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        StringBuilder strb = new StringBuilder();

        while (sc.hasNextLine()) {
            String[] line = parseLine(sc.nextLine());

            String timeStamp = subtractTimestamps(line[3], line[4]);

            for (int i = 0; i < 3; i++) {
                strb.append(line[i] + " ");
            }
            strb.append(timeStamp);

            System.out.println(strb.toString().trim());
            strb.delete(0, strb.length());

        }
        sc.close();
    }

    public static String[] parseLine(String in) {
        return in.split(" ");
    }

    public static String subtractTimestamps(String a, String b) {
        int[] time_a = parseTimestampToInt(a);
        int[] time_b = parseTimestampToInt(b);

        int mins = time_b[1] - time_a[1];
        int hours = time_b[0] - time_a[0];

        if (mins < 0) {
            hours = hours - 1;
            mins = 60 + mins;
        }

        return String.valueOf(hours) + " hours " + String.valueOf(mins) + " minutes";
    }

    public static int[] parseTimestampToInt(String stp) {
        String[] tmp = stp.split(":");
        return new int[] { Integer.parseInt(tmp[0]), Integer.parseInt(tmp[1]) };
    }
}