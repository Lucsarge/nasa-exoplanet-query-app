using System.Collections.ObjectModel;
using System.Windows.Input;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Model for SciVisView
    /// </summary>
    public class SciVisModel : ModelBase {
        private DiscoveryMethodBase mCurrentVisualization;
        private DiscoveryMethodBase mCurrentToolConfig;
        private DiscoveryMethodBase mSelectedDiscoveryMethod;
        private ObservableCollection<DiscoveryMethodBase> mAvailableDiscoveryMethods;
        private ICommand? mApplyVisualizationCommand;

        public Action<DiscoveryMethodBase> DiscoveryMethodChanged;

        public SciVisModel() {
            // Initialize available discovery methods
            mAvailableDiscoveryMethods = new ObservableCollection<DiscoveryMethodBase> {
                new RadialVelocityMethod(),
                new TransitMethod()
            };

            // Set default selection
            SelectedDiscoveryMethod = mAvailableDiscoveryMethods[0];
        }

        public ObservableCollection<DiscoveryMethodBase> AvailableDiscoveryMethods {
            get => mAvailableDiscoveryMethods;
        }

        public DiscoveryMethodBase CurrentVisualization {
            get => mCurrentVisualization;
            set {
                mCurrentVisualization = value;
                OnPropertyChanged();
            }
        }

        public DiscoveryMethodBase CurrentToolConfig {
            get => mCurrentToolConfig;
            set {
                mCurrentToolConfig = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MethodSummary));
            }
        }

        public DiscoveryMethodBase SelectedDiscoveryMethod {
            get => mSelectedDiscoveryMethod;
            set {
                mSelectedDiscoveryMethod = value;
                OnPropertyChanged();

                DiscoveryMethodChanged?.Invoke(mSelectedDiscoveryMethod);
                //CurrentToolConfig = value;
            }
        }

        public string MethodSummary {
            get => CurrentToolConfig?.Description ?? "Select a discovery method to view its details.";
        }

        public ICommand ApplyVisualizationCommand {
            get => mApplyVisualizationCommand ??= new RelayCommand(ApplyVisualization);
        }

        private void ApplyVisualization() {
            // This method will be called when the user clicks "Apply Visualization"
            // It will trigger the visualization to update based on current tool settings
            // Implementation will be added when visualization logic is ready
            System.Diagnostics.Debug.WriteLine($"Applying visualization for {CurrentToolConfig?.MethodName}");
        }
    }
}
