using System;
using System.Windows.Input;

namespace KpProjects.WpfClient.ViewModels.Base
{
    /// <summary>
    ///     Реализация интерфейса ICommand
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Properties & fields

        #region Caption

        /// <summary>
        ///     Подпись команды
        /// </summary>
        public string Caption { get; }

        #endregion

        #region _execute

        /// <summary>
        ///     Действие команды
        /// </summary>
        private Action<object> _execute;

        #endregion

        #region _canExecute

        /// <summary>
        ///     Признак возможности исполнения
        /// </summary>
        private Predicate<object> _canExecute;

        #endregion

        #endregion

        #region ctors

        private RelayCommand() { }

        public RelayCommand(string caption, Action<object> execute, Predicate<object> canExecute = null)
        {
            Caption = caption;
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
            : this("", execute, canExecute)
        { }

        #endregion

        #region ICommand implementation

        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) => _execute.Invoke(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion

     }
}
