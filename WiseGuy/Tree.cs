using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace WiseGuy;

public class BinaryTree
{

    public Node root { get; set; }
    public int size = 0;

    public BinaryTree()
    {
        root = null;
    }

    public BinaryTree(Node node)
    {
        root = node;
    }

    public void Put(int key)
    {
        Node newNode = new Node(key, "a");
        if (root is null)
        {
            size = size + 1;
            root = newNode;
        }

        Node parent = FindNode(key);

        if (key < parent.Key)
        {
            parent.Left = newNode;
            parent.Left.parent = parent;
        }
        else if (key > parent.Key)
        {
            parent.Right = newNode;
            parent.Right.parent = parent;
        }
        else {
            
        }

    }

    public bool Contains(int key)
    {
        return FindNode(key) != null;
    }


    public Node FindNode(int key)
    {
        Node current = root;
        while (current != null)
        {
            if (key < current.Key)
            {
                if (current.Left == null) { return current; }
                current = current.Left;
            }
            else if (key > current.Key)
            {
                if (current.Right == null) { return current; }
                current = current.Right;
            }
            else
            {
                return current;
            }
        }
        return null;
    }



    public class Node
    {
        public int Key { get; set; }
        public string Val { get; set; }
        public bool Visited { get; set; } = false;
        public Node parent { get; set; } = null;
        public Node Left { get; set; } = null;
        public Node Right { get; set; } = null;

        public Node(int _key, string _val)
        {
            Key = _key;
            Val = _val;
        }

        public override string ToString()
        {
            return $"Node: Key = {Key} ; Val = {Val} ";
        }
    }

    public void PrintTree()
    {
        if (size == 0)
        {
            Console.WriteLine("Empty tree");
        }

        Stack<Node> stack = new Stack<Node>();
        Node current = root;

        while (current != null || stack.Count > 0)
        {

            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            Console.WriteLine(current.ToString());
            current = current.Right;
        }
    }

}