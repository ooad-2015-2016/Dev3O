using BSF.DAL;
using BSF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BSF.ViewModel
{
    public class SupervisorPanelViewModel : INotifyPropertyChanged
    {
        public INavigation MyNavigationServis { get; set; }
        private ObservableCollection<Person> _PenndingAccounts;
        private LoginViewModel loginViewModel;

        public ObservableCollection<Person> PenndingAccounts
        {
            get { return _PenndingAccounts; }
            set { _PenndingAccounts = value;
                  OnPropertyChanged();
            }
        }

        public SupervisorPanelViewModel()
        {
            MyNavigationServis = new NavigationService();
            using(var db = new BankDbContext())
            {
                PenndingAccounts = (ObservableCollection<Person>) db.Persons.Where(x => x.Validated == false);
            }
        }

        public SupervisorPanelViewModel(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string property = "")
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
