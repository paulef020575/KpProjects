using KpProjects.Connector;
using KpProjects.WpfClient.Properties;
using KpProjects.WpfClient.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace KpProjects.WpfClient.ViewModels
{
    /// <summary>
    ///     Фабрика моделей представления
    /// </summary>
    public class ViewModelFactory
    {
        private IDataClient DataClient { get; }

        private Dictionary<string, Type> _vmDictionary;
        private Dictionary<string, Type> _dcVmDictionary;


        public ViewModelFactory()
        {
            DataClient = new KpProjectsApiClient(Settings.Default.DataClientUri);

            InitializeVmDictionaries();
        }

        private void InitializeVmDictionaries()
        {
            InitializeVmDictionary();
            InitializeDcVmDictionary();
        }

        private void InitializeDcVmDictionary()
        {
            _dcVmDictionary = new Dictionary<string, Type>();

            _dcVmDictionary.Add(nameof(PersonListViewModel), typeof(PersonListViewModel));
            _dcVmDictionary.Add(nameof(PersonViewModel), typeof(PersonViewModel));
        }

        private void InitializeVmDictionary()
        {
            _vmDictionary = new Dictionary<string, Type>();
        }

        public BaseViewModel CreateViewModel(string vmName)
        {
            if (_vmDictionary.ContainsKey(vmName))
                return CreateViewModel(_vmDictionary[vmName]);

            if (_dcVmDictionary.ContainsKey(vmName))
                return CreateDcViewModel(_dcVmDictionary[vmName]);

            throw new ArgumentException("Unknown viewModel type");
        }

        private BaseViewModel CreateDcViewModel(Type vmType)
        {
            ConstructorInfo constructorInfo = vmType.GetConstructor(new Type[] { typeof(IDataClient) });

            if (constructorInfo != null)
                return (BaseViewModel)constructorInfo.Invoke(new object[] { DataClient });

            throw new ArgumentException("Constructor with dataClient parameter not found");
        }

        private BaseViewModel CreateViewModel(Type vmType)
        {
            ConstructorInfo constructorInfo = vmType.GetConstructor(new Type[] { });

            if (constructorInfo != null)
                return (BaseViewModel)constructorInfo.Invoke(Array.Empty<object>());

            throw new ArgumentException("Constructor w/o parameters not found");
        }
    }
}
