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
            mRadialVelocityMethod = new RadialVelocityMethod();
            mCurrentVisView = mRadialVelocityView = new RadialVelocityView(); // Default visualization view
            mRadialVelocityView.DataContext = mRadialVelocityMethod;
            mCurrentToolView = mRadialVelocityTool = new RadialVelocityTool(); // Default tool view
            mRadialVelocityTool.DataContext = mRadialVelocityMethod; // Bind tool view to method config
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
