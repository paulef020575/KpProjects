using KpProjects.Connector;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace KpProjects.WpfClient.ViewModels.Base
{
    /// <summary>
    ///     Базовый класс для моделей представления
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        #region Properties

        #region Title

        /// <summary>
        ///     Заголовок представления
        /// </summary>
        public abstract string Title { get; }

        #endregion

        #region IsLoading

        private bool _isLoading;
        /// <summary>
        ///     Признак "Загрузка данных"
        /// </summary>
        public virtual bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region IsModified

        private bool _isModified;
        /// <summary>
        ///     Признак "Данные были изменены"
        /// </summary>
        public virtual bool IsModified
        {
            get => _isModified;
            set
            {
                if (_isModified != value)
                {
                    _isModified = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (!string.Equals(propertyName, nameof(IsModified)))
            {
                IsModified = true;
            }
        }

        #endregion

        #region RaiseLoading

        public async virtual void RaiseLoading()
        {
            IsLoading = true;
            await LoadingData();
            IsLoading = false;
        }

        protected abstract Task LoadingData();

        #endregion
    }
}
