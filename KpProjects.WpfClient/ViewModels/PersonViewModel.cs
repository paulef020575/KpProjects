using KpProjects.Classes;
using KpProjects.Connector;
using KpProjects.WpfClient.ViewModels.Base;
using System;
using System.DirectoryServices.AccountManagement;

namespace KpProjects.WpfClient.ViewModels
{
    /// <summary>
    ///     Модель представления для редактирования данных пользователя
    /// </summary>
    public class PersonViewModel : DataItemViewModel<Person>
    {
        #region Properties

        #region Title
        
        /// <inheritdoc />
        public override string Title => DataItem.Name;

        #endregion

        #region Lastname

        public string Lastname
        {
            get
            {
                return GetValue<string>();
            }

            set
            {
                SetValue(value);
                RaisePropertyChanged(nameof(Title));
            }

        }

        #endregion

        #endregion

        #region ctor's
        public PersonViewModel(IDataClient client) : base(client) { }

        #endregion

        #region Methods

        #region ReadFromAd

        private void ReadFromAd(object search)
        {
            if (search is string searchString)
            {
                string[] principals = searchString.Trim().Split(new char[] {'/', '\\'}, StringSplitOptions.RemoveEmptyEntries);
                string userName = principals[0], domain = "";
                if (principals.Length > 1)
                {
                    userName = principals[1];
                    domain = principals[0];
                }


                UserPrincipal adUser = GetAdUser(userName, domain);

                if (adUser == null)
                {
                    ShowErrorMessage("Пользователь домена не найден");
                    return;
                }

                Lastname = adUser.Surname;
            }
        }

        #endregion

        #region GetAdUser

        private UserPrincipal GetAdUser(string userName, string domain = "")
        {
            PrincipalContext adContextGeneral;

            if (string.IsNullOrEmpty(domain))
                adContextGeneral = new PrincipalContext(ContextType.Domain);
            else
                adContextGeneral = new PrincipalContext(ContextType.Domain, domain);

            return UserPrincipal.FindByIdentity(adContextGeneral, userName);
        }

        #endregion

        #endregion

        #region Commands

        #region ReadFromAdCommand

        private RelayCommand _readFromAdCommand;

        public RelayCommand ReadFromAdCommand
        {
            get
            {
                if (_readFromAdCommand == null)
                    _readFromAdCommand = new RelayCommand("Поиск", x => ReadFromAd(x), x => !string.IsNullOrEmpty((string)x));

                return _readFromAdCommand;
            }
        }

        #endregion

        #endregion
       
        
    }
}
