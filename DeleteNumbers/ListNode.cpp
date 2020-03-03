#include<iostream>
#include "ListNode.h"

class ListNode
{
public:
  int value;
  ListNode* Next;

  ListNode(int data);
  void Push(ListNode*, int data);
};

ListNode::ListNode(int data)
{
  value = data;
}

void ListNode::Push(ListNode* head, int data)
{
  ListNode* newNode = new ListNode(data);
  if (head == NULL)
  {
    head = newNode;
  }
  else
  {
    newNode->Next = head;
    head = newNode;
  }
}



