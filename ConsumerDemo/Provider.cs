using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerDemo
{
    public class Provider
    {
        public event EventHandler<MyInfoEventArgs> StatusUpdated;
        private MyInfoEventArgs _myInfo = new MyInfoEventArgs();

        public Provider()
        {
            _myInfo.Status = 10;
        }

        public void StartUpdate()
        {
            for(var i = 0; i < 10; i++)
            {
                OnStatusUpdated();
                _myInfo.Status += 10;
                Thread.Sleep(100);
            }
        }

        protected virtual void OnStatusUpdated()
        {
            if (StatusUpdated != null)
            {
                StatusUpdated(this, _myInfo);
            }
        }
    }
}
