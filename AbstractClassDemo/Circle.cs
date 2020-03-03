using System;

namespace AbstractClassDemo
{
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a circle");
        }

        public override void Copy()
        {
            Console.WriteLine("Circle copy");
        }
    }
}
