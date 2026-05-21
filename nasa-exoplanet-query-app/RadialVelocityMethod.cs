namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Radial Velocity discovery method configuration
    /// </summary>
    public class RadialVelocityMethod : DiscoveryMethodBase {
        private double mMinMass = 1.0;
        private double mEccentricity = 0.5;
        private bool mShowVelocityCurve = true;

        public override string MethodName => "RadialVelocity";
        public override string DisplayName => "Radial Velocity";
        public override string Description => "Detects planets by measuring the wobble of the host star caused by gravitational pull from orbiting planets. The star's velocity toward and away from Earth is measured using Doppler spectroscopy.";

        public double MinMass {
            get => mMinMass;
            set { mMinMass = value; OnPropertyChanged(); }
        }

        public double Eccentricity {
            get => mEccentricity;
            set { mEccentricity = value; OnPropertyChanged(); }
        }

        public bool ShowVelocityCurve {
            get => mShowVelocityCurve;
            set { mShowVelocityCurve = value; OnPropertyChanged(); }
        }
    }
}
