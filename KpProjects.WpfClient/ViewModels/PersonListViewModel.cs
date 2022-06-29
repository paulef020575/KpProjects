using KpProjects.Classes;
using KpProjects.Connector;
using KpProjects.WpfClient.ViewModels.Base;

namespace KpProjects.WpfClient.ViewModels
{
    public class PersonListViewModel : DataListViewModel<Person>
    {
        public override string Title => "Список пользователей";

        public PersonListViewModel()
            : base()
        {
            DataList.Add(new Person { Firstname = "Иван", Secondname = "Иванович", Lastname = "Иванов"});
            DataList.Add(new Person { Firstname = "Петр", Secondname = "Петрович", Lastname = "Петров"});
            DataList.Add(new Person { Firstname = "Сидор", Secondname = "Сидорович", Lastname = "Сидоров"});
        }

        public PersonListViewModel(IDataClient client) : base(client) { }

        protected override void Add()
        {
            DataList.Add(new Person {Lastname = "Петрова", Firstname = "Ирина", Secondname = "Викторовна"});
        }
    }
}
