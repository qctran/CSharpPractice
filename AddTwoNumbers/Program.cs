using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }

    internal class SingleLinkedList
    {
        internal ListNode head;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new SingleLinkedList();
            InsertFront(list1, 3);
            InsertFront(list1, 4);
            InsertFront(list1, 2);

            var list2 = new SingleLinkedList();
            InsertFront(list2, 4);
            InsertFront(list2, 6);
            InsertFront(list2, 5);

            PrintList(list1.head);
            
        }

        private static void PrintList(ListNode node)
        {
            if (node.next == null)
            {
                Console.WriteLine();
            }
            else
            {
                
                Console.Write(node.val + "->");
                PrintList(node.next);
            }
        }

        private static void InsertFront(SingleLinkedList singleList, int num)
        {
            var newNode = new ListNode(num);
            newNode.next = singleList.head;
            singleList.head = newNode;
        }
    }
}
