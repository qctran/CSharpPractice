using System;

namespace AbstractClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var cir = new Circle();
            cir.Draw();
            cir.Copy();

            var rect = new Rectangular();
            rect.Draw();
            rect.Copy();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
