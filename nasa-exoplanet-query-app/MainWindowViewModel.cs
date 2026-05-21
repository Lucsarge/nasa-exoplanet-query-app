using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace nasa_exoplanet_query_app {
    public class MainWindowViewModel {
        private QueryView mQueryView;
        private QueryViewModel mQueryViewModel;
        private SciVisView mSciVisView;
        private SciVisViewModel mSciVisViewModel;

        public QueryView QueryView {
            get => mQueryView;
        }

        public SciVisView SciVisView {
            get => mSciVisView;
        }

        public MainWindowViewModel() {
            mQueryView = new QueryView();
            mQueryView.DataContext = mQueryViewModel = new QueryViewModel();
            mSciVisView = new SciVisView();
            mSciVisView.DataContext = mSciVisViewModel = new SciVisViewModel();
        }
    }
}
