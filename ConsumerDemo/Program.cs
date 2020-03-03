using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var consumer = new Consumer();
            consumer.StartToListen();
        }
    }
}
