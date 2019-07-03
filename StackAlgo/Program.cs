using static System.Console;

namespace StackAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            var theStack = new Stack(4);
            theStack.Push("Star Wars");
            theStack.Push("Jaws");
            theStack.Push("Jaws 2");
            theStack.Push("Titanic");
            theStack.Push("Rocky");

            WriteLine("======\nAbout to peek:");
            WriteLine("'" + theStack.Peek() + "'" + " is as the top of the stack.\n");

            WriteLine("====== \nThe stack contains:\n");
            while (!theStack.IsEmpty())
            {
                var movie = theStack.Pop();
                WriteLine(movie);
            }
        }
    }

    public class Stack
    {
        private int maxSize;
        private string[] stackArray;
        private int top;

        public Stack(int size)
        {
            maxSize = size;
            stackArray = new string[maxSize];
            top = -1;
        }

        public void Push(string m)
        {
            if (IsFull())
            {
                WriteLine("Stack is full.");
            }
            else
            {
                top++;
                stackArray[top] = m;
            }
        }

        public string Pop()
        {
            if (IsEmpty())
            {
                WriteLine("Stack is empty.");
                return "--";
            }

            var oldTop = top;
            top--;
            return stackArray[oldTop];
        }

        public string Peek()
        {
            return stackArray[top];
        }

        public bool IsEmpty()
        {
            return (top == -1);
        }

        private bool IsFull()
        {
            return (maxSize - 1 == top);
        }
    }
}
