using System.Collections.ObjectModel;
using System.Windows.Input;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Model for SciVisView
    /// </summary>
    public class SciVisModel : ModelBase {
        public Action<DiscoveryMethodBase> DiscoveryMethodChanged;

        private ObservableCollection<DiscoveryMethodBase> mAvailableDiscoveryMethods;
        public ObservableCollection<DiscoveryMethodBase> AvailableDiscoveryMethods {
            get => mAvailableDiscoveryMethods;
        }

        private DiscoveryMethodBase mSelectedDiscoveryMethod;
        public DiscoveryMethodBase SelectedDiscoveryMethod {
            get => mSelectedDiscoveryMethod;
            set {
                mSelectedDiscoveryMethod = value;
                OnPropertyChanged();

                DiscoveryMethodChanged?.Invoke(mSelectedDiscoveryMethod);
                OnPropertyChanged(nameof(MethodSummary));
            }
        }

        public string MethodSummary {
            get => mSelectedDiscoveryMethod.Description;
        }

        public SciVisModel() {
            // Initialize available discovery methods
            mAvailableDiscoveryMethods = new ObservableCollection<DiscoveryMethodBase> {
                new RadialVelocityMethod(),
                new TransitMethod()
            };

            // Set default selection
            SelectedDiscoveryMethod = mAvailableDiscoveryMethods[0];
        }
    }
}
