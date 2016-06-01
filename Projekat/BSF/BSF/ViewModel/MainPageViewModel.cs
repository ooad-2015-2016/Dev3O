using BSF.Helpers;
using BSF.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BSF.ViewModel
{
    public class MainPageViewModel
    {
        public INavigation MyNavigationService { get; set; }
        public ICommand NavigateToRegistration { get; set; }
        public ICommand NavigateToLogin { get; set; }
        public MainPageViewModel()
        {
            MyNavigationService = new NavigationService();
            NavigateToRegistration = new RelayCommand<object>(registration);
        }
        private void registration(object parameter)
        {
            MyNavigationService.Navigate(typeof(Registration), new RegistrationViewModel(this));
        }
    }
}
    