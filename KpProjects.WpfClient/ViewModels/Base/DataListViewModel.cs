using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using KpProjects.Classes;
using KpProjects.Connector;

namespace KpProjects.WpfClient.ViewModels.Base
{
    public abstract class DataListViewModel<TDataClass> : DataClientViewModel
        where TDataClass : DataClass
    {
        #region Properties

        #region DataList

        public ObservableCollection<TDataClass> DataList { get; }

        #endregion

        #region Title

        public override string Title => throw new System.NotImplementedException();

        #endregion

        #endregion

        #region ctor

        public DataListViewModel() { }

        public DataListViewModel(IDataClient dataClient) : base(dataClient) { }

        #endregion


        #region Methods

        #region LoadingData

        protected async override Task LoadingData()
        {
            IEnumerable<TDataClass> items = await DataClient.LoadList<TDataClass>();
        }

        #endregion

        #endregion
    }
}
