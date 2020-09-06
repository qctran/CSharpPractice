using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismWpfDemo
{
    [Obsolete]
    public class Bootstrapper : UnityBootstrapper
    {
        // This is from Prism 6.  Prism 7 may have a different
        // way to do this.
        //protected override DependencyObject CreateShell()
        //{
        //    return Container.Resolve<MainWindow>();
        //    //return base.CreateShell();
        //}
        public Bootstrapper()
        {
        }
    }
}
