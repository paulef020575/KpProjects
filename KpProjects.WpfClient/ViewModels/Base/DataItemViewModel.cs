using KpProjects.Classes;
using KpProjects.Connector;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace KpProjects.WpfClient.ViewModels.Base
{
    /// <summary>
    ///     Модель представления для работы с элементом данных
    /// </summary>
    /// <typeparam name="TDataClass">Класс редактируемого элемента</typeparam>
    public abstract class DataItemViewModel<TDataClass> : DataClientViewModel
        where TDataClass : DataClass, new()
    {
        #region Properties

        #region DataItem

        /// <summary>
        ///     Редактируемый объект
        /// </summary>
        protected TDataClass DataItem { get; private set; }

        #endregion

        #endregion

        #region ctors

        public DataItemViewModel()
            : base()
        {
            DataItem = new TDataClass();
        }

        public DataItemViewModel(IDataClient dataClient) : base(dataClient) { }

        #endregion

        #region Methods

        #region SetDataItem

        public void SetDataItem(TDataClass dataItem)
        {
            DataItem = dataItem;
        }

        #endregion

        #region SetValue

        /// <summary>
        ///     Устанавливает значение свойства редактируемого объекта
        /// </summary>
        /// <param name="value">значение</param>
        /// <param name="propertyName">имя свойства</param>
        protected virtual void SetValue(object value, [CallerMemberName] string propertyName = null)
        {
            PropertyInfo propertyInfo = typeof(TDataClass).GetProperty(propertyName, BindingFlags.Public);

            if (propertyInfo != null)
            {
                object currentValue = propertyInfo.GetValue(DataItem);

                if (currentValue == null || !currentValue.Equals(value))
                {
                    propertyInfo.SetValue(DataItem, value);
                    RaisePropertyChanged(propertyName);
                }
            }
            else
            {
                throw new ArgumentException($"Property {propertyName} not found");
            }
        }

        #endregion

        #region LoadingData

        protected override async Task LoadingData()
        {
            if (!DataItem.Id.Equals(Guid.Empty))
            {
                TDataClass dataItem = await DataClient.Load<TDataClass>(DataItem.Id);
            }
        }

        #endregion

        #endregion

    }
}
