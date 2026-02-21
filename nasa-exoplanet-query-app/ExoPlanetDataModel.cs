using System.Collections.ObjectModel;

namespace nasa_exoplanet_query_app {
    public class ExoPlanetDataModel : ModelBase {
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
                mDiscYearStrings = value;
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
                mDiscMethodStrings = value;
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
                mHostNameStrings = value;
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
                mDiscFacilityStrings = value;
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

        public ExoPlanetDataModel() {
            mDiscYearStrings = [NOT_SPECIFIED];
            mDiscYearSelectedIndex = 0;

            mDiscMethodStrings = [NOT_SPECIFIED];
            mDiscMethodSelectedIndex = 0;

            mHostNameStrings = [NOT_SPECIFIED];
            mHostNameSelectedIndex = 0;

            mDiscFacilityStrings = [NOT_SPECIFIED];
            mDiscFacilitySelectedIndex = 0;

            mExoPlanetCollection = new ObservableCollection<ExoPlanetData>();
        }
    }
}
