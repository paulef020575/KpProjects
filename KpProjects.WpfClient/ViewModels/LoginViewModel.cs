using KpProjects.WpfClient.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace KpProjects.WpfClient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties

        #region Login

        private string _login;

        public string Login
        {
            get => _login;
            set
            {
                if (!string.Equals(_login, value, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    _login = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Domain

        private string _domain;

        public string Domain
        {
            get => _domain;
            set
            {
                if (!string.Equals(_domain, value, StringComparison.CurrentCultureIgnoreCase))
                {
                    _domain = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Password

        public string Password { get; set; }

        #endregion

        #endregion


        public override string Title => "Авторизация";

        protected override async Task LoadingData()
        {
            Login = Environment.UserName;


        }
    }
}
