namespace nasa_exoplanet_query_app {
    /// <summary>
    /// ViewModel for SciVisView
    /// </summary>
    public class SciVisViewModel {
        private SciVisModel mSciVisModel;

        public RadialVelocityMethod RadialVelocityMethod { get; }
        public TransitMethod TransitMethod { get; }

        public SciVisModel SciVisModel {
            get => mSciVisModel;
        }

        public SciVisViewModel() {
            mSciVisModel = new SciVisModel();

            // Initialize public properties for RadialVelocity and Transit methods
            RadialVelocityMethod = new RadialVelocityMethod();
            TransitMethod = new TransitMethod();
        }
    }
}
