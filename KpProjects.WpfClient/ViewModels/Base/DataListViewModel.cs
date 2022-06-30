using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using KpProjects.Classes;
using KpProjects.Connector;

namespace KpProjects.WpfClient.ViewModels.Base
{
    public abstract class DataListViewModel<TDataClass> : DataClientViewModel
        where TDataClass : DataClass, new()
    {
        #region Properties

        #region DataList

        public ObservableCollection<TDataClass> DataList { get; }

        #endregion

        #region ItemViewModelName

        protected abstract string ItemViewModelName { get; }

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

        #region Edit

        private void Edit(object item)
        {
            TDataClass dataItem = item as TDataClass;

            if (dataItem != null)
            {
                DataItemViewModel<TDataClass> viewModel = (DataItemViewModel<TDataClass>)GetViewModel(ItemViewModelName);
                viewModel.SetDataItem(dataItem);
                SwitchTo(viewModel);
            }
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

        #region ShowDetailsCommand

        private RelayCommand _editCommand;

        public RelayCommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new RelayCommand("Просмотр", x => Edit(x));

                return _editCommand;
            }
        }

        #endregion

        #endregion
    }
}
