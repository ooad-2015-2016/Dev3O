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
        private List<Person> _PenndingAccounts;
        private LoginViewModel loginViewModel;

        public List<Person> PenndingAccounts
        {
            get { return _PenndingAccounts; }
            set { _PenndingAccounts = value;
                  OnPropertyChanged("PenndingAccounts");
            }
        }

        public SupervisorPanelViewModel()
        {
           
        }

        public SupervisorPanelViewModel(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
            MyNavigationServis = new NavigationService();
            using (var db = new BankDbContext())
            {
                PenndingAccounts = new List<Person>();
                foreach(var person in db.Persons)
                {
                    if (person.Validated == false) PenndingAccounts.Add(person);
                }
            }
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
