using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using KpProjects.WpfClient.ViewModels.Base;

namespace KpProjects.WpfClient.ViewModels
{
    /// <summary>
    ///     Модель представления окна
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties & fields

        #region ViewModelFactory

        private ViewModelFactory ViewModelFactory { get; }

        #endregion

        #region Title

        private string _mainWindowTitle = "Проекты Карелия Палп";

        /// <inheritdoc />
        public override string Title => $"{_mainWindowTitle} - {CurrentViewModel?.Title ?? ""}";

        #endregion

        #region CurrentViewModel

        private BaseViewModel _currentViewModel;

        /// <summary>
        ///     Выбранная для отображения модель представления
        /// </summary>
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }

        #endregion

        #region MenuWidth

        private int _menuWidth = 52;

        public int MenuWidth
        {
            get => _menuWidth;
            set
            {
                if (_menuWidth != value)
                {
                    _menuWidth = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #endregion

        #region ctor

        public MainWindowViewModel()
        {
            ViewModelFactory = new ViewModelFactory();
        }

        #endregion

        #region Methods

        #region SetMenuWidth

        /// <summary>
        ///     Устанавливает заданную ширину меню
        /// </summary>
        /// <param name="width"></param>
        private void SetMenuWidth(int width)
        {
            MenuWidth = width;
        }

        #endregion

        #region CloseWindow

        private void CloseWindow(object window)
        {
            (window as Window)?.Close();
        }

        #endregion

        #region MaximizeWindow

        private void MaximizeWindow(object window)
        {
            ((Window) window).WindowState = WindowState.Maximized;
        }

        private bool CanMaximizeWindow(object window)
        {
            return (window as Window)?.WindowState != WindowState.Maximized;
        }

        #endregion

        #region RestoreWindow

        private void RestoreWindow(object window)
        {
            ((Window) window).WindowState = WindowState.Normal;
        }

        #endregion

        #region MinimizeWindow

        private void MinimizeWindow(object window)
        {
            ((Window) window).WindowState = WindowState.Minimized;
        }

        #endregion

        #region ChangeWindowState

        private void ChangeWindowState(object parameter)
        {
            if (parameter is Window window)
            {
                if (window.WindowState == WindowState.Normal)
                {
                    MaximizeCommand.Execute(window);
                }
                else
                {
                    RestoreCommand.Execute(window);
                }
            }
        }

        #endregion

        #region LoadingData

        protected override async Task LoadingData() 
        {
        }

        #endregion

        #region CreateViewModel

        private BaseViewModel CreateViewModel(string viewModelName)
        {
            return ViewModelFactory.CreateViewModel(viewModelName);
        }

        #endregion

        #region ShowViewModel

        private void ShowViewModel(BaseViewModel viewModel)
        {
            viewModel.GetViewModel = CreateViewModel;
            viewModel.SwitchTo = ShowViewModel;

            CurrentViewModel = viewModel;
            CurrentViewModel.RaiseLoading();
        }

        #endregion

        #region OpenViewModel

        private void OpenViewModel(string viewModelName)
        {
            ShowViewModel(CreateViewModel(viewModelName));
        }

        #endregion

        #endregion

        #region Commands

        #region ShowFullMenuCommand

        private RelayCommand _showFullMenuCommand;

        public RelayCommand ShowFullMenuCommand
        {
            get
            {
                if (_showFullMenuCommand == null)
                {
                    int fullMenuWidth = 300;
                    _showFullMenuCommand = new RelayCommand("развернуть", 
                        x => SetMenuWidth(fullMenuWidth),
                        x => (MenuWidth != fullMenuWidth));
                }

                return _showFullMenuCommand;
            }
        }

        #endregion

        #region CollapseMenuCommand

        private RelayCommand _collapseMenuCommand;

        public RelayCommand CollapseMenuCommand
        {
            get 
            {
                if (_collapseMenuCommand == null)
                {
                    int collapsedMenuWidth = 52;
                    _collapseMenuCommand = new RelayCommand("скрыть",
                        x => SetMenuWidth(collapsedMenuWidth),
                        x => (MenuWidth != collapsedMenuWidth));
                }

                return _collapseMenuCommand;
            }
        }


        #endregion

        #region CloseCommand

        private RelayCommand _closeCommand;

        public RelayCommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand("Закрыть", CloseWindow);
                }

                return _closeCommand;
            }
        }

        #endregion

        #region MaximizeCommand

        private RelayCommand _maximizeCommand;

        public RelayCommand MaximizeCommand
        {
            get
            {
                if (_maximizeCommand == null)
                {
                    _maximizeCommand = new RelayCommand("Развернуть", 
                        MaximizeWindow,
                        CanMaximizeWindow);
                }

                return _maximizeCommand;
            }
        }

        #endregion

        #region RestoreCommand

        private RelayCommand _restoreCommand;

        public RelayCommand RestoreCommand
        {
            get
            {
                if (_restoreCommand == null)
                    _restoreCommand = new RelayCommand("Восстановить", 
                        RestoreWindow,
                        x => !CanMaximizeWindow(x));

                return _restoreCommand;
            }
        }

        #endregion

        #region MinimizeCommand

        private RelayCommand _minimizeCommand;

        public RelayCommand MinimizeCommand
        {
            get
            {
                if (_minimizeCommand == null)
                    _minimizeCommand = new RelayCommand("Свернуть", 
                        MinimizeWindow);
                return _minimizeCommand;
            }
        }

        #endregion

        #region ChangeWindowStateCommand

        private RelayCommand _changeWindowStateCommand;

        public RelayCommand ChangeWindowStateCommand
        {
            get
            {
                if (_changeWindowStateCommand == null)
                    _changeWindowStateCommand = new RelayCommand(ChangeWindowState);

                return _changeWindowStateCommand;
            }
        }

        #endregion

        #region OpenViewModelCommand

        private RelayCommand _openViewModelCommand;

        public RelayCommand OpenViewModelCommand
        {
            get
            {
                if (_openViewModelCommand == null)
                    _openViewModelCommand = new RelayCommand(x => OpenViewModel((string)x));

                return _openViewModelCommand;
            }
        }

        #endregion

        #endregion
    }
}
