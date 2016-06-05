using BSF.DAL;
using BSF.Helpers;
using BSF.View;
using System.Windows.Input;

namespace BSF.ViewModel
{
    internal class ReferentAccount
    {
        private LoginViewModel loginViewModel;
        private Person user;
        public ICommand MyAccount { get; set; }
        public ICommand PanelNav { get; set; }
        public INavigation MyNavigationService { get; set; }

        public ReferentAccount(LoginViewModel loginViewModel, ref Person user)
        {
            this.loginViewModel = loginViewModel;
            this.user = user;
            MyNavigationService = new NavigationService();
            MyAccount = new RelayCommand<object>(myAccount);
            PanelNav = new RelayCommand<object>(panelNav);
        }

        private void myAccount(object parameter)
        {
            MyNavigationService.Navigate(typeof(UserAccount), new UserAccountViewModel(this, ref user)):
        }
        private void panelNav (object parameter)
        {
            MyNavigationService.Navigate(typeof(ReferentAccountPanel), this);
        }
    }
}