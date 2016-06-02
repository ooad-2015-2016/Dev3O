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
        private bool? _TermsOfUse;

        public bool? TermsOfUse
        {
            get { return _TermsOfUse; }
            set { _TermsOfUse = value;
                OnPropertyChanged("TermsOfUse");
            }
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


        public RegistrationViewModel(MainPageViewModel parent)
        {
            NewPerson = new Person();
            NewBankAccount = new BankAccount();
            this.Parent = parent;
            MyNavigationService = new NavigationService();
            Back = new RelayCommand<object>(goBack);
            Register = new RelayCommand<object>(register, canRegister);
            TermsOfUse = false;

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

        private async void register(object parameter)
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
                if (Name.Length == 0 || SurName.Length == 0 || NameOfFather.Length == 0 || JMBG.Length == 0
                    || Adress.Length == 0 || City.Length == 0 || TelephoneNumber1.Length == 0 || TelephoneNumber2.Length == 0
                    || Email.Length == 0)

                {
                    var notValidated = new MessageDialog("Niste unijeli sve podatke");
                    await notValidated.ShowAsync();
                }
                else if (JMBG.Length != 13 || !IsDigitsOnly(JMBG))
                {
                    var notValidated = new MessageDialog("JMBG nije u ispravnom formau");
                    await notValidated.ShowAsync();
                }
                else if (TelephoneNumber1.Length != 4 || !TelephoneNumber1.StartsWith("+") || !IsDigitsOnly(TelephoneNumber1.Substring(1)))
                {
                    var notValidated = new MessageDialog("Telefon nije u ispravnom formatu");
                    await notValidated.ShowAsync();
                }
                else if(TelephoneNumber2.Length != 8 || !IsDigitsOnly(TelephoneNumber2))
                {
                    var notValidated = new MessageDialog("Telefon nije u ispravnom formatu");
                    await notValidated.ShowAsync();
                }
                else if(!Email.Contains("@"))
                {
                    var notValidated = new MessageDialog("Email nije u ispravnom formatu");
                    await notValidated.ShowAsync();
                }
                else if (TermsOfUse == false)
                {
                    var notValidated = new MessageDialog("Morate prihvatiti odredbe i uvjete koristenja");
                    await notValidated.ShowAsync();
                }
                else {
                    db.Persons.Add(NewPerson);
                    db.BankAccounts.Add(NewBankAccount);
                    db.SaveChanges();
                    var message = new MessageDialog("Registracija uspješna!", "Uspjeh!");
                    await message.ShowAsync();
                    MyNavigationService.Navigate(typeof(MainPage), new MainPageViewModel());
                }
            }

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