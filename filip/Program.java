package filip;

import java.util.Scanner;

public class Program {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String a = reverse(sc.next());
        String b = reverse(sc.next());
        
        if (Integer.parseInt(b) > Integer.parseInt(a)) {
            System.out.println(b);
        } else {
            System.out.println(a);
        }
        sc.close();
    }

    public static String reverse(String str) {
        StringBuilder strb = new StringBuilder();
        char[] tmp = str.toCharArray();

        for (int i = tmp.length - 1; i >= 0; i--) {
            strb.append(tmp[i]);
        }

        return strb.toString();
    }

    public static String reverse2(String str) {
        return new StringBuilder(str).reverse().toString();
    }

}