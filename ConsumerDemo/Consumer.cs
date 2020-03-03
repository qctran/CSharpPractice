using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDemo
{
    public class Consumer
    {
        Provider _provider;
        public Consumer()
        {
            _provider = new Provider();
            _provider.StatusUpdated += OnStatusUpdated;

            
        }

        public void StartToListen()
        {
            _provider.StartUpdate();
        }

        private void OnStatusUpdated(object sender, MyInfoEventArgs e)
        {
            if (e == null) return;

            Console.WriteLine("Status: {0}", e.Status);
        }
    }
}
