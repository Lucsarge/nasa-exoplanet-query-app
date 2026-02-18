namespace nasa_exoplanet_query_app {
    // Class for utilizing the Table Access Protocol (TAP) to query the Exoplanet Archive
    // Documentation here: https://exoplanetarchive.ipac.caltech.edu/docs/TAP/usingTAP.html
    public static class ExoplanetTAPHelper {
        //public static readonly string EXOPLANET_ARCHIVE_BASE_URL = "https://exoplanetarchive.ipac.caltech.edu/cgi-bin/nstedAPI/nph-nstedAPI?";
        public static readonly string PlANETARY_SYSTEMS_TABLE = "ps";
        public static readonly string SELECT_DISC_YEAR = "disc_year";
        public static readonly string SELECT_DISC_METHOD = "discoverymethod";
        public static readonly string SELECT_HOST_NAME = "hostname";
        public static readonly string SELECT_DISC_FACILITY = "disc_facility";

        public static readonly string EXOPLANET_ARCHIVE_BASE_URL = "https://exoplanetarchive.ipac.caltech.edu/TAP/sync?query=";

        public static readonly string CSV_FORMAT = "&format=csv";

        // selectParam must be separated by comma if multiple
        // TODO: change distinct to use group by
        public static string GetPSHTTPRequestString(string selectParam = "*", string format = "") {
            string requestString = $"{EXOPLANET_ARCHIVE_BASE_URL}" +
                                   $"select+distinct+{selectParam}" +
                                   $"+from+{PlANETARY_SYSTEMS_TABLE}" +
                                   $"+order+by+{selectParam}+asc" +
                                   $"{format}";

            return requestString;
        }

        // Builds a http request string that queries the Planetary System table for unique discovery years in ascending order
        public static string GetPSDiscYearValuesString(string format = "") {
            string requestString = EXOPLANET_ARCHIVE_BASE_URL +
                                   "select+distinct+disc_year+from+ps+order+by+disc_year+asc";

            if (!String.IsNullOrEmpty(format)) {
                requestString += format;
            }

            return requestString;
        }
    }
}
