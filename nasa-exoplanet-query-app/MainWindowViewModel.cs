using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace nasa_exoplanet_query_app {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private readonly string NOT_SPECIFIED = "N/S";

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

        public MainWindowViewModel() {
            mDiscYearStrings = ["N/S"];
            mDiscYearSelectedIndex = 0;

            mDiscMethodStrings = ["N/S"];
            mDiscMethodSelectedIndex = 0;

            mHostNameStrings = ["N/S"];
            mHostNameSelectedIndex = 0;

            mDiscFacilityStrings = ["N/S"];
            mDiscFacilitySelectedIndex = 0;
        }

        private string[] CopyArrayValuesToDropDown(string[] values) {
            string[] newStrings = new string[values.Length];
            newStrings[0] = NOT_SPECIFIED; // Set the first value to Not Specifieds
            // starting at 1 ignores the column header
            for (int i = 1; i < values.Length; i++) {
                newStrings[i] = values[i];
            }

            return newStrings;
        }


        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
