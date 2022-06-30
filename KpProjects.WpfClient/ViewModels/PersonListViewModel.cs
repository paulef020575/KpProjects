using KpProjects.Classes;
using KpProjects.Connector;
using KpProjects.WpfClient.ViewModels.Base;
using System;
using System.DirectoryServices.AccountManagement;

namespace KpProjects.WpfClient.ViewModels
{
    /// <summary>
    ///     Модель представления "Список пользователей"
    /// </summary>
    public class PersonListViewModel : DataListViewModel<Person>
    {
        #region Properties

        #region Title

        /// <inheritdoc />
        public override string Title => "Список пользователей";

        #endregion

        #region ItemViewModelName

        protected override string ItemViewModelName => nameof(PersonViewModel);

        #endregion

        #endregion

        #region ctors

        public PersonListViewModel()
            : base()
        {
            DataList.Add(new Person { Firstname = "Иван", Secondname = "Иванович", Lastname = "Иванов"});
            DataList.Add(new Person { Firstname = "Петр", Secondname = "Петрович", Lastname = "Петров"});
            DataList.Add(new Person { Firstname = "Сидор", Secondname = "Сидорович", Lastname = "Сидоров"});
        }

        public PersonListViewModel(IDataClient client) : base(client) { }

        #endregion

        #region Methods

        #endregion
    }
}
