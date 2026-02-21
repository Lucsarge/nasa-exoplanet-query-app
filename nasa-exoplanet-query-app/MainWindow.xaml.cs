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

        private void PS_Table_Refresh_Button_Click(object sender, RoutedEventArgs e) {
            vm.GetResultsFromPlanetarySystems();
        }
    }
}
