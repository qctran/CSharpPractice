// LinkListDemo.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

struct LinkNode
{
  int value;
  LinkNode* next;
};
typedef LinkNode* nodePtr;

void Push(nodePtr& head, int data);
int Pop(nodePtr& head);
void DeleteNumbers(nodePtr& head, int n);
void Print(nodePtr& head);
void InsertLast(nodePtr& head, int data);
void DeleteLast(nodePtr& head);

int main()
{
  nodePtr head;
  head = new LinkNode;
  head->value = 20;
  head->next = NULL;

  Push(head, 30);
  Push(head, 40);
  Push(head, 6);
  Push(head, 3);
  Push(head, 6);
  Print(head);
  DeleteNumbers(head, 6);
  Print(head);
  /*cout << "Pop: " << Pop(head) << endl;
  cout << "Pop: " << Pop(head) << endl;
  Print(head);*/
  InsertLast(head, 100);
  Print(head);
  DeleteLast(head);
  Print(head);
}

void Print(nodePtr& head)
{
  if (head == NULL)
  {
    cout << "Empty list" << endl;
    return;
  }
  nodePtr tmp = new LinkNode;
  tmp = head;
  while (tmp->next != NULL)
  {
    cout << tmp->value << " ";
    tmp = tmp->next;
  }
  cout << tmp->value;
  cout << endl;
}

void Push(nodePtr& head, int data)
{
  nodePtr tmp;
  tmp = new LinkNode;
  tmp->value = data;
  tmp->next = head;
  head = tmp;

}

int Pop(nodePtr& head)
{
  int val = head->value;
  if (head->next != NULL)
  {
    head = head->next;
  }
  else
  {
    head = NULL;
  }
  return val;
}

void DeleteNumbers(nodePtr& head, int n)
{
  if (head == NULL)
  {
    cout << "Empty List" << endl;
    return;
  }

  if (head->next == NULL && head->value == n)
  {
    head = NULL;
    return;
  }

  LinkNode* trailing = head;
  LinkNode* tmp = head->next;
  while (tmp->next != NULL)
  {
    if (trailing->value != NULL && trailing->value == n)
    {
      trailing = tmp;
      tmp = tmp->next;
      head = trailing;
    }
    else
    {
      if (tmp->value == n)
      {
        tmp = tmp->next;
        trailing->next = tmp;
      }
      else
      {
        trailing = tmp;
        tmp = tmp->next;
      }
    }
  }
}

void InsertLast(nodePtr& head, int data)
{
  LinkNode* tmp = head;

  while (tmp->next != NULL)
  {
    tmp = tmp->next;
  }
  LinkNode* newNode = new LinkNode;
  newNode->value = data;
  newNode->next = NULL;
  tmp->next = newNode;
}

void DeleteLast(nodePtr& head)
{
  if (head == NULL)
  {
    cout << "Empty List" << endl;
    return;
  }

  // single node: delete it.
  if (head->next == NULL)
  {
    head = NULL;
    return;
  }

  // more than one node then mark the last trailing node's next to NULL
  LinkNode* trailing = head;
  LinkNode* tmp = head->next;
  while (tmp->next != NULL)
  {
    trailing = tmp;
    tmp = tmp->next;
  }

  trailing->next = NULL;
}

