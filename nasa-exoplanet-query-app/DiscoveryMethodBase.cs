namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Base class for all discovery method configurations
    /// </summary>
    public abstract class DiscoveryMethodBase : ModelBase {
        public abstract string MethodName { get; }
        public abstract string DisplayName { get; }
        public abstract string Description { get; }
        public abstract bool IsAnimating { get; set; }
    }
}
