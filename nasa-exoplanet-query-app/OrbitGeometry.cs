using System.Windows.Media.Media3D;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Helper for calculating positions along a circular orbit
    /// </summary>
    public static class OrbitGeometry {
        public static Point3D CalculatePosition(double orbitDistance, double angleRadians) =>
            new Point3D(orbitDistance * Math.Cos(angleRadians), 0, orbitDistance * Math.Sin(angleRadians));
    }
}
