using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace nasa_exoplanet_query_app {
    public class MainWindowViewModel {
        private QueryView mQueryView;
        private QueryViewModel mQueryViewModel;
        private InteractiveView mInteractiveView;

        public QueryView QueryView {
            get => mQueryView;
        }

        public InteractiveView InteractiveView {
            get => mInteractiveView;
        }

        public MainWindowViewModel() {
            mQueryView = new QueryView();
            mQueryView.DataContext = mQueryViewModel = new QueryViewModel();
            mInteractiveView = new InteractiveView();
        }
    }
}
