using BSF.DAL;
using BSF.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;
using BSF.Model;
using System.Collections.Generic;
using Windows.UI.Popups;
using BSF.View;

namespace BSF.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public INavigation MyNavigationService { get; set; }
        MainPageViewModel parent;
        private string _Username;
        Person User;

        public string Username
        {
            get { return _Username; }
            set { _Username = value;
                OnProprertyChanged("Username"); }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value;
                OnProprertyChanged("Password");
            }
        }

        public ICommand Login { get; set; }


        public LoginViewModel(MainPageViewModel parent)
        {
            this.parent = parent;
            MyNavigationService = new NavigationService();
            Login = new RelayCommand<object>(login, canLogin);

        }

        private bool canLogin(object parameter)
        {
            //if (Username.Length == 0 || Password.Length == 0) return false;
            return true;
        }

        private void login(object parameter)
        {
            using(var db = new BankDbContext())
            {
                List<Person> list = db.Persons.ToList<Person>();
                User =(Person) list.Where(x => x.Username == Username && x.Password == Password).FirstOrDefault();
            }
            if(User != null)
            {
                if (!User.Validated)
                {
                    var message = new MessageDialog("Vas racun jos nije verifikovan!", "Greska!");
                    message.ShowAsync();
                    return;
                }
                if (User.Type == "Supervisor") MyNavigationService.Navigate(typeof(SupervisorPanel), new SupervisorPanelViewModel(this));
                else if (User.Type == "User") MyNavigationService.Navigate(typeof(UserAccount), new UserAccountViewModel(this,ref User));
                else if (User.Type == "Referent") MyNavigationService.Navigate(typeof(ReferentAccountMain), new ReferentAccount(this,ref User));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnProprertyChanged([CallerMemberName] string property  = "")
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}