using System;

namespace ConsumerDemo
{
    public class MyInfoEventArgs : EventArgs
    {
        public int Status { get; set; }
        public MyInfoEventArgs()
        {
        }
    }
}
