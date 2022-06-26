using System.Collections.ObjectModel;
using KpProjects.Classes;

namespace KpProjects.WpfClient.ViewModels.Base
{
    public class DataListViewModel<TDataClass>
        where TDataClass : DataClass
    {
        #region Properties

        #region DataList

        public ObservableCollection<TDataClass> DataList { get; }

        #endregion

        #endregion
    }
}
