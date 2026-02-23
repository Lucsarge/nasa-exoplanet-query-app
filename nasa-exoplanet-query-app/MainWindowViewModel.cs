using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace nasa_exoplanet_query_app {
    public class MainWindowViewModel {
        private ExoPlanetDataModel mEPModel;
        public ExoPlanetDataModel EPModel {
            get => mEPModel;
        }

        public MainWindowViewModel() {
            mEPModel = new ExoPlanetDataModel();

            PopulateDropdownFields();
        }

        private string[] CopyArrayValuesToDropDown(string[] values) {
            if (values.Length == 0) {
                return new string[] { ExoPlanetDataModel.NOT_SPECIFIED };
            }

            // values length should be the number of unique values plus the column header, so unnecessary to add 1 for Not Specified
            string[] newStrings = new string[values.Length];
            newStrings[0] = ExoPlanetDataModel.NOT_SPECIFIED; // Set the first value to Not Specifieds

            // starting at 1 ignores the column header
            for (int i = 1; i < values.Length; i++) {
                newStrings[i] = values[i];
            }

            return newStrings;
        }

        private void PopulateDropdownFields() {
            string requestHostName = ExoplanetTAPHelper.GetPSUniqueColumnValuesRequestString(ExoplanetTAPHelper.HOST_NAME, ExoplanetTAPHelper.FORMAT_CSV);
            string requestDiscFacility = ExoplanetTAPHelper.GetPSUniqueColumnValuesRequestString(ExoplanetTAPHelper.DISC_FACILITY, ExoplanetTAPHelper.FORMAT_CSV);
            string requestDiscYear = ExoplanetTAPHelper.GetPSUniqueColumnValuesRequestString(ExoplanetTAPHelper.DISC_YEAR, ExoplanetTAPHelper.FORMAT_CSV);
            string requestDiscMethod = ExoplanetTAPHelper.GetPSUniqueColumnValuesRequestString(ExoplanetTAPHelper.DISC_METHOD, ExoplanetTAPHelper.FORMAT_CSV);

            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestHostName);
                string[] values = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                values = values.Select(s => s.Substring(1, s.Length - 2)).ToArray(); // remove the double quotes around each element
                EPModel.HostNameStrings = CopyArrayValuesToDropDown(values);
            });
            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestDiscFacility);
                string[] values = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                values = values.Select(s => s.Substring(1, s.Length - 2)).ToArray(); // remove the double quotes around each element
                EPModel.DiscFacilityStrings = CopyArrayValuesToDropDown(values);
            });
            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestDiscYear);
                string[] values = response.Split('\n', StringSplitOptions.RemoveEmptyEntries); // elements are returned as numbers, no double quotes
                EPModel.DiscYearStrings = CopyArrayValuesToDropDown(values);
            });
            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestDiscMethod);
                string[] values = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                values = values.Select(s => s.Substring(1, s.Length - 2)).ToArray(); // remove the double quotes around each element
                EPModel.DiscMethodStrings = CopyArrayValuesToDropDown(values);
            });
        }

        public void GetResultsFromPlanetarySystems() {
            string requestString = ExoplanetTAPHelper.GetPSFilteredResultsRequestString(mEPModel.HostNameStrings[mEPModel.HostNameSelectedIndex],
                                                                                        mEPModel.DiscFacilityStrings[mEPModel.DiscFacilitySelectedIndex],
                                                                                        mEPModel.DiscYearStrings[mEPModel.DiscYearSelectedIndex],
                                                                                        mEPModel.DiscMethodStrings[mEPModel.DiscMethodSelectedIndex]);

            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestString);

                try {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var data = JsonSerializer.Deserialize<List<ExoPlanetData>>(response, options);

                    if (data != null) {
                        EPModel.ExoPlanetCollection = new ObservableCollection<ExoPlanetData>(data);
                    }
                }
                catch (JsonException ex) {
                    MessageBox.Show($"JSON Error: {ex.Message}\n\nResponse preview: {response.Substring(0, Math.Min(200, response.Length))}");
                    System.Diagnostics.Debug.WriteLine($"Full response: {response}");
                }
            });
        }
    }
}
