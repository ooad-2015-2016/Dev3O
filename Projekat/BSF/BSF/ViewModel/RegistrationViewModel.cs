using BSF;
using BSF.DAL;
using BSF.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace BSF.ViewModel
{
    internal class RegistrationViewModel : INotifyPropertyChanged
    { 
        public MainPageViewModel Parent { get; set; }
        public INavigation MyNavigationService { get; set; }
        public Person NewPerson { get; set; }
        public BankAccount NewBankAccount { get; set; }
        public ICommand Register { get; set; }
        public ICommand Back { get; set; }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _SurName;

        public string SurName
        {
            get { return _SurName; }
            set { _SurName = value;
                OnPropertyChanged("SurName");
            }
        }
        private string _NameOfFather;

        public string NameOfFather
        {
            get { return _NameOfFather; }
            set { _NameOfFather = value;
                OnPropertyChanged("NameOfFather");
            }
        }

        public string JMBG { get; set; }
        public string  Adress { get; set; }
        public string City { get; set; }
        public int PostalNumber { get; set; }
        public string TelephoneNumber1 { get; set; }
        public string TelephoneNumber2 { get; set; }
        public string Email { get; set; }
        public Boolean? TermsOfUse { get; set; }


        public RegistrationViewModel(MainPageViewModel parent)
        {
            NewPerson = new Person();
            NewBankAccount = new BankAccount();
            this.Parent = parent;
            MyNavigationService = new NavigationService();
            Back = new RelayCommand<object>(goBack);
            Register = new RelayCommand<object>(register, canRegister);
            Adress = "Proba";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void goBack(object parameter)
        {
            MyNavigationService.Navigate(typeof(MainPage), new MainPageViewModel());
        }

        private bool canRegister(object parameter)
        {
            return true;
        }

        private void register(object parameter)
        {
            #region Person
            NewPerson.Name = Name;
            NewPerson.SurName = SurName;
            NewPerson.JMBG = JMBG;
            NewPerson.NameOfFather = NameOfFather;
            NewPerson.Adress = Adress;
            NewPerson.City = City;
            NewPerson.PostalNumber = PostalNumber;
            NewPerson.TelephoneNumber = "(" + TelephoneNumber1 + ")" + TelephoneNumber2;
            NewPerson.Email = Email;
            NewPerson.Username = Email;
            NewPerson.Password = "12345";
            NewPerson.Type = "Tip";
            #endregion Person

            #region Account
            NewBankAccount.Balance = 0;
            NewBankAccount.Owner = NewPerson;
            #endregion Account

            using (var db = new BankDbContext())
            {
                db.Persons.Add(NewPerson);
                db.BankAccounts.Add(NewBankAccount);
                db.SaveChanges();
                var message = new MessageDialog("Registracija uspješna!", "Uspjeh!");
                message.ShowAsync();
            }
            MyNavigationService.Navigate(typeof(MainPage), new MainPageViewModel());
        }         
        
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
}