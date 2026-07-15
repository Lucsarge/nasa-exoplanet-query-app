using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Interaction logic for TransitPhotoView.xaml
    /// </summary>
    public partial class TransitPhotoView : UserControl {
        public Action<double>? OnRendered;
        private DateTime _LastTime;

        private bool _Loaded;

        public TransitPhotoView() {
            InitializeComponent();

            _Loaded = false;
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            if (_Loaded) return; // redundancy check

            _LastTime = DateTime.Now;

            _Loaded = true;
            CompositionTarget.Rendering += OnRendering;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e) {
            if (!_Loaded) return; // redundancy check

            _Loaded = false;
            CompositionTarget.Rendering -= OnRendering;
        }

        private void OnRendering(object? sender, EventArgs e) {
            var currentTime = DateTime.Now;
            double deltaTime = (currentTime - _LastTime).TotalSeconds; // calculate delta time in seconds
            _LastTime = currentTime; // prepare last time for next frame
            OnRendered?.Invoke(deltaTime);
        }
    }
}
