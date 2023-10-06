package DifferentProblem;

import java.util.Scanner;
import java.math.BigInteger;

// https://open.kattis.com/problems/differnet

class Program {
   public static void main(String[] args) {

      Scanner sc = new Scanner(System.in);

      while (sc.hasNextLine()) {
         String line = sc.nextLine();
         if (line == "") {
            break;
         }

         String[] nums = line.split(" ");

         BigInteger a = new BigInteger(nums[0]);
         BigInteger b = new BigInteger(nums[1]);

         System.out.println((a.subtract(b).abs()));
      }
      sc.close();
   }
}