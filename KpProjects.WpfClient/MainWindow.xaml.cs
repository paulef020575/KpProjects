using KpProjects.Classes;
using KpProjects.Connector;
using System.Threading.Tasks;
using System.Windows;

namespace KpProjects.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KpProjectsApiClient client = new KpProjectsApiClient(@"https://localhost:44363/");
            listBox.ItemsSource = await client.LoadList<Person>();
        }
    }
}
