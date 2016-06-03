using BSF.DAL;

namespace BSF.ViewModel
{
    internal class ReferentAccount
    {
        private LoginViewModel loginViewModel;
        private Person user;

        public ReferentAccount(LoginViewModel loginViewModel, ref Person user)
        {
            this.loginViewModel = loginViewModel;
            this.user = user;
        }
    }
}