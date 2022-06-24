using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KpProjects.WpfClient.ViewModels.Base
{
    /// <summary>
    ///     Базовый класс для моделей представления
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
