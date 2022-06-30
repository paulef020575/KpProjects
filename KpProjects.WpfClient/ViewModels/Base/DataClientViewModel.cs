using KpProjects.Connector;

namespace KpProjects.WpfClient.ViewModels.Base
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
