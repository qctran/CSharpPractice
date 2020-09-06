using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWpfDemo.ViewModels
{
    public class ViewAViewModel: BindableBase
    {
        private string _firstname = "Conan";
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                SetProperty(ref _firstname, value);
            }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                SetProperty(ref _lastname, value);
            }
        }

        private DateTime? _lastUpdated;
        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set
            {
                SetProperty(ref _lastUpdated, value);
            }
        }

        public DelegateCommand UpdateCommand { get; set; }
        public ViewAViewModel()
        {
            UpdateCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => Lastname).ObservesProperty(() => Firstname);
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Lastname) && !string.IsNullOrWhiteSpace(Firstname);
        }

        private void Execute()
        {
            LastUpdated = DateTime.Now;
        }
    }
}
