using KpProjects.Classes;
using KpProjects.Connector;
using KpProjects.WpfClient.ViewModels.Base;

namespace KpProjects.WpfClient.ViewModels
{
    public class PersonViewModel : DataItemViewModel<Person>
    {
        public override string Title => DataItem.Name;

        public PersonViewModel(IDataClient client) : base(client)
        {

        }

    }
}
