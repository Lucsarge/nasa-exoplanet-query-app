namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Template selector that chooses the appropriate tool UI based on discovery method type
    /// </summary>
    public class DiscoveryMethodTemplateSelector : System.Windows.Controls.DataTemplateSelector {
        public System.Windows.DataTemplate? RadialVelocityTemplate { get; set; }
        public System.Windows.DataTemplate? TransitTemplate { get; set; }
        public System.Windows.DataTemplate? DefaultTemplate { get; set; }

        public override System.Windows.DataTemplate? SelectTemplate(object item, System.Windows.DependencyObject container) {
            if (item is RadialVelocityMethod) return RadialVelocityTemplate;
            if (item is TransitMethod) return TransitTemplate;
            return DefaultTemplate;
        }
    }
}
