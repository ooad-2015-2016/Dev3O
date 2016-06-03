using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSF.DAL;
using BSF.Helpers;
using System.Runtime.CompilerServices;
using BSF.Model;
using System.Windows.Input;

namespace BSF.ViewModel
{
    public class KonverzijaViewModel : INotifyPropertyChanged
    {
        public INavigation MyNavigationService { get; set; }
        MainPageViewModel parent;

        public string _Iznos;
        public string IznosZaKonvertirati
        {
            get { return _Iznos; }
            set
            {
                _Iznos = value;
                OnProprertyChanged();
            }
        }
        public string _PretvoreniIznos;
        public string PretvoreniIznos
        {
            get { return _PretvoreniIznos; }
            set
            {
                _PretvoreniIznos = value;
                OnProprertyChanged();
            }
        }
        public ICommand Pretvori { get; set; }

        public KonverzijaViewModel(MainPageViewModel parent)
        {
            this.parent = parent;
            MyNavigationService = new NavigationService();
            Pretvori = new RelayCommand<object>(pretvori, mozeLiSePretvoriti);

        }
        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private bool mozeLiSePretvoriti(object parameter)
        {
            if (IznosZaKonvertirati.Length == 0 || !IsDigitsOnly(IznosZaKonvertirati)) return false;
            return true;
        }
        private void pretvori(object parameter)
        {
            int x = Convert.ToInt32(IznosZaKonvertirati);
            double y = x * 0.57408;
            PretvoreniIznos = y.ToString();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnProprertyChanged([CallerMemberName] string property = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
