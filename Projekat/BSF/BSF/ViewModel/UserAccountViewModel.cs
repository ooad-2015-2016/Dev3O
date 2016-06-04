using BSF.DAL;
using BSF.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Popups;

namespace BSF.ViewModel
{
    internal class UserAccountViewModel : INotifyPropertyChanged
    {
        private LoginViewModel loginViewModel;
        private Person user;
        private ObservableCollection<Transaction> _UserTransactions;

        public ObservableCollection<Transaction> UserTransactions
        {
            get { return _UserTransactions; }
            set {
                _UserTransactions = value;
                OnPropertyChanged();
            }
        }

        public BankAccount Account { get; set; }

        public ICommand  DoTransaction { get; set; }
        public int NumberToAccount { get; set; }
        public int Amount { get; set; }

        public UserAccountViewModel(LoginViewModel loginViewModel, ref Person user)
        {
            this.loginViewModel = loginViewModel;
            this.user = user;
            DoTransaction = new RelayCommand<object>(doTransaction);
            using (var db = new BankDbContext())
            {
                Account = db.BankAccounts.Where(ac=>ac.Owner.AccoutnId == this.user.AccoutnId).FirstOrDefault();
                _UserTransactions = new ObservableCollection<Transaction>();
                foreach(var transaction in db.Transactions)
                {
                    if (transaction.FromAccount == Account || transaction.ToAccount == Account)
                        _UserTransactions.Add(transaction);
                }
            }
        }


        private void doTransaction(object parameter)
        {
            using (var db = new BankDbContext())
            {
                BankAccount ba = db.BankAccounts.Where(b => b.BankAccountID == NumberToAccount).FirstOrDefault();
                if(ba == null)
                {
                    var message = new MessageDialog("Ne postoji racun sa tim brojem!");
                    message.ShowAsync();
                }else
                {
                    Transaction newTransaction = new Transaction();
                    newTransaction.Amount = Amount;
                    newTransaction.FromAccount = Account;
                    newTransaction.ToAccount = ba;
                    newTransaction.TimeStamp = DateTime.Now;
                    ba.Balance += Amount;
                    Account.Balance -= Amount;
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
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}