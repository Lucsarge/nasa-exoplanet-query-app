using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        MainWindowViewModel vm;

        public MainWindow() {
            InitializeComponent();

            vm = new MainWindowViewModel();

            DataContext = vm;
        }
    }
}
