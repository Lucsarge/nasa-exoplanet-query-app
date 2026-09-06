using System.Numerics;
using System.Windows.Media.Media3D;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Radial Velocity discovery method configuration
    /// </summary>
    public class RadialVelocityMethod : DiscoveryMethodBase {
        private double mMinMass = 1.0;
        private double mEccentricity = 1.0;
        private bool mShowVelocityCurve = true;

        public override string MethodName => "RadialVelocity";
        public override string DisplayName => "Radial Velocity";
        public override string Description => "Detects planets by measuring the wobble of the host star caused by gravitational pull from orbiting planets. The star's velocity toward and away from Earth is measured using Doppler spectroscopy.";
        public override bool IsAnimating { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        private Point3D mExoplanetCoords = new Point3D(3, 0, 0);
        public Point3D ExoplanetCoords {
            get => mExoplanetCoords;
            set { mExoplanetCoords = value; OnPropertyChanged(); }
        }
    }
}
