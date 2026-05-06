using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// ViewModel for SciVisView
    /// </summary>
    public class SciVisViewModel : INotifyPropertyChanged{

        private SciVisModel mSciVisModel;
        public SciVisModel SciVisModel {
            get => mSciVisModel;
        }

        private RadialVelocityMethod mRadialVelocityMethod;
        public RadialVelocityMethod RadialVelocityMethod {
            get => mRadialVelocityMethod;
            set {
                mRadialVelocityMethod = value;
                OnPropertyChanged();
            }
        }

        private RadialVelocityView mRadialVelocityView;
        public RadialVelocityView RadialVelocityView {
            get => mRadialVelocityView;
            set {
                mRadialVelocityView = value;
                OnPropertyChanged();
            }
        }

        private RadialVelocityTool mRadialVelocityTool;
        public RadialVelocityTool RadialVelocityTool {
            get => mRadialVelocityTool;
            set {
                mRadialVelocityTool = value;
                OnPropertyChanged();
            }
        }

        private TransitMethod mTransitMethod;
        public TransitMethod TransitMethod {
            get => mTransitMethod;
            set {
                mTransitMethod = value;
                OnPropertyChanged();
            }
        }

        private TransitPhotoView mTransitPhotoView;
        public TransitPhotoView TransitPhotoView {
            get => mTransitPhotoView;
            set {
                mTransitPhotoView = value;
                OnPropertyChanged();
            }
        }

        private TransitPhotoTool mTransitPhotoTool;
        public TransitPhotoTool TransitPhotoTool {
            get => mTransitPhotoTool;
            set {
                mTransitPhotoTool = value;
                OnPropertyChanged();
            }
        }

        private object mCurrentVisView;
        public object CurrentVisView {
            get => mCurrentVisView;
            set {
                mCurrentVisView = value;
                OnPropertyChanged();
            }
        }

        private object mCurrentToolView;
        public object CurrentToolView {
            get => mCurrentToolView;
            set {
                mCurrentToolView = value;
                OnPropertyChanged();
            }
        }

        public SciVisViewModel() {
            mSciVisModel = new SciVisModel();
            mSciVisModel.DiscoveryMethodChanged += OnDiscoveryMethodChanged;

            mRadialVelocityMethod = new RadialVelocityMethod();
            mCurrentVisView = mRadialVelocityView = new RadialVelocityView(); // Default visualization view
            mRadialVelocityView.DataContext = mRadialVelocityMethod;
            mCurrentToolView = mRadialVelocityTool = new RadialVelocityTool(); // Default tool view
            mRadialVelocityTool.DataContext = mRadialVelocityMethod; // Bind tool view to method config

            mTransitMethod = new TransitMethod();
            mTransitPhotoView = new TransitPhotoView();
            mTransitPhotoView.DataContext = mTransitMethod;
            mTransitPhotoTool = new TransitPhotoTool();
            mTransitPhotoTool.DataContext = mTransitMethod;
        }

        private void OnDiscoveryMethodChanged(DiscoveryMethodBase selectedMethod) {
            // When the selected Discovery Method changes, update the following:
            // 1. Visualization
            // 2. Tool configuration
            if (selectedMethod is RadialVelocityMethod) {
                CurrentVisView = mRadialVelocityView;
                CurrentToolView = mRadialVelocityTool;
            } else if (selectedMethod is TransitMethod) {
                CurrentVisView = mTransitPhotoView;
                CurrentToolView = mTransitPhotoTool;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
