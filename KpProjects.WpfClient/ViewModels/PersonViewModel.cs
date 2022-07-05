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

        #region Firstname

        public string Firstname
        {
            get => GetValue<string>();
            set
            {
                SetValue(value);
                RaisePropertyChanged(nameof(Title));
            }
        }

        #endregion

        #region Secondname

        public string Secondname
        {
            get => GetValue<string>();
            set
            {
                SetValue(value);
                RaisePropertyChanged(nameof(Title));
            }

        }


        #endregion

        #region Birthday

        public DateTime Birthday
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }

        #endregion

        #region AdGuid

        public Guid AdGuid
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        #endregion

        #region Domain

        public string Domain
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        #endregion

        #region DomainName

        public string DomainName
        {
            get => GetValue<string>();
            set => SetValue(value);
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

                string[] userNames = adUser.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (userNames.Length > 0)
                {
                    Lastname = userNames[0];
                    if (userNames.Length > 1)
                    {
                        Firstname = userNames[1];
                        if (userNames.Length > 2)
                            Secondname = userNames[2];
                    }
                }

                AdGuid = adUser.Guid.Value;

                PrincipalContext context = new PrincipalContext(ContextType.Domain, "karjalapulp.local");
                bool result = context.ValidateCredentials("efremovpv", "pauk522017");
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
