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

        public DataListViewModel()
        {
            DataList = new ObservableCollection<TDataClass>();
        }

        public DataListViewModel(IDataClient dataClient)
            : base(dataClient)
        {
            DataList = new ObservableCollection<TDataClass>();
        }

        #endregion


        #region Methods

        #region LoadingData

        protected async override Task LoadingData()
        {
            IEnumerable<TDataClass> items = await DataClient.LoadList<TDataClass>();
            foreach (TDataClass item in items)
            {
                DataList.Add(item);
            }
        }

        #endregion

        #region Add

        protected virtual void Add()
        {
        }

        #endregion

        #endregion

        #region Commands

        #region AddCommand

        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand("Добавить", x => Add());

                return _addCommand;
            }
        }

        #endregion


        #endregion
    }
}
