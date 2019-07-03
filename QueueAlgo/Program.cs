using static System.Console;

namespace QueueAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            var myQueue = new Queue(5);
            myQueue.Insert(100);
            myQueue.Insert(10);
            myQueue.Insert(2);
            myQueue.Insert(30);
            myQueue.Insert(99);
            myQueue.View();

            WriteLine($"Front of the queue is {myQueue.PeekFront()}");

            WriteLine("About to remove item from the queue");
            myQueue.Remove();
            myQueue.View();
        }

        public class Queue
        {
            private int maxSize;
            private long[] myQueue;
            private int front;
            private int rear;
            private int items;

            public Queue(int size)
            {
                maxSize = size;
                myQueue = new long[size];
                front = 0;
                rear = -1;
                items = 0;
            }

            public void Insert(long j)
            {
                if (IsFull())
                {
                    WriteLine("The queue is full.");
                }
                else
                {
                    if (rear == maxSize - 1)
                    {
                        rear = -1;
                    }

                    rear++;
                    myQueue[rear] = j;
                    items++;

                }
            }

            public long Remove()
            {
                var temp = myQueue[front];
                front++;
                if (front == maxSize)
                {
                    front = 0;
                }

                return temp;
            }

            public long PeekFront()
            {
                return myQueue[front];
            }

            public bool IsEmpty()
            {
                return items == 0;
            }

            public void View()
            {
                Write("[");
                for (var i = 0; i < myQueue.Length; i++)
                {
                    Write(myQueue[i] + " ");
                }
                WriteLine("]");
            }

            private bool IsFull()
            {
                return (items == maxSize);
            }
        }
    }
}
