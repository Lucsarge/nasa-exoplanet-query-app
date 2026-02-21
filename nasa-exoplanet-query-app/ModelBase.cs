using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace nasa_exoplanet_query_app {
    public abstract class ModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
