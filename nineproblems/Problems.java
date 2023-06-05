package nineproblems;

// https://open.kattis.com/problems/99problems
import java.util.Scanner;

class Problems {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int num = sc.nextInt();
        int result = 0;

        if (1 <= num && num <= 100000) {
            int remainder = num % 100;
            int diff = 99 - remainder;


            if (diff <= 0) {
                result = num + diff + 100;
            } else {
                if (diff <= 51) {
                    result = num + diff;
                } else {
                    if (num <= 47) {
                        result = 99;
                    } else {
                        result = num - (remainder + 100) + 99;
                    }
                }
            }
        }

        System.out.println(result);
    }
}
