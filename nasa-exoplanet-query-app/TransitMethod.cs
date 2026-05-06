using System.Windows.Media.Media3D;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Transit discovery method configuration
    /// </summary>
    public class TransitMethod : DiscoveryMethodBase {
        private double mPlanetRadius = 1.0;
        private double mOrbitalPeriod = 365;
        private double mImpactParameter = 0.5;
        private bool mShowTransitPath = true;

        public override string MethodName => "Transit";
        public override string DisplayName => "Transit Photometry";
        public override string Description => "Detects planets by measuring the dimming of a star's light when a planet passes in front of it. The amount of dimming reveals the planet's size, and the frequency reveals its orbital period.";

        public double PlanetRadius {
            get => mPlanetRadius;
            set { mPlanetRadius = value; OnPropertyChanged(); }
        }

        public double OrbitalPeriod {
            get => mOrbitalPeriod;
            set { mOrbitalPeriod = value; OnPropertyChanged(); }
        }

        public double ImpactParameter {
            get => mImpactParameter;
            set { mImpactParameter = value; OnPropertyChanged(); }
        }

        public bool ShowTransitPath {
            get => mShowTransitPath;
            set { mShowTransitPath = value; OnPropertyChanged(); }
        }

        public Point3D ExoplanetCoords {
            get => new Point3D(2.5, 0, 0);
        }
    }
}
