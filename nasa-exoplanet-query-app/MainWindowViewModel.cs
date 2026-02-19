using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace nasa_exoplanet_query_app {
    public class MainWindowViewModel : INotifyPropertyChanged {
        public const string NOT_SPECIFIED = "N/S";

        private int mDiscYearSelectedIndex;
        public int DiscYearSelectedIndex {
            get => mDiscYearSelectedIndex;
            set {
                mDiscYearSelectedIndex = value;
                OnPropertyChanged();
            }
        }

        private string[] mDiscYearStrings;
        public string[] DiscYearStrings {
            get => mDiscYearStrings;
            set {
                mDiscYearStrings = CopyArrayValuesToDropDown(value);
                OnPropertyChanged();
            }
        }

        private int mDiscMethodSelectedIndex;
        public int DiscMethodSelectedIndex {
            get => mDiscMethodSelectedIndex;
            set {
                mDiscMethodSelectedIndex = value;
                OnPropertyChanged();
            }
        }

        private string[] mDiscMethodStrings;
        public string[] DiscMethodStrings {
            get => mDiscMethodStrings;
            set {
                mDiscMethodStrings = CopyArrayValuesToDropDown(value);
                OnPropertyChanged();
            }
        }

        private int mHostNameSelectedIndex;
        public int HostNameSelectedIndex {
            get => mHostNameSelectedIndex;
            set {
                mHostNameSelectedIndex = value;
                OnPropertyChanged();
            }
        }

        private string[] mHostNameStrings;
        public string[] HostNameStrings {
            get => mHostNameStrings;
            set {
                mHostNameStrings = CopyArrayValuesToDropDown(value);
                OnPropertyChanged();
            }
        }

        private int mDiscFacilitySelectedIndex;
        public int DiscFacilitySelectedIndex {
            get => mDiscFacilitySelectedIndex;
            set {
                mDiscFacilitySelectedIndex = value;
                OnPropertyChanged();
            }
        }

        private string[] mDiscFacilityStrings;
        public string[] DiscFacilityStrings {
            get => mDiscFacilityStrings;
            set {
                mDiscFacilityStrings = CopyArrayValuesToDropDown(value);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ExoPlanetData> mExoPlanetCollection;
        public ObservableCollection<ExoPlanetData> ExoPlanetCollection {
            get => mExoPlanetCollection;
            set {
                mExoPlanetCollection = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel() {
            mDiscYearStrings = [NOT_SPECIFIED];
            mDiscYearSelectedIndex = 0;

            mDiscMethodStrings = [NOT_SPECIFIED];
            mDiscMethodSelectedIndex = 0;

            mHostNameStrings = [NOT_SPECIFIED];
            mHostNameSelectedIndex = 0;

            mDiscFacilityStrings = [NOT_SPECIFIED];
            mDiscFacilitySelectedIndex = 0;

            PopulateDropdownFields();

            mExoPlanetCollection = new ObservableCollection<ExoPlanetData>();
        }

        private string[] CopyArrayValuesToDropDown(string[] values) {
            // values length should be the number of unique values plus the column header, so unnecessary to add 1 for Not Specified
            string[] newStrings = new string[values.Length];
            newStrings[0] = NOT_SPECIFIED; // Set the first value to Not Specifieds

            // starting at 1 ignores the column header
            for (int i = 1; i < values.Length; i++) {
                newStrings[i] = values[i];
            }

            return newStrings;
        }

        private void PopulateDropdownFields() {
            string requestHostName = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.HOST_NAME, ExoplanetTAPHelper.FORMAT_CSV);
            string requestDiscFacility = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.DISC_FACILITY, ExoplanetTAPHelper.FORMAT_CSV);
            string requestDiscYear = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.DISC_YEAR, ExoplanetTAPHelper.FORMAT_CSV);
            string requestDiscMethod = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.DISC_METHOD, ExoplanetTAPHelper.FORMAT_CSV);

            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestHostName);
                string[] values = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                values = values.Select(s => s.Substring(1, s.Length - 2)).ToArray(); // remove the double quotes around each element
                HostNameStrings = values;
            });
            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestDiscFacility);
                string[] values = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                values = values.Select(s => s.Substring(1, s.Length - 2)).ToArray(); // remove the double quotes around each element
                DiscFacilityStrings = values;
            });
            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestDiscYear);
                string[] values = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                DiscYearStrings = values;
            });
            Task.Run(async () => {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(requestDiscMethod);
                string[] values = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                values = values.Select(s => s.Substring(1, s.Length - 2)).ToArray(); // remove the double quotes around each element
                DiscMethodStrings = values;
            });
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
