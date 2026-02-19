using System.Text.Json.Serialization;

namespace nasa_exoplanet_query_app {
    public class ExoPlanetData {
        [JsonPropertyName(ExoplanetTAPHelper.PLANET_NAME)]
        public string PlanetName { get; set; }

        [JsonPropertyName(ExoplanetTAPHelper.HOST_NAME)]
        public string HostName { get; set; }

        [JsonPropertyName(ExoplanetTAPHelper.DISC_FACILITY)]
        public string DiscoveryFacility { get; set; }

        // Discovery year is nullable because some entries in the archive return as null
        [JsonPropertyName(ExoplanetTAPHelper.DISC_YEAR)]
        public int? DiscoveryYear { get; set; }

        [JsonPropertyName(ExoplanetTAPHelper.DISC_METHOD)]
        public string DiscoveryMethod { get; set; }

        [JsonPropertyName(ExoplanetTAPHelper.STAR_COUNT)]
        public int StarCount { get; set; }

        [JsonPropertyName(ExoplanetTAPHelper.PLANET_COUNT)]
        public int PlanetCount { get; set; }

        [JsonPropertyName(ExoplanetTAPHelper.MOON_COUNT)]
        public int MoonCount { get; set; }
    }
}
