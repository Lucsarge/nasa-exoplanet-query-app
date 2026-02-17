using System.Net.Http;
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

        private void QueryPlanetarySystems() {
            string requestDiscYear = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.SELECT_DISC_YEAR, ExoplanetTAPHelper.CSV_FORMAT);
            string requestDiscMethod = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.SELECT_DISC_METHOD, ExoplanetTAPHelper.CSV_FORMAT);
            string requestHostName = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.SELECT_HOST_NAME, ExoplanetTAPHelper.CSV_FORMAT);
            string requestDiscFacility = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.SELECT_DISC_FACILITY, ExoplanetTAPHelper.CSV_FORMAT);

            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string discYearResponse =await client.GetStringAsync(requestDiscYear);
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

        private void PS_Table_Refresh_Button_Click(object sender, RoutedEventArgs e) {
            QueryPlanetarySystems();
        }
    }
}
