namespace AbstractClassDemo
{
    public abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void Draw();

        public virtual void Copy()
        {
            System.Console.WriteLine("Shape copy");
        }
    }
}
