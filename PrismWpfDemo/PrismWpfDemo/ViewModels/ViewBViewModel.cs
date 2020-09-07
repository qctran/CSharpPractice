using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace PrismWpfDemo.ViewModels
{
    public class ViewBViewModel: BindableBase
    {
        private string _myText = "My View B";
        public string MyText
        {
            get { return _myText; }
            set
            {
                SetProperty(ref _myText, value);
            }
        }

    }
}
