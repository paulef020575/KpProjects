using KpProjects.Classes;
using KpProjects.Connector;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        private void HeaderPanel_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
