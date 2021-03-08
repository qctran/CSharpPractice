using System.Windows.Controls;
using CurrencyExchange.ViewModels;

namespace CurrencyExchange.Views
{
    /// <summary>
    /// Interaction logic for CurrencyExchangeView.xaml
    /// </summary>
    public partial class CurrencyExchangeView : UserControl
    {
        public CurrencyExchangeView()
        {
            InitializeComponent();
            DataContext = new CurrencyExchangeViewModel();
        }
    }
}
