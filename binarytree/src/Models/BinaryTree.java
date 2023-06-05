package src.Models;

public class BinaryTree {

	public int size;
	public Node root;

	public BinaryTree() {

	}

	public BinaryTree(Node root) {
		this.root = root;
	}

	public int compareNodeToKey(Node a, int b) {
		if (a.key == b) { return 0; }
		if (a.key < b) { return -1 ;}
		return 1;
	}

	// insert from data
	public void insert(int key, String val) {
		root = insert(this.root, key, val);
	}

	// insert a node obj
	public Node insert(Node x, int key, String val) {
		if (x == null) { return new Node(key, val); }

		int comp = compareNodeToKey(x, key);	
		if (comp < 0) x.left = insert(x.left, key, val);
		else if (comp > 0) x.right = insert(x.right, key, val);
		else x.val = val;
		return x;
	}

	public Node findNode(int searchKey) {
		return new Node(); // to be implemented
	}

	public void delete() {

	}




	public class Node {

		private int key;
		private String val;
		private Node left;
		private Node right;
		private boolean visited;

		public Node() {

		}

		public Node(int key) {
			this.key = key;
		}

		public Node(int key, String val) {
			this.key = key;
			this.val = val;
		}

		public Node(int key, Node left, Node right) {
			this.key = key;
			this.left = left;
			this.right = right;
		}

		public String getValue() {
			return val;
		}

		public void setValue(String val) {

			this.val = val;
		}

		public int getKey() {
			return key;
		}

		public void setKey(int key) {
			this.key = key;
		}

		public Node getRight() {
			return right;
		}

		public void setRight(Node right) {
			this.right = right;
		}

		public Node getLeft() {
			return left;
		}

		public void setLeft(Node left) {
			this.left = left;
		}

		public boolean isVisited() {
			return visited;
		}

		public void setVisited(boolean visited) {
			this.visited = visited;
		}

	}

}
