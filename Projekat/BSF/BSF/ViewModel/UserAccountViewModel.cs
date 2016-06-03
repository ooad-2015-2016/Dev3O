using BSF.DAL;

namespace BSF.ViewModel
{
    internal class UserAccountViewModel
    {
        private LoginViewModel loginViewModel;
        private Person user;

        public UserAccountViewModel(LoginViewModel loginViewModel, ref Person user)
        {
            this.loginViewModel = loginViewModel;
            this.user = user;
        }
    }
}