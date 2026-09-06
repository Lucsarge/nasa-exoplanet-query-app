using System.Runtime.InteropServices;
using System.Windows.Media.Media3D;

namespace nasa_exoplanet_query_app {
    public static partial class OrbitalGeometry {
        [LibraryImport("OrbitalGeometryNative.dll")]
        private static partial void CalculatePosition(
            double orbitDistance, double angleRadians,
            out double x, out double y, out double z);

        public static Point3D CalculatePosition(double orbitDistance, double angleRadians) {
            double x, y, z;
            CalculatePosition(orbitDistance, angleRadians, out x, out y, out z);
            return new Point3D(x, y, z);
        }
    }
}
