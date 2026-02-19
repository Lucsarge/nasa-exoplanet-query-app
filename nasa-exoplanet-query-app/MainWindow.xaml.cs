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

        private void GetResultsFromPlanetarySystems() {
            string requestString = ExoplanetTAPHelper.GetPSFilteredResultsRequestString(vm.HostNameStrings[vm.HostNameSelectedIndex],
                                                                                        vm.DiscFacilityStrings[vm.DiscFacilitySelectedIndex],
                                                                                        vm.DiscYearStrings[vm.DiscYearSelectedIndex],
                                                                                        vm.DiscMethodStrings[vm.DiscMethodSelectedIndex]);

            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestString);

                try {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var data = JsonSerializer.Deserialize<List<ExoPlanetData>>(response, options);

                    if (data != null) {
                        vm.ExoPlanetCollection = new ObservableCollection<ExoPlanetData>(data);
                    }
                }
                catch (JsonException ex) {
                    MessageBox.Show($"JSON Error: {ex.Message}\n\nResponse preview: {response.Substring(0, Math.Min(200, response.Length))}");
                    System.Diagnostics.Debug.WriteLine($"Full response: {response}");
                }
            });
        }

        private void PS_Table_Refresh_Button_Click(object sender, RoutedEventArgs e) {
            GetResultsFromPlanetarySystems();
        }
    }
}
