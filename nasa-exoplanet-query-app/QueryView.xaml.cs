using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Interaction logic for QueryView.xaml
    /// </summary>
    public partial class QueryView : UserControl {
        public QueryView() {
            InitializeComponent();
        }

        private void PS_Table_Refresh_Button_Click(object sender, RoutedEventArgs e) {
            if (DataContext is QueryViewModel dataContext) {
                dataContext.GetResultsFromPlanetarySystems();
            }
        }
    }
}
