using KpProjects.Connector;
using KpProjects.WpfClient.ViewModels.Base;

namespace KpProjects.WpfClient.ViewModels
{
    public abstract class DataClientViewModel : BaseViewModel
    {
        #region Properties

        #region DataClient

        protected IDataClient DataClient { get; }

        #endregion

        #endregion

        #region ctors

        public DataClientViewModel() : base() { }

        public DataClientViewModel(IDataClient dataClient)
        {
            DataClient = dataClient;
        }


        #endregion
    }
}
