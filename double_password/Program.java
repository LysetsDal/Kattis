package double_password;

import java.util.Arrays;
import java.util.Scanner;


public class Program {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        char[] pw1 = sc.next().toCharArray();
        char[] pw2 = sc.next().toCharArray();

        if (Arrays.equals(pw1, pw2)) { 
            System.out.println(1); 
            sc.close();
            return;
        }

        int total_sequences = 1;
        for (int i = 0; i < pw1.length; i++) {
            if (pw1[i] == pw2[i]) { 
                total_sequences *= 1;
            } else {
                total_sequences *= 2;
            }
        }
        System.out.println(total_sequences);
        sc.close();
    }
}