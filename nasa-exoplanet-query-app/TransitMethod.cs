using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Transit discovery method configuration
    /// </summary>
    public class TransitMethod : DiscoveryMethodBase {
        public override string MethodName => "Transit";
        public override string DisplayName => "Transit Photometry";
        public override string Description => "Detects planets by measuring the dimming of a star's light when a planet passes in front of it. The amount of dimming reveals the planet's size, and the frequency reveals its orbital period.";

        private bool mIsAnimating = false;
        public override bool IsAnimating {
            get => mIsAnimating;
            set { mIsAnimating = value; OnPropertyChanged(); }
        }

        private double mExoplanetRadius = 1.0;
        public double ExoplanetRadius {
            get => mExoplanetRadius;
            set { mExoplanetRadius = value; OnPropertyChanged(); OnPropertyChanged(nameof(MinOrbitDistance)); }
        }

        private double mStarRadius = 1.0;
        public double StarRadius {
            get => mStarRadius;
            set { mStarRadius = value; OnPropertyChanged(); OnPropertyChanged(nameof(MinOrbitDistance)); }
        }

        // Currently unused parameters, but could be used for more advanced orbital calculations in the future

        //private double mOrbitalPeriod = 365;
        //public double OrbitalPeriod {
        //    get => mOrbitalPeriod;
        //    set { mOrbitalPeriod = value; OnPropertyChanged(); }
        //}

        //private double mImpactParameter = 0.5;
        //public double ImpactParameter {
        //    get => mImpactParameter;
        //    set { mImpactParameter = value; OnPropertyChanged(); }
        //}

        public double MinOrbitDistance => StarRadius + ExoplanetRadius;
        private double mOrbitDistance = 5.0;
        public double OrbitDistance {
            get => mOrbitDistance;
            set {
                mOrbitDistance = value;
                OnPropertyChanged();
                ExoplanetCoords = OrbitalGeometry.CalculatePosition(mOrbitDistance, OrbitalAngle);
            }
        }

        private double mOrbitalAngle = 0;
        public double OrbitalAngle {
            get => mOrbitalAngle;
            set {
                mOrbitalAngle = value;
                OnPropertyChanged();
                ExoplanetCoords = OrbitalGeometry.CalculatePosition(OrbitDistance, mOrbitalAngle);
            }
        }

        private Point3D mExoplanetCoords = new Point3D(5, 0, 0);
        public Point3D ExoplanetCoords {
            get => mExoplanetCoords;
            set {
                mExoplanetCoords = value;
                OnPropertyChanged();
            }
        }

        private DiffuseMaterial mExoplanetMaterial = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(60, 75, 110)));
        public DiffuseMaterial ExoplanetMaterial {
            get => mExoplanetMaterial;
            set {
                mExoplanetMaterial = value;
                OnPropertyChanged();
            }
        }

        private EmissiveMaterial mStarCoreMaterial = new EmissiveMaterial(new SolidColorBrush(Color.FromRgb(255, 245, 180)));
        public EmissiveMaterial StarCoreMaterial {
            get => mStarCoreMaterial;
            set {
                mStarCoreMaterial = value;
                OnPropertyChanged();
            }
        }

        private EmissiveMaterial mStarCoronaMaterial = new EmissiveMaterial(new SolidColorBrush(Color.FromArgb(120, 255, 200, 80)));
        public EmissiveMaterial StarCoronaMaterial {
            get => mStarCoronaMaterial;
            set {
                mStarCoreMaterial = value;
                OnPropertyChanged();
            }
        }

        private EmissiveMaterial mStarHaloMaterial = new EmissiveMaterial(new SolidColorBrush(Color.FromArgb(40, 255, 160, 40)));
        public EmissiveMaterial StarHaloMaterial {
            get => mStarHaloMaterial;
            set {
                mStarHaloMaterial = value;
                OnPropertyChanged();
            }
        }
    }
}
