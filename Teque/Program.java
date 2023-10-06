package Teque;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

// https://open.kattis.com/problems/teque

class Program {

    static class Teque {
        Index head;
        Index tail;
        int size;
    }

    public static class Index {
        public Index prev;
        public Index next;
        public int val;

        public Index(int val) {
            this.val = val;
        }
    }

    public static void main(String[] args) throws IOException, NumberFormatException {

        // InputStream stream = System.in;
        BufferedInputStream bufferedStream = new BufferedInputStream(System.in);
        BufferedReader reader = new BufferedReader(new InputStreamReader(bufferedStream));
        int n = Integer.parseInt(reader.readLine());

        Teque teque = new Teque();

        for (int i = 0; i < n; i++) {
            String line = reader.readLine();
            String[] inputCommands = line.split(" ", 2);

            // System.out.println("Command: " + inputCommands[0]);
            // System.out.println("Num: " + inputCommands[1]);

            if ("push_back".equals(inputCommands[0])) {
                pushBack(teque, Integer.parseInt(inputCommands[1]));
                // System.out.println("PUSH BACK");
            }
            if ("push_front".equals(inputCommands[0])) {
                pushFront(teque, Integer.parseInt(inputCommands[1]));
                // System.out.println("PUSH FRONT");
            }
            if ("push_middle".equals(inputCommands[0])) {
                pushMid(teque, Integer.parseInt(inputCommands[1]));
                // System.out.println("PUSH MID");
            }
            if ("get".equals(inputCommands[0])) {
                getI(teque, Integer.parseInt(inputCommands[1]));
                // System.out.println("GET I");
            }
        }
    }

    public static void pushFront(Teque teque, int val) {
        Index newNode = new Index(val);
        if (teque.head != null) {
            teque.head.prev = newNode;
            newNode.next = teque.head;
        }
        teque.head = newNode;
        if (teque.tail == null) {
            teque.tail = newNode;
        }
        teque.size++;
    }

    public static void pushBack(Teque teque, int val) {
        Index newNode = new Index(val);
        if (teque.tail != null) {
            teque.tail.next = newNode;
            newNode.prev = teque.tail;
        }
        teque.tail = newNode;
        if (teque.head == null) {
            teque.head = newNode;
        }
        teque.size++;
    }

    public static void pushMid(Teque teque, int val) {
        if (teque.head == null) {
            pushFront(teque, val);
            return;
        } else if (teque.tail == teque.head) {
            pushBack(teque, val);
            return;
        }

        Index slow = teque.head;
        Index fast = teque.head;
        while (fast != null && fast.next != null && fast.next.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        Index newNode = new Index(val);
        newNode.next = slow.next;
        newNode.prev = slow;

        if (slow.next != null) {
            slow.next.prev = newNode;
        }
        slow.next = newNode;

        teque.size++;
    }

    public static void getI(Teque teque, int index) {
        if (index < 0 || index >= teque.size) {
            System.out.println("Index out of bounds");
            return;
        }

        if (index < teque.size / 2) {
            int count = 0;
            Index current = teque.head;
            while (current != null && count < index) {
                current = current.next;
                count++;
            }
            if (current != null) {
                System.out.println(current.val);
            }
        } else {
            int count = teque.size - 1;
            Index current = teque.tail;
            while (current != null && count > index) {
                current = current.prev;
                count--;
            }
            if (current != null) {
                System.out.println(current.val);
            }
        }
    }
}
