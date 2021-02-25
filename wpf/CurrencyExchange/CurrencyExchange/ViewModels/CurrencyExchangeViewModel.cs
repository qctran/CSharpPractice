using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CurrencyExchange.ViewModels
{
    public class CurrencyExchangeViewModel : INotifyPropertyChanged
    {
        #region Properties
        private ObservableCollection<ExchangeItem> _exchangeList = new ObservableCollection<ExchangeItem>();
        public ObservableCollection<ExchangeItem> ExchangeList
        {
            get { return _exchangeList; }
            set
            {
                _exchangeList = value;
                NotifyPropertyChanged("ExchangeList");
            }
        }

        private ExchangeItem _selectedExchange = new ExchangeItem();
        public ExchangeItem SelectedExchange
        {
            get { return _selectedExchange; }
            set
            {
                _selectedExchange = value;
                NotifyPropertyChanged("SelectedExchange");
                CalculateExchangeFund(SelectedExchange);
            }
        }

        

        private double _srcAmount;
        public double SrcAmount
        {
            get { return _srcAmount; }
            set
            {
                if (value != _srcAmount)
                {
                    _srcAmount = value;
                    NotifyPropertyChanged("SrcAmount");
                }
            }
        }

        private double _tgtAmount;
        public double TgtAmount
        {
            get { return _tgtAmount; }
            set
            {
                if (value != _tgtAmount)
                {
                    _tgtAmount = value;
                    NotifyPropertyChanged("TgtAmount");
                }
            }
        }
        #endregion

        public CurrencyExchangeViewModel()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            _srcAmount = _tgtAmount = 0.0;
            GetExchangableItems();
            SelectedExchange = ExchangeList[0];
        }

        private void GetExchangableItems()
        {
            ExchangeList.Add(new ExchangeItem { CountryName = "Japan", CountryCode = 3 });
            ExchangeList.Add(new ExchangeItem { CountryName = "Canada", CountryCode = 4});
            ExchangeList.Add(new ExchangeItem { CountryName = "Euro", CountryCode = 20 });
            ExchangeList.Add(new ExchangeItem { CountryName = "China", CountryCode = 33 });
            ExchangeList.Add(new ExchangeItem { CountryName = "Mexico", CountryCode = 12 });
        }

        private void CalculateExchangeFund(ExchangeItem selectedExchange)
        {
            throw new NotImplementedException();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

    }
}
