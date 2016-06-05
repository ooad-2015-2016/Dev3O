using BSF.DAL;
using BSF.Helpers;
using BSF.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Popups;

namespace BSF.ViewModel
{
    internal class ReferentAccount : INotifyPropertyChanged
    {
        private LoginViewModel loginViewModel;
        private Person user;
        public ICommand MyAccount { get; set; }
        public ICommand PanelNav { get; set; }
        public ICommand DoWork { get; set; }
        public INavigation MyNavigationService { get; set; }

        public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        public double Amount { get; set; }
        public bool? Trans { get; set; }
        public bool? Dep { get; set; }
        public bool? Rise { get; set; }

        private ObservableCollection<Transaction> _UserTransactions;
        public ObservableCollection<Transaction> UserTransactions
        {
            get { return _UserTransactions; }
            set
            {
                _UserTransactions = value;
                OnPropertyChanged();
            }
        }


        public ReferentAccount(LoginViewModel loginViewModel, ref Person user)
        {
            this.loginViewModel = loginViewModel;
            this.user = user;
            MyNavigationService = new NavigationService();
            MyAccount = new RelayCommand<object>(myAccount);
            PanelNav = new RelayCommand<object>(panelNav);
            using (var db = new BankDbContext())
            {
                _UserTransactions = new ObservableCollection<Transaction>();
                foreach (var transaction in db.Transactions)
                {
                    if (transaction.Referent == this.user)
                        _UserTransactions.Add(transaction);
                }
            }
            DoWork = new RelayCommand<object>(doWork);
        }

        private void myAccount(object parameter)
        {
            MyNavigationService.Navigate(typeof(UserAccount), new UserAccountViewModel(this, ref user));
        }
        private void panelNav (object parameter)
        {
            MyNavigationService.Navigate(typeof(ReferentAccountPanel), this);
        }

        private void doWork(object parameter)
        {
            if (Amount <= 0)
            {
                var message = new MessageDialog("Vrijednost ne moze biti negativna!");
                message.ShowAsync();
            }
            using (var db = new BankDbContext())
            {
                BankAccount bTo = db.BankAccounts.Where(b => b.BankAccountID == AccountTo).FirstOrDefault();
                BankAccount bFrom = db.BankAccounts.Where(b => b.BankAccountID == AccountFrom).FirstOrDefault();
                if (bTo == null && (Trans == true || Dep == true))
                {
                    var message = new MessageDialog("Ne postoji racun sa tim brojem!(Prema)");
                    message.ShowAsync();
                }
                else if (bFrom == null && (Trans == true || Rise == true))
                {
                    var message = new MessageDialog("Ne postoji racun sa tim brojem!(Sa)");
                    message.ShowAsync();
                }
                else
                {
                    Transaction newTransaction = new Transaction();
                    newTransaction.Amount = Amount;
                    newTransaction.FromAccount = bFrom;
                    newTransaction.ToAccount = bTo;
                    newTransaction.TimeStamp = DateTime.Now;
                    newTransaction.Referent = user;
                    if(bTo != null)bTo.Balance += Amount;
                    if(bFrom != null)bFrom.Balance -= Amount;
                    db.Transactions.Add(newTransaction);
                    _UserTransactions.Add(newTransaction);
                    db.SaveChanges();
                    var message = new MessageDialog("Transakcija uspjesna!");
                    message.ShowAsync();

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string property = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}