using System;

namespace LinkedListAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new SinglyLinkedList();
            myList.InsertFirst(100);
            myList.InsertFirst(40);
            myList.InsertFirst(30);
            myList.InsertFirst(99);
            myList.InsertLast(9999);
            myList.DisplayList();

            myList.DeleteFirst();
            myList.DisplayList();
        }
    }

    public class SinglyLinkedList
    {
        private Node first;

        public bool IsEmpty()
        {
            return first == null;
        }

        public void InsertFirst(int data)
        {
            var newNode = new Node {data = data, next = first};
            first = newNode;
        }

        public Node DeleteFirst()
        {
            var temp = first;
            first = first.next;
            return temp;
        }

        public void DisplayList()
        {
            Console.WriteLine("List (first -- last) ");
            Node current = first;
            while (current != null)
            {
                current.DisplayNode();
                current = current.next;
            }

            Console.WriteLine();
        }

        public void InsertLast(int data)
        {
            var current = first;
            while (current.next != null)
            {
                current = current.next;
            }

            var newNode = new Node {data = data};
            current.next = newNode;
        }
    }
    public class Node
    {
        public int data;
        public Node next;

        public void DisplayNode()
        {
            Console.WriteLine("<" + data + ">");
        }
    }
}
