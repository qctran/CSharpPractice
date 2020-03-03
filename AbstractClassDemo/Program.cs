using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
