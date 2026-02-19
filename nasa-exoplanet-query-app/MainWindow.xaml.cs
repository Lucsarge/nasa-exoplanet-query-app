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

        private void PopulateDropdownFields() {
            string requestDiscYear = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.DISC_YEAR, ExoplanetTAPHelper.FORMAT_CSV);
            string requestDiscMethod = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.DISC_METHOD, ExoplanetTAPHelper.FORMAT_CSV);
            string requestHostName = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.HOST_NAME, ExoplanetTAPHelper.FORMAT_CSV);
            string requestDiscFacility = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.DISC_FACILITY, ExoplanetTAPHelper.FORMAT_CSV);

            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string discYearResponse = await client.GetStringAsync(requestDiscYear);
                string discMethodResponse = await client.GetStringAsync(requestDiscMethod);
                string hostNameResponse = await client.GetStringAsync(requestHostName);
                string discFacilityResponse = await client.GetStringAsync(requestDiscFacility);

                string[] values;
                values = discYearResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                vm.DiscYearStrings = values;
                values = discMethodResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                vm.DiscMethodStrings = values;
                values = hostNameResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                vm.HostNameStrings = values;
                values = discFacilityResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                vm.DiscFacilityStrings = values;
            });
        }

        private void GetResultsFromPlanetarySystems() {
            string requestString = ExoplanetTAPHelper.GetPSFilteredResultsRequestString();
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
            //PopulateDropdownFields();
        }
    }
}
